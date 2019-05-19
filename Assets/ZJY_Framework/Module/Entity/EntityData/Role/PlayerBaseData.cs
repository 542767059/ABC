using System;
using UnityEngine;

namespace ZJY.Framework 
{
    /// <summary>
    /// 角色基类数据
    /// </summary>
    [Serializable]
    public abstract class PlayerBaseData: RoleEntityBaseData
    {
        /// <summary>
        /// 获取角色基本信息
        /// </summary>
        public abstract RoleInfoBase RoleInfoBase
        {
            get;
        }
    }
}
