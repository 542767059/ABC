using System;

namespace ZJY.Framework
{
    /// <summary>
    /// 显示实体更新事件
    /// </summary>
    public sealed class ShowEntityUpdateGameEvent : GameEventBase
    {
        /// <summary>
        /// 显示实体更新事件编号
        /// </summary>
        public static readonly int EventId = typeof(ShowEntityUpdateGameEvent).GetHashCode();

        /// <summary>
        /// 获取显示实体更新事件编号
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
        /// 获取显示实体进度
        /// </summary>
        public float Progress
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
        /// 填充显示实体更新事件
        /// </summary>
        /// <param name="entityId">实体编号</param>
        /// <param name="entityAssetName">实体资源名称</param>
        /// <param name="entityGroupName">实体组名称</param>
        /// <param name="entityLogicType">实体类型</param>
        /// <param name="progress">显示实体进度</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>显示实体更新事件</returns>
        public ShowEntityUpdateGameEvent Fill(int entityId, string entityAssetName, string entityGroupName, Type entityLogicType, float progress, object userData)
        {
            EntityId = entityId;
            EntityLogicType = entityLogicType;
            EntityAssetName = entityAssetName;
            EntityGroupName = entityGroupName;
            Progress = progress;
            UserData = userData;

            return this;
        }
    }
}
