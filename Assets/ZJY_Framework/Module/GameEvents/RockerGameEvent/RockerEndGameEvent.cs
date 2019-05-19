
namespace ZJY.Framework
{
    /// <summary>
    /// 遥感结束事件编号
    /// </summary>
    public class RockerEndGameEvent : GameEventBase
    {
        /// <summary>
        /// 遥感结束事件编号
        /// </summary>
        public static readonly int EventId = typeof(RockerEndGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }
    }
}