using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    public partial class ControllerManager : ManagerBase
    {
        public LoadControllerSuccessEvent LoadControllerSuccess;
        public LoadControllerFailureEvent LoadControllerFailure;
        public LoadControllerUpdateEvent LoadControllerUpdate;
        public LoadControllerDependencyAssetEvent LoadControllerDependencyAsset;

        private float m_LastOperationElapse = 0f;
        private float m_AutoClearInetrval = 0f;
        private readonly LoadAssetCallbacks m_LoadAssetCallbacks;

        private IObjectPool<AssetObject> m_AssetPool;
        private Dictionary<Animator, AssetObject> m_ControllerInfos;
        private List<Animator> m_Animators;


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

        public  Dictionary<Animator, AssetObject> ControllerInfos
        {
            get
            {
                return m_ControllerInfos;
            }
        }

        public ControllerManager()
        {
            m_AssetPool = null;
            m_ControllerInfos = new Dictionary<Animator, AssetObject>();
            m_Animators = new List<Animator>();
            m_AutoClearInetrval = 60f;
            m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadControllerSuccessCallback, LoadControllerFailureCallback, LoadControllerUpdateCallback, LoadControllerDependencyAssetCallback);

            LoadControllerSuccess = null;
            LoadControllerFailure = null;
            LoadControllerUpdate = null;
            LoadControllerDependencyAsset = null;
        }

        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            m_LastOperationElapse += unscaledDeltaTime;
            if (m_LastOperationElapse > m_AutoClearInetrval)
            {
                m_LastOperationElapse = 0;
                ClearAnimators();
            }
        }

        public override void Dispose()
        {
            LoadControllerSuccess = null;
            LoadControllerFailure = null;
            LoadControllerUpdate = null;
            LoadControllerDependencyAsset = null;
            m_ControllerInfos.Clear();
            m_Animators.Clear();
        }

        private void ClearAnimators()
        {
            m_Animators.Clear();
            foreach (var item in m_ControllerInfos)
            {
                m_Animators.Add(item.Key);
            }
            foreach (var animator in m_Animators)
            {
                if (animator == null)
                {
                    m_AssetPool.Unspawn(m_ControllerInfos[animator]);
                    m_ControllerInfos.Remove(animator);
                }
            }
        }

        /// <summary>
        /// 设置对象池管理器
        /// </summary>
        public void SetObjectPoolManager()
        {
            m_AssetPool = GameEntry.Pool.CreateMultiSpawnObjectPool<AssetObject>("Controller Asset Pool", 60f, 16, 60f, 0);
        }

        /// <summary>
        /// 设置控制器
        /// </summary>
        /// <param name="entity">要设置的状态机</param>
        /// <param name="assetName">要设置的资源名称</param>
        public void SetController(Animator animator, string assetName)
        {
            AssetObject assetObject = m_AssetPool.Spawn(assetName);
            if (assetObject == null)
            {
                GameEntry.Resource.LoadAsset(assetName, typeof(UnityEngine.Object), Constant.AssetPriority.TextureAsset, m_LoadAssetCallbacks, new LoadControllerInfo(animator));
            }
            else
            {
                InternalSetController(animator, assetObject);
            }
        }

        /// <summary>
        /// 设置控制器为空
        /// </summary>
        /// <param name="animator">要设置的状态机</param>
        public void SetControllerEmpty(Animator animator)
        {
            AssetObject oldasset;
            if (m_ControllerInfos.TryGetValue(animator, out oldasset))
            {
                m_ControllerInfos.Remove(animator);
                m_AssetPool.Unspawn(oldasset);
            }
        }
        
        private void InternalSetController(Animator animator, AssetObject assetObject)
        {
            SetControllerEmpty(animator);

            animator.runtimeAnimatorController = (RuntimeAnimatorController)assetObject.Target;
            m_ControllerInfos.Add(animator, assetObject);
            
        }
        
        private void LoadControllerSuccessCallback(string assetName, UnityEngine.Object asset, float duration, object userData)
        {
            AssetObject assetObject = new AssetObject(assetName, asset);
            m_AssetPool.Register(assetObject, true);

            LoadControllerInfo loadControllerInfo = (LoadControllerInfo)userData;
            if (loadControllerInfo.TargetAnimator == null)
            {
                m_AssetPool.Unspawn(assetObject);
                return;
            }
            InternalSetController(loadControllerInfo.TargetAnimator, assetObject);

            //todo
        }

        private void LoadControllerFailureCallback(string assetName, string errorMessage, object userData)
        {
            //todo
        }

        private void LoadControllerUpdateCallback(string assetName, float progress, object userData)
        {
            //todo
        }

        private void LoadControllerDependencyAssetCallback(string assetName, string dependencyAssetName, int loadedCount, int totalCount, object userData)
        {
            //todo
        }
    }
}
