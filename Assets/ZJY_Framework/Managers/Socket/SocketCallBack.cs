namespace ZJY.Framework
{
    /// <summary>
    /// 网络连接成功事件
    /// </summary>
    /// <param name="socketTcpRoutine">Socket</param>
    public delegate void SocketConnectedEvent(SocketTcpRoutine socketTcpRoutine);

    /// <summary>
    /// 网络连接关闭事件
    /// </summary>
    /// <param name="socketTcpRoutine">Socket</param>
    public delegate void SocketClosedEvent(SocketTcpRoutine socketTcpRoutine);

    /// <summary>
    /// 网络错误事件
    /// </summary>
    /// <param name="socketTcpRoutine">Socket</param>
    /// <param name="errorCode">错误码</param>
    /// <param name="errorMessage">错误信息</param>
    public delegate void SocketErrorEvent(SocketTcpRoutine socketTcpRoutine, NetworkErrorCode errorCode, string errorMessage);

    /// <summary>
    /// 用户自定义网络错误事件
    /// </summary>
    /// <param name="networkChannel">网络频道</param>
    /// <param name="customErrorData">用户自定义错误数据</param>
    public delegate void SocketCustomErrorEvent(SocketTcpRoutine socketTcpRoutine, object customErrorData);

}
