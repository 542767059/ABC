using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// JobWeapon实体
    /// </summary>
    public partial class JobWeaponEntity : DataTableEntityBase
    {
        /// <summary>
        /// 职业编号
        /// </summary>
        public int JobId;

        /// <summary>
        /// 每个职业的武器资源序号
        /// </summary>
        public int WeaponId;

        /// <summary>
        /// 武器资源名称
        /// </summary>
        public string AssetName;

        /// <summary>
        /// 武器战力
        /// </summary>
        public int WeaponFighting;

    }
}
