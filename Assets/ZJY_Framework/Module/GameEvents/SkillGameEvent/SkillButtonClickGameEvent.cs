using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 技能按钮点击事件
    /// </summary>
    public class SkillButtonClickGameEvent : GameEventBase
    {
        /// <summary>
        /// 技能按钮点击事件编号
        /// </summary>
        public static readonly int EventId = typeof(SkillButtonClickGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 技能位置
        /// </summary>
        public Vector2 Postion
        {
            get;
            private set;
        }

        /// <summary>
        /// 是否普通点击技能
        /// </summary>
        public bool IsNormalClick
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

        public SkillButtonClickGameEvent Fill(int skillId,Vector2 pos,bool isNormalClick)
        {
            SkillId = skillId;
            Postion = pos;
            IsNormalClick = isNormalClick;
            return this;
        }
    }
}