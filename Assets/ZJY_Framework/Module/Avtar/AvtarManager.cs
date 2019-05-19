using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    public partial class AvtarManager : ManagerBase
    {
        public LoadAvtarSuccessEvent LoadAvtarSuccess;
        public LoadAvtarFailureEvent LoadAvtarFailure;
        public LoadAvtarUpdateEvent LoadAvtarUpdate;
        public LoadAvtarDependencyAssetEvent LoadAvtarDependencyAsset;

        private float m_LastOperationElapse = 0f;
        private float m_AutoClearInetrval = 0f;
        private readonly LoadAssetCallbacks m_LoadAssetCallbacks;

        private IObjectPool<AssetObject> m_AssetPool;
        private Dictionary<Entity, AvtarInfo> m_AvtarInfos;
        private List<Entity> m_Entitys;


        public float AutoClearInetrval
        {
            get
            {
                return m_AutoClearInetrval;
            }
            set
            {
                m_AutoClearInetrval = value;
            }
        }

        /// <summary>
        /// 获取所有换装信息
        /// </summary>
        public Dictionary<Entity, AvtarInfo> AvtarInfos
        {
            get
            {
                return m_AvtarInfos;
            }
        }

        public AvtarManager()
        {
            m_AssetPool = null;
            m_AvtarInfos = new Dictionary<Entity, AvtarInfo>();
            m_Entitys = new List<Entity>();
            m_AutoClearInetrval = 60f;
            m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadAvtarSuccessCallback, LoadAvtarFailureCallback, LoadAvtarUpdateCallback, LoadAvtarDependencyAssetCallback);

            LoadAvtarSuccess = null;
            LoadAvtarFailure = null;
            LoadAvtarUpdate = null;
            LoadAvtarDependencyAsset = null;
        }

        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            m_LastOperationElapse += unscaledDeltaTime;
            if (m_LastOperationElapse > m_AutoClearInetrval)
            {
                m_LastOperationElapse = 0;
                ClearEntitys(); 
            }
        }

        public override void Dispose()
        {
            LoadAvtarSuccess = null;
            LoadAvtarFailure = null;
            LoadAvtarUpdate = null;
            LoadAvtarDependencyAsset = null;
            m_AvtarInfos.Clear();
            m_Entitys.Clear();
        }

        private void ClearEntitys()
        {
            m_Entitys.Clear();
            foreach (var item in m_AvtarInfos)
            {
                m_Entitys.Add(item.Key);
            }
            foreach (var entity in m_Entitys)
            {
                if (entity == null || !entity.IsAvailable)
                {
                    RemoveAllSkinnedMesh(entity);
                    m_AvtarInfos.Remove(entity);
                }
            }
        }

        /// <summary>
        /// 设置对象池管理器
        /// </summary>
        public void SetObjectPoolManager()
        {
            m_AssetPool = GameEntry.Pool.CreateMultiSpawnObjectPool<AssetObject>("Avtar Asset Pool", 60f, 16, 60f, 0);
        }

        /// <summary>
        /// 增加蒙皮信息
        /// </summary>
        /// <param name="entity">要换装的实体</param>
        /// <param name="assetName">要换装的资源名称</param>
        public void AddSkinnedMesh(Entity entity, string assetName)
        {
            AvtarInfo avtarInfo = null;
            if (!m_AvtarInfos.TryGetValue(entity, out avtarInfo))
            {
                avtarInfo = new AvtarInfo(entity, this);
                m_AvtarInfos.Add(entity, avtarInfo);
            }

            if (avtarInfo.HasSkinnedMesh(assetName))
            {
                Log.Error("SkinnedMesh {0} is already added !", assetName);
                return;
            }

            AssetObject assetObject = m_AssetPool.Spawn(assetName);
            if (assetObject == null)
            {
                GameEntry.Resource.LoadAsset(assetName, typeof(UnityEngine.Object), Constant.AssetPriority.AvtarAsset, m_LoadAssetCallbacks, new LoadAvtarInfo(avtarInfo));
            }
            else
            {
                InternalAddSkinnedMesh(avtarInfo, assetObject);
            }
        }

        /// <summary>
        /// 移除蒙皮信息
        /// </summary>
        /// <param name="entity">要换装的实体</param>
        /// <param name="assetName">要换装的资源名称</param>
        public void RemoveSkinnedMesh(Entity entity, string assetName)
        {
            AvtarInfo avtarInfo = null;
            if (!m_AvtarInfos.TryGetValue(entity, out avtarInfo))
            {
                Log.Error("Can not find entity to remove avtar !");
                return;
            }
            else
            {
                if (!avtarInfo.RemoveSkinMeshInfo(assetName))
                {
                    Log.Error("Can not remove {0} from entity - {1}", assetName, entity.Name);
                    return;
                }
            }
        }

        /// <summary>
        /// 移除所有蒙皮信息
        /// </summary>
        /// <param name="entity">要换装的实体</param>
        public void RemoveAllSkinnedMesh(Entity entity)
        {
            AvtarInfo avtarInfo = null;
            if (m_AvtarInfos.TryGetValue(entity, out avtarInfo))
            {
                avtarInfo.Clear();
            }
        }

        /// <summary>
        /// 换装(删除之前所有增加的)
        /// </summary>
        /// <param name="entity">要换装的实体</param>
        /// <param name="assetName">要换装的资源名称</param>
        public void ChangeSkinnedMesh(Entity entity, string assetName)
        {
            AvtarInfo avtarInfo = null;
            if (m_AvtarInfos.TryGetValue(entity, out avtarInfo))
            {
                avtarInfo.Clear();
            }
            else
            {
                avtarInfo = new AvtarInfo(entity, this);
                m_AvtarInfos.Add(entity, avtarInfo);
            }

            AssetObject assetObject = m_AssetPool.Spawn(assetName);
            if (assetObject == null)
            {
                GameEntry.Resource.LoadAsset(assetName, typeof(UnityEngine.Object), Constant.AssetPriority.TextureAsset, m_LoadAssetCallbacks, new LoadAvtarInfo(avtarInfo));
            }
            else
            {
                InternalAddSkinnedMesh(avtarInfo, assetObject);
            }
        }

        private void InternalAddSkinnedMesh(AvtarInfo avtarInfo, AssetObject assetObject)
        {
            if (!avtarInfo.AddSkinMeshInfo(assetObject))
            {
                m_AssetPool.Unspawn(assetObject);
            }
        }


        private void LoadAvtarSuccessCallback(string assetName, UnityEngine.Object asset, float duration, object userData)
        {
            AssetObject assetObject = new AssetObject(assetName, asset);
            m_AssetPool.Register(assetObject, true);

            LoadAvtarInfo loadAvtarInfo = (LoadAvtarInfo)userData;
            if (loadAvtarInfo.AvtarInfo.Owner == null || !loadAvtarInfo.AvtarInfo.Owner.IsAvailable)
            {
                m_AssetPool.Unspawn(assetObject);
                return;
            }
            InternalAddSkinnedMesh(loadAvtarInfo.AvtarInfo, assetObject);

            //todo
        }

        private void LoadAvtarFailureCallback(string assetName, string errorMessage, object userData)
        {
            //todo
        }

        private void LoadAvtarUpdateCallback(string assetName, float progress, object userData)
        {
            //todo
        }

        private void LoadAvtarDependencyAssetCallback(string assetName, string dependencyAssetName, int loadedCount, int totalCount, object userData)
        {
            //todo
        }
    }
}
