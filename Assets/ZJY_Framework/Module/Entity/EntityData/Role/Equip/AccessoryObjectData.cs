using System;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 附件实体数据
    /// </summary>
    [Serializable]
    public class AccessoryObjectData : EntityData
    {
        [SerializeField]
        private int m_OwnerId = 0;

        [SerializeField]
        private int m_JobId = 0;

        [SerializeField]
        private string m_AssetName;

        public AccessoryObjectData(int entityId, int typeId, int jobId, int ownerId)
            : base(entityId, typeId)
        {
            m_JobId = jobId;
            m_OwnerId = ownerId;
        }

        /// <summary>
        /// 拥有者编号。
        /// </summary>
        public int OwnerId
        {
            get
            {
                return m_OwnerId;
            }
        }

        /// <summary>
        /// 拥有者职业编号。
        /// </summary>
        public int JobId
        {
            get
            {
                return m_JobId;
            }
        }


        /// <summary>
        /// 资源名称
        /// </summary>
        public string AssetName
        {
            get
            {
                return m_AssetName;
            }
        }

        /// <summary>
        /// 填充资源名称
        /// </summary>
        /// <param name="assetName">资源名称</param>
        public void Fill(string assetName)
        {
            m_AssetName = assetName;
        }        
    }
}
