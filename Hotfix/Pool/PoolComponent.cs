using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hotfix
{
    /// <summary>
    /// 对象池组件
    /// </summary>
    public class PoolComponent : IHotfixComponent
    {
        private PoolManager m_PoolManager;

        /// <summary>
        /// 得到对象池管理器
        /// </summary>
        public PoolManager PoolManager
        {
            get
            {
                return m_PoolManager;
            }
        }


        public void Init()
        {
            m_PoolManager = new PoolManager();
        }

        
        #region SpawnClassObject 取出一个对象
        /// <summary>
        /// 取出一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T SpawnClassObject<T>() where T : class, new()
        {
            return m_PoolManager.ClassObjectPool.Spawn<T>();
        }
        #endregion

        #region UnSpawnClassObject 对象回池
        /// <summary>
        /// 对象回池
        /// </summary>
        /// <param name="obj"></param>
        public void UnSpawnClassObject(object obj)
        {
            m_PoolManager.ClassObjectPool.UnSpawn(obj);
        }
        #endregion

        
        public void Shutdown()
        {
            m_PoolManager.Shutdown();
        }



        public  void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            m_PoolManager.OnUpdate(deltaTime, unscaledDeltaTime);
        }
    }
}
