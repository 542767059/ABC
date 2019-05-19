namespace ZJY.Framework
{
    /// <summary>
    /// 播放动作任务
    /// </summary>
    public class MotionCondition : OnceTaskCondition
    {
        public MotionCondition(Skill skill) : base(skill)
        {

        }


        public override void Start()
        {
            base.Start();

            //todo 播放动作
            UnityEngine.Debug.Log("播放动作");


            AnimatorComponent animatorComponent = m_Skill.Caster.GetUnitComponent<AnimatorComponent>();
            SkillData skillData = m_Skill.SkillData;

            if (skillData.IsNormalAttack == 1)
            {
                animatorComponent.SetIntValue(Constant.AnimatorParam.AttackId, skillData.SkillAnimatorIndex);
                animatorComponent.SetTrigger(Constant.AnimatorParam.Attack);
            }
            else
            {
                animatorComponent.SetIntValue(Constant.AnimatorParam.SkillId, skillData.SkillAnimatorIndex);
                animatorComponent.SetTrigger(Constant.AnimatorParam.Skill);
            }
        }
    }
}
