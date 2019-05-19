using System;
using UnityEngine;

namespace ZJY.Framework
{
    [Serializable]
    public class MountsData : EntityData
    {
        [SerializeField]
        private int m_OwnerId;

        public MountsData(int entityId, int mountsId, int ownerId)
            : base(entityId, mountsId)
        {
            m_OwnerId = ownerId;
        }

        /// <summary>
        /// 拥有者编号
        /// </summary>
        public int OwnerId
        {
            get
            {
                return m_OwnerId;
            }
        }
    }
}
