namespace ZJY.Framework
{
    /// <summary>
    /// 资源更新失败事件
    /// </summary>
    public sealed class ResourceUpdateFailureGameEvent : GameEventBase
    {
        /// <summary>
        /// 资源更新失败事件编号
        /// </summary>
        public static readonly int EventId = typeof(ResourceUpdateFailureGameEvent).GetHashCode();

        /// <summary>
        /// 获取资源更新失败事件编号
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取资源名称
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取下载地址
        /// </summary>
        public string DownloadUri
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取已重试次数
        /// </summary>
        public int RetryCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取设定的重试次数
        /// </summary>
        public int TotalRetryCount
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
        /// 填充资源更新失败事件
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <param name="downloadUri">下载地址</param>
        /// <param name="retryCount">已重试次数</param>
        /// <param name="totalRetryCount">设定的重试次数</param>
        /// <param name="errorMessage">错误信息</param>
        /// <returns>资源更新失败事件</returns>
        public ResourceUpdateFailureGameEvent Fill(string name, string downloadUri, int retryCount, int totalRetryCount, string errorMessage)
        {
            Name = name;
            DownloadUri = downloadUri;
            RetryCount = retryCount;
            TotalRetryCount = totalRetryCount;
            ErrorMessage = errorMessage;

            return this;
        }
    }
}
