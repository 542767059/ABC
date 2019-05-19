using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// Avtar组件
    /// </summary>
    public class AvtarComponent : GameBaseComponent
    {
        [SerializeField]
        private float m_AutoClearInetrval = 60f;

        /// <summary>
        /// 获取或设置自动释放间隔
        /// </summary>
        public float AutoClearInetrval
        {
            get
            {
                return m_AvtarManager.AutoClearInetrval;
            }
            set
            {
                m_AvtarManager.AutoClearInetrval = value;
            }
        }

        /// <summary>
        /// 获取所有换装信息
        /// </summary>
        public Dictionary<Entity, AvtarManager.AvtarInfo> AvtarInfos
        {
            get
            {
                return m_AvtarManager.AvtarInfos;
            }
        }

        private AvtarManager m_AvtarManager;
        protected override void OnAwake()
        {
            base.OnAwake();
            m_AvtarManager = new AvtarManager();
        }

        protected override void OnStart()
        {
            base.OnStart();
            m_AvtarManager.SetObjectPoolManager();
            m_AvtarManager.AutoClearInetrval = m_AutoClearInetrval;
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            m_AvtarManager.OnUpdate(deltaTime, unscaledDeltaTime);
        }

        public override void Shutdown()
        {
            base.Shutdown();
            m_AvtarManager.Dispose();
        }

        /// <summary>
        /// 增加蒙皮信息
        /// </summary>
        /// <param name="entity">要换装的实体</param>
        /// <param name="assetName">要换装的资源名称</param>
        public void AddSkinnedMesh(Entity entity, string assetName)
        {
            m_AvtarManager.AddSkinnedMesh(entity, assetName);
        }

        /// <summary>
        /// 移除蒙皮信息
        /// </summary>
        /// <param name="entity">要换装的实体</param>
        /// <param name="assetName">要换装的资源名称</param>
        public void RemoveSkinnedMesh(Entity entity, string assetName)
        {
            m_AvtarManager.RemoveSkinnedMesh(entity, assetName);
        }

        /// <summary>
        /// 移除所有蒙皮信息
        /// </summary>
        /// <param name="entity">要换装的实体</param>
        public void RemoveAllSkinnedMesh(Entity entity)
        {
            m_AvtarManager.RemoveAllSkinnedMesh(entity);
        }

        /// <summary>
        /// 换装(删除之前所有增加的)
        /// </summary>
        /// <param name="entity">要换装的实体</param>
        /// <param name="assetName">要换装的资源名称</param>
        public void ChangeSkinnedMesh(Entity entity, string assetName)
        {
            m_AvtarManager.ChangeSkinnedMesh(entity, assetName);
        }


    }
}
