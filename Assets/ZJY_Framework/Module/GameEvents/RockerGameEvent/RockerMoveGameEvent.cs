using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 遥感移动事件
    /// </summary>
    public class RockerMoveGameEvent : GameEventBase
    {
        /// <summary>
        /// 遥感移动事件
        /// </summary>
        public static readonly int EventId = typeof(RockerMoveGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }
        
        /// <summary>
        /// 移动的位置
        /// </summary>
        public Vector2 Postion
        {
            get;
            private set;
        }

        /// <summary>
        /// 填充遥感移动事件
        /// </summary>
        /// <param name="postion"></param>
        /// <returns></returns>
        public RockerMoveGameEvent Fill(Vector2 postion)
        {
            Postion = postion;
            return this;
        }
    }
}
