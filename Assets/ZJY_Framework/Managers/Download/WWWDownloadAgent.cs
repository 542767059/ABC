using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// WWW 下载代理
    /// </summary>
    public class WWWDownloadAgent : DownloadAgentBase
    {
        private WWW m_WWW = null;
        private int m_LastDownloadedSize = 0;
        private bool m_Disposed = false;

        /// <summary>
        /// 通过下载代理下载指定地址的数据
        /// </summary>
        /// <param name="downloadUri">下载地址</param>
        /// <param name="userData">用户自定义数据</param>
        public override void Download(string downloadUri, object userData)
        {
            m_WWW = new WWW(downloadUri);
        }

        /// <summary>
        /// 通过下载代理下载指定地址的数据
        /// </summary>
        /// <param name="downloadUri">下载地址</param>
        /// <param name="fromPosition">下载数据起始位置</param>
        /// <param name="userData">用户自定义数据</param>
        public override void Download(string downloadUri, int fromPosition, object userData)
        {
            Dictionary<string, string> header = new Dictionary<string, string>
            {
                { "Range", TextUtil.Format("bytes={0}-", fromPosition.ToString()) }
            };

            m_WWW = new WWW(downloadUri, null, header);
        }

        /// <summary>
        /// 通过下载代理下载指定地址的数据
        /// </summary>
        /// <param name="downloadUri">下载地址</param>
        /// <param name="fromPosition">下载数据起始位置</param>
        /// <param name="toPosition">下载数据结束位置</param>
        /// <param name="userData">用户自定义数据</param>
        public override void Download(string downloadUri, int fromPosition, int toPosition, object userData)
        {
            if (DownloadAgentUpdate == null || DownloadAgentSuccess == null || DownloadAgentError == null)
            {
                Debug.LogError("Download agent callback is invalid.");
                return;
            }

            Dictionary<string, string> header = new Dictionary<string, string>
            {
                { "Range", TextUtil.Format("bytes={0}-{1}", fromPosition.ToString(), toPosition.ToString()) }
            };

            m_WWW = new WWW(downloadUri, null, header);
        }

        /// <summary>
        /// 重置下载代理
        /// </summary>
        public override void OnReset()
        {
            if (m_WWW != null)
            {
                m_WWW.Dispose();
                m_WWW = null;
            }

            m_LastDownloadedSize = 0;
        }
        
        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放资源标记</param>
        protected override void Clear(bool disposing)
        {
            base.Clear(disposing);
            if (m_Disposed)
            {
                return;
            }

            if (disposing)
            {
                if (m_WWW != null)
                {
                    m_WWW.Dispose();
                    m_WWW = null;
                }
            }

            m_Disposed = true;
        }


        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            if (m_WWW == null)
            {
                return;
            }

            int deltaLength = m_WWW.bytesDownloaded - m_LastDownloadedSize;
            if (deltaLength > 0)
            {
                m_LastDownloadedSize = m_WWW.bytesDownloaded;
                DownloadUpdateLength(deltaLength);
            }

            if (!m_WWW.isDone)
            {
                return;
            }

            if (!string.IsNullOrEmpty(m_WWW.error))
            {
                DownloadError(m_WWW.error);
            }
            else
            {
                byte[] bytes = m_WWW.bytes;
                DownloadUpdateBytes(bytes, 0, bytes.Length);
                DownloadComplete(bytes.Length);
            }
        }
    }
}
