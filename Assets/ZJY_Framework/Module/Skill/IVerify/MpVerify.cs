namespace ZJY.Framework
{
    /// <summary>
    /// 蓝耗验证
    /// </summary>
    public class MpVerify : IVerify
    {
        /// <summary>
        /// 验证优先级 越小越靠前
        /// </summary>
        /// <returns></returns>
        public int Priority()
        {
            return 1;
        }

        public bool Verify(PlayerBase caster, PlayerBase target, SkillData skillData)
        {
            UnityEngine.Debug.Log("需要消耗蓝直接为false！");
            return false;
        }
    }
}
