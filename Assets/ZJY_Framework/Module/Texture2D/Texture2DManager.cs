using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    public class Texture2DManager : ManagerBase
    {
        public LoadTexture2DSuccessEvent LoadTexture2DSuccess;
        public LoadTexture2DFailureEvent LoadTexture2DFailure;
        public LoadTexture2DUpdateEvent LoadTexture2DUpdate;
        public LoadTexture2DDependencyAssetEvent LoadTexture2DDependencyAsset;

        private float m_LastOperationElapse = 0f;
        private float m_AutoClearInetrval = 0f;
        private readonly LoadAssetCallbacks m_LoadAssetCallbacks;

        private IObjectPool<AssetObject> m_AssetPool;
        private Dictionary<UnityEngine.Object, AssetObject> m_Textures;
        private List<UnityEngine.Object> m_ImageObjects;

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

        public Texture2DManager()
        {
            m_AssetPool = null;
            m_ImageObjects = new List<UnityEngine.Object>();
            m_Textures = new Dictionary<UnityEngine.Object, AssetObject>();
            m_AutoClearInetrval = 60f;
            m_LoadAssetCallbacks = new LoadAssetCallbacks(LoadTexture2DSuccessCallback, LoadTexture2DFailureCallback, LoadTexture2DUpdateCallback, LoadTexture2DDependencyAssetCallback);

            LoadTexture2DSuccess = null;
            LoadTexture2DFailure = null;
            LoadTexture2DUpdate = null;
            LoadTexture2DDependencyAsset = null;
        }

        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            m_LastOperationElapse += unscaledDeltaTime;
            if (m_LastOperationElapse > m_AutoClearInetrval)
            {
                m_LastOperationElapse = 0;
                ClearImage();
            }
        }

        public override void Dispose()
        {
            LoadTexture2DSuccess = null;
            LoadTexture2DFailure = null;
            LoadTexture2DUpdate = null;
            LoadTexture2DDependencyAsset = null;

            m_Textures.Clear();
        }

        /// <summary>
        /// 设置对象池管理器
        /// </summary>
        public void SetObjectPoolManager()
        {
            m_AssetPool = GameEntry.Pool.CreateMultiSpawnObjectPool<AssetObject>("Texture Asset Pool", 60f, 64, 60f, 0);
        }

        private void ClearImage()
        {
            m_ImageObjects.Clear();
            foreach (var item in m_Textures)
            {
                m_ImageObjects.Add(item.Key);
            }
            foreach (var unityobject in m_ImageObjects)
            {
                if (unityobject==null)
                {
                    m_AssetPool.Unspawn(m_Textures[unityobject]);
                    m_Textures.Remove(unityobject);
                }
            }
        }

        /// <summary>
        /// 设置目标图片为null
        /// </summary>
        /// <param name="targetImage">目标图片</param>
        public void SetTargetImageEmpty(UnityEngine.Object targetImage)
        {
            AssetObject oldasset;
            if (m_Textures.TryGetValue(targetImage, out oldasset))
            {
                m_Textures.Remove(targetImage);
                m_AssetPool.Unspawn(oldasset);
            }
        }

        /// <summary>
        /// 设置图片
        /// </summary>
        /// <param name="targetImage">目标图片</param>
        /// <param name="assetName">资源名称</param>
        /// <param name="setNativeSize">自适应大小</param>
        public void SetImage(Image targetImage, string assetName, bool setNativeSize)
        {
            AssetObject assetObject = m_AssetPool.Spawn(assetName);
            if (assetObject == null)
            {
                GameEntry.Resource.LoadAsset(assetName, typeof(UnityEngine.Object), Constant.AssetPriority.TextureAsset, m_LoadAssetCallbacks, new LoadTextureInfo(targetImage, setNativeSize));
            }
            else
            {
                InternalSetImage(targetImage, assetObject, setNativeSize);
            }
        }

        /// <summary>
        /// 设置RawImage图片
        /// </summary>
        /// <param name="targetRawImage">目标图片</param>
        /// <param name="assetName">资源名称</param>
        /// <param name="setNativeSize">自适应大小</param>
        public void SetRawImage(RawImage targetRawImage, string assetName, bool setNativeSize)
        {
            AssetObject assetObject = m_AssetPool.Spawn(assetName);
            if (assetObject == null)
            {
                GameEntry.Resource.LoadAsset(assetName, typeof(UnityEngine.Object), Constant.AssetPriority.TextureAsset, m_LoadAssetCallbacks, new LoadTextureInfo(targetRawImage, setNativeSize));
            }
            else
            {
                InternalSetRawImage(targetRawImage, assetObject, setNativeSize);
            }
        }


        private void InternalSetImage(Image targetImage, AssetObject assetObject, bool setNativeSize)
        {
            SetTargetImageEmpty(targetImage);
            m_Textures.Add(targetImage, assetObject);
            Sprite obj = null;
            if (assetObject.Target is Sprite)
            {
                obj = assetObject.Target as Sprite;
            }
            else if (assetObject.Target is Texture2D)
            {
                Texture2D texture = assetObject.Target as Texture2D;
                obj = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(.5f, .5f));
            }

            targetImage.sprite = obj;

            if (setNativeSize)
            {
                targetImage.SetNativeSize();
            }
        }

        private void InternalSetRawImage(RawImage targetRawImage, AssetObject assetObject, bool setNativeSize)
        {
            SetTargetImageEmpty(targetRawImage);
            m_Textures.Add(targetRawImage, assetObject);
            targetRawImage.texture = assetObject.Target as Texture;

            if (setNativeSize)
            {
                targetRawImage.SetNativeSize();
            }
        }

        private void LoadTexture2DSuccessCallback(string assetName, UnityEngine.Object asset, float duration, object userData)
        {
            AssetObject assetObject = new AssetObject(assetName, asset);
            m_AssetPool.Register(assetObject, true);

            LoadTextureInfo loadTextureInfo = (LoadTextureInfo)userData;
            if (loadTextureInfo.Target == null)
            {
                m_AssetPool.Unspawn(assetObject);
                return;
            }

            if (loadTextureInfo.Target is Image)
            {
                Image target = (Image)loadTextureInfo.Target;
                InternalSetImage(target, assetObject, loadTextureInfo.SetNativeSize);
            }
            else if (loadTextureInfo.Target is RawImage)
            {
                RawImage target = (RawImage)loadTextureInfo.Target;
                InternalSetRawImage(target, assetObject, loadTextureInfo.SetNativeSize);
            }
            //todo
        }

        private void LoadTexture2DFailureCallback(string assetName, string errorMessage, object userData)
        {
            //todo
        }

        private void LoadTexture2DUpdateCallback(string assetName, float progress, object userData)
        {
            //todo
        }

        private void LoadTexture2DDependencyAssetCallback(string assetName, string dependencyAssetName, int loadedCount, int totalCount, object userData)
        {
            //todo
        }
    }
}
