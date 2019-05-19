namespace ZJY.Framework
{
    public delegate void DamageResult(int result);

    /// <summary>
    /// 伤害计算任务
    /// </summary>
    public class DamageCondtion : OnceTaskCondition
    {
        private DamageResult m_Result;
        public DamageCondtion(Skill skill, DamageResult result) :base(skill)
        {
            this.m_Result = result;
        }

        public override void Start()
        {
            base.Start();

            //todo
            UnityEngine.Debug.Log("计算伤害! 要根据技能类型来!");
            int result = this.m_Skill.Caculate(new FixAddHp());
            if (m_Result != null) m_Result(result);
        }
    }
}
