namespace Hotfix
{
    /// <summary>
    /// 加载表格成功事件
    /// </summary>
    /// <param name="dataTableAssetName">数据表资源名称</param>
    /// <param name="duration">加载持续时间</param>
    /// <param name="userData">用户自定义数据</param>
    public delegate void LoadDataTableSuccessEvent(string dataTableAssetName, float duration, object userData);

    /// <summary>
    /// 加载表格失败事件
    /// </summary>
    /// <param name="dataTableAssetName">数据表资源名称</param>
    /// <param name = "errorMessage" > 错误信息 </ param >
    /// <param name="userData">用户自定义数据</param>
    public delegate void LoadDataTableFailureEvent(string dataTableAssetName, string errorMessage, object userData);

    /// <summary>
    /// 加载表格更新事件
    /// </summary>
    /// <param name="dataTableAssetName">数据表资源名称</param>
    /// <param name="progress">加载数据表进度</param>
    /// <param name="userData">用户自定义数据</param>
    public delegate void LoadDataTableUpdateEvent(string dataTableAssetName, float progress, object userData);

}
