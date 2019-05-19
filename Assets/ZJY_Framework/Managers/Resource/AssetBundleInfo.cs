using System;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// AssetBundle资源信息
    /// </summary>
    public class AssetBundleInfo : AssetInfoBase
    {
        /// <summary>
        /// 初始化Assetbundle对象的新实例
        /// </summary>
        /// <param name="assetPath">路径</param>
        /// <param name="obj">Assetbundle对象</param>
        /// <param name="spawned">对象是否已被获取</param>
        public AssetBundleInfo(string assetBundleName, AssetBundle assetBundle, bool spawned)
            :base(assetBundleName, assetBundle, spawned)
        {
            
        }

        public override bool IsAsset
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 释放对象
        /// </summary>
        /// <param name="isShutdown">是否完全释放</param>
        public override void Release(bool isShutdown)
        {
            ((AssetBundle)Asset).Unload(isShutdown);
        }
    }
}
