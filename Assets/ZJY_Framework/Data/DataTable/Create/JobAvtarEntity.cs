using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// JobAvtar实体
    /// </summary>
    public partial class JobAvtarEntity : DataTableEntityBase
    {
        /// <summary>
        /// 职业编号
        /// </summary>
        public int JobId;

        /// <summary>
        /// 每个职业的换装资源序号
        /// </summary>
        public int AvtarId;

        /// <summary>
        /// 换装资源名称
        /// </summary>
        public string AssetName;

    }
}
