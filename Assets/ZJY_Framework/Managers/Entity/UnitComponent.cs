using UnityEngine;
using System;

namespace ZJY.Framework
{
    /// <summary>
    /// 组件控制基类
    /// </summary>
    public abstract class UnitComponent
    {
        private Entity m_Owner;

        /// <summary>
        /// 组件拥有者
        /// </summary>
        public Entity Owner
        {
            get
            {
                return m_Owner;
            }
            set
            {
                m_Owner = value;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init()
        {

        }

        /// <summary>
        /// 管理轮询
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <param name="unscaledDeltaTime"></param>
        public virtual void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {

        }


        /// <summary>
        /// 关闭
        /// </summary>
        public virtual void Shutdown()
        {
            m_Owner = null;
            GameEntry.Pool.UnSpawnClassObject(this);
        }

    }
}
