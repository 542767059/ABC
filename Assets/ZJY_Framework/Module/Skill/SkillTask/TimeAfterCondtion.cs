
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 时间过后任务 用于处理延时效果
    /// </summary>
    public class TimeAfterCondtion : ITaskCondition
    {
        private float m_AfterTime;

        /// <summary>
        /// 时间过后任务
        /// </summary>
        /// <param name="afterTime">经过的时间点</param>
        public TimeAfterCondtion(float afterTime)
        {
            m_AfterTime = afterTime;
        }

        public void Handle()
        {
            
        }

        public bool IsFinish()
        {
            return Time.time > m_AfterTime;
        }

        public string Name()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Start()
        {
            
        }
    }
}
