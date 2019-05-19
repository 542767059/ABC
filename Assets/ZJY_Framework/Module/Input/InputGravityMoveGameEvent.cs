using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 输入重力移动事件
    /// </summary>
    public class InputGravityMoveGameEvent : GameEventBase
    {
        /// <summary>
        /// 输入重力移动事件编号
        /// </summary>
        public static readonly int EventId = typeof(InputGravityMoveGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 重力方向
        /// </summary>
        public MoveDir MoveDir
        {
            get;
            private set;
        }

        /// <summary>
        /// 速度
        /// </summary>
        public float Speed
        {
            get;
            private set;
        }


        /// <summary>
        /// 填充重力移动事件
        /// </summary>
        /// <param name="moveDir"></param>
        /// <returns></returns>
        public InputGravityMoveGameEvent Fill(MoveDir moveDir,float speed)
        {
            MoveDir = moveDir;
            Speed = speed;
            return this;
        }
    }
}
