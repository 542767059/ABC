using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// Ride实体
    /// </summary>
    public partial class RideEntity : DataTableEntityBase
    {
        /// <summary>
        /// 坐骑资源名称
        /// </summary>
        public string AssetName;

        /// <summary>
        /// 骑乘方式(0站立 1坐着)
        /// </summary>
        public int RideType;

        /// <summary>
        /// 挂点
        /// </summary>
        public string Point;

        /// <summary>
        /// 坐骑名称
        /// </summary>
        public string RideName;

        /// <summary>
        /// 坐骑战力
        /// </summary>
        public int RideFighting;

    }
}
