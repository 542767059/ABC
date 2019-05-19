using System;
using UnityEngine;

namespace ZJY.Framework
{
    [Serializable]
    public class BuffEfectEntityData : EntityData
    {
        [SerializeField]
        private string m_Point;

        [SerializeField]
        private int m_OwnerId;

        [SerializeField]
        private BaseBuffHandler m_BaseBuffHandler;

        public BuffEfectEntityData(int entityId, int typeId, string point,int ownerId, BaseBuffHandler baseBuffHandler)
            : base(entityId, typeId)
        {
            m_Point = point;
            m_OwnerId = ownerId;
            m_BaseBuffHandler = baseBuffHandler;
        }

        /// <summary>
        /// 挂点
        /// </summary>
        public string Point
        {
            get
            {
                return m_Point;
            }
        }

        /// <summary>
        /// 拥有者Id
        /// </summary>
        public int OwnerId
        {
            get
            {
                return m_OwnerId;
            }
        }

        /// <summary>
        /// buff
        /// </summary>
        public BaseBuffHandler BaseBuffHandler
        {
            get
            {
                return m_BaseBuffHandler;
            }
        }

    }
}
