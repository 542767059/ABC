using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// 加载数据表失败事件
    /// </summary>
    public class LoadDataTableFailureGameEvent : GameEventBase
    {
        /// <summary>
        /// 加载数据表失败事件编号
        /// </summary>
        public static readonly int EventId = typeof(LoadDataTableFailureGameEvent).GetHashCode();

        /// <summary>
        /// 获取加载数据表失败事件编号
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
        /// 填充加载表格失败事件
        /// </summary>
        /// <param name="dataTableAssetName">数据表资源名称</param>
        /// <param name="errorMessage">错误信息</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>加载数据表成功事件</returns>
        public LoadDataTableFailureGameEvent Fill(string dataTableAssetName, string errorMessage, object userData)
        {
            DataTableInfo loadDataTableInfo = (DataTableInfo)userData;
            UserData = loadDataTableInfo.UserData;
            DataTableName = loadDataTableInfo.DataTableName;
            DataTableAssetName = dataTableAssetName;
            ErrorMessage = errorMessage;

            return this;
        }
    }
}