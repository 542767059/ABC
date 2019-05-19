using System;
using System.Collections.Generic;
using UnityEngine;
namespace ZJY.Framework
{
    /// <summary>
    /// 实体抽象类
    /// </summary>
    public abstract class Entity : EntityBase
    {
        [SerializeField]
        private EntityData m_EntityData = null;

        private int m_OriginalLayer = 0;
        private Transform m_OriginalTransform = null;

        protected Dictionary<string, UnitComponent> m_UnitComponents = new Dictionary<string, UnitComponent>();

        /// <summary>
        /// 自身带的动画
        /// </summary>
        public Animation CachedAnimation
        {
            get;
            private set;
        }

        /// <summary>
        /// 初始化实体
        /// </summary>
        /// <param name="userData"></param>
        protected override void OnInit(object userData)
        {
            m_OriginalLayer = gameObject.layer;
            m_OriginalTransform = SelfTransform.parent;
            CachedAnimation = GetComponent<Animation>();
        }

        /// <summary>
        /// 实体显示
        /// </summary>
        /// <param name="userData">用户自定义数据</param>
        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_EntityData = userData as EntityData;
            if (m_EntityData == null)
            {
                Log.Error("Entity data is invalid.");
                return;
            }

            SelfTransform.localPosition = m_EntityData.Position;
            SelfTransform.localRotation = m_EntityData.Rotation;
            SelfTransform.localScale = Vector3.one;

            SelfTransform.localScale = Vector3.one;
        }

        /// <summary>
        /// 实体隐藏
        /// </summary>
        /// <param name="userData">用户自定义数据</param>
        protected internal override void OnHide(object userData)
        {
            base.OnHide(userData);
            gameObject.SetLayerRecursively(m_OriginalLayer);
            foreach (UnitComponent unitComponent in m_UnitComponents.Values)
            {
                unitComponent.Shutdown();
            }
            m_UnitComponents.Clear();
        }

        /// <summary>
        /// 实体附加子实体(父物体触发)
        /// </summary>
        /// <param name="childEntity">附加的子实体</param>
        /// <param name="parentTransform">被附加父实体的位置</param>
        /// <param name="userData">用户自定义数据</param>
        protected internal override void OnAttached(EntityBase childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);
        }

        /// <summary>
        /// 实体解除子实体(父物体触发)
        /// </summary>
        /// <param name="childEntity">解除的子实体</param>
        /// <param name="userData">用户自定义数据</param>
        protected internal override void OnDetached(EntityBase childEntity, object userData)
        {
            base.OnDetached(childEntity, userData);
        }

        /// <summary>
        /// 实体附加子实体(子物体触发)
        /// </summary>
        /// <param name="parentEntity">被附加的父实体</param>
        /// <param name="parentTransform">被附加父实体的位置</param>
        /// <param name="userData">用户自定义数据</param>
        protected internal override void OnAttachTo(EntityBase parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);
            SelfTransform.SetParent(parentTransform);
        }

        /// <summary>
        /// 实体解除子实体(子物体触发)
        /// </summary>
        /// <param name="parentEntity">被解除的父实体</param>
        /// <param name="userData">用户自定义数据</param>
        protected internal override void OnDetachFrom(EntityBase parentEntity, object userData)
        {
            base.OnDetachFrom(parentEntity, userData);
            SelfTransform.SetParent(m_OriginalTransform);
        }

        /// <summary>
        /// 实体轮询
        /// </summary>
        /// <param name="deltaTime">逻辑流逝时间，以秒为单位</param>
        /// <param name="unscaledDeltaTime">真实流逝时间，以秒为单位</param>
        protected internal override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            foreach (UnitComponent unitComponent in m_UnitComponents.Values)
            {
                unitComponent.OnUpdate(deltaTime, unscaledDeltaTime);
            }
        }

        /// <summary>
        /// 增加组件
        /// </summary>
        /// <typeparam name="T">要增加的组件</typeparam>
        /// <returns>得到的组件</returns>
        public T GetOrAddUnitComponent<T>() where T : UnitComponent
        {
            Type type = typeof(T);

            UnitComponent unitComponent = null;
            if (m_UnitComponents.TryGetValue(type.FullName, out unitComponent))
            {
                return (T)unitComponent;
            }
            
            unitComponent = (UnitComponent)GameEntry.Pool.SpawnClassObject(type);
            m_UnitComponents.Add(type.FullName, unitComponent);
            unitComponent.Owner = this;
            unitComponent.Init();
            return (T)unitComponent;
        }

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <typeparam name="T">要获取的组件</typeparam>
        public T GetUnitComponent<T>() where T : UnitComponent
        {
            Type type = typeof(T);
            UnitComponent unitComponent = null;
            if (m_UnitComponents.TryGetValue(type.FullName,out unitComponent))
            {
                return (T)unitComponent;
            }

            return null;
        }

        /// <summary>
        /// 移除组件
        /// </summary>
        /// <typeparam name="T">要移除的组件</typeparam>
        /// <returns>是否移除成功</returns>
        public bool RemoveUnitComponent<T>() where T : UnitComponent
        {
            Type type = typeof(T);

            UnitComponent unitComponent = null;
            if (m_UnitComponents.TryGetValue(type.FullName, out unitComponent))
            {
                unitComponent.Shutdown();
                m_UnitComponents.Remove(type.FullName);
                return true;
            }

            return false;
        }
    }
}