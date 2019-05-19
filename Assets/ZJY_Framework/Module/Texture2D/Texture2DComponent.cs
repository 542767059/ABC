using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    /// <summary>
    /// 图片组件
    /// </summary>
    public class Texture2DComponent : GameBaseComponent
    {
        [Range(0, 360)]
        [SerializeField]
        private float m_AutoClearInetrval = 60f;

        private Texture2DManager m_Texture2DManager;

        /// <summary>
        /// 获取或设置自动释放间隔
        /// </summary>
        public float AutoClearInetrval
        {
            get
            {
                return m_Texture2DManager.AutoClearInetrval;
            }
            set
            {
                m_Texture2DManager.AutoClearInetrval = value;
            }
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            m_Texture2DManager = new Texture2DManager();
        }

        protected override void OnStart()
        {
            base.OnStart();
            m_Texture2DManager.SetObjectPoolManager();
            m_Texture2DManager.AutoClearInetrval = m_AutoClearInetrval;
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            m_Texture2DManager.OnUpdate(deltaTime, unscaledDeltaTime);
        }


        public override void Shutdown()
        {
            base.Shutdown();
            m_Texture2DManager.Dispose();
        }

        /// <summary>
        /// 设置图片为空
        /// </summary>
        /// <param name="targetImage"></param>
        public void SetTargetImageEmpty(UnityEngine.Object targetImage)
        {
            m_Texture2DManager.SetTargetImageEmpty(targetImage);
        }

        /// <summary>
        /// 设置图片 
        /// </summary>
        /// <param name="targetImage">目标图片</param>
        /// <param name="assetName">资源名称</param>
        public void SetImage(Image targetImage, string assetName)
        {
            SetImage(targetImage, assetName, false);
        }

        /// <summary>
        /// 设置图片 
        /// </summary>
        /// <param name="targetImage">目标图片</param>
        /// <param name="assetName">资源名称</param>
        /// <param name="setNativeSize">自适应大小</param>
        public void SetImage(Image targetImage, string assetName, bool setNativeSize)
        {
            m_Texture2DManager.SetImage(targetImage, assetName, setNativeSize);
        }

        /// <summary>
        /// 设置RawImage图片 
        /// </summary>
        /// <param name="targetRawImage">目标图片</param>
        /// <param name="assetName">资源名称</param>
        public void SetRawImg(RawImage targetRawImage, string assetName)
        {
            SetRawImg(targetRawImage, assetName, false);
        }

        /// <summary>
        /// 设置RawImage图片
        /// </summary>
        /// <param name="targetRawImage">目标图片</param>
        /// <param name="assetName">资源名称</param>
        /// <param name="setNativeSize">自适应大小</param>
        public void SetRawImg(RawImage targetRawImage, string assetName, bool setNativeSize)
        {
            m_Texture2DManager.SetRawImage(targetRawImage, assetName, setNativeSize);
        }
    }
}
