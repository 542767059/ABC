using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 技能任务
    /// </summary>
    public class SkillTask
    {
        /// <summary>
        /// 任务完成所需要的条件
        /// </summary>
        private ITaskCondition m_Condition;

        public string m_Name;

        public SkillTask(string name, ITaskCondition condition)
        {
            this.m_Name = name;
            this.m_Condition = condition;
        }

        public SkillTask(ITaskCondition condition)
        {
            this.m_Condition = condition;
        }

        public ITaskCondition Condition
        {
            get
            {
                return m_Condition;
            }
        }
        
        public bool IsFinish()
        {
            return m_Condition.IsFinish();
        }

    }
}