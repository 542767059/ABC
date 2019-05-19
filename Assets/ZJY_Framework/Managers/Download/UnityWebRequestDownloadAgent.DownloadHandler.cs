using GameFramework.Download;
using System;
#if UNITY_5_4_OR_NEWER
using UnityEngine.Networking;
#else
using UnityEngine.Experimental.Networking;
#endif

namespace ZJY.Framework
{
    public partial class UnityWebRequestDownloadAgent : DownloadAgentBase, IDisposable
    {
        private sealed class DownloadHandler : DownloadHandlerScript
        {
            private readonly UnityWebRequestDownloadAgent m_Owner;

            public DownloadHandler(UnityWebRequestDownloadAgent owner)
                : base(owner.m_DownloadCache)
            {
                m_Owner = owner;
            }

            protected override bool ReceiveData(byte[] data, int dataLength)
            {
                if (m_Owner != null && dataLength > 0)
                {
                    m_Owner.DownloadUpdateBytes(data, 0, dataLength);
                    m_Owner.DownloadUpdateLength(dataLength);
                }

                return base.ReceiveData(data, dataLength);
            }
        }
    }
}
