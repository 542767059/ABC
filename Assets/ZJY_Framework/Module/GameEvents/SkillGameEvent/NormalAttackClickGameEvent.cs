using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 普攻点击事件编号
    /// </summary>
    public class NormalAttackClickGameEvent : GameEventBase
    {
        /// <summary>
        /// 普攻点击事件编号
        /// </summary>
        public static readonly int EventId = typeof(NormalAttackClickGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }
    }
}