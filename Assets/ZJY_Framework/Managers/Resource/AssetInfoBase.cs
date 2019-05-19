using System;

namespace ZJY.Framework
{
    public abstract class AssetInfoBase
    {
        private string m_AssetName;
        private object m_Asset;
        private int m_SpawnCount;
        private DateTime m_LastUseTime;

        public AssetInfoBase (string assetName, object asset, bool spawned)
        {
            if (string.IsNullOrEmpty(assetName))
            {
                throw new Exception("AssetName is invalid.");
            }
            if (asset == null)
            {
                throw new Exception("Asset is invalid.");
            }

            m_AssetName = assetName;
            m_Asset = asset;
            m_SpawnCount = spawned ? 1 : 0;
            m_LastUseTime = DateTime.Now;
        }

        /// <summary>
        /// 获取资源对象
        /// </summary>
        public object Asset
        {
            get
            {
                return m_Asset;
            }
        }


        /// <summary>
        /// 获取对象的获取计数
        /// </summary>
        public int SpawnCount
        {
            get
            {
                return m_SpawnCount;
            }
        }

        /// <summary>
        /// 是否被使用
        /// </summary>
        public bool IsUsed
        {
            get
            {
                return SpawnCount > 0;
            }
        }

        /// <summary>
        /// 是否是资源
        /// </summary>
        public abstract bool IsAsset
        {
            get;
        }

        /// <summary>
        /// 获取资源对象的名称
        /// </summary>
        public string AssetName
        {
            get
            {
                return m_AssetName;
            }
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <returns></returns>
        public AssetInfoBase Spawn()
        {
            m_SpawnCount++;
            m_LastUseTime = DateTime.Now;
            return this;
        }

        /// <summary>
        /// 回收对象
        /// </summary>
        public void Unspawn()
        {
            m_LastUseTime = DateTime.Now;
            m_SpawnCount--;
            if (m_SpawnCount < 0)
            {
                throw new Exception("Spawn count is less than 0.");
            }
        }


        /// <summary>
        /// 获取对象上次使用时间
        /// </summary>
        public DateTime LastUseTime
        {
            get
            {
                return m_LastUseTime;
            }
            set
            {
                m_LastUseTime = value;
            }
        }

        /// <summary>
        /// 释放对象
        /// </summary>
        /// <param name="isShutdown">是否完全释放</param>
        public abstract void Release(bool isShutdown);
        
    }
}
