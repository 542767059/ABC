using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 资源池
    /// </summary>
    public class AssetPool<T> where T : AssetInfoBase
    {
        private readonly Dictionary<string, T> m_AssetInfos;
        private readonly List<T> m_CachedCanReleaseObjects;

        /// <summary>
        /// 自动释放时间
        /// </summary>
        private float m_AutoReleaseTime;

        /// <summary>
        /// 自动释放间隔
        /// </summary>
        private float m_AutoReleaseInterval;

        /// <summary>
        /// 过期时间
        /// </summary>
        private float m_ExpireTime;

        public AssetPool()
        {
            m_AssetInfos = new Dictionary<string, T>();
            m_CachedCanReleaseObjects = new List<T>();
            m_AutoReleaseTime = 0f;
            m_AutoReleaseInterval = 60f;
            m_ExpireTime = 300f;
        }

        /// <summary>
        /// 资源池轮询
        /// </summary>
        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            m_AutoReleaseTime += unscaledDeltaTime;
            if (m_AutoReleaseTime < m_AutoReleaseInterval)
            {
                return;
            }

            Release();
        }

        /// <summary>
        /// 获取或设置自动释放资源间隔
        /// </summary>
        public float AutoReleaseInterval
        {
            get
            {
                return m_AutoReleaseInterval;
            }
            set
            {
                m_AutoReleaseInterval = value;
            }
        }

        /// <summary>
        /// 获取或设置资源过期时间
        /// </summary>
        public float ExpireTime
        {
            get
            {
                return m_ExpireTime;
            }
            set
            {
                m_ExpireTime = value;
            }
        }


        /// <summary>
        /// 释放对象池中的可释放对象
        /// </summary>
        private void Release()
        {
            m_AutoReleaseTime = 0f;
            GetCanReleaseObjects(m_CachedCanReleaseObjects);
            foreach (T toReleaseObject in m_CachedCanReleaseObjects)
            {
                ReleaseAssetInfo(toReleaseObject);
            }
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="spawned">对象是否已被获取</param>
        public void Register(T obj, bool spawned)
        {
            if (obj == null)
            {
                throw new Exception("assetInfo is invalid.");
            }

            m_AssetInfos.Add(obj.AssetName, obj);
        }


        /// <summary>
        /// 获取资源对象
        /// </summary>
        /// <param name="assetName">资源对象名称</param>
        /// <returns>要获取的对象</returns>
        public T SpawnAsset(string assetName)
        {
            T assetInfo = GetAssetInfo(assetName);
            if (assetInfo != null)
            {
                return (T)assetInfo.Spawn();
            }

            return null;
        }

        /// <summary>
        /// 检查资源对象
        /// </summary>
        /// <param name="assetName">资源对象名称</param>
        /// <returns>要检查的对象是否存在</returns>
        public bool CanSpawnAsset(string assetName)
        {
            T assetInfo = GetAssetInfo(assetName);
            if (assetInfo != null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 回收资源对象
        /// </summary>
        /// <param name="target">要回收的资源</param>
        public void UnspawnAsset(object target)
        {
            if (target == null)
            {
                throw new Exception("Target is invalid.");
            }

            T assetInfo = GetAssetInfo(target);
            if (assetInfo != null)
            {
                assetInfo.Unspawn();
            }
            else
            {
                //throw new Exception(TextUtil.Format("Can not find  target in object '{0}'.", typeof(T).FullName));
            }
        }

        private T GetAssetInfo(string name)
        {
            if (name == null)
            {
                throw new Exception("Name is invalid.");
            }

            T assetInfo = null;
            if (m_AssetInfos.TryGetValue(name, out assetInfo))
            {
                return assetInfo;
            }

            return null;
        }

        private T GetAssetInfo(object target)
        {
            if (target == null)
            {
                throw new Exception("Target is invalid.");
            }

            foreach (KeyValuePair<string, T> assetInfo in m_AssetInfos)
            {
                if (assetInfo.Value.Asset == target)
                {
                    return assetInfo.Value;
                }
            }

            return null;
        }

        private void ReleaseAssetInfo(T assetInfo)
        {
            if (assetInfo == null)
            {
                throw new Exception("AssetInfo is invalid.");
            }

            m_AssetInfos.Remove(assetInfo.AssetName);
            assetInfo.Release(false);
        }


        /// <summary>
        /// 释放未使用的资源
        /// </summary>
        public void UnloadUnusedAssets()
        {
            Release();
        }

        private void GetCanReleaseObjects(List<T> results)
        {
            if (results == null)
            {
                throw new Exception("Results is invalid.");
            }

            results.Clear();
            foreach (KeyValuePair<string, T> assetInfos in m_AssetInfos)
            {
                T internalObject = assetInfos.Value;
                if ((float)(DateTime.Now - internalObject.LastUseTime).TotalSeconds < m_ExpireTime|| (internalObject.IsAsset && internalObject.IsUsed))
                {
                    continue;
                }

                results.Add(internalObject);
            }
        }

        internal void Shutdown()
        {
            foreach (KeyValuePair<string, T> assetInfo in m_AssetInfos)
            {
                assetInfo.Value.Release(true);
            }

            m_AssetInfos.Clear();
        }
    }
}
