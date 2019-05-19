using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 日志工具
    /// </summary>
    public static class Log
    {
        #region Info 打印信息日志 
        /// <summary>
        /// 打印信息日志
        /// </summary>
        /// <param name="format">日志内容</param>
        [Conditional("ENABLE_LOG")]
        public static void Info(string message)
        {
            UnityEngine.Debug.Log(message);
        }

        /// <summary>
        /// 打印信息日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="arg0">日志参数 0</param>
        [Conditional("ENABLE_LOG")]
        public static void Info(string format, object arg0)
        {
            UnityEngine.Debug.Log(TextUtil.Format(format, arg0));
        }

        /// <summary>
        /// 打印信息日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="arg0">日志参数 0</param>
        /// <param name="arg1">日志参数 1</param>
        [Conditional("ENABLE_LOG")]
        public static void Info(string format, object arg0, object arg1)
        {
            UnityEngine.Debug.Log(TextUtil.Format(format, arg0, arg1));
        }

        /// <summary>
        /// 打印信息日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="arg0">日志参数 0</param>
        /// <param name="arg1">日志参数 1</param>
        /// <param name="arg2">日志参数 2</param>
        [Conditional("ENABLE_LOG")]
        public static void Info(string format, object arg0, object arg1, object arg2)
        {
            UnityEngine.Debug.Log(TextUtil.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// 打印信息日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="args">日志参数 0</param>
        [Conditional("ENABLE_LOG")]
        public static void Info(string format, params object[] args)
        {
            UnityEngine.Debug.Log(TextUtil.Format(format, args));
        }
        #endregion

        #region Warning 打印警告日志 
        /// <summary>
        /// 打印警告日志
        /// </summary>
        /// <param name="format">日志内容</param>
        [Conditional("ENABLE_LOG")]
        public static void Warning(string message)
        {
            UnityEngine.Debug.LogWarning(message);
        }

        /// <summary>
        /// 打印警告日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="arg0">日志参数 0</param>
        [Conditional("ENABLE_LOG")]
        public static void Warning(string format, object arg0)
        {
            UnityEngine.Debug.LogWarning(TextUtil.Format(format, arg0));
        }

        /// <summary>
        /// 打印警告日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="arg0">日志参数 0</param>
        /// <param name="arg1">日志参数 1</param>
        [Conditional("ENABLE_LOG")]
        public static void Warning(string format, object arg0, object arg1)
        {
            UnityEngine.Debug.LogWarning(TextUtil.Format(format, arg0, arg1));
        }

        /// <summary>
        /// 打印警告日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="arg0">日志参数 0</param>
        /// <param name="arg1">日志参数 1</param>
        /// <param name="arg2">日志参数 2</param>
        [Conditional("ENABLE_LOG")]
        public static void Warning(string format, object arg0, object arg1, object arg2)
        {
            UnityEngine.Debug.LogWarning(TextUtil.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// 打印警告日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="args">日志参数 0</param>
        [Conditional("ENABLE_LOG")]
        public static void Warning(string format, params object[] args)
        {
            UnityEngine.Debug.LogWarning(TextUtil.Format(format, args));
        }
        #endregion

        #region Error 打印错误日志 
        /// <summary>
        /// 打印错误日志
        /// </summary>
        /// <param name="format">日志内容</param>
        [Conditional("ENABLE_LOG")]
        public static void Error(string message)
        {
            UnityEngine.Debug.LogError(message);
        }

        /// <summary>
        /// 打印错误日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="arg0">日志参数 0</param>
        [Conditional("ENABLE_LOG")]
        public static void Error(string format, object arg0)
        {
            UnityEngine.Debug.LogError(TextUtil.Format(format, arg0));
        }

        /// <summary>
        /// 打印错误日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="arg0">日志参数 0</param>
        /// <param name="arg1">日志参数 1</param>
        [Conditional("ENABLE_LOG")]
        public static void Error(string format, object arg0, object arg1)
        {
            UnityEngine.Debug.LogError(TextUtil.Format(format, arg0, arg1));
        }

        /// <summary>
        /// 打印错误日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="arg0">日志参数 0</param>
        /// <param name="arg1">日志参数 1</param>
        /// <param name="arg2">日志参数 2</param>
        [Conditional("ENABLE_LOG")]
        public static void Error(string format, object arg0, object arg1, object arg2)
        {
            UnityEngine.Debug.LogError(TextUtil.Format(format, arg0, arg1, arg2));
        }

        /// <summary>
        /// 打印错误日志
        /// </summary>
        /// <param name="format">日志格式</param>
        /// <param name="args">日志参数 0</param>
        [Conditional("ENABLE_LOG")]
        public static void Error(string format, params object[] args)
        {
            UnityEngine.Debug.LogError(TextUtil.Format(format, args));
        }
        #endregion
    }
}