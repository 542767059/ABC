﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 热更实体数据
    /// </summary>
    [Serializable]
    public class HotfixEntityData : EntityData
    {
        [SerializeField]
        private string m_HotfixEntityName;

        private object m_UserData;

        public HotfixEntityData()
        {

        }

        /// <summary>
        /// 初始化热更实体数据
        /// </summary>
        /// <param name="hotfixEntityName">热更实体类的名称</param>
        /// <param name="userData">用户数据</param>
        public HotfixEntityData(string hotfixEntityName, object userData)
        {
            m_HotfixEntityName = hotfixEntityName;
            m_UserData = userData;
        }

        /// <summary>
        /// 对应的热更新层实体逻辑类名
        /// </summary>
        public string HotfixEntityName
        {
            get
            {
                return m_HotfixEntityName;
            }
            set
            {
                m_HotfixEntityName = value;
            }
        }

        /// <summary>
        /// 要传递给热更新层实体的实体数据
        /// </summary>
        public object UserData
        {
            get
            {
                return m_UserData;
            }
            set
            {
                m_UserData = value;
            }
        }

        /// <summary>
        /// 填充实体数据
        /// </summary>
        public HotfixEntityData Fill(int id, int typeId, string hotfixEntityName, object userData)
        {
            Fill(id, typeId);
            HotfixEntityName = hotfixEntityName;
            UserData = userData;
            return this;
        }
    }
}