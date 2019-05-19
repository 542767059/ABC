

namespace ZJY.Framework
{
    /// <summary>
    /// 隐藏实体完成事件
    /// </summary>
    public sealed class HideEntityCompleteEventArgs : GameEventBase
    {
        /// <summary>
        /// 隐藏实体完成事件编号
        /// </summary>
        public static readonly int EventId = typeof(HideEntityCompleteEventArgs).GetHashCode();

        /// <summary>
        /// 获取隐藏实体完成事件编号
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
        /// 获取实体资源名称
        /// </summary>
        public string EntityAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取实体所属的实体组
        /// </summary>
        public EntityGroup EntityGroup
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
        /// 填充隐藏实体完成事件
        /// </summary>
        /// <param name="entityId">实体编号</param>
        /// <param name="entityAssetName">实体资源名称</param>
        /// <param name="entityGroup">实体所属的实体组</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>隐藏实体完成事件</returns>
        public HideEntityCompleteEventArgs Fill(int entityId, string entityAssetName, EntityGroup entityGroup, object userData)
        {
            EntityId = entityId;
            EntityAssetName = entityAssetName;
            EntityGroup = entityGroup;
            UserData = userData;

            return this;
        }
    }
}
