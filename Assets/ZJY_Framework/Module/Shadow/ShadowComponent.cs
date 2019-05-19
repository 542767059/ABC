using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 阴影组件
    /// </summary>
    public class ShadowComponent : GameBaseComponent
    {
        [SerializeField]
        private Quaternion m_Rotation;

        [SerializeField]
        private PJShadow m_PJShadow;

        [SerializeField]
        private bool m_EnableBlur = false;

        [SerializeField]
        private bool m_EnableShadow = false;

        protected override void OnAwake()
        {
            base.OnAwake();
            if (m_PJShadow == null)
            {
                m_PJShadow = transform.Find("Projector").GetComponent<PJShadow>();
            }
            if (m_PJShadow == null)
            {
                Log.Error("PJShadow is invalid!");
                return;
            }
            
            m_PJShadow.gameObject.transform.rotation = m_Rotation;
            m_PJShadow.useBlur = m_EnableBlur;
            m_PJShadow.gameObject.SetActive(m_EnableShadow);
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            transform.position = GameEntry.Camera.transform.position;
        }

        /// <summary>
        /// 设置阴影旋转
        /// </summary>
        /// <param name="rotation">旋转角度</param>
        public void SetRotate(Quaternion rotation)
        {
            if (m_PJShadow != null)
            {
                m_PJShadow.transform.rotation = rotation;
            }
        }

        /// <summary>
        /// 设置阴影旋转
        /// </summary>
        /// <param name="rotation">旋转角度</param>
        public void SetRotate(Vector3 rotation)
        {
            SetRotate(Quaternion.Euler(rotation));
        }

        /// <summary>
        /// 是否启用虚化
        /// </summary>
        public bool EnableBlur
        {
            get
            {
                return m_PJShadow.useBlur;
            }
            set
            {
                m_PJShadow.useBlur = m_EnableBlur = value;
            }
        }

        /// <summary>
        /// 是否启用阴影
        /// </summary>
        public bool EnableShadow
        {
            get
            {
                return m_PJShadow.gameObject.activeSelf;
            }
            set
            {
                m_EnableShadow = value;
                m_PJShadow.gameObject.SetActive(value);
            }
        }
    }
}