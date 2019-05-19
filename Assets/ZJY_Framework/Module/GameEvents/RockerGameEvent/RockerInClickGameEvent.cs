using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 遥感中心点点击事件
    /// </summary>
    public class RockerInClickGameEvent : GameEventBase
    {
        /// <summary>
        /// 遥感中心点点击事件编号
        /// </summary>
        public static readonly int EventId = typeof(RockerInClickGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }
    }
}
