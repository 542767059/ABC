using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ZJY.Framework
{
    public class SkillTaskManager
    {
        private Action m_Complate;
        private string m_QueueName;

        private Queue<SkillTask> m_TaskQueue = new Queue<SkillTask>();
        /// <summary>
        /// 当前任务
        /// </summary>
        private SkillTask m_Task;

        public SkillTask SkillTask
        {
            get
            {
                return m_Task;
            }
        }

        /// <summary>
        /// 是否任务已经做完了
        /// </summary>
        /// <returns></returns>
        public bool IsTaskFinish()
        {
            return (m_Task == null);

        }

        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(SkillTask task)
        {
            m_TaskQueue.Enqueue(task);
        }

        /// <summary>
        /// 清除所有任务
        /// </summary>
        public void RemoveAllTask()
        {
            m_Task = null;
            m_TaskQueue.Clear();
        }

        /// <summary>
        /// 执行下一个任务
        /// </summary>
        public SkillTask Next()
        {
            if (m_TaskQueue.Count > 0)
            {
                m_Task = m_TaskQueue.Dequeue();
                m_Task.Condition.Start();
            }
            else
            {
                m_Task = null;
            }

            return m_Task;
        }

        public void Start(string queueName = "", Action complate = null)
        {
            m_Complate = complate;
            m_QueueName = queueName;

            SkillTask current = Next();
            if (current != null)
            {
                CheckFinish(current);
            }
            else
            {
                Log.Error("任务是空的!");
            }
        }


        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            if (m_Task != null)
            {
                CheckFinish(m_Task);
            }
        }

        private void CheckFinish(SkillTask skillTask)
        {
            Debug.Log(TextUtil.Format("当前执行的任务序列{0}, 当前任务{1}", this.m_QueueName, skillTask.m_Name));
            if (skillTask.IsFinish())
            {
                SkillTask current = Next();
                if (current != null)
                {
                    CheckFinish(current);
                }
                else
                {
                    EndSkill();
                }
            }
        }

        private void EndSkill()
        {
            Debug.Log(TextUtil.Format("结束: 任务序列{0}", m_QueueName));
            if (m_Complate != null)
            {
                m_Complate();
            }
        }
    }
}

