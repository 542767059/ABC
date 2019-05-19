using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace ZJY.Framework
{
    public class ResourceLoader : MonoBehaviour, ITaskAgent<ResourceLoaderTask>
    {
        private static readonly HashSet<string> s_LoadingAssetNames = new HashSet<string>();
        private static readonly HashSet<string> s_LoadingResourceNames = new HashSet<string>();
        private static Shader[] m_AllShader;

        private AssetPool<AssetInfo> m_AssetPool;
        private AssetPool<AssetBundleInfo> m_AssetBundlePool;

        private ResourceLoaderTask m_Task;
        private string m_FilePath;
        private float m_LastProgress = 0f;
        private string m_ResourceChildName = null;

#if UNITY_5_4_OR_NEWER
        private UnityWebRequest m_UnityWebRequest = null;
#else
        private WWW m_WWW = null;
#endif
        private AssetBundleCreateRequest m_BytesAssetBundleCreateRequest = null;
        private AssetBundleRequest m_AssetBundleRequest = null;
        private AsyncOperation m_AsyncOperation = null;


        public ResourceLoader()
        {
            m_Task = null;
        }

        /// <summary>
        /// 获取加载资源任务
        /// </summary>
        public ResourceLoaderTask Task
        {
            get
            {
                return m_Task;
            }
        }

        /// <summary>
        /// 设置资源池
        /// </summary>
        /// <param name="assetPool"></param>
        /// <param name="assetBundlePool"></param>
        public void SetAssetPool(AssetPool<AssetInfo> assetPool, AssetPool<AssetBundleInfo> assetBundlePool)
        {
            m_AssetPool = assetPool;
            m_AssetBundlePool = assetBundlePool;
        }

        /// <summary>
        /// 初始化资源加载器
        /// </summary>
        public void Initialize()
        {
            GameEntry.Event.CommonEvent.AddEventListener(LoadAssetFileEvent.EventId, LoadAssetFileCallBack);
        }

        /// <summary>
        /// 读取Assetbundle资源文件回调事件
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void LoadAssetFileCallBack(GameEventBase gameEventBase)
        {
            LoadAssetFileEvent loadAssetFileEvent = gameEventBase as LoadAssetFileEvent;
            if (loadAssetFileEvent == null)
            {
                return;
            }
            ResourceLoader resourceLoader = loadAssetFileEvent.Sender as ResourceLoader;
            if (resourceLoader == null)
            {
                return;
            }
            if (resourceLoader != this)
            {
                return;
            }

            byte[] buffer = loadAssetFileEvent.Buffer;
            if (loadAssetFileEvent.Success)
            {
                ParseBytes(buffer);
            }
            else
            {
                string erroemessage = string.Format("can't load assetbundle, the name is '{0}'", loadAssetFileEvent.AssetName);
                OnError(LoadResourceStatus.NotExist, erroemessage);
            }
        }

        private void ParseBytes(byte[] buffer)
        {
            byte[] bytes = SecurityUtil.Xor(buffer);
            m_BytesAssetBundleCreateRequest = AssetBundle.LoadFromMemoryAsync(bytes);
        }

        /// <summary>
        /// 开始处理加载资源任务
        /// </summary>
        /// <param name="task">要处理的加载资源任务</param>
        /// <returns>开始处理任务的状态</returns>
        public StartTaskStatus StartTask(ResourceLoaderTask task)
        {
            if (task == null)
            {
                throw new Exception("Task is invalid.");
            }

            m_Task = task;
            m_Task.StartTime = DateTime.Now;

            if (string.IsNullOrEmpty(m_Task.AssetName))
            {
                if (IsResourceLoading(m_Task.AssetBundleName))
                {
                    m_Task.StartTime = default(DateTime);
                    return StartTaskStatus.HasToWait;
                }

                AssetBundleInfo bundleInfo = m_AssetBundlePool.SpawnAsset(m_Task.AssetBundleName);
                if (bundleInfo != null)
                {
                    OnResourceObjectReady((AssetBundle)bundleInfo.Asset);
                    return StartTaskStatus.CanResume;
                }

                s_LoadingResourceNames.Add(m_Task.AssetBundleName);

                ResourceInfo resourcinfo = GameEntry.Resource.GetResourceInfo(m_Task.AssetBundleName);
                string fullpath = PathUtil.GetCombinePath(resourcinfo.StorageInReadOnly ? GameEntry.Resource.ReadOnlyPath : GameEntry.Resource.ReadWritePath, PathUtil.GetResourceNameWithSuffix(resourcinfo.ResourceName));
                ReadBytes(fullpath);
                //if (resourceInfo.StorageInReadOnly)
                //{
                //    ReadOnlyByte(resourcinfo.ResourceName);
                //}
                //else
                //{
                //    ReadWriteByte(resourcinfo.ResourceName);
                //}
                return StartTaskStatus.CanResume;
            }

            if (IsAssetLoading(m_Task.AssetName))
            {
                m_Task.StartTime = default(DateTime);
                return StartTaskStatus.HasToWait;
            }

            if (!m_Task.IsScene)
            {
                AssetInfo assetInfo = m_AssetPool.SpawnAsset(m_Task.AssetName);
                if (assetInfo != null)
                {
                    OnAssetObjectReady((UnityEngine.Object)assetInfo.Asset);
                    return StartTaskStatus.Done;
                }
            }

            foreach (string dependencyAssetName in m_Task.GetDependencyAssetNames())
            {
                if (!m_AssetBundlePool.CanSpawnAsset(dependencyAssetName))
                {
                    m_Task.StartTime = default(DateTime);
                    return StartTaskStatus.HasToWait;
                }
            }

            if (IsResourceLoading(m_Task.AssetBundleName))
            {
                m_Task.StartTime = default(DateTime);
                return StartTaskStatus.HasToWait;
            }

            s_LoadingAssetNames.Add(m_Task.AssetName);

            AssetBundleInfo assetBundleInfo = m_AssetBundlePool.SpawnAsset(m_Task.AssetBundleName);
            if (assetBundleInfo != null)
            {
                OnResourceObjectReady((AssetBundle)assetBundleInfo.Asset);
                return StartTaskStatus.CanResume;
            }

            s_LoadingResourceNames.Add(m_Task.AssetBundleName);

            ResourceInfo resourceInfo = GameEntry.Resource.GetResourceInfo(m_Task.AssetBundleName);
            string fullPath = PathUtil.GetCombinePath(resourceInfo.StorageInReadOnly ? GameEntry.Resource.ReadOnlyPath : GameEntry.Resource.ReadWritePath, PathUtil.GetResourceNameWithSuffix(resourceInfo.ResourceName));
            ReadBytes(fullPath);
            //if (resourceInfo.StorageInReadOnly)
            //{
            //    ReadOnlyByte(resourceInfo.ResourceName);
            //}
            //else
            //{
            //    ReadWriteByte(resourceInfo.ResourceName);
            //}
            return StartTaskStatus.CanResume;
        }

        /// <summary>
        /// 读取2进制流
        /// </summary>
        /// <param name="fullPath"></param>
        private void ReadBytes(string fullPath)
        {
#if UNITY_5_4_OR_NEWER
            m_UnityWebRequest = UnityWebRequest.Get(PathUtil.GetRemotePath(fullPath));
#if UNITY_2017_2_OR_NEWER
            m_UnityWebRequest.SendWebRequest();
#else
            m_UnityWebRequest.Send();
#endif
#else
            m_WWW = new WWW(PathUtil.GetRemotePath(fullPath));
#endif
        }

        /// <summary>
        /// 读写目录读文件
        /// </summary>
        /// <param name="assetName">资源名称</param>
        private void ReadWriteByte(string assetName)
        {
            m_FilePath = TextUtil.Format("{0}/{1}", GameEntry.Resource.ReadWritePath, PathUtil.GetResourceNameWithSuffix(assetName));
            System.Threading.Tasks.Task.Factory.StartNew(ReadWriteByteAsync);
        }

        /// <summary>
        /// 异步读写目录读文件
        /// </summary>
        private void ReadWriteByteAsync()
        {
            byte[] buffer = null;
            try
            {
                buffer = GameEntry.Resource.GetFileBuffer(m_FilePath);
                GameEntry.Event.CommonEvent.Dispatch(this, new LoadAssetFileEvent().Fill(m_FilePath, buffer, true));
            }
            catch (Exception e)
            {
                GameEntry.Event.CommonEvent.Dispatch(this, new LoadAssetFileEvent().Fill(m_FilePath, buffer, false));
                throw new Exception(e.ToString());
            }
        }


        /// <summary>
        /// 只读目录读文件
        /// </summary>
        /// <param name="assetName">资源名称</param>
        private void ReadOnlyByte(string assetName)
        {
            m_FilePath = PathUtil.GetRemotePath(GameEntry.Resource.ReadOnlyPath, PathUtil.GetResourceNameWithSuffix(assetName));

#if UNITY_5_4_OR_NEWER
            m_UnityWebRequest = UnityWebRequest.Get(m_FilePath);
#if UNITY_2017_2_OR_NEWER
            m_UnityWebRequest.SendWebRequest();
#else
            m_UnityWebRequest.Send();
#endif
#else
            m_WWW = new WWW(m_FilePath);
#endif
        }

        private void OnError(LoadResourceStatus status, string errorMessage)
        {
            ToReset();
            m_Task.OnLoadAssetFailure(status, errorMessage);
            s_LoadingAssetNames.Remove(m_Task.AssetName);
            s_LoadingResourceNames.Remove(m_Task.AssetBundleName);
            m_Task.Done = true;
        }

        public void ToReset()
        {
            m_FilePath = null;
            m_ResourceChildName = null;
            m_LastProgress = 0f;

#if UNITY_5_4_OR_NEWER
            if (m_UnityWebRequest != null)
            {
                m_UnityWebRequest.Dispose();
                m_UnityWebRequest = null;
            }
#else
            if (m_WWW != null)
            {
                m_WWW.Dispose();
                m_WWW = null;
            }
#endif
            m_BytesAssetBundleCreateRequest = null;
            m_AssetBundleRequest = null;
            m_AsyncOperation = null;
        }

        public void Reset()
        {
            ToReset();
            m_Task = null;
        }

        /// <summary>
        /// Asset是否已经在加载中
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        private static bool IsAssetLoading(string assetName)
        {
            return s_LoadingAssetNames.Contains(assetName);
        }

        /// <summary>
        /// AssetBundle资源是否在加载中
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        private static bool IsResourceLoading(string resourceName)
        {
            return s_LoadingResourceNames.Contains(resourceName);
        }

        /// <summary>
        /// AssetBundle资源准备完毕
        /// </summary>
        /// <param name="assetBundle"></param>
        private void OnResourceObjectReady(AssetBundle assetBundle)
        {
            if (string.IsNullOrEmpty(m_Task.AssetName))
            {
                ToReset();
                m_Task.OnLoadDependencyAsset(m_Task.AssetBundleName, assetBundle);
                m_Task.Done = true;
                return;
            }
            LoadAsset(assetBundle, m_Task.AssetName, m_Task.AssetType, m_Task.IsScene);

        }

        /// <summary>
        /// 开始异步加载资源
        /// </summary>
        /// <param name="resource">资源</param>
        /// <param name="resourceChildName">要加载的子资源名称</param>
        /// <param name="assetType">要加载资源的类型</param>
        /// <param name="isScene">要加载的资源是否是场景</param>
        private void LoadAsset(AssetBundle assetBundle, string resourceChildName, Type assetType, bool isScene)
        {
            if (assetBundle == null)
            {
                OnError(LoadResourceStatus.TypeError, "Can not load asset bundle from loaded resource which is not an asset bundle.");
                return;
            }

            if (string.IsNullOrEmpty(resourceChildName))
            {
                OnError(LoadResourceStatus.ChildAssetError, "Can not load asset from asset bundle which child name is invalid.");
                return;
            }

            m_ResourceChildName = resourceChildName;
            if (isScene)
            {
                int sceneNamePositionStart = resourceChildName.LastIndexOf('/');
                int sceneNamePositionEnd = resourceChildName.LastIndexOf('.');
                if (sceneNamePositionStart <= 0 || sceneNamePositionEnd <= 0 || sceneNamePositionStart > sceneNamePositionEnd)
                {
                    OnError(LoadResourceStatus.SceneAssetError, TextUtil.Format("Scene name '{0}' is invalid.", resourceChildName));
                    return;
                }

                string sceneName = resourceChildName.Substring(sceneNamePositionStart + 1, sceneNamePositionEnd - sceneNamePositionStart - 1);
                m_AsyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
            else
            {
                if (assetType != null)
                {
                    m_AssetBundleRequest = assetBundle.LoadAssetAsync(resourceChildName, assetType);
                }
                else
                {
                    m_AssetBundleRequest = assetBundle.LoadAssetAsync(resourceChildName);
                }
            }
        }

        /// <summary>
        /// 加载asset资源完毕
        /// </summary>
        /// <param name="asset"></param>
        private void OnLoadAssetLoadComplete(UnityEngine.Object asset)
        {
            if (!m_Task.IsScene)
            {
                AssetInfo assetInfo = new AssetInfo(m_Task.AssetName, asset, true);
                m_AssetPool.Register(assetInfo, true);
            }

            s_LoadingAssetNames.Remove(m_Task.AssetName);
            OnAssetObjectReady(asset);
        }

        private void OnAssetObjectReady(UnityEngine.Object asset)
        {
            ToReset();

            if (m_Task.IsScene)
            {
                //Debug.Log("todo scene");
            }

            m_Task.OnLoadAssetSuccess(asset, (float)(DateTime.Now - m_Task.StartTime).TotalSeconds);
            m_Task.Done = true;
        }


        /// <summary>
        /// 加载资源代理轮询
        /// </summary>
        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {

#if UNITY_5_4_OR_NEWER
            UpdateUnityWebRequest();
#else
            UpdateWWW();
#endif
            UpdateBytesAssetBundleCreateRequest();
            UpdateAssetBundleRequest();
            UpdateAsyncOperation();
        }



#if UNITY_5_4_OR_NEWER
        private void UpdateUnityWebRequest()
        {
            if (m_UnityWebRequest != null)
            {
                if (m_UnityWebRequest.isDone)
                {
                    if (string.IsNullOrEmpty(m_UnityWebRequest.error))
                    {
                        ParseBytes(m_UnityWebRequest.downloadHandler.data);
                        m_UnityWebRequest.Dispose();
                        m_UnityWebRequest = null;
                        m_FilePath = null;
                        m_LastProgress = 0f;
                    }
                    else
                    {
                        bool isError = false;
#if UNITY_2017_1_OR_NEWER
                        isError = m_UnityWebRequest.isNetworkError;
#else
                        isError = m_UnityWebRequest.isError;
#endif
                        OnError(LoadResourceStatus.NotExist, string.Format("Can not load asset bundle '{0}' with error message '{1}'.", m_FilePath, isError ? m_UnityWebRequest.error : null));
                    }
                }
                else if (m_UnityWebRequest.downloadProgress != m_LastProgress)
                {
                    m_LastProgress = m_UnityWebRequest.downloadProgress;
                    m_Task.OnLoadAssetUpdate(m_UnityWebRequest.downloadProgress);
                }
            }
        }
#else
        private void UpdateWWW()
        {
            if (m_WWW != null)
            {
                if (m_WWW.isDone)
                {
                    if (string.IsNullOrEmpty(m_WWW.error))
                    {
                        ParseBytes(m_WWW.bytes);
                        m_WWW.Dispose();
                        m_WWW = null;
         m_FilePath = null;
        m_LastProgress = 0f;
                    }
                    else
                    {
                        OnError(LoadResourceStatus.NotExist, string.Format("Can not load asset bundle '{0}' with error message '{1}'.", m_FilePath, m_WWW.error));
                    }
                }
                else if (m_WWW.progress != m_LastProgress)
                {
                    m_LastProgress = m_WWW.progress;
                    m_Task.OnLoadAssetUpdate(m_WWW.progress);
                }
            }
        }
#endif


        private void UpdateBytesAssetBundleCreateRequest()
        {
            if (m_BytesAssetBundleCreateRequest != null)
            {
                if (m_BytesAssetBundleCreateRequest.isDone)
                {
                    AssetBundle assetBundle = m_BytesAssetBundleCreateRequest.assetBundle;
                    if (assetBundle != null)
                    {
                        AssetBundleCreateRequest oldBytesAssetBundleCreateRequest = m_BytesAssetBundleCreateRequest;
                        AssetBundleInfo assetBundleInfo = new AssetBundleInfo(m_Task.AssetBundleName, assetBundle, true);
                        m_AssetBundlePool.Register(assetBundleInfo, true);
                        s_LoadingResourceNames.Remove(m_Task.AssetBundleName);
                        OnResourceObjectReady(assetBundle);
                        if (m_BytesAssetBundleCreateRequest == oldBytesAssetBundleCreateRequest)
                        {
                            m_BytesAssetBundleCreateRequest = null;
                            m_LastProgress = 0f;
                        }

                    }
                    else
                    {
                        OnError(LoadResourceStatus.NotExist, "Can not load asset bundle from memory which is not a valid asset bundle.");
                    }
                }
                else if (m_BytesAssetBundleCreateRequest.progress != m_LastProgress)
                {
                    m_LastProgress = m_BytesAssetBundleCreateRequest.progress;
                    m_Task.OnLoadAssetUpdate(m_BytesAssetBundleCreateRequest.progress);
                }
            }
        }


        private void UpdateAssetBundleRequest()
        {
            if (m_AssetBundleRequest != null)
            {
                if (m_AssetBundleRequest.isDone)
                {
                    if (m_AssetBundleRequest.asset != null)
                    {
                        OnLoadAssetLoadComplete(m_AssetBundleRequest.asset);
                        m_ResourceChildName = null;
                        m_LastProgress = 0f;
                        m_AssetBundleRequest = null;
                    }
                    else
                    {
                        OnError(LoadResourceStatus.ChildAssetError, string.Format("Can not load asset '{0}' from asset bundle which is not exist.", m_ResourceChildName));
                    }
                }
                else if (m_AssetBundleRequest.progress != m_LastProgress)
                {
                    m_LastProgress = m_AssetBundleRequest.progress;
                    m_Task.OnLoadAssetUpdate(m_AssetBundleRequest.progress);
                }
            }
        }



        private void UpdateAsyncOperation()
        {
            if (m_AsyncOperation != null)
            {
                if (m_AsyncOperation.isDone)
                {
                    if (m_AsyncOperation.allowSceneActivation)
                    {
                        OnLoadAssetLoadComplete(null);
                        m_ResourceChildName = null;
                        m_LastProgress = 0f;
                        m_AsyncOperation = null;
                    }
                    else
                    {
                        OnError(LoadResourceStatus.SceneAssetError, string.Format("Can not load scene asset '{0}' from asset bundle.", m_ResourceChildName));
                    }
                }
                else if (m_AsyncOperation.progress != m_LastProgress)
                {
                    m_LastProgress = m_AsyncOperation.progress;
                    m_Task.OnLoadAssetUpdate(m_AsyncOperation.progress);
                }
            }
        }

        public void Shutdown()
        {
            Reset();
            GameEntry.Event.CommonEvent.RemoveEventListener(LoadAssetFileEvent.EventId, LoadAssetFileCallBack);
        }
    }
}
