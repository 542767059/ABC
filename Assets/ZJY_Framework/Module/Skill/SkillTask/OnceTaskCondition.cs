

namespace ZJY.Framework
{
    /// <summary>
    /// 单次瞬发任务
    /// </summary>
    public class OnceTaskCondition : ITaskCondition
    {
        protected bool m_IsComplete = false;
        protected Skill m_Skill;

        public OnceTaskCondition(Skill skill)
        {
            m_Skill = skill;
            m_IsComplete = false;
        }

        public void Handle()
        {
            throw new System.NotImplementedException();
        }

        public bool IsFinish()
        {
            return m_IsComplete;
        }

        public string Name()
        {
            return this.ToString();
        }

        public virtual void Start()
        {
            m_IsComplete = true;
        }
    }
}
