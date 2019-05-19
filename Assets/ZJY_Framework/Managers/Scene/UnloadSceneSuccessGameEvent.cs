namespace ZJY.Framework
{
    /// <summary>
    /// 卸载场景成功事件
    /// </summary>
    public sealed class UnloadSceneSuccessGameEvent : GameEventBase
    {
        /// <summary>
        /// 加载场景成功事件编号
        /// </summary>
        public static readonly int EventId = typeof(UnloadSceneSuccessGameEvent).GetHashCode();

        /// <summary>
        /// 获取加载场景成功事件编号
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
        /// 填充卸载场景成功事件
        /// </summary>
        /// <param name="sceneAssetName">场景资源名称</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>卸载场景成功事件</returns>
        public UnloadSceneSuccessGameEvent Fill(string sceneAssetName, object userData)
        {
            SceneAssetName = sceneAssetName;
            UserData = userData;

            return this;
        }
    }
}
