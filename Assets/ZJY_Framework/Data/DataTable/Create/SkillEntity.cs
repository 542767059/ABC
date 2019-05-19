using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// Skill实体
    /// </summary>
    public partial class SkillEntity : DataTableEntityBase
    {
        /// <summary>
        /// 技能名称
        /// </summary>
        public string SkillName;

        /// <summary>
        /// 技能描述
        /// </summary>
        public string SkillDesc;

        /// <summary>
        /// 技能释放按钮图片
        /// </summary>
        public string SkillIcon;

        /// <summary>
        /// 技能状态机索引
        /// </summary>
        public int SkillIndex;

        /// <summary>
        /// 技能持续时间(秒的1000倍)
        /// </summary>
        public int SkillNeedTime;

        /// <summary>
        /// 特效名称
        /// </summary>
        public string Skill_Effect_Name;

        /// <summary>
        /// 特效持续时间
        /// </summary>
        public float Skill_Effect_Time;

        /// <summary>
        /// 技能声音编号
        /// </summary>
        public int SoundId;

        /// <summary>
        /// 技能最大等级
        /// </summary>
        public int LevelLimit;

        /// <summary>
        /// 是否物理攻击
        /// </summary>
        public int IsPhyAttack;

        /// <summary>
        /// 伤害目标数量
        /// </summary>
        public int AttackTargetCount;

        /// <summary>
        /// 此技能攻击攻击范围(米)
        /// </summary>
        public float AttackRange;

        /// <summary>
        /// 群攻的伤害判定半径
        /// </summary>
        public float AreaAttackRadius;

        /// <summary>
        /// 攻击动作发出多少秒后被攻击者才播放受伤效果
        /// </summary>
        public float ShowHurtEffectDelaySecond;

    }
}
