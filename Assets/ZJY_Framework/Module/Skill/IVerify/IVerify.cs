namespace ZJY.Framework
{
    public interface IVerify
    {
        /// <summary>
        /// 合法性验证
        /// </summary>
        /// <param name="caster">释放者</param>
        /// <param name="target">目标</param>
        /// <param name="skillData">技能数据</param>
        /// <returns></returns>
        bool Verify(PlayerBase caster, PlayerBase target, SkillData skillData);

        /// <summary>
        /// 验证的优先级，优先级决定验证的先后顺序
        /// </summary>
        /// <returns></returns>
        int Priority();
    }
}
