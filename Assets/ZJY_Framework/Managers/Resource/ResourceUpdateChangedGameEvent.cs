namespace ZJY.Framework
{
    /// <summary>
    /// 资源更新改变事件
    /// </summary>
    public sealed class ResourceUpdateChangedGameEvent : GameEventBase
    {
        /// <summary>
        /// 资源更新改变事件编号
        /// </summary>
        public static readonly int EventId = typeof(ResourceUpdateChangedGameEvent).GetHashCode();

        /// <summary>
        /// 获取资源更新改变事件编号
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
        /// 获取资源下载后存放路径
        /// </summary>
        public string DownloadPath
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
        /// 获取当前下载大小
        /// </summary>
        public int CurrentLength
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取压缩包大小
        /// </summary>
        public int ZipLength
        {
            get;
            private set;
        }


        /// <summary>
        /// 填充资源更新改变事件
        /// </summary>
        /// <param name="name">资源名称</param>
        /// <param name="downloadPath">资源下载后存放路径</param>
        /// <param name="downloadUri">资源下载地址</param>
        /// <param name="currentLength">当前下载大小</param>
        /// <param name="zipLength">压缩包大小</param>
        /// <returns>资源更新改变事件</returns>
        public ResourceUpdateChangedGameEvent Fill(string name, string downloadPath, string downloadUri, int currentLength, int zipLength)
        {
            Name = name;
            DownloadPath = downloadPath;
            DownloadUri = downloadUri;
            CurrentLength = currentLength;
            ZipLength = zipLength;

            return this;
        }
    }
}
