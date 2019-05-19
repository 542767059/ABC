namespace ZJY.Framework
{
    /// <summary>
    /// 加载数据表时加载依赖资源事件
    /// </summary>
    public sealed class LoadDataTableDependencyAssetGameEvent : GameEventBase
    {
        /// <summary>
        /// 加载数据表时加载依赖资源事件编号
        /// </summary>
        public static readonly int EventId = typeof(LoadDataTableDependencyAssetGameEvent).GetHashCode();

        /// <summary>
        /// 获取加载数据表时加载依赖资源事件编号
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
        /// 获取被加载的依赖资源名称
        /// </summary>
        public string DependencyAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取当前已加载依赖资源数量
        /// </summary>
        public int LoadedCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取总共加载依赖资源数量
        /// </summary>
        public int TotalCount
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
        /// 加载数据表时加载依赖资源事件
        /// </summary>
        /// <param name="dataTableAssetName">数据表资源名称</param>
        /// <param name="dependencyAssetName">被加载的依赖资源名称</param>
        /// <param name="loadedCount">当前已加载依赖资源数量</param>
        /// <param name="totalCount">总共加载依赖资源数量</param>
        /// <param name="userData">用户自定义数据</param>
        public LoadDataTableDependencyAssetGameEvent Fill(string dataTableAssetName, string dependencyAssetName, int loadedCount, int totalCount, object userData)
        {
            DataTableInfo loadDataTableInfo = (DataTableInfo)userData;
            UserData = loadDataTableInfo.UserData;
            DataTableName = loadDataTableInfo.DataTableName;
            DataTableAssetName = dataTableAssetName;
            DependencyAssetName = dependencyAssetName;
            LoadedCount = loadedCount;
            TotalCount = totalCount;

            return this;
        }
    }
}
