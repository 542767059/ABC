namespace ZJY.Framework
{
    /// <summary>
    /// 用户自定义网络错误事件
    /// </summary>
    public sealed class SocketCustomErrorGameEvent : GameEventBase
    {
        /// <summary>
        /// 用户自定义网络错误事件编号
        /// </summary>
        public static readonly int EventId = typeof(SocketCustomErrorGameEvent).GetHashCode();

        /// <summary>
        /// 获取用户自定义网络错误事件编号
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取网络频道
        /// </summary>
        public SocketTcpRoutine Socket
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取用户自定义错误数据
        /// </summary>
        public object CustomErrorData
        {
            get;
            private set;
        }



        /// <summary>
        /// 填充用户自定义网络错误事件
        /// </summary>
        /// <param name="socketTcpRoutine">Socket</param>
        /// <param name="customErrorData">用户自定义网络错误</param>
        /// <returns>用户自定义网络错误事件</returns>
        public SocketCustomErrorGameEvent Fill(SocketTcpRoutine socketTcpRoutine, object customErrorData)
        {
            Socket = socketTcpRoutine;
            CustomErrorData = customErrorData;

            return this;
        }
    }
}
