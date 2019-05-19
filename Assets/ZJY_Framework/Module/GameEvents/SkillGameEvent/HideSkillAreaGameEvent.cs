using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 取消技能指示器事件
    /// </summary>
    public class HideSkillAreaGameEvent : GameEventBase
    {
        /// <summary>
        /// 取消技能指示器事件编号
        /// </summary>
        public static readonly int EventId = typeof(HideSkillAreaGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }
    }
}