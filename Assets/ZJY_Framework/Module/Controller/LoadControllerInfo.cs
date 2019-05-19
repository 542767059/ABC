using UnityEngine;

namespace ZJY.Framework
{
    public class LoadControllerInfo
    {
        private readonly Animator m_TargetAnimator;

        public LoadControllerInfo(Animator targetAnimator)
        {
            m_TargetAnimator = targetAnimator;
        }

        /// <summary>
        /// 获取要替换的目标状态机
        /// </summary>
        public Animator TargetAnimator
        {
            get
            {
                return m_TargetAnimator;
            }
        }
        
    }
}
