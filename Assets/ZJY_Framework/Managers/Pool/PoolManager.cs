﻿//===================================================
//
//===================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ZJY.Framework
{
    /// <summary>
    /// 对象池管理器
    /// </summary>
    public class PoolManager : ManagerBase, IDisposable
    {
        private const int DefaultCapacity = int.MaxValue;
        private const float DefaultExpireTime = float.MaxValue;
        private const int DefaultPriority = 0;

        private readonly Dictionary<string, ObjectPoolBase> m_ObjectPools;

        public ClassObjectPool ClassObjectPool
        {
            get;
            private set;
        }

        public float ClearClassObjectInterval
        {
            get
            {
                return ClassObjectPool.ClearClassObjectInterval;
            }
            set
            {
                ClassObjectPool.ClearClassObjectInterval = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PoolManager()
        {
            ClassObjectPool = new ClassObjectPool();

            m_ObjectPools = new Dictionary<string, ObjectPoolBase>();
        }
        

        /// <summary>
        /// 获取对象池数量
        /// </summary>
        public int Count
        {
            get
            {
                return m_ObjectPools.Count;
            }
        }

        /// <summary>
        /// 对象池管理器轮询
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位</param>
        internal void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            foreach (KeyValuePair<string, ObjectPoolBase> objectPool in m_ObjectPools)
            {
                objectPool.Value.OnUpdate(deltaTime, unscaledDeltaTime);
            }
            ClassObjectPool.OnUpdate(deltaTime, unscaledDeltaTime);
        }


        /// <summary>
        /// 关闭并清理对象池管理器
        /// </summary>
        public override void Dispose()
        {
            ClassObjectPool.Dispose();

            foreach (KeyValuePair<string, ObjectPoolBase> objectPool in m_ObjectPools)
            {
                objectPool.Value.Shutdown();
            }

            m_ObjectPools.Clear();
        }
        
        /// <summary>
        /// 检查是否存在对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>是否存在对象池</returns>
        public bool HasObjectPool<T>() where T : ObjectBase
        {
            return HasObjectPool(TextUtil.GetFullName<T>(string.Empty));
        }

        /// <summary>
        /// 检查是否存在对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>是否存在对象池</returns>
        public bool HasObjectPool(Type objectType)
        {
            if (objectType == null)
            {
                throw new Exception("Object type is invalid.");
            }

            if (!typeof(ObjectBase).IsAssignableFrom(objectType))
            {
                throw new Exception(TextUtil.Format("Object type '{0}' is invalid.", objectType.FullName));
            }

            return HasObjectPool(TextUtil.GetFullName(objectType, string.Empty));
        }

        /// <summary>
        /// 检查是否存在对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <returns>是否存在对象池</returns>
        public bool HasObjectPool<T>(string name) where T : ObjectBase
        {
            return HasObjectPool(TextUtil.GetFullName<T>(name));
        }

        /// <summary>
        /// 检查是否存在对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <returns>是否存在对象池</returns>
        public bool HasObjectPool(Type objectType, string name)
        {
            if (objectType == null)
            {
                throw new Exception("Object type is invalid.");
            }

            if (!typeof(ObjectBase).IsAssignableFrom(objectType))
            {
                throw new Exception(TextUtil.Format("Object type '{0}' is invalid.", objectType.FullName));
            }

            return HasObjectPool(TextUtil.GetFullName(objectType, name));
        }

        /// <summary>
        /// 检查是否存在对象池
        /// </summary>
        /// <param name="fullName">对象池完整名称</param>
        /// <returns>是否存在对象池</returns>
        public bool HasObjectPool(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new Exception("Full name is invalid.");
            }

            return m_ObjectPools.ContainsKey(fullName);
        }

        /// <summary>
        /// 检查是否存在对象池
        /// </summary>
        /// <param name="condition">要检查的条件</param>
        /// <returns>是否存在对象池</returns>
        public bool HasObjectPool(Predicate<ObjectPoolBase> condition)
        {
            if (condition == null)
            {
                throw new Exception("Condition is invalid.");
            }

            foreach (KeyValuePair<string, ObjectPoolBase> objectPool in m_ObjectPools)
            {
                if (condition(objectPool.Value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>要获取的对象池</returns>
        public IObjectPool<T> GetObjectPool<T>() where T : ObjectBase
        {
            return (IObjectPool<T>)GetObjectPool(TextUtil.GetFullName<T>(string.Empty));
        }

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>要获取的对象池</returns>
        public ObjectPoolBase GetObjectPool(Type objectType)
        {
            if (objectType == null)
            {
                throw new Exception("Object type is invalid.");
            }

            if (!typeof(ObjectBase).IsAssignableFrom(objectType))
            {
                throw new Exception(TextUtil.Format("Object type '{0}' is invalid.", objectType.FullName));
            }

            return GetObjectPool(TextUtil.GetFullName(objectType, string.Empty));
        }

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <returns>要获取的对象池</returns>
        public IObjectPool<T> GetObjectPool<T>(string name) where T : ObjectBase
        {
            return (IObjectPool<T>)GetObjectPool(TextUtil.GetFullName<T>(name));
        }

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <returns>要获取的对象池</returns>
        public ObjectPoolBase GetObjectPool(Type objectType, string name)
        {
            if (objectType == null)
            {
                throw new Exception("Object type is invalid.");
            }

            if (!typeof(ObjectBase).IsAssignableFrom(objectType))
            {
                throw new Exception(TextUtil.Format("Object type '{0}' is invalid.", objectType.FullName));
            }

            return GetObjectPool(TextUtil.GetFullName(objectType, name));
        }

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <param name="fullName">对象池完整名称</param>
        /// <returns>要获取的对象池</returns>
        public ObjectPoolBase GetObjectPool(string fullName)
        {
            if (string.IsNullOrEmpty(fullName))
            {
                throw new Exception("Full name is invalid.");
            }

            ObjectPoolBase objectPool = null;
            if (m_ObjectPools.TryGetValue(fullName, out objectPool))
            {
                return objectPool;
            }

            return null;
        }

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <param name="condition">要检查的条件</param>
        /// <returns>要获取的对象池</returns>
        public ObjectPoolBase GetObjectPool(Predicate<ObjectPoolBase> condition)
        {
            if (condition == null)
            {
                throw new Exception("Condition is invalid.");
            }

            foreach (KeyValuePair<string, ObjectPoolBase> objectPool in m_ObjectPools)
            {
                if (condition(objectPool.Value))
                {
                    return objectPool.Value;
                }
            }

            return null;
        }

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <param name="condition">要检查的条件</param>
        /// <returns>要获取的对象池</returns>
        public ObjectPoolBase[] GetObjectPools(Predicate<ObjectPoolBase> condition)
        {
            if (condition == null)
            {
                throw new Exception("Condition is invalid.");
            }

            List<ObjectPoolBase> results = new List<ObjectPoolBase>();
            foreach (KeyValuePair<string, ObjectPoolBase> objectPool in m_ObjectPools)
            {
                if (condition(objectPool.Value))
                {
                    results.Add(objectPool.Value);
                }
            }

            return results.ToArray();
        }

        /// <summary>
        /// 获取对象池
        /// </summary>
        /// <param name="condition">要检查的条件</param>
        /// <param name="results">要获取的对象池</param>
        public void GetObjectPools(Predicate<ObjectPoolBase> condition, List<ObjectPoolBase> results)
        {
            if (condition == null)
            {
                throw new Exception("Condition is invalid.");
            }

            if (results == null)
            {
                throw new Exception("Results is invalid.");
            }

            results.Clear();
            foreach (KeyValuePair<string, ObjectPoolBase> objectPool in m_ObjectPools)
            {
                if (condition(objectPool.Value))
                {
                    results.Add(objectPool.Value);
                }
            }
        }

        /// <summary>
        /// 获取所有对象池
        /// </summary>
        /// <returns>所有对象池</returns>
        public ObjectPoolBase[] GetAllObjectPools()
        {
            return GetAllObjectPools(false);
        }

        /// <summary>
        /// 获取所有对象池
        /// </summary>
        /// <param name="results">所有对象池</param>
        public void GetAllObjectPools(List<ObjectPoolBase> results)
        {
            GetAllObjectPools(false, results);
        }

        /// <summary>
        /// 获取所有对象池
        /// </summary>
        /// <param name="sort">是否根据对象池的优先级排序</param>
        /// <returns>所有对象池</returns>
        public ObjectPoolBase[] GetAllObjectPools(bool sort)
        {
            if (sort)
            {
                List<ObjectPoolBase> results = new List<ObjectPoolBase>();
                foreach (KeyValuePair<string, ObjectPoolBase> objectPool in m_ObjectPools)
                {
                    results.Add(objectPool.Value);
                }

                results.Sort(ObjectPoolComparer);
                return results.ToArray();
            }
            else
            {
                int index = 0;
                ObjectPoolBase[] results = new ObjectPoolBase[m_ObjectPools.Count];
                foreach (KeyValuePair<string, ObjectPoolBase> objectPool in m_ObjectPools)
                {
                    results[index++] = objectPool.Value;
                }

                return results;
            }
        }

        /// <summary>
        /// 获取所有对象池
        /// </summary>
        /// <param name="sort">是否根据对象池的优先级排序</param>
        /// <param name="results">所有对象池</param>
        public void GetAllObjectPools(bool sort, List<ObjectPoolBase> results)
        {
            if (results == null)
            {
                throw new Exception("Results is invalid.");
            }

            results.Clear();
            foreach (KeyValuePair<string, ObjectPoolBase> objectPool in m_ObjectPools)
            {
                results.Add(objectPool.Value);
            }

            if (sort)
            {
                results.Sort(ObjectPoolComparer);
            }
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>() where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, false, DefaultExpireTime, DefaultCapacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType)
        {
            return InternalCreateObjectPool(objectType, string.Empty, false, DefaultExpireTime, DefaultCapacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(string name) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, false, DefaultExpireTime, DefaultCapacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, string name)
        {
            return InternalCreateObjectPool(objectType, name, false, DefaultExpireTime, DefaultCapacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="capacity">对象池的容量</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(int capacity) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, false, DefaultExpireTime, capacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="capacity">对象池的容量</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, int capacity)
        {
            return InternalCreateObjectPool(objectType, string.Empty, false, DefaultExpireTime, capacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(float expireTime) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, false, expireTime, DefaultCapacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, float expireTime)
        {
            return InternalCreateObjectPool(objectType, string.Empty, false, expireTime, DefaultCapacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(string name, int capacity) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, false, DefaultExpireTime, capacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, string name, int capacity)
        {
            return InternalCreateObjectPool(objectType, name, false, DefaultExpireTime, capacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(string name, float expireTime) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, false, expireTime, DefaultCapacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, string name, float expireTime)
        {
            return InternalCreateObjectPool(objectType, name, false, expireTime, DefaultCapacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(int capacity, float expireTime) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, false, expireTime, capacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, int capacity, float expireTime)
        {
            return InternalCreateObjectPool(objectType, string.Empty, false, expireTime, capacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(int capacity, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, false, DefaultExpireTime, capacity, DefaultExpireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, int capacity, int priority)
        {
            return InternalCreateObjectPool(objectType, string.Empty, false, DefaultExpireTime, capacity, DefaultExpireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(float expireTime, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, false, expireTime, DefaultCapacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, float expireTime, int priority)
        {
            return InternalCreateObjectPool(objectType, string.Empty, false, expireTime, DefaultCapacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(string name, int capacity, float expireTime) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, false, expireTime, capacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, string name, int capacity, float expireTime)
        {
            return InternalCreateObjectPool(objectType, name, false, expireTime, capacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(string name, int capacity, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, false, DefaultExpireTime, capacity, DefaultExpireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, string name, int capacity, int priority)
        {
            return InternalCreateObjectPool(objectType, name, false, DefaultExpireTime, capacity, DefaultExpireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(string name, float expireTime, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, false, expireTime, DefaultCapacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, string name, float expireTime, int priority)
        {
            return InternalCreateObjectPool(objectType, name, false, expireTime, DefaultCapacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(int capacity, float expireTime, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, false, expireTime, capacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, int capacity, float expireTime, int priority)
        {
            return InternalCreateObjectPool(objectType, string.Empty, false, expireTime, capacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(string name, int capacity, float expireTime, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, false, expireTime, capacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, string name, int capacity, float expireTime, int priority)
        {
            return InternalCreateObjectPool(objectType, name, false, expireTime, capacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="autoReleaseInterval">对象池自动释放可释放对象的间隔秒数</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public IObjectPool<T> CreateSingleSpawnObjectPool<T>(string name, float autoReleaseInterval, int capacity, float expireTime, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, false, autoReleaseInterval, capacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许单次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="autoReleaseInterval">对象池自动释放可释放对象的间隔秒数</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许单次获取的对象池</returns>
        public ObjectPoolBase CreateSingleSpawnObjectPool(Type objectType, string name, float autoReleaseInterval, int capacity, float expireTime, int priority)
        {
            return InternalCreateObjectPool(objectType, name, false, autoReleaseInterval, capacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>() where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, true, DefaultExpireTime, DefaultCapacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType)
        {
            return InternalCreateObjectPool(objectType, string.Empty, true, DefaultExpireTime, DefaultCapacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(string name) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, true, DefaultExpireTime, DefaultCapacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, string name)
        {
            return InternalCreateObjectPool(objectType, name, true, DefaultExpireTime, DefaultCapacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="capacity">对象池的容量</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(int capacity) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, true, DefaultExpireTime, capacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="capacity">对象池的容量</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, int capacity)
        {
            return InternalCreateObjectPool(objectType, string.Empty, true, DefaultExpireTime, capacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(float expireTime) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, true, expireTime, DefaultCapacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, float expireTime)
        {
            return InternalCreateObjectPool(objectType, string.Empty, true, expireTime, DefaultCapacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(string name, int capacity) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, true, DefaultExpireTime, capacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, string name, int capacity)
        {
            return InternalCreateObjectPool(objectType, name, true, DefaultExpireTime, capacity, DefaultExpireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(string name, float expireTime) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, true, expireTime, DefaultCapacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, string name, float expireTime)
        {
            return InternalCreateObjectPool(objectType, name, true, expireTime, DefaultCapacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(int capacity, float expireTime) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, true, expireTime, capacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, int capacity, float expireTime)
        {
            return InternalCreateObjectPool(objectType, string.Empty, true, expireTime, capacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(int capacity, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, true, DefaultExpireTime, capacity, DefaultExpireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, int capacity, int priority)
        {
            return InternalCreateObjectPool(objectType, string.Empty, true, DefaultExpireTime, capacity, DefaultExpireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(float expireTime, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, true, expireTime, DefaultCapacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, float expireTime, int priority)
        {
            return InternalCreateObjectPool(objectType, string.Empty, true, expireTime, DefaultCapacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(string name, int capacity, float expireTime) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, true, expireTime, capacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, string name, int capacity, float expireTime)
        {
            return InternalCreateObjectPool(objectType, name, true, expireTime, capacity, expireTime, DefaultPriority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(string name, int capacity, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, true, DefaultExpireTime, capacity, DefaultExpireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, string name, int capacity, int priority)
        {
            return InternalCreateObjectPool(objectType, name, true, DefaultExpireTime, capacity, DefaultExpireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(string name, float expireTime, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, true, expireTime, DefaultCapacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, string name, float expireTime, int priority)
        {
            return InternalCreateObjectPool(objectType, name, true, expireTime, DefaultCapacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(int capacity, float expireTime, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(string.Empty, true, expireTime, capacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, int capacity, float expireTime, int priority)
        {
            return InternalCreateObjectPool(objectType, string.Empty, true, expireTime, capacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(string name, int capacity, float expireTime, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, true, expireTime, capacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, string name, int capacity, float expireTime, int priority)
        {
            return InternalCreateObjectPool(objectType, name, true, expireTime, capacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">对象池名称</param>
        /// <param name="autoReleaseInterval">对象池自动释放可释放对象的间隔秒数</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public IObjectPool<T> CreateMultiSpawnObjectPool<T>(string name, float autoReleaseInterval, int capacity, float expireTime, int priority) where T : ObjectBase
        {
            return InternalCreateObjectPool<T>(name, true, autoReleaseInterval, capacity, expireTime, priority);
        }

        /// <summary>
        /// 创建允许多次获取的对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">对象池名称</param>
        /// <param name="autoReleaseInterval">对象池自动释放可释放对象的间隔秒数</param>
        /// <param name="capacity">对象池的容量</param>
        /// <param name="expireTime">对象池对象过期秒数</param>
        /// <param name="priority">对象池的优先级</param>
        /// <returns>要创建的允许多次获取的对象池</returns>
        public ObjectPoolBase CreateMultiSpawnObjectPool(Type objectType, string name, float autoReleaseInterval, int capacity, float expireTime, int priority)
        {
            return InternalCreateObjectPool(objectType, name, true, autoReleaseInterval, capacity, expireTime, priority);
        }

        /// <summary>
        /// 销毁对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns>是否销毁对象池成功</returns>
        public bool DestroyObjectPool<T>() where T : ObjectBase
        {
            return InternalDestroyObjectPool(TextUtil.GetFullName<T>(string.Empty));
        }

        /// <summary>
        /// 销毁对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <returns>是否销毁对象池成功</returns>
        public bool DestroyObjectPool(Type objectType)
        {
            if (objectType == null)
            {
                throw new Exception("Object type is invalid.");
            }

            if (!typeof(ObjectBase).IsAssignableFrom(objectType))
            {
                throw new Exception(TextUtil.Format("Object type '{0}' is invalid.", objectType.FullName));
            }

            return InternalDestroyObjectPool(TextUtil.GetFullName(objectType, string.Empty));
        }

        /// <summary>
        /// 销毁对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="name">要销毁的对象池名称</param>
        /// <returns>是否销毁对象池成功</returns>
        public bool DestroyObjectPool<T>(string name) where T : ObjectBase
        {
            return InternalDestroyObjectPool(TextUtil.GetFullName<T>(name));
        }

        /// <summary>
        /// 销毁对象池
        /// </summary>
        /// <param name="objectType">对象类型</param>
        /// <param name="name">要销毁的对象池名称</param>
        /// <returns>是否销毁对象池成功</returns>
        public bool DestroyObjectPool(Type objectType, string name)
        {
            if (objectType == null)
            {
                throw new Exception("Object type is invalid.");
            }

            if (!typeof(ObjectBase).IsAssignableFrom(objectType))
            {
                throw new Exception(TextUtil.Format("Object type '{0}' is invalid.", objectType.FullName));
            }

            return InternalDestroyObjectPool(TextUtil.GetFullName(objectType, name));
        }

        /// <summary>
        /// 销毁对象池
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="objectPool">要销毁的对象池</param>
        /// <returns>是否销毁对象池成功</returns>
        public bool DestroyObjectPool<T>(IObjectPool<T> objectPool) where T : ObjectBase
        {
            if (objectPool == null)
            {
                throw new Exception("Object pool is invalid.");
            }

            return InternalDestroyObjectPool(TextUtil.GetFullName<T>(objectPool.Name));
        }

        /// <summary>
        /// 销毁对象池
        /// </summary>
        /// <param name="objectPool">要销毁的对象池</param>
        /// <returns>是否销毁对象池成功</returns>
        public bool DestroyObjectPool(ObjectPoolBase objectPool)
        {
            if (objectPool == null)
            {
                throw new Exception("Object pool is invalid.");
            }

            return InternalDestroyObjectPool(TextUtil.GetFullName(objectPool.ObjectType, objectPool.Name));
        }

        /// <summary>
        /// 释放对象池中的可释放对象
        /// </summary>
        public void Release()
        {
            ObjectPoolBase[] objectPools = GetAllObjectPools(true);
            foreach (ObjectPoolBase objectPool in objectPools)
            {
                objectPool.Release();
            }
        }

        /// <summary>
        /// 释放对象池中的所有未使用对象
        /// </summary>
        public void ReleaseAllUnused()
        {
            ObjectPoolBase[] objectPools = GetAllObjectPools(true);
            foreach (ObjectPoolBase objectPool in objectPools)
            {
                objectPool.ReleaseAllUnused();
            }
        }

        private IObjectPool<T> InternalCreateObjectPool<T>(string name, bool allowMultiSpawn, float autoReleaseInterval, int capacity, float expireTime, int priority) where T : ObjectBase
        {
            if (HasObjectPool<T>(name))
            {
                throw new Exception(TextUtil.Format("Already exist object pool '{0}'.", TextUtil.GetFullName<T>(name)));
            }

            ObjectPool<T> objectPool = new ObjectPool<T>(name, allowMultiSpawn, autoReleaseInterval, capacity, expireTime, priority);
            m_ObjectPools.Add(TextUtil.GetFullName<T>(name), objectPool);
            return objectPool;
        }

        private ObjectPoolBase InternalCreateObjectPool(Type objectType, string name, bool allowMultiSpawn, float autoReleaseInterval, int capacity, float expireTime, int priority)
        {
            if (objectType == null)
            {
                throw new Exception("Object type is invalid.");
            }

            if (!typeof(ObjectBase).IsAssignableFrom(objectType))
            {
                throw new Exception(TextUtil.Format("Object type '{0}' is invalid.", objectType.FullName));
            }

            if (HasObjectPool(objectType, name))
            {
                throw new Exception(TextUtil.Format("Already exist object pool '{0}'.", TextUtil.GetFullName(objectType, name)));
            }

            Type objectPoolType = typeof(ObjectPool<>).MakeGenericType(objectType);
            ObjectPoolBase objectPool = (ObjectPoolBase)Activator.CreateInstance(objectPoolType, name, allowMultiSpawn, autoReleaseInterval, capacity, expireTime, priority);
            m_ObjectPools.Add(TextUtil.GetFullName(objectType, name), objectPool);
            return objectPool;
        }

        private bool InternalDestroyObjectPool(string fullName)
        {
            ObjectPoolBase objectPool = null;
            if (m_ObjectPools.TryGetValue(fullName, out objectPool))
            {
                objectPool.Shutdown();
                return m_ObjectPools.Remove(fullName);
            }

            return false;
        }

        private int ObjectPoolComparer(ObjectPoolBase a, ObjectPoolBase b)
        {
            return a.Priority.CompareTo(b.Priority);
        }
    }
}
