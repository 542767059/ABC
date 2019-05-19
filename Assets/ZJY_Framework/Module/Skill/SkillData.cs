using System;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 技能数据
    /// </summary>
    [Serializable]
    public class SkillData
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
        /// 冷却时间
        /// </summary>
        public float CDTime;

        /// <summary>
        /// 施放距离
        /// </summary>
        public float Distance;

        /// <summary>
        /// 吟唱时间
        /// </summary>
        public float SingTime;

        /// <summary>
        /// 吟唱动作
        /// </summary>
        public string SingMotion;

        /// <summary>
        /// 吟唱特效
        /// </summary>
        public string SingEffect;




        /// <summary>
        /// 技能音效
        /// </summary>
        public string Sound;

        /// <summary>
        /// 目标上限
        /// </summary>
        public byte TargetCeiling;

        /// <summary>
        /// 技能伤害类型
        /// </summary>
        public SkillDmageType SkillDmageType;

        /// <summary>
        /// 是否单体攻击
        /// </summary>
        public bool IsSingle;

        /// <summary>
        /// 技能范围类型
        /// </summary>
        public SKillAreaType SKillAreaType;

        /// <summary>
        /// 范围长度/半径 
        /// </summary>
        public float Aoe_long;

        /// <summary>
        /// 范围宽度(矩形)
        /// </summary>
        public float Aoe_wide;

        /// <summary>
        /// 扇形角度
        /// </summary>
        public float Angle;

        /// <summary>
        /// 需要消耗的MP
        /// </summary>
        public int SpendMP;

        /// <summary>
        /// 技能特效持续时间
        /// </summary>
        public float Skill_effect_time;
        
        /// <summary>
        /// 伤害延迟时间
        /// </summary>
        public float HurtDealy;
        
        /// <summary>
        /// 增加的buffId
        /// </summary>
        public int[] AddBuffId;

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