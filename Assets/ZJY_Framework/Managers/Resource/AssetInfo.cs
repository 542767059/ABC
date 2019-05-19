using System;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// Asset资源信息
    /// </summary>
    public class AssetInfo : AssetInfoBase
    {
        /// <summary>
        /// 初始化内部对象的新实例
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="spawned">对象是否已被获取</param>
        public AssetInfo(string assetName, UnityEngine.Object asset, bool spawned)
            :base(assetName, asset, spawned)
        {
            
        }

        public override bool IsAsset
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 释放对象
        /// </summary>
        /// <param name="isShutdown">是否完全释放</param>
        public override void Release(bool isShutdown)
        {
            //Debug.Log("Unity 当前 Resources.UnloadAsset 在 iOS 设备上会导致一些诡异问题，先不用这部分");

            /*if (m_Asset is GameObject || m_Asset is MonoBehaviour)
            {
                // UnloadAsset may only be used on individual assets and can not be used on GameObject's / Components or AssetBundles.
                throw new Exception("UnloadAsset may only be used on individual assets and can not be used on GameObject's / Components or AssetBundles.");
            }
            Resources.UnloadAsset(m_Asset);
            */
        }
    }
}
