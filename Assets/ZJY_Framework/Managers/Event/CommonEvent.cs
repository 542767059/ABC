//===================================================
//
//===================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    /// <summary>
    /// 通用事件
    /// </summary>
    public class CommonEvent : IDisposable
    {
        /// <summary>
        /// 事件队列
        /// </summary>
        private readonly Queue<GameEventBase> m_Events;

        public delegate void OnActionHandler(GameEventBase gameEventBase);
        private Dictionary<int, LinkedList<OnActionHandler>> m_EventHandlers;

        public CommonEvent()
        {
            m_Events = new Queue<GameEventBase>();
            m_EventHandlers = new Dictionary<int, LinkedList<OnActionHandler>>();
        }

       

        /// <summary>
        /// 获取事件处理函数的数量
        /// </summary>
        public int EventHandlerCount
        {
            get
            {
                return m_EventHandlers.Count;
            }
        }

        /// <summary>
        /// 获取事件数量
        /// </summary>
        public int EventCount
        {
            get
            {
                return m_Events.Count;
            }
        }


        #region AddEventListener 添加监听
        /// <summary>
        /// 添加监听
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        public void AddEventListener(int key, OnActionHandler handler)
        {
            LinkedList<OnActionHandler> lstHandler = null;
            m_EventHandlers.TryGetValue(key, out lstHandler);
            if (lstHandler == null)
            {
                lstHandler = new LinkedList<OnActionHandler>();
                m_EventHandlers[key] = lstHandler;
            }
            lstHandler.AddLast(handler);
        }
        #endregion

        #region RemoveEventListener 移除监听
        /// <summary>
        /// 移除监听
        /// </summary>
        /// <param name="key"></param>
        /// <param name="handler"></param>
        public void RemoveEventListener(int key, OnActionHandler handler)
        {
            LinkedList<OnActionHandler> lstHandler = null;
            if (!m_EventHandlers.TryGetValue(key, out lstHandler))
            {
                throw new Exception(TextUtil.Format("Event '{0}' not exists any handler.", key.ToString()));
            }


            if (!lstHandler.Remove(handler))
            {
                throw new Exception(TextUtil.Format("Event '{0}' not exists specified handler.", key.ToString()));
            }
        }
        #endregion



        #region Dispatch 派发
        /// <summary>
        /// 立刻派发事件，这不是线程安全的
        /// </summary>
        /// <param name="sender">事件发送者，一般填this即可</param>
        /// <param name="gameEventBase">事件内容</param>
        public void DispatchNow(object sender, GameEventBase gameEventBase)
        {
            gameEventBase.Sender = sender;
            LinkedList<OnActionHandler> lstHandler = null;

            if(m_EventHandlers.TryGetValue(gameEventBase.Id, out lstHandler) && lstHandler.Count > 0)
            {
                LinkedListNode<OnActionHandler> current = lstHandler.First;
                while (current != null)
                {
                    LinkedListNode<OnActionHandler> next = current.Next;
                    if (current.Value != null)
                    {
                        current.Value(gameEventBase);
                    }
                    current = next;
                }
            }

            GameEntry.Pool.UnSpawnClassObject(gameEventBase);
        }


        /// <summary>
        /// 派发事件，这是线程安全的
        /// </summary>
        /// <param name="sender">事件发送者，一般填this即可</param>
        /// <param name="gameEventBase"></param>
        public void Dispatch(object sender, GameEventBase gameEventBase)
        {
            lock (m_Events)
            {
                gameEventBase.Sender = sender;
                m_Events.Enqueue(gameEventBase);
            }
        }

        #endregion

        /// <summary>
        /// 事件轮询
        /// </summary>
        internal void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            lock (m_Events)
            {
                while (m_Events.Count > 0)
                {
                    GameEventBase gameEventBase = m_Events.Dequeue();
                    DispatchNow(gameEventBase.Sender, gameEventBase);
                }

            }
        }

        public void Dispose()
        {
            lock (m_Events)
            {
                m_Events.Clear();
            }
            m_EventHandlers.Clear();
        }
    }
}
