using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ZJY.Framework
{
    /// <summary>
    /// 角色信息
    /// </summary>
    [Serializable]
    public struct RoleItem 
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId;
        /// <summary>
        /// 角色昵称
        /// </summary>
        public string RoleNickName;
        /// <summary>
        /// 角色职业
        /// </summary>
        public byte RoleJob;
        /// <summary>
        /// 角色等级
        /// </summary>
        public int RoleLevel;
    }
}