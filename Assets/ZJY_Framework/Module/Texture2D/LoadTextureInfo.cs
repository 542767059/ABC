namespace ZJY.Framework
{
    public class LoadTextureInfo
    {
        private readonly UnityEngine.Object m_Target;
        private readonly bool m_SetNativeSize;

        public LoadTextureInfo(UnityEngine.Object target, bool setNativeSize)
        {
            m_Target = target;
            m_SetNativeSize = setNativeSize;
        }

        /// <summary>
        /// 获取要替换的目标图片
        /// </summary>
        public UnityEngine.Object Target
        {
            get
            {
                return m_Target;
            }
        }

        /// <summary>
        /// 获取是否设置NativeSize
        /// </summary>
        public bool SetNativeSize
        {
            get
            {
                return m_SetNativeSize;
            }
        }
    }
    
}
