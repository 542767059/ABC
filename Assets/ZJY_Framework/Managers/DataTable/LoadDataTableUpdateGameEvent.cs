namespace ZJY.Framework
{
    /// <summary>
    /// 加载数据表更新事件
    /// </summary>
    public sealed class LoadDataTableUpdateGameEvent : GameEventBase
    {
        /// <summary>
        /// 加载数据表更新事件编号
        /// </summary>
        public static readonly int EventId = typeof(LoadDataTableUpdateGameEvent).GetHashCode();

        /// <summary>
        /// 获取加载数据表更新事件编号
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取数据表名称
        /// </summary>
        public string DataTableName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数据表资源名称
        /// </summary>
        public string DataTableAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取加载数据表进度
        /// </summary>
        public float Progress
        {
            get;
            private set;
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
        /// 填充加载表格更新事件
        /// </summary>
        /// <param name="dataTableAssetName">数据表资源名称</param>
        /// <param name="progress">加载数据表进度</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>加载数据表更新事件</returns>
        public LoadDataTableUpdateGameEvent Fill(string dataTableAssetName, float progress, object userData)
        {
            DataTableInfo loadDataTableInfo = (DataTableInfo)userData;
            UserData = loadDataTableInfo.UserData;
            DataTableName = loadDataTableInfo.DataTableName;
            DataTableAssetName = dataTableAssetName;
            Progress = progress;

            return this;
        }
    }
}
