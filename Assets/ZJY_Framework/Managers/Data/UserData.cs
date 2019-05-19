using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZJY.Framework
{
    /// <summary>
    /// 用户数据
    /// </summary>
    [Serializable]
    public class UserData 
    {
        [SerializeField]
        private int m_AccountId;

        [SerializeField]
        private List<RoleItem> m_RoleLists;

        /// <summary>
        /// 角色信息
        /// </summary>
        public RoleInfo RoleInfo
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或者设置用户账号Id
        /// </summary>
        public int AccountId
        {
            get
            {
                return m_AccountId;
            }
            set
            {
                m_AccountId = value;
            }
        }

        /// <summary>
        /// 获取或者设置账户所有角色信息
        /// </summary>
        public List<RoleItem> RoleLists
        {
            get
            {
                return m_RoleLists;
            }
            set
            {
                m_RoleLists = value;
            }
        }

        public UserData()
        {
            m_RoleLists = new List<RoleItem>();
        }

        /// <summary>
        /// 清空数据
        /// </summary>
        public void Clear()
        {

        }
      
    }
}
