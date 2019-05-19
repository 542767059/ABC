using System.Collections.Generic;

namespace ZJY.Framework
{
    /// <summary>
    /// 登录游戏返回事件
    /// </summary>
    public class LogOnGameServerReturnGameEvent : GameEventBase
    {
        /// <summary>
        /// 登录游戏返回事件编号
        /// </summary>
        public static readonly int EventId = typeof(LogOnGameServerReturnGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 角色数量
        /// </summary>
        public int RoleCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 填充服务器返回登录信息
        /// </summary>
        /// <param name="roleCount"></param>
        /// <returns></returns>
        public LogOnGameServerReturnGameEvent Fill(int roleCount)
        {
            RoleCount = roleCount;
            return this;
        }
    }
}
