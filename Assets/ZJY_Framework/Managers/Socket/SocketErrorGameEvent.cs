namespace ZJY.Framework
{
    /// <summary>
    /// 网络错误事件
    /// </summary>
    public sealed class SocketErrorGameEvent : GameEventBase
    {
        /// <summary>
        /// 连接错误事件编号
        /// </summary>
        public static readonly int EventId = typeof(SocketErrorGameEvent).GetHashCode();

        /// <summary>
        /// 获取连接错误事件编号
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
        /// 获取错误码
        /// </summary>
        public NetworkErrorCode ErrorCode
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取错误信息
        /// </summary>
        public string ErrorMessage
        {
            get;
            private set;
        }


        /// <summary>
        /// 填充网络错误事件
        /// </summary>
        /// <param name="socketTcpRoutine">Socket</param>
        /// <param name="errorCode">获取错误码</param>
        /// <param name="errorMessage">错误信息</param>
        /// <returns>网络错误事件</returns>
        public SocketErrorGameEvent Fill(SocketTcpRoutine socketTcpRoutine, NetworkErrorCode errorCode,string errorMessage)
        {
            Socket = socketTcpRoutine;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;

            return this;
        }
    }
}
