using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 输入靠近远离事件
    /// </summary>
    public class InputZoomGameEvent : GameEventBase
    {
        /// <summary>
        /// 输入变换大小事件编号
        /// </summary>
        public static readonly int EventId = typeof(InputZoomGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }
        
        /// <summary>
        /// 靠近远离
        /// </summary>
        public ZoomType ZoomType
        {
            get;
            private set;
        }

        /// <summary>
        /// 填充输入靠近远离事件
        /// </summary>
        /// <param name="zoomType"></param>
        /// <returns></returns>
        public InputZoomGameEvent Fill(ZoomType zoomType)
        {
            ZoomType = zoomType;
            return this;
        }
    }
}
