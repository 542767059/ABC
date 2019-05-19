using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 输入抬起事件
    /// </summary>
    public class InputPointUpGameEvent : GameEventBase
    {
        /// <summary>
        /// 输入抬起事件编号
        /// </summary>
        public static readonly int EventId = typeof(InputPointUpGameEvent).GetHashCode();

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
        /// 手势类型
        /// </summary>
        public FingerType FingerType
        {
            get;
            private set;
        }

        /// <summary>
        /// 填充输入抬起事件
        /// </summary>
        /// <param name="fingerId"></param>
        /// <param name="postion"></param>
        /// <param name="fingerType"></param>
        /// <returns></returns>
        public InputPointUpGameEvent Fill(int fingerId, Vector2 postion, FingerType fingerType)
        {
            FingerId = fingerId;
            Postion = postion;
            FingerType = fingerType;
            return this;
        }
    }
}
