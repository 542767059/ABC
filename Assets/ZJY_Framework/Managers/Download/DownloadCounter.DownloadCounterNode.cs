using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 下载计数器
    /// </summary>
    public partial class DownloadCounter
    {
        /// <summary>
        /// 下载计数器节点
        /// </summary>
        private sealed class DownloadCounterNode 
        {
            private int m_DownloadedLength;
            private float m_ElapseSeconds;

            public DownloadCounterNode()
            {
                m_DownloadedLength = 0;
                m_ElapseSeconds = 0f;
            }

            public int DownloadedLength
            {
                get
                {
                    return m_DownloadedLength;
                }
                set
                {
                    m_DownloadedLength = value;
                }
            }

            public float ElapseSeconds
            {
                get
                {
                    return m_ElapseSeconds;
                }
            }

            public void OnUpdate(float deltaTime, float unscaledDeltaTime)
            {
                m_ElapseSeconds += unscaledDeltaTime;
            }

            public void Clear()
            {
                m_DownloadedLength = 0;
                m_ElapseSeconds = 0f;
            }
        }
    }
}