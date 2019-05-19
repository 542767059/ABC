using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// ChapterXLSX实体
    /// </summary>
    public partial class ChapterXLSXEntity : DataTableEntityBase
    {
        /// <summary>
        /// 章名称
        /// </summary>
        public string ChapterName;

        /// <summary>
        /// 拥有关卡个数
        /// </summary>
        public int GameLevelCount;

        /// <summary>
        /// 背景图
        /// </summary>
        public string BG_Pic;

        /// <summary>
        /// Uvx
        /// </summary>
        public float Uvx;

        /// <summary>
        /// Uvy
        /// </summary>
        public float Uvy;

    }
}
