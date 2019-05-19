using System;

namespace ZJY.Framework
{
    /// <summary>
    /// 显示实体失败事件
    /// </summary>
    public sealed class ShowEntityFailureGameEvent : GameEventBase
    {
        /// <summary>
        /// 显示实体失败事件编号
        /// </summary>
        public static readonly int EventId = typeof(ShowEntityFailureGameEvent).GetHashCode();

        /// <summary>
        /// 获取显示实体失败事件编号
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取实体编号
        /// </summary>
        public int EntityId
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取实体逻辑类型
        /// </summary>
        public Type EntityLogicType
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取实体资源名称
        /// </summary>
        public string EntityAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取实体组名称
        /// </summary>
        public string EntityGroupName
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
        /// 填充显示实体失败事件
        /// </summary>
        /// <param name="entityId">实体编号</param>
        /// <param name="entityAssetName">实体资源名称</param>
        /// <param name="entityGroupName">实体组名称</param>
        /// <param name="entityLogicType">实体类型</param>
        /// <param name="errorMessage">错误信息</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>显示实体失败事件</returns>
        public ShowEntityFailureGameEvent Fill(int entityId, string entityAssetName, string entityGroupName,Type entityLogicType, string errorMessage, object userData)
        {
            EntityLogicType = entityLogicType;
            EntityId = entityId;
            EntityAssetName = entityAssetName;
            EntityGroupName = entityGroupName;
            ErrorMessage = errorMessage;
            UserData = userData;

            return this;
        }
    }
}
