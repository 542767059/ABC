using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 显示技能指示器事件
    /// </summary>
    public class ShowSkillAreaGameEvent : GameEventBase
    {
        /// <summary>
        /// 显示技能指示器事件事件编号
        /// </summary>
        public static readonly int EventId = typeof(ShowSkillAreaGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public SKillAreaType SKillAreaType
        {
            get;
            private set;
        }

        public ShowSkillAreaGameEvent Fill(SKillAreaType sKillAreaType)
        {
            SKillAreaType = sKillAreaType;
            return this;
        }
    }
}