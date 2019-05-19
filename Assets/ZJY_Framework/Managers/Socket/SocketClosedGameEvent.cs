namespace ZJY.Framework { 
    /// <summary>
    /// 网络连接关闭事件
    /// </summary>
    public sealed class SocketClosedGameEvent : GameEventBase
    {
        /// <summary>
        /// 连接成功事件编号
        /// </summary>
        public static readonly int EventId = typeof(SocketClosedGameEvent).GetHashCode();

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
        public SocketTcpRoutine SocketTcpRoutine
        {
            get;
            private set;
        }



        /// <summary>
        /// 填充网络连接关闭事件
        /// </summary>
        /// <param name="socketTcpRoutine">socket</param>
        /// <returns>网络连接关闭事件</returns>
        public SocketClosedGameEvent Fill(SocketTcpRoutine socketTcpRoutine)
        {
            SocketTcpRoutine = socketTcpRoutine;

            return this;
        }
    }
}
