namespace Hotfix
{
    /// <summary>
    /// 加载数据表成功事件
    /// </summary>
    public class LoadDataTableSuccessGameEvent : GameEventBase
    {
        /// <summary>
        /// 加载数据表成功事件编号
        /// </summary>
        public static readonly int EventId = typeof(LoadDataTableSuccessGameEvent).GetHashCode();

        /// <summary>
        /// 获取加载数据表成功事件编号
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取数据表名称。
        /// </summary>
        public string DataTableName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取数据表资源名称。
        /// </summary>
        public string DataTableAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取加载持续时间。
        /// </summary>
        public float Duration
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取用户自定义数据。
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }

        /// <summary>
        /// 填充加载数据表成功事件
        /// </summary>
        /// <param name="dataTableAssetName">数据表资源名称</param>
        /// <param name="duration">加载持续时间</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>加载数据表成功事件</returns>
        public LoadDataTableSuccessGameEvent Fill(string dataTableAssetName, float duration, object userData)
        {
            DataTableInfo loadDataTableInfo = (DataTableInfo)userData;
            UserData = loadDataTableInfo.UserData;
            DataTableName = loadDataTableInfo.DataTableName;
            DataTableAssetName = dataTableAssetName;
            Duration = duration;
            

            return this;
        }
    }
}