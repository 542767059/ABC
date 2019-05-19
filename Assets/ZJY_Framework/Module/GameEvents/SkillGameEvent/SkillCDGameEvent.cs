using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 技能冷却事件
    /// </summary>
    public class SkillCDGameEvent : GameEventBase
    {
        /// <summary>
        /// 技能冷却事件编号
        /// </summary>
        public static readonly int EventId = typeof(SkillCDGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// CD时间
        /// </summary>
        public float? CD
        {
            get;
            private set;
        }

        /// <summary>
        /// 技能Id
        /// </summary>
        public int SkillId
        {
            get;
            private set;
        }

        public SkillCDGameEvent Fill(int  skillId, float?  cdtime)
        {
            SkillId = skillId;
            CD = cdtime;
            return this;
        }
    }
}