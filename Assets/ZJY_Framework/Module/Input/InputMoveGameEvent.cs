using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 输入手势移动事件
    /// </summary>
    public class InputMoveGameEvent : GameEventBase
    {
        /// <summary>
        /// 输入手势移动事件编号
        /// </summary>
        public static readonly int EventId = typeof(InputMoveGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 手势方向
        /// </summary>
        public MoveDir MoveDir
        {
            get;
            private set;
        }

        /// <summary>
        /// 手势速度
        /// </summary>
        public float Speed
        {
            get;
            private set;
        }

        /// <summary>
        /// 填充手势移动事件
        /// </summary>
        /// <param name="moveDir"></param>
        /// <param name="speed">速度</param>
        /// <returns></returns>
        public InputMoveGameEvent Fill(MoveDir moveDir,float speed)
        {
            MoveDir = moveDir;
            Speed = speed;
            return this;
        }
    }
}
