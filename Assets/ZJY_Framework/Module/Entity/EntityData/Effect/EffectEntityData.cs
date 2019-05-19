using System;
using UnityEngine;

namespace ZJY.Framework
{
    [Serializable]
    public class EffectEntityData :EntityData
    {
        [SerializeField]
        private float m_KeepTime = 0f;
        
        public EffectEntityData(int entityId, int typeId,float keepTime)
            : base(entityId, typeId)
        {
            m_KeepTime = keepTime;
        }

        /// <summary>
        /// 持续时间
        /// </summary>
        public float KeepTime
        {
            get
            {
                return m_KeepTime;
            }
        }
    }
}
