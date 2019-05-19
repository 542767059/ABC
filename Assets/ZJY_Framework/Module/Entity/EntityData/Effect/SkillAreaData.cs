using System;
using UnityEngine;

namespace ZJY.Framework
{
    [Serializable]
    public class SkillAreaData : EntityData
    {
        [SerializeField]
        private Entity m_Owner = null;

        [SerializeField]
        private SKillAreaType m_SKillAreaType;

        public SkillAreaData(int entityId, int typeId, Entity owner, SKillAreaType sKillAreaType)
            : base(entityId, typeId)
        {
            m_Owner = owner;
            m_SKillAreaType = sKillAreaType;
        }

        /// <summary>
        /// 获取拥有者
        /// </summary>
        public Entity Owner
        {
            get
            {
                return m_Owner;
            }
        }

        /// <summary>
        /// 获取区域类型
        /// </summary>
        public SKillAreaType SKillAreaType
        {
            get
            {
                return m_SKillAreaType;
            }
        }
    }
}
