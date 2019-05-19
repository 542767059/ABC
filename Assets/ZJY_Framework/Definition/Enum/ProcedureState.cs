namespace ZJY.Framework
{
    /// <summary>
    /// 流程状态
    /// </summary>
    public enum ProcedureState
    {
        /// <summary>
        /// 启动
        /// </summary>
        Launch = 0,
        /// <summary>
        /// Splash动画
        /// </summary>
        ProcedureSplash = 1,
        /// <summary>
        /// 检查更新
        /// </summary>
        CheckVersion = 2,
        /// <summary>
        /// 预加载
        /// </summary>
        Preload = 3,
        /// <summary>
        /// 切换场景
        /// </summary>
        ChangeScene = 4,
        /// <summary>
        /// 登录
        /// </summary>
        LogOn = 5,
        /// <summary>
        /// 选人
        /// </summary>
        SelectRole = 6,
        /// <summary>
        /// 进入游戏
        /// </summary>
        EnterGame = 7,
        /// <summary>
        /// 世界地图
        /// </summary>
        WorldMap = 8,
        /// <summary>
        /// 游戏关卡
        /// </summary>
        GameLevel = 9
    }
}
