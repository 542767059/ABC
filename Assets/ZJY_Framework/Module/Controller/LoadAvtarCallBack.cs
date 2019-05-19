namespace ZJY.Framework
{
    /// <summary>
    /// 加载控制器资源成功事件
    /// </summary>
    /// <param name="controllerAssetName">控制器资源名称</param>
    /// <param name="asset">控制器资源</param>
    /// <param name="duration">加载持续时间</param>
    /// <param name="userData">用户自定义数据</param>
    public delegate void LoadControllerSuccessEvent(string controllerAssetName, UnityEngine.Object asset, float duration, object userData);

    /// <summary>
    /// 加载控制器资源失败事件
    /// </summary>
    /// <param name="controllerAssetName">控制器资源名称</param>
    /// <param name="errorMessage">错误信息</param>
    /// <param name="userData">用户自定义数据</param>
    public delegate void LoadControllerFailureEvent(string controllerAssetName, string errorMessage, object userData);

    /// <summary>
    /// 加载控制器资源更新事件
    /// </summary>
    /// <param name="controllerAssetName">控制器资源名称</param>
    /// <param name="progress">加载控制器进度</param>
    /// <param name="userData">用户自定义数据</param>
    public delegate void LoadControllerUpdateEvent(string controllerAssetName, float progress, object userData);

    /// <summary>
    /// 加载控制器时加载依赖资源事件
    /// </summary>
    /// <param name="controllerAssetName">控制器资源名称</param>
    /// <param name="dependencyAssetName">被加载的依赖资源名称</param>
    /// <param name="loadedCount">当前已加载依赖资源数量</param>
    /// <param name="totalCount">总共加载依赖资源数量</param>
    /// <param name="userData">用户自定义数据</param>
    public delegate void LoadControllerDependencyAssetEvent(string controllerAssetName, string dependencyAssetName, int loadedCount, int totalCount, object userData);
}
