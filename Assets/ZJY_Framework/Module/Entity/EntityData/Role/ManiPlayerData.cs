using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    [Serializable]
    public class ManiPlayerData : PlayerBaseData
    {
        [SerializeField]
        private RoleInfo m_RoleInfo;


        public override RoleInfoBase RoleInfoBase
        {
            get
            {
                return m_RoleInfo;
            }
        }

        public ManiPlayerData Fill(RoleInfo roleInfo)
        {
            m_RoleInfo = roleInfo;
            Vector3 position;
            Quaternion quaternion;
            if(GameUtil.GetRoleBornPos(GameEntry.Data.CacheData.NextWorldMapPos, out position, out quaternion))
            {
                Position = position;
                Rotation = quaternion;
            }

            return this;
        }
    }
}