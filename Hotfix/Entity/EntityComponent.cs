﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZJY.Framework;

namespace Hotfix
{
    /// <summary>
    /// 实体组件
    /// </summary>
    public class EntityComponent : IHotfixComponent
    {
        private const int DefaultPriority = 0;

        private Dictionary<int, HotEntityBase> m_EntityInfos;


        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            Debug.Log("初始化");
            m_EntityInfos = new Dictionary<int, HotEntityBase>();
        }

        /// <summary>
        /// 获取所有加载的热更类中的实体
        /// </summary>
        public Dictionary<int, HotEntityBase> EntityInfos
        {
            get
            {
                return m_EntityInfos;
            }
        }

        /// <summary>
        /// 实体组件轮询
        /// </summary>
        /// <param name="deltaTime">逻辑流逝时间，以秒为单位</param>
        /// <param name="unscaledDeltaTime">真实流逝时间，以秒为单位</param>
        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {

        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Shutdown()
        {
            Debug.Log("关闭");
            m_EntityInfos.Clear();
        }


        /// <summary>
        /// 获取热更实体
        /// </summary>
        /// <param name="entityId">实体编号</param>
        /// <returns>实体</returns>
        public HotEntityBase GetEntity(int entityId)
        {
            HotEntityBase hotfixEntity = null;
            if (m_EntityInfos.TryGetValue(entityId, out hotfixEntity))
            {
                return hotfixEntity;
            }
            return null;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="entityAssetName">实体资源名称</param>
        /// <returns>要获取的实体</returns>
        public HotEntityBase GetEntity(string entityAssetName)
        {
            if (string.IsNullOrEmpty(entityAssetName))
            {
                throw new Exception("Entity asset name is invalid.");
            }

            foreach (KeyValuePair<int, HotEntityBase> entityInfo in m_EntityInfos)
            {
                if (entityInfo.Value.Entity.EntityAssetName == entityAssetName)
                {
                    return entityInfo.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取所有已加载的实体
        /// </summary>
        /// <returns>所有已加载的实体</returns>
        public HotEntityBase[] GetAllLoadedEntities()
        {
            int index = 0;
            HotEntityBase[] results = new HotEntityBase[m_EntityInfos.Count];
            foreach (KeyValuePair<int, HotEntityBase> entityInfo in m_EntityInfos)
            {
                results[index++] = entityInfo.Value;
            }

            return results;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="entityAssetName">实体资源名称</param>
        /// <returns>要获取的实体</returns>
        public HotEntityBase[] GetEntities(string entityAssetName)
        {
            if (string.IsNullOrEmpty(entityAssetName))
            {
                throw new Exception("Entity asset name is invalid.");
            }

            List<HotEntityBase> results = new List<HotEntityBase>();
            foreach (KeyValuePair<int, HotEntityBase> entityInfo in m_EntityInfos)
            {
                if (entityInfo.Value.Entity.EntityAssetName == entityAssetName)
                {
                    results.Add(entityInfo.Value);
                }
            }

            return results.ToArray();
        }

        /// <summary>
        /// 是否是合法的实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>实体是否合法</returns>
        public bool IsValidEntity(HotEntityBase entity)
        {
            return GameEntry.Entity.IsValidEntity(entity.Entity);
        }
        
        /// <summary>
        /// 显示实体
        /// </summary>
        /// <typeparam name="T">实体逻辑类型</typeparam>
        /// <param name="entityId">实体编号</param>
        /// <param name="entityAssetName">实体资源名称</param>
        /// <param name="entityGroupName">实体组名称</param>
        /// <param name="data">实体数据</param>
        public void ShowEntity<T>(int entityId, string entityAssetName, string entityGroupName, HotEntityData data) where T : HotEntityBase
        {
            ShowEntity(entityId, typeof(T), entityAssetName, entityGroupName, DefaultPriority, data);
        }

        /// <summary>
        /// 显示实体
        /// </summary>
        /// <param name="entityId">实体编号</param>
        /// <param name="hotfixEntity">实体逻辑类型</param>
        /// <param name="entityAssetName">实体资源名称</param>
        /// <param name="entityGroupName">实体组名称</param>
        /// <param name="data">实体数据</param>
        public void ShowEntity(int entityId, Type hotfixEntity, string entityAssetName, string entityGroupName, HotEntityData data)
        {
            ShowEntity(entityId, hotfixEntity, entityAssetName, entityGroupName, DefaultPriority, data);
        }

        /// <summary>
        /// 显示实体
        /// </summary>
        /// <typeparam name="T">实体逻辑类型</typeparam>
        /// <param name="entityId">实体编号</param>
        /// <param name="entityAssetName">实体资源名称</param>
        /// <param name="entityGroupName">实体组名称</param>
        /// <param name="priority">加载实体资源的优先级</param>
        /// <param name="data">实体数据</param>
        public void ShowEntity<T>(int entityId, string entityAssetName, string entityGroupName, int priority, HotEntityData data) where T : HotEntityBase
        {
            ShowEntity(entityId, typeof(T), entityAssetName, entityGroupName, priority, data);
        }

        /// <summary>
        /// 显示实体
        /// </summary>
        /// <param name="entityId">实体编号</param>
        /// <param name="hotfixEntity">实体逻辑类型</param>
        /// <param name="entityAssetName">实体资源名称</param>
        /// <param name="entityGroupName">实体组名称</param>
        /// <param name="priority">加载实体资源的优先级</param>
        /// <param name="data">实体数据</param>
        public void ShowEntity(int entityId, Type hotfixEntity, string entityAssetName, string entityGroupName, int priority, HotEntityData data)
        {
            if (hotfixEntity == null)
            {
                Log.Error("Entity type is invalid.");
                return;
            }


            GameEntry.Entity.ShowEntity(entityId, typeof(ZJY.Framework.HotEntity), entityAssetName, entityGroupName, priority, new HotfixEntityData()
            {
                Position = data.Position,
                Rotation = data.Rotation,
            }.Fill(data.Id, data.TypeId, hotfixEntity.FullName, data));
        }


        /// <summary>
        /// 隐藏实体
        /// </summary>
        /// <param name="entityId">实体编号</param>
        public void HideEntity(int entityId)
        {
            GameEntry.Entity.HideEntity(entityId);
        }

        /// <summary>
        /// 隐藏实体
        /// </summary>
        /// <param name="entityId">实体编号</param>
        /// <param name="userData">用户自定义数据</param>
        public void HideEntity(int entityId, object userData)
        {
            GameEntry.Entity.HideEntity(entityId, userData);
        }

        /// <summary>
        /// 隐藏实体
        /// </summary>
        /// <param name="entity">实体</param>
        public void HideEntity(HotEntityBase entity)
        {
            GameEntry.Entity.HideEntity(entity.Entity);
        }

        /// <summary>
        /// 隐藏实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="userData">用户自定义数据</param>
        public void HideEntity(HotEntityBase entity, object userData)
        {
            GameEntry.Entity.HideEntity(entity.Entity, userData);
        }

    }
}
