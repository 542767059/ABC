//===================================================
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
    /// 类对象池 (不支持带参数构造函数的类，必须使用Init之类的初始化方法)
    /// </summary>
    public class ClassObjectPool : IDisposable
    {
        /// <summary>
        /// 下次释放时间
        /// </summary>
        private float m_NextRunTime;

        /// <summary>
        /// 释放间隔
        /// </summary>
        private float m_ClearClassObjectInterval = 60f;

        /// <summary>
        /// 类对象在池中的常驻数量
        /// </summary>
        private Dictionary<string, byte> m_ClassObjectCount;

        /// <summary>
        /// 类对象池字典
        /// </summary>
        private Dictionary<string, Queue<object>> m_ClassObjetPoolDic;

        private List<string> m_NeedMoveType;

        public ClassObjectPool()
        {
            m_NeedMoveType = new List<string>();
            m_ClassObjectCount = new Dictionary<string, byte>();
            m_ClassObjetPoolDic = new Dictionary<string, Queue<object>>();
            m_NextRunTime = 0f;
        }

        /// <summary>
        /// 类对象在池中的常驻数量
        /// </summary>
        public Dictionary<string, byte> ClassObjectCount
        {
            get
            {
                return m_ClassObjectCount;
            }
        }

        /// <summary>
        /// 获取类对象池字典
        /// </summary>
        public Dictionary<string, Queue<object>> ClassObjetPoolDic
        {
            get
            {
                return m_ClassObjetPoolDic;
            }
        }

        /// <summary>
        /// 获取或设置类对象池是否间隔
        /// </summary>
        public float ClearClassObjectInterval
        {
            get
            {
                return m_ClearClassObjectInterval;
            }
            set
            {
                m_ClearClassObjectInterval = value;
            }
        }

        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            if (Time.time > m_NextRunTime + m_ClearClassObjectInterval)
            {
                //释放
                m_NextRunTime = Time.time;
                Clear();//释放类对象池
            }
        }

        #region SetResideCount 设置类常驻数量
        /// <summary>
        /// 设置类常驻数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="count"></param>
        public void SetResideCount<T>(byte count) where T : class
        {
            string fullName = typeof(T).FullName;
            m_ClassObjectCount[fullName] = count;
        }
        #endregion

        #region Spawn 取出一个对象
        /// <summary>
        /// 取出一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Spawn<T>() where T : class, new()
        {
            lock (m_ClassObjetPoolDic)
            {
                //先找到这个类全名
                string fullName = typeof(T).FullName;

                Queue<object> queue = null;
                m_ClassObjetPoolDic.TryGetValue(fullName, out queue);

                if (queue == null)
                {
                    queue = new Queue<object>();
                    m_ClassObjetPoolDic[fullName] = queue;
                }

                //开始获取对象
                if (queue.Count > 0)
                {
                    //说明队列中有闲置的
                    object obj = queue.Dequeue();
                    return (T)obj;
                }
                else
                {
                    //如果队列中没有 才实例化一个
                    return new T();
                }
            }
        }

        public object Spawn(Type type)
        {
            lock (m_ClassObjetPoolDic)
            {
                //先找到这个类的全名
                string fullName = type.FullName;

                Queue<object> queue = null;
                m_ClassObjetPoolDic.TryGetValue(fullName, out queue);

                if (queue == null)
                {
                    queue = new Queue<object>();
                    m_ClassObjetPoolDic[fullName] = queue;
                }

                //开始获取对象
                if (queue.Count > 0)
                {
                    //说明队列中有闲置的
                    object obj = queue.Dequeue();
                    return obj;
                }
                else
                {
                    //如果队列中没有 才实例化一个
                    return Activator.CreateInstance(type);
                }
            }
        }
        #endregion

        #region UnSpawn 对象回池
        /// <summary>
        /// 对象回池
        /// </summary>
        /// <param name="obj"></param>
        public void UnSpawn(object obj)
        {
            lock (m_ClassObjetPoolDic)
            {
                string fullName = obj.GetType().FullName;

                Queue<object> queue = null;
                m_ClassObjetPoolDic.TryGetValue(fullName, out queue);

                if (queue == null)
                {
                    queue = new Queue<object>();
                    m_ClassObjetPoolDic[fullName] = queue;
                }
                queue.Enqueue(obj);

            }
        }
        #endregion


        /// <summary>
        /// 释放类对象池
        /// </summary>
        public void Clear()
        {
            lock (m_ClassObjetPoolDic)
            {
                m_NeedMoveType.Clear();
                int queueCount = 0;//队列数量

                //1.定义迭代器
                var enumerator = m_ClassObjetPoolDic.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    string fullName = enumerator.Current.Key;
                    //拿到队列
                    Queue<object> queue = m_ClassObjetPoolDic[fullName];

                    queueCount = queue.Count;

                    //用于释放的时候判断
                    byte resideCount = 0;
                    m_ClassObjectCount.TryGetValue(fullName, out resideCount);
                    while (queueCount > resideCount)
                    {
                        //队列中有可释放的对象
                        queueCount--;
                        object obj = queue.Dequeue();//从队列中取出一个 这个对象没有任何引用，就变成了野指针 等待GC回收
                    }

                    if (queueCount == 0)
                    {
                        m_NeedMoveType.Add(fullName);
                    }
                }

                int count = m_NeedMoveType.Count;
                for (int i = 0; i < count; i++)
                {
                    m_ClassObjetPoolDic.Remove(m_NeedMoveType[i]);
                }
            }
        }

        public void Dispose()
        {
            m_ClassObjetPoolDic.Clear();
            m_ClassObjectCount.Clear();
        }
    }
}
