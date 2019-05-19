using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// Scene实体
    /// </summary>
    public partial class SceneEntity : DataTableEntityBase
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc;

        /// <summary>
        /// 资源名称
        /// </summary>
        public string AssetName;

        /// <summary>
        /// 背景音乐编号
        /// </summary>
        public int BackgroundMusicId;

        /// <summary>
        /// 传送点
        /// </summary>
        public string RoleBirthPos;

        /// <summary>
        /// 小地图图片
        /// </summary>
        public string SmallMapImageAssets;

        /// <summary>
        /// 小地图资源大小
        /// </summary>
        public int SmallMapSize;

    }
}
