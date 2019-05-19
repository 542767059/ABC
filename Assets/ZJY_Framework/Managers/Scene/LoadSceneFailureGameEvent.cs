namespace ZJY.Framework
{
    /// <summary>
    /// 加载场景失败事件
    /// </summary>
    public sealed class LoadSceneFailureGameEvent : GameEventBase
    {
        /// <summary>
        /// 加载场景失败事件编号
        /// </summary>
        public static readonly int EventId = typeof(LoadSceneFailureGameEvent).GetHashCode();

        /// <summary>
        /// 获取加载场景失败事件编号
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取场景资源名称
        /// </summary>
        public string SceneAssetName
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
        /// 获取用户自定义数据
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }


        /// <summary>
        /// 填充加载场景更新事件
        /// </summary>
        /// <param name="sceneAssetName">场景资源名称</param>
        /// <param name="errorMessage">加载场景进度</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>加载场景更新事件</returns>
        public LoadSceneFailureGameEvent Fill(string sceneAssetName, string errorMessage, object userData)
        {
            SceneAssetName = sceneAssetName;
            ErrorMessage = errorMessage;
            UserData = userData;

            return this;
        }
    }
}
