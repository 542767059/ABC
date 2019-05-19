using System.Collections.Generic;

namespace ZJY.Framework
{
    /// <summary>
    /// 删除角色成功事件
    /// </summary>
    public class DeleateRoleSuccessGameEvent : GameEventBase
    {
        /// <summary>
        /// 返回选人事件事件编号
        /// </summary>
        public static readonly int EventId = typeof(DeleateRoleSuccessGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }
    }
}
