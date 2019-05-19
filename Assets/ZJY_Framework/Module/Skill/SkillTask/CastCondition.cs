namespace ZJY.Framework
{
    /// <summary>
    /// 特效任务
    /// </summary>
    public class CastCondition : OnceTaskCondition
    {
        public CastCondition(Skill skill) : base(skill)
        {

        }

        public override void Start()
        {
            base.Start();
            //TO-DO 创建特效
            UnityEngine.Debug.Log("创建特效");

            SkillData skillData = m_Skill.SkillData;

            GameEntry.Entity.ShowSkillEffect(m_Skill.Caster,skillData.Skill_effect_name, skillData.Skill_effect_time);

        }
    }
}