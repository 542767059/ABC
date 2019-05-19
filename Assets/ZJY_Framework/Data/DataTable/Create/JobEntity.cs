using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// Job实体
    /// </summary>
    public partial class JobEntity : DataTableEntityBase
    {
        /// <summary>
        /// 职业名称
        /// </summary>
        public string Name;

        /// <summary>
        /// 创建角色资源名称
        /// </summary>
        public string CreateRoleAssetName;

        /// <summary>
        /// 资源名称
        /// </summary>
        public string AssetName;

        /// <summary>
        /// 性别(0男  1女)
        /// </summary>
        public int Sex;

        /// <summary>
        /// 职业图标未选中资源
        /// </summary>
        public string HeadNotSelectAssetName;

        /// <summary>
        /// 职业图标选中资源
        /// </summary>
        public string HeadSelectAssetName;

        /// <summary>
        /// 职业图片描述资源
        /// </summary>
        public string DescImageAssetName;

        /// <summary>
        /// 职业总描述资源
        /// </summary>
        public string DescAllAssetName;

        /// <summary>
        /// 职业具体描述资源
        /// </summary>
        public string DescSpecificAssetName;

        /// <summary>
        /// 系数---攻击
        /// </summary>
        public int Attack;

        /// <summary>
        /// 系数--防御
        /// </summary>
        public int Defense;

        /// <summary>
        /// 系数--命中率
        /// </summary>
        public int Hit;

        /// <summary>
        /// 系数--闪避率
        /// </summary>
        public int Dodge;

        /// <summary>
        /// 系数--暴击率
        /// </summary>
        public int Cri;

        /// <summary>
        /// 系数--抗性
        /// </summary>
        public int Res;

        /// <summary>
        /// 使用的物理攻击Id
        /// </summary>
        public string UsedPhyAttackIds;

        /// <summary>
        /// 使用的技能Id
        /// </summary>
        public string UsedSkillIds;

        /// <summary>
        /// 角色动画控制器
        /// </summary>
        public string RoleController;

        /// <summary>
        /// 武器挂点数量
        /// </summary>
        public int WeaponPointCount;

        /// <summary>
        /// 武器挂点1
        /// </summary>
        public string WeaponPoint1;

        /// <summary>
        /// 武器挂点2
        /// </summary>
        public string WeaponPoint2;

        /// <summary>
        /// 武器挂点3
        /// </summary>
        public string WeaponPoint3;

        /// <summary>
        /// 武器挂点4
        /// </summary>
        public string WeaponPoint4;

        /// <summary>
        /// 翅膀挂点
        /// </summary>
        public string WingPoint;

        /// <summary>
        /// 翅膀控制器
        /// </summary>
        public string WingController;

        /// <summary>
        /// 法宝挂点
        /// </summary>
        public string TrumpPoint;

    }
}
