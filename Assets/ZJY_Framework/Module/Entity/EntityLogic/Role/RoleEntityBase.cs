using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZJY.Framework
{
    /// <summary>
    /// 角色基类(所有人形的基类)
    /// </summary>
    public abstract class RoleEntityBase : Entity
    {
        [SerializeField]
        private RoleEntityBaseData m_RoleEntityBaseData = null;
        
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_RoleEntityBaseData = userData as RoleEntityBaseData;

            if (m_RoleEntityBaseData == null)
            {
                Log.Error("RoleEntityBase data is invalid.");
                return;
            }
        }

        protected internal override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);

        }
    }
}