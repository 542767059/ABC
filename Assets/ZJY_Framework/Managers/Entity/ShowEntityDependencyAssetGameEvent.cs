using System;

namespace ZJY.Framework
{
    /// <summary>
    /// 显示实体时加载依赖资源事件
    /// </summary>
    public sealed class ShowEntityDependencyAssetGameEvent : GameEventBase
    {
        /// <summary>
        /// 显示实体时加载依赖资源事件编号
        /// </summary>
        public static readonly int EventId = typeof(ShowEntityDependencyAssetGameEvent).GetHashCode();

        /// <summary>
        /// 获取显示实体时加载依赖资源事件编号
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
        /// 获取被加载的依赖资源名称
        /// </summary>
        public string DependencyAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取当前已加载依赖资源数量
        /// </summary>
        public int LoadedCount
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取总共加载依赖资源数量
        /// </summary>
        public int TotalCount
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
        /// 填充显示实体时加载依赖资源事件
        /// </summary>
        /// <param name="entityId">实体编号</param>
        /// <param name="entityAssetName">实体资源名称</param>
        /// <param name="entityGroupName">实体组名称</param>
        /// <param name="entityLogicType">实体类型</param>
        /// <param name="dependencyAssetName">被加载的依赖资源名称</param>
        /// <param name="loadedCount">当前已加载依赖资源数量</param>
        /// <param name="totalCount">总共加载依赖资源数量</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>显示实体时加载依赖资源事件</returns>
        public ShowEntityDependencyAssetGameEvent Fill(int entityId, string entityAssetName, string entityGroupName, Type entityLogicType, string dependencyAssetName, int loadedCount, int totalCount, object userData)
        {
            EntityId = entityId;
            EntityLogicType = entityLogicType;
            EntityAssetName = entityAssetName;
            EntityGroupName = entityGroupName;
            DependencyAssetName = dependencyAssetName;
            LoadedCount = loadedCount;
            TotalCount = totalCount;
            UserData = userData;

            return this;
        }
    }
}
