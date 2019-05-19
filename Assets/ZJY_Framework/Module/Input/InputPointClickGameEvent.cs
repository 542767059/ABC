using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 输入点击事件
    /// </summary>
    public class InputPointClickGameEvent : GameEventBase
    {
        /// <summary>
        /// 输入点击事件编号
        /// </summary>
        public static readonly int EventId = typeof(InputPointClickGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 手势Id
        /// </summary>
        public int FingerId
        {
            get;
            private set;
        }

        /// <summary>
        /// 位置
        /// </summary>
        public Vector2 Postion
        {
            get;
            private set;
        }

        /// <summary>
        /// 填充输入点击事件
        /// </summary>
        /// <param name="fingerId"></param>
        /// <param name="postion"></param>
        /// <returns></returns>
        public InputPointClickGameEvent Fill(int fingerId, Vector2 postion)
        {
            FingerId = fingerId;
            Postion = postion;
            return this;
        }
    }
}
