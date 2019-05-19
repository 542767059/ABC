using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ZJY.Framework
{
    /// <summary>
    /// 角色信息基类
    /// </summary>
    [Serializable]
    public abstract class RoleInfoBase
    {
        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleId;

        /// <summary>
        /// 角色昵称
        /// </summary>
        public string RoleNickName;

        /// <summary>
        /// 等级
        /// </summary>
        public int Level;

        /// <summary>
        /// 最大HP
        /// </summary>
        public int MaxHP;

        /// <summary>
        /// 当前HP
        /// </summary>
        public int CurrHP;

        /// <summary>
        /// 职业编号
        /// </summary>
        public byte JobId; 
    }
}