using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZJY.Framework;

namespace Hotfix
{
    /// <summary>
    /// 热更新层实体
    /// </summary>
    public abstract class HotEntityBase
    {
        [SerializeField]
        private HotEntityData m_HotEntityData = null;

        private HotEntity m_Entity;

        /// <summary>
        /// 获取真正的实体
        /// </summary>
        public HotEntity Entity
        {
            get
            {
                return m_Entity;
            }
        }

        /// <summary>
        /// 实体初始化
        /// </summary>
        public virtual void OnInit(HotEntity entity, object userData)
        {
            m_Entity = entity;
        }

        /// <summary>
        /// 实体显示
        /// </summary>
        public virtual void OnShow(object userData)
        {
            if (HotfixEntry.Entity.EntityInfos.ContainsKey(m_Entity.Id))
            {
                throw new Exception(TextUtil.Format("Entity id '{0}' is already exist.", m_Entity.Id.ToString()));
            }
            HotfixEntry.Entity.EntityInfos.Add(m_Entity.Id, this);

            m_HotEntityData = userData as HotEntityData;
            if (m_HotEntityData == null)
            {
                Log.Error("Entity data is invalid.");
                return;
            }

            m_Entity.SelfTransform.localPosition = m_HotEntityData.Position;
            m_Entity.SelfTransform.localRotation = m_HotEntityData.Rotation;
            m_Entity.SelfTransform.localScale = Vector3.one;
            m_Entity.SelfTransform.localScale = Vector3.one;
        }

        /// <summary>
        /// 实体隐藏
        /// </summary>
        /// <param name="userData"></param>
        public virtual void OnHide(object userData)
        {
            if (!HotfixEntry.Entity.EntityInfos.Remove(m_Entity.Id))
            {
                throw new Exception("Entity info is unmanaged.");
            }
        }

        /// <summary>
        /// 实体附加子实体
        /// </summary>
        public virtual void OnAttached(EntityBase childEntity, Transform parentTransform, object userData)
        {

        }

        /// <summary>
        /// 实体解除子实体
        /// </summary>
        public virtual void OnDetached(EntityBase childEntity, object userData)
        {

        }

        /// <summary>
        /// 实体附加子实体
        /// </summary>
        public virtual void OnAttachTo(EntityBase parentEntity, Transform parentTransform, object userData)
        {

        }

        /// <summary>
        /// 实体解除子实体
        /// </summary>
        public virtual void OnDetachFrom(EntityBase parentEntity, object userData)
        {

        }

        /// <summary>
        /// 实体轮询
        /// </summary>
        public virtual void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {

        }
    }
}

