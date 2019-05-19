using System;

namespace ZJY.Framework
{
    /// <summary>
    /// 显示实体成功事件
    /// </summary>
    public sealed class ShowEntitySuccessGameEvent : GameEventBase
    {
        /// <summary>
        /// 显示实体成功事件编号
        /// </summary>
        public static readonly int EventId = typeof(ShowEntitySuccessGameEvent).GetHashCode();

        /// <summary>
        /// 获取显示实体成功事件编号
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取显示成功的实体
        /// </summary>
        public EntityBase Entity
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取加载持续时间
        /// </summary>
        public float Duration
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
        /// 填充显示实体成功事件
        /// </summary>
        /// <param name="entity">加载成功的实体</param>
        /// <param name="duration">加载持续时间</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>显示实体成功事件</returns>
        public ShowEntitySuccessGameEvent Fill(EntityBase entity, float duration, object userData)
        {
            Entity = entity;
            Duration = duration;
            UserData = userData;

            return this;
        }
    }
}
