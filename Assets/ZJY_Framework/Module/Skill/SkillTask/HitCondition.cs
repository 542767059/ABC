

namespace ZJY.Framework
{
    public class HitCondition : TimeAfterCondtion
    {
        public HitCondition(Skill skill,int result,float afterTime) : base(afterTime)
        {

        }

        public override void Start()
        {
            base.Start();
            //
            UnityEngine.Debug.Log("处理伤害result");
        }
    }
}
