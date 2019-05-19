namespace ZJY.Framework
{
    /// <summary>
    /// 网络连接成功事件
    /// </summary>
    public sealed class SocketConnectedGameEvent : GameEventBase
    {
        /// <summary>
        /// 连接成功事件编号
        /// </summary>
        public static readonly int EventId = typeof(SocketConnectedGameEvent).GetHashCode();

        /// <summary>
        /// 获取连接成功事件编号
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
        /// 填充网络连接成功事件
        /// </summary>
        /// <param name="socketTcpRoutine">socket</param>
        /// <returns>网络连接成功事件</returns>
        public SocketConnectedGameEvent Fill(SocketTcpRoutine socketTcpRoutine)
        {
            Socket = socketTcpRoutine;

            return this;
        }
    }
}
