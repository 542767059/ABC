namespace ZJY.Framework
{
    /// <summary>
    /// 打断技能
    /// </summary>
    public interface IInterrupt
    {
        /// <summary>
        /// 打断技能处理
        /// </summary>
        /// <param name="entity">被打断技能的一方</param>
        void Handle(PlayerBase entity);
    }
}
