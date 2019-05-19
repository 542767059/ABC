using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// JobWings实体
    /// </summary>
    public partial class JobWingsEntity : DataTableEntityBase
    {
        /// <summary>
        /// 职业编号
        /// </summary>
        public int JobId;

        /// <summary>
        /// 每个职业的翅膀资源序号
        /// </summary>
        public int WingId;

        /// <summary>
        /// 翅膀资源名称
        /// </summary>
        public string AssetName;

        /// <summary>
        /// 翅膀战力
        /// </summary>
        public int WingFighting;

    }
}
