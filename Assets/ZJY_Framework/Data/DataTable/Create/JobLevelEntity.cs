using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// JobLevel实体
    /// </summary>
    public partial class JobLevelEntity : DataTableEntityBase
    {
        /// <summary>
        /// 等级
        /// </summary>
        public int Level;

        /// <summary>
        /// 从本级升到下一级所需经验
        /// </summary>
        public int NeedExp;

        /// <summary>
        /// 体力
        /// </summary>
        public int Energy;

        /// <summary>
        /// 基础血量
        /// </summary>
        public int HP;

        /// <summary>
        /// 基础魔法值
        /// </summary>
        public int MP;

        /// <summary>
        /// 攻击
        /// </summary>
        public int Attack;

        /// <summary>
        /// 防御
        /// </summary>
        public int Defense;

        /// <summary>
        /// 命中
        /// </summary>
        public int Hit;

        /// <summary>
        /// 闪避
        /// </summary>
        public int Dodge;

        /// <summary>
        /// 暴击
        /// </summary>
        public int Cri;

        /// <summary>
        /// 抗性
        /// </summary>
        public int Res;

    }
}
