namespace ZJY.Framework
{
    /// <summary>
    /// ILRuntime预加载完毕事件
    /// </summary>
    public class ILRuntimePreloadGameEvent : GameEventBase
    {
        /// <summary>
        /// 加载数据表成功事件编号
        /// </summary>
        public static readonly int EventId = typeof(ILRuntimePreloadGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取用户自定义数据
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取加载是否成功
        /// </summary>
        public bool Success
        {
            get;
            private set;
        }

        /// <summary>
        /// 填充ILRuntime预加载完毕事件
        /// </summary>
        /// <param name="success">是否成功</param>
        /// <param name="userData">用户数据</param>
        /// <returns></returns>
        public ILRuntimePreloadGameEvent Fill(bool success, object userData)
        {
            UserData = userData;
            Success = success;
            return this;
        }
    }
}
