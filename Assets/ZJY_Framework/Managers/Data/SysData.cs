using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ZJY.Framework
{
    /// <summary>
    /// 系统相关数据
    /// </summary>
    [Serializable]
    public class SystemData 
    {
        [SerializeField]
        private long m_CurrentGameServerTime;

        [SerializeField]
        private long m_CurrentAccountServerTime;

        [SerializeField]
        private string m_SourceUrl;

        [SerializeField]
        private string m_RechargeUrl;

        [SerializeField]
        private string m_Ip;

        [SerializeField]
        private int m_Port;

        [SerializeField]
        private string m_TDAppId;

        [SerializeField]
        private bool m_IsOpenTD;

        [SerializeField]
        private int m_VersionLength;

        [SerializeField]
        private int m_VersionHashCode;

        [SerializeField]
        private int m_VersionZipLength;

        [SerializeField]
        private int m_VersionZipHashCode;


        private float m_GameServerTimeInterval = 0;
        /// <summary>
        /// 获取或者设置当前的游戏服务器时间
        /// </summary>
        public long CurrGameServerTime
        {
            get
            {
                return m_CurrentGameServerTime + (long)m_GameServerTimeInterval;
            }
            set
            {
                m_GameServerTimeInterval = 0;
                m_CurrentGameServerTime = value;
            }
        }


        private float m_AccountTimeInterval = 0;
        /// <summary>
        /// 获取或者设置当前的账户服务器时间
        /// </summary>
        public long CurrAccountServerTime
        {
            get
            {
                return m_CurrentAccountServerTime + (long)m_AccountTimeInterval;
            }
            set
            {
                m_AccountTimeInterval = 0;
                m_CurrentAccountServerTime = value;
            }
        }

        /// <summary>
        /// 获取或者设置资源地址
        /// </summary>
        public string SourceUrl
        {
            get
            {
                return m_SourceUrl;
            }
            set
            {
                m_SourceUrl = value;
            }
        }

        /// <summary>
        /// 获取或者设置充值地址
        /// </summary>
        public string RechargeUrl
        {
            get
            {
                return m_RechargeUrl;
            }
            set
            {
                m_RechargeUrl = value;
            }
        }

        /// <summary>
        /// 获取或者设置服务器IP地址
        /// </summary>
        public string Ip
        {
            get
            {
                return m_Ip;
            }
            set
            {
                m_Ip = value;
            }
        }

        /// <summary>
        /// 获取或者设置服务器端口号
        /// </summary>
        public int Port
        {
            get
            {
                return m_Port;
            }
            set
            {
                m_Port = value;
            }
        }

        /// <summary>
        /// 获取或者设置TD账号统计
        /// </summary>
        public string TDAppId
        {
            get
            {
                return m_TDAppId;
            }
            set
            {
                m_TDAppId = value;
            }
        }

        /// <summary>
        /// 获取或者设置是否开启TD统计
        /// </summary>
        public bool IsOpenTD
        {
            get
            {
                return m_IsOpenTD;
            }
            set
            {
                m_IsOpenTD = value;
            }
        }

        /// <summary>
        /// 获取或者设置版本号资源长度
        /// </summary>
        public int VersionLength
        {
            get
            {
                return m_VersionLength;
            }
            set
            {
                m_VersionLength = value;
            }
        }

        /// <summary>
        /// 获取或者设置版本号资源哈希值
        /// </summary>
        public int VersionHashCode
        {
            get
            {
                return m_VersionHashCode;
            }
            set
            {
                m_VersionHashCode = value;
            }
        }

        /// <summary>
        /// 获取或者设置版本号资源压缩长度
        /// </summary>
        public int VersionZipLength
        {
            get
            {
                return m_VersionZipLength;
            }
            set
            {
                m_VersionZipLength = value;
            }
        }

        /// <summary>
        /// 获取或者设置版本号资源压缩哈希值
        /// </summary>
        public int VersionZipHashCode
        {
            get
            {
                return m_VersionZipHashCode;
            }
            set
            {
                m_VersionZipHashCode = value;
            }
        }

        public SystemData()
        {

        }

        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            m_AccountTimeInterval += unscaledDeltaTime;
            m_GameServerTimeInterval += unscaledDeltaTime;
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {

        }

    }
}
