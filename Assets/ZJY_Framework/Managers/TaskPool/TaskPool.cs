﻿using System;
using System.Collections.Generic;

namespace ZJY.Framework
{
    /// <summary>
    /// 任务池
    /// </summary>
    /// <typeparam name="T">任务类型</typeparam>
    internal sealed class TaskPool<T> where T : ITask
    {
        private readonly Stack<ITaskAgent<T>> m_FreeAgents;
        private readonly LinkedList<ITaskAgent<T>> m_WorkingAgents;
        private readonly LinkedList<T> m_WaitingTasks;

        public TaskPool()
        {
            m_FreeAgents = new Stack<ITaskAgent<T>>();
            m_WorkingAgents = new LinkedList<ITaskAgent<T>>();
            m_WaitingTasks = new LinkedList<T>();
        }

        /// <summary>
        /// 获取任务代理总数量
        /// </summary>
        public int TotalTaskCount
        {
            get
            {
                return FreeAgentCount + WorkingAgentCount;
            }
        }

        /// <summary>
        /// 获取可用任务代理数量
        /// </summary>
        public int FreeAgentCount
        {
            get
            {
                return m_FreeAgents.Count;
            }
        }

        /// <summary>
        /// 获取工作中任务代理数量
        /// </summary>
        public int WorkingAgentCount
        {
            get
            {
                return m_WorkingAgents.Count;
            }
        }

        /// <summary>
        /// 获取等待任务数量
        /// </summary>
        public int WaitingTaskCount
        {
            get
            {
                return m_WaitingTasks.Count;
            }
        }

        /// <summary>
        /// 任务池轮询
        /// </summary>
        /// <param name="deltaTime">逻辑流逝时间，以秒为单位</param>
        /// <param name="unscaledDeltaTime">真实流逝时间，以秒为单位</param>
        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            ProcessRunningTasks(deltaTime, unscaledDeltaTime);
            ProcessWaitingTasks(deltaTime, unscaledDeltaTime);
        }


        /// <summary>
        /// 关闭并清理任务池
        /// </summary>
        public void Shutdown()
        {
            while (FreeAgentCount > 0)
            {
                m_FreeAgents.Pop().Shutdown();
            }

            foreach (ITaskAgent<T> workingAgent in m_WorkingAgents)
            {
                workingAgent.Shutdown();
            }
            m_WorkingAgents.Clear();

            m_WaitingTasks.Clear();
        }

        /// <summary>
        /// 增加任务加载器
        /// </summary>
        /// <param name="Loader">要增加的任务加载器</param>
        public void AddAgent(ITaskAgent<T> agent)
        {
            if (agent == null)
            {
                throw new Exception("ResourceLoader is invalid.");
            }

            agent.Initialize();
            m_FreeAgents.Push(agent);
        }

        /// <summary>
        /// 增加任务
        /// </summary>
        /// <param name="task">要增加的任务</param>
        public void AddTask(T task)
        {
            LinkedListNode<T> current = m_WaitingTasks.First;
            while (current != null)
            {
                if (task.Priority > current.Value.Priority)
                {
                    break;
                }

                current = current.Next;
            }

            if (current != null)
            {
                m_WaitingTasks.AddBefore(current, task);
            }
            else
            {
                m_WaitingTasks.AddLast(task);
            }
        }

        /// <summary>
        /// 移除任务
        /// </summary>
        /// <param name="serialId">要移除任务的序列编号</param>
        /// <returns>被移除的任务</returns>
        public T RemoveTask(int serialId)
        {
            foreach (T waitingTask in m_WaitingTasks)
            {
                if (waitingTask.SerialId == serialId)
                {
                    m_WaitingTasks.Remove(waitingTask);
                    return waitingTask;
                }
            }

            foreach (ITaskAgent<T> workingAgent in m_WorkingAgents)
            {
                if (workingAgent.Task.SerialId == serialId)
                {
                    workingAgent.Reset();
                    m_FreeAgents.Push(workingAgent);
                    m_WorkingAgents.Remove(workingAgent);
                    return workingAgent.Task;
                }
            }

            return default(T);
        }

        /// <summary>
        /// 移除所有任务
        /// </summary>
        public void RemoveAllTasks()
        {
            m_WaitingTasks.Clear();
            foreach (ITaskAgent<T> workingAgent in m_WorkingAgents)
            {
                workingAgent.Reset();
                m_FreeAgents.Push(workingAgent);
            }
            m_WorkingAgents.Clear();
        }

        private void ProcessRunningTasks(float deltaTime, float unscaledDeltaTime)
        {
            LinkedListNode<ITaskAgent<T>> current = m_WorkingAgents.First;
            while (current != null)
            {
                if (!current.Value.Task.Done)
                {
                    current.Value.OnUpdate(deltaTime, unscaledDeltaTime);
                    current = current.Next;
                    continue;
                }

                LinkedListNode<ITaskAgent<T>> next = current.Next;
                current.Value.Reset();
                m_FreeAgents.Push(current.Value);
                m_WorkingAgents.Remove(current);
                current = next;
            }
        }

        private void ProcessWaitingTasks(float deltaTime, float unscaledDeltaTime)
        {
            LinkedListNode<T> current = m_WaitingTasks.First;
            while (current != null && FreeAgentCount > 0)
            {
                ITaskAgent<T> agent = m_FreeAgents.Pop();
                LinkedListNode<ITaskAgent<T>> agentNode = m_WorkingAgents.AddLast(agent);
                LinkedListNode<T> next = current.Next;
                StartTaskStatus status = agent.StartTask(current.Value);
                if (status == StartTaskStatus.Done || status == StartTaskStatus.HasToWait || status == StartTaskStatus.UnknownError)
                {
                    agent.Reset();
                    m_FreeAgents.Push(agent);
                    m_WorkingAgents.Remove(agentNode);
                }

                if (status == StartTaskStatus.Done || status == StartTaskStatus.CanResume || status == StartTaskStatus.UnknownError)
                {
                    m_WaitingTasks.Remove(current);
                }

                current = next;
            }
        }
    }
}