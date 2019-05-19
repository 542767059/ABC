using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>                                                                       
    /// 获取资源路径扩展
    /// </summary>
    public static class AssetUtility
    {
        /// <summary>
        /// 获取数据表路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetDataTableAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/DataTable/{0}.{1}", assetName, "bytes");
        }

        /// <summary>
        /// 获取本地化数据表路径
        /// </summary>
        /// <returns></returns>
        public static string GetLocalizationDataTableAsset()
        {
            return TextUtil.Format("Assets/DownLoad/DataTable/Localization/{0}.{1}", GameEntry.Localization.CurrLanguage.ToString(), "bytes");
        }

        /// <summary>
        /// 获取场景资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetSceneAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Scene/{0}.unity", assetName);
        }

        /// <summary>
        /// 获取UI资源名称路径(从Prefabs后的路径名)
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetUIFormAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/UI/UIPrefab/{0}.prefab", assetName);
        }

        /// <summary>
        /// 获取Music背景音乐声音路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetMusicAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Sound/{0}", assetName);
        }

        /// <summary>
        /// 获取Sound声音路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetSoundAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Sound/SkillSound/{0}.mp3", assetName);
        }

        /// <summary>
        /// 获取UISound声音路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetUISoundAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Sound/UISound/{0}.mp3", assetName);
        }

        /// <summary>
        /// 获取UISound声音路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetLoadingBGAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/UI/UIResources/Loading/{0}.png", assetName);
        }

        /// <summary>
        /// 获取创建角色资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetCreateRoleAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Prefab/CreateRole/{0}.prefab", assetName);
        }

        /// <summary>
        /// 获取创建角色图片资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetCreateRoleImageAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/UI/UIResources/SelectRole/{0}.png", assetName);
        }

        /// <summary>
        /// 获取角色人物资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetRoleAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Prefab/Roles/Player/{0}.prefab", assetName);
        }

        /// <summary>
        /// 获取角色人物控制器资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetRoleControllerAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Prefab/Roles/Controller/{0}.controller", assetName);
        }

        /// <summary>
        /// 获取法宝资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetMagicAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Prefab/Equip/Trump/{0}.prefab", assetName);
        }

        /// <summary>
        /// 获取翅膀资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetWingAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Prefab/Equip/Wings/{0}.prefab", assetName);
        }

        /// <summary>
        /// 获取翅膀控制器资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetWingControllerAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Prefab/Equip/Wings/ControllerWing/{0}.controller", assetName);
        }

        /// <summary>
        /// 获取武器资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetWeaponAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Prefab/Equip/Weapon/{0}.prefab", assetName);
        }

        /// <summary>
        /// 获取小地图资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetSmallMapAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/UI/UIResources/SmallMap/{0}.png", assetName);
        }

        /// <summary>
        /// 获取坐骑资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetRideAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Prefab/Roles/Ride/{0}.prefab", assetName);
        }

        /// <summary>
        /// 获取技能特效资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetSkillEffectAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Effect/SkillEffect/{0}.prefab", assetName);
        }

        /// <summary>
        /// 获取技能特效资源路径
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static string GetBuffEffectAsset(string assetName)
        {
            return TextUtil.Format("Assets/DownLoad/Effect/BuffEffect/{0}.prefab", assetName);
        }
    }
}