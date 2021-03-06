﻿
namespace ZJY.Framework
{
    /// <summary>
    /// 调试器激活窗口类型
    /// </summary>
    public enum DebuggerActiveWindowType
    {
        /// <summary>
        /// 自动（发布版本状态关闭，开发版本状态打开）
        /// </summary>
        Auto = 0,

        /// <summary>
        /// 关闭
        /// </summary>
        Close,

        /// <summary>
        /// 打开
        /// </summary>
        Open,
    }
}
