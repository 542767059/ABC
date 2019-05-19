namespace ZJY.Framework
{
    /// <summary>
    /// 卸载场景失败事件
    /// </summary>
    public sealed class UnloadSceneFailureGameEvent : GameEventBase
    {
        /// <summary>
        /// 加载场景失败事件编号
        /// </summary>
        public static readonly int EventId = typeof(UnloadSceneFailureGameEvent).GetHashCode();

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
        /// 获取用户自定义数据
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }

        /// <summary>
        /// 填充卸载场景失败事件
        /// </summary>
        /// <param name="sceneAssetName">场景资源名称</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>卸载场景失败事件</returns>
        public UnloadSceneFailureGameEvent Fill(string sceneAssetName, object userData)
        {
            SceneAssetName = sceneAssetName;
            UserData = userData;

            return this;
        }
    }
}
