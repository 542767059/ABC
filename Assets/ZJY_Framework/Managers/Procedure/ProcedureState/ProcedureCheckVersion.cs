using System;
using System.Collections.Generic;
using UnityEngine;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// 检查更新流程
    /// </summary>
    public class ProcedureCheckVersion : ProcedureBase
    {
        private long m_CurrentUpdateZipLength;
        private long m_UpdateTotalZipLength;

        private bool m_IsUpdateing;
        private Dictionary<string, VarInt> m_AllAssetSize;

        public override void OnEnter()
        {
            base.OnEnter();

            m_AllAssetSize = new Dictionary<string, VarInt>();
            m_CurrentUpdateZipLength = 0;
            m_UpdateTotalZipLength = 0;
            m_IsUpdateing = false;

            GameEntry.Event.CommonEvent.AddEventListener(ResourceUpdateStartGameEvent.EventId, OnResourceUpdateStartGameEvent);
            GameEntry.Event.CommonEvent.AddEventListener(ResourceUpdateSuccessGameEvent.EventId, OnResourceUpdateSuccessGameEvent);
            GameEntry.Event.CommonEvent.AddEventListener(ResourceUpdateFailureGameEvent.EventId, OnResourceUpdateFailureGameEvent);
            GameEntry.Event.CommonEvent.AddEventListener(ResourceUpdateChangedGameEvent.EventId, OnResourceUpdateChangedGameEvent);

            CheckVersion();
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            if (m_IsUpdateing)
            {
                InitForm.Instance.ShowProgress(TextUtil.Format("正在更新中 {0}/{1} {2}/S", GetSize(m_CurrentUpdateZipLength), GetSize(m_UpdateTotalZipLength), GetSize((long)GameEntry.Download.CurrentSpeed)), m_CurrentUpdateZipLength / (float)m_UpdateTotalZipLength);
            }
        }

        public override void OnLeave()
        {
            base.OnLeave();

            GameEntry.Event.CommonEvent.RemoveEventListener(ResourceUpdateStartGameEvent.EventId, OnResourceUpdateStartGameEvent);
            GameEntry.Event.CommonEvent.RemoveEventListener(ResourceUpdateSuccessGameEvent.EventId, OnResourceUpdateSuccessGameEvent);
            GameEntry.Event.CommonEvent.RemoveEventListener(ResourceUpdateFailureGameEvent.EventId, OnResourceUpdateFailureGameEvent);
            GameEntry.Event.CommonEvent.RemoveEventListener(ResourceUpdateChangedGameEvent.EventId, OnResourceUpdateChangedGameEvent);
            m_AllAssetSize.Clear();
            m_AllAssetSize = null;
        }

        private void OnResourceUpdateStartGameEvent(GameEventBase gameEventBase)
        {

            ResourceUpdateStartGameEvent resourceUpdateStartGameEvent = (ResourceUpdateStartGameEvent)gameEventBase;
            Debug.Log(resourceUpdateStartGameEvent.Name + "开始更新!");

            if (!m_AllAssetSize.ContainsKey(resourceUpdateStartGameEvent.Name))
            {
                m_CurrentUpdateZipLength += resourceUpdateStartGameEvent.CurrentLength;
                m_AllAssetSize.Add(resourceUpdateStartGameEvent.Name, resourceUpdateStartGameEvent.CurrentLength);
            }
            

            //todo
        }

        private void OnResourceUpdateSuccessGameEvent(GameEventBase gameEventBase)
        {
            ResourceUpdateSuccessGameEvent resourceUpdateSuccessGameEvent = (ResourceUpdateSuccessGameEvent)gameEventBase;
            Debug.Log(resourceUpdateSuccessGameEvent.Name + "更新成功!");
            //todo
        }

        /// <summary>
        /// 资源更新失败回调
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void OnResourceUpdateFailureGameEvent(GameEventBase gameEventBase)
        {
            ResourceUpdateFailureGameEvent resourceUpdateFailureGameEvent = (ResourceUpdateFailureGameEvent)gameEventBase;
            Log.Error("资源更新失败" + resourceUpdateFailureGameEvent.DownloadUri + resourceUpdateFailureGameEvent.ErrorMessage);
            Debug.LogError("资源更新失败" + resourceUpdateFailureGameEvent.DownloadUri + resourceUpdateFailureGameEvent.ErrorMessage);

            if (m_AllAssetSize.ContainsKey(resourceUpdateFailureGameEvent.Name))
            {
                m_CurrentUpdateZipLength -= m_AllAssetSize[resourceUpdateFailureGameEvent.Name];
                m_AllAssetSize.Remove(resourceUpdateFailureGameEvent.Name);
            }
            //todo
        }

        /// <summary>
        /// 资源更新变更回调
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void OnResourceUpdateChangedGameEvent(GameEventBase gameEventBase)
        {
            ResourceUpdateChangedGameEvent resourceUpdateChangedGameEvent = (ResourceUpdateChangedGameEvent)gameEventBase;
            //Debug.Log(resourceUpdateChangedGameEvent.Name);

            //Debug.Log("更新变化!");
            VarInt currentsize = null;
            if (m_AllAssetSize.TryGetValue(resourceUpdateChangedGameEvent.Name, out currentsize))
            {
                m_CurrentUpdateZipLength -= currentsize.Value;
                currentsize.Value = resourceUpdateChangedGameEvent.CurrentLength;
                m_CurrentUpdateZipLength += currentsize.Value;
            }
            //todo

        }

        /// <summary>
        /// 检查更新
        /// </summary>
        private void CheckVersion()
        {
            InitForm.Instance.ShowProgress("正在检查更新", 0);
#if UNITY_STANDALONE_WIN
            GameEntry.Resource.UpdatePrefixUri = GameEntry.Data.SystemData.SourceUrl + "/Windows/";
#elif UNITY_ANDROID
            GameEntry.Resource.UpdatePrefixUri = GameEntry.Data.SystemData.SourceUrl + "/Android/";
#elif UNITY_IPHONE
            GameEntry.Resource.UpdatePrefixUri = GameEntry.Data.SystemData.SourceUrl + "/iOS/";
#endif

            GameEntry.Resource.UpdateVersionList
                (GameEntry.Data.SystemData.VersionLength, GameEntry.Data.SystemData.VersionHashCode,
                GameEntry.Data.SystemData.VersionZipLength, GameEntry.Data.SystemData.VersionZipHashCode,
                new UpdateVersionListCallbacks((downloadPath, dodownloadurl) =>
            {
                GameEntry.Resource.CheckResources(OnCheckResourcesCompleteCallback);
            },
            (downloadUri, errorMessage) =>
            {
                Log.Error(TextUtil.Format("downloadUri :{0}, error message:{1}", downloadUri, errorMessage));
                Debug.LogError(TextUtil.Format("downloadUri :{0}, error message:{1}", downloadUri, errorMessage));
                //todo
            }));
        }

        /// <summary>
        /// 检查更新回调
        /// </summary>
        /// <param name="needUpdateResources">是否需要更新</param>
        /// <param name="removedCount">移除的资源数量</param>
        /// <param name="updateCount">更新的资源数量</param>
        /// <param name="updateTotalLength">更新的资源大小</param>
        /// <param name="updateTotalZipLength">更新的资源压缩大小</param>
        private void OnCheckResourcesCompleteCallback(bool needUpdateResources, int removedCount, int updateCount, long updateTotalLength, long updateTotalZipLength)
        {
            if (needUpdateResources)
            {
                m_IsUpdateing = true;
                GameEntry.Resource.UpdateResources(OnUpdateResourcesCompleteCallback);
            }
            else
            {
                GameEntry.Resource.LoadManifest(OnLoadManifertCallBack);
                InitForm.Instance.ShowProgress("正在整理资源", 0);
            }

            m_UpdateTotalZipLength = updateTotalZipLength;

            Debug.Log(removedCount);
            Debug.Log(updateCount);
            Debug.Log(updateTotalLength);
            Debug.Log(updateTotalZipLength);
        }

        private string GetSize(long size)
        {
            if (size > 1024 * 1024)
            {
                return TextUtil.Format("{0}M", (size / (1024 * 1024f)).ToString("F1"));
            }
            else if (size > 1024)
            {
                return TextUtil.Format("{0}K", (size / 1024f).ToString("F1"));
            }
            else
            {
                return TextUtil.Format("{0}", size.ToString("F0"));
            }
        }

        /// <summary>
        /// 更新资源完成
        /// </summary>
        private void OnUpdateResourcesCompleteCallback(bool result)
        {
            if (!result)
            {
                Debug.Log("失败 尝试换Ip更新等操作");
                return;
                //tddo
            }
            m_IsUpdateing = false;
            Debug.Log("更新完成");
            InitForm.Instance.ShowProgress("更新完成", 1);
            GameEntry.Resource.LoadManifest(OnLoadManifertCallBack);
            InitForm.Instance.ShowProgress("正在整理资源", 0);
        }

        /// <summary>
        /// 加载依赖配置完毕
        /// </summary>
        private void OnLoadManifertCallBack()
        {
            Debug.Log("加载依赖配置完毕");
            ChangeState<ProcedurePreload>();
        }
    }
}
