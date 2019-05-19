using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 改变技能指示器事件
    /// </summary>
    public class ChangeSkillAreaGameEvent : GameEventBase
    {
        /// <summary>
        /// 改变技能指示器事件事件编号
        /// </summary>
        public static readonly int EventId = typeof(ChangeSkillAreaGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 技能指示器位置
        /// </summary>
        public Vector2 Postion
        {
            get;
            private set;
        }

        public ChangeSkillAreaGameEvent Fill(Vector2 postion)
        {
            Postion = postion;

            return this;
        }
    }
}