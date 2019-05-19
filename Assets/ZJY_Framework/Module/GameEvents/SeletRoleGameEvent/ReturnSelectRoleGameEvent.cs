using System.Collections.Generic;

namespace ZJY.Framework
{
    /// <summary>
    /// 返回选人事件
    /// </summary>
    public class ReturnSelectRoleGameEvent : GameEventBase
    {
        /// <summary>
        /// 返回选人事件事件编号
        /// </summary>
        public static readonly int EventId = typeof(ReturnSelectRoleGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }
    }
}
