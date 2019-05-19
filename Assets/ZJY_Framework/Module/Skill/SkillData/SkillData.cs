using System;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 技能数据
    /// </summary>
    [Serializable]
    public partial class SkillData
    {
        /// <summary>
        /// 技能Id
        /// </summary>
        public int SkillId;

        /// <summary>
        /// 技能名称
        /// </summary>
        public string SkillName;

        /// <summary>
        /// 技能说明
        /// </summary>
        public string Des;

        /// <summary>
        /// 技能图标icon
        /// </summary>
        public string SkillIcon;

        /// <summary>
        /// 技能状态机索引(用于改变状态机值)
        /// </summary>
        public int SkillAnimatorIndex;

        /// <summary>
        /// 是否平A(0不是  1是)
        /// </summary>
        public int IsNormalAttack;


        /// <summary>
        /// 是否连续技
        /// </summary>
        public bool IsCombo;
        

        /// <summary>
        /// 目标上限
        /// </summary>
        public byte TargetCeiling;

        /// <summary>
        /// 技能伤害类型
        /// </summary>
        public SkillDmageType SkillDmageType;

        

        

        /// <summary>
        /// 技能加成系数[伤害,百分比] 
        /// </summary>
        public int[] Skill_ratio;

        /// <summary>
        /// 是否需要目标
        /// </summary>
        public bool  NeedTarget;

        /// <summary>
        /// 选择目标规则
        /// </summary>
        public ChoseTarget ChoseTarget;
    }
}