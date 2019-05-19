using System.Collections.Generic;
using System;


namespace ZJY.Framework
{
    public class SocketManager : ManagerBase, IDisposable
    {
        private Dictionary<string, SocketTcpRoutine> m_SocketTcpRoutines;

        public SocketConnectedEvent SocketConnectedEvent;
        public SocketClosedEvent SocketClosedEvent;
        public SocketErrorEvent SocketErrorEvent;
        public SocketCustomErrorEvent SocketCustomErrorEvent;

        public SocketManager()
        {
            m_SocketTcpRoutines = new Dictionary<string, SocketTcpRoutine>();
        }

        /// <summary>
        /// 获取Socket数量
        /// </summary>
        public int SocketTcpRoutineCount
        {
            get
            {
                return m_SocketTcpRoutines.Count;
            }
        }
        
        /// <summary>
        /// 轮询Socket
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <param name="unscaledDeltaTime"></param>
        internal void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            foreach (KeyValuePair<string, SocketTcpRoutine> socketTcpRoutine in m_SocketTcpRoutines)
            {
                socketTcpRoutine.Value.OnUpdate(deltaTime, unscaledDeltaTime);
            }
            
        }

        public override void Dispose()
        {
            foreach (KeyValuePair<string, SocketTcpRoutine> socketTcpRoutines in m_SocketTcpRoutines)
            {
                SocketTcpRoutine socket = socketTcpRoutines.Value;
                socket.SocketConnected -= OnSocketConnected;
                socket.SocketClosed -= OnSocketClosed;
                socket.SocketError -= OnSocketError;
                socket.SocketCustomError -= OnSocketCustomError;
                socket.Shutdown();
            }

            m_SocketTcpRoutines.Clear();
        }

        /// <summary>
        /// 检查是否存在Socket
        /// </summary>
        /// <param name="name">Socket名称</param>
        /// <returns>是否存在Socket</returns>
        public bool HasSocketTcp(string name)
        {
            return m_SocketTcpRoutines.ContainsKey(name ?? string.Empty);
        }

        /// <summary>
        /// 获取Socket
        /// </summary>
        /// <param name="name">Socket名称</param>
        /// <returns>要获取的Socket</returns>
        public SocketTcpRoutine GetSocketTcpRoutine(string name)
        {
            SocketTcpRoutine socketTcpRoutine = null;
            if (m_SocketTcpRoutines.TryGetValue(name ?? string.Empty, out socketTcpRoutine))
            {
                return socketTcpRoutine;
            }

            return null;
        }

        /// <summary>
        /// 获取所有Socket
        /// </summary>
        /// <returns>所有Socket</returns>
        public SocketTcpRoutine[] GetAllSocketTcpRoutines()
        {
            int index = 0;
            SocketTcpRoutine[] results = new SocketTcpRoutine[m_SocketTcpRoutines.Count];
            foreach (KeyValuePair<string, SocketTcpRoutine> SocketTcpRoutine in m_SocketTcpRoutines)
            {
                results[index++] = SocketTcpRoutine.Value;
            }

            return results;
        }

        /// <summary>
        /// 获取所有Socket
        /// </summary>
        /// <param name="results">所有Socket</param>
        public void GetAllSocketTcpRoutines(List<SocketTcpRoutine> results)
        {
            if (results == null)
            {
                throw new Exception("Results is invalid.");
            }

            results.Clear();
            foreach (KeyValuePair<string, SocketTcpRoutine> SocketTcpRoutine in m_SocketTcpRoutines)
            {
                results.Add(SocketTcpRoutine.Value);
            }
        }

        /// <summary>
        /// 创建SocketTcp访问器
        /// </summary>
        /// <param name="name">SocketTcp名称</param>
        /// <returns></returns>
        public SocketTcpRoutine CreateSocketTcpRoutine(string name)
        {
            if (HasSocketTcp(name))
            {
                throw new Exception(TextUtil.Format("Already exist network channel '{0}'.", name ?? string.Empty));
            }

            SocketTcpRoutine socketTcpRoutine = new SocketTcpRoutine(name);
            socketTcpRoutine.SocketConnected += OnSocketConnected;
            socketTcpRoutine.SocketClosed += OnSocketClosed;
            socketTcpRoutine.SocketError += OnSocketError;
            socketTcpRoutine.SocketCustomError += OnSocketCustomError;
            m_SocketTcpRoutines.Add(name, socketTcpRoutine);
            return socketTcpRoutine;
        }

        /// <summary>
        /// 销毁网络频道
        /// </summary>
        /// <param name="name">网络频道名称</param>
        /// <returns>是否销毁网络频道成功</returns>
        public bool DestroySocketTcpRoutine(string name)
        {
            SocketTcpRoutine socketTcpRoutine = null;
            if (m_SocketTcpRoutines.TryGetValue(name ?? string.Empty, out socketTcpRoutine))
            {
                socketTcpRoutine.SocketConnected -= OnSocketConnected;
                socketTcpRoutine.SocketClosed -= OnSocketClosed;
                socketTcpRoutine.SocketError -= OnSocketError;
                socketTcpRoutine.SocketCustomError -= OnSocketCustomError;
                socketTcpRoutine.Shutdown();
                return m_SocketTcpRoutines.Remove(name);
            }

            return false;
        }

        private void OnSocketConnected(SocketTcpRoutine socketTcpRoutine)
        {
            if (SocketConnectedEvent != null)
            {
                lock (SocketConnectedEvent)
                {
                    SocketConnectedEvent(socketTcpRoutine);
                }
            }
        }

        private void OnSocketClosed(SocketTcpRoutine socketTcpRoutine)
        {
            if (SocketClosedEvent != null)
            {
                lock (SocketClosedEvent)
                {
                    SocketClosedEvent(socketTcpRoutine);
                }
            }
        }
        
        private void OnSocketError(SocketTcpRoutine socketTcpRoutine, NetworkErrorCode errorCode, string errorMessage)
        {
            if (SocketErrorEvent != null)
            {
                lock (SocketErrorEvent)
                {
                    SocketErrorEvent(socketTcpRoutine,errorCode, errorMessage);
                }
            }
        }

        private void OnSocketCustomError(SocketTcpRoutine socketTcpRoutine, object customErrorData)
        {
            if (SocketCustomErrorEvent != null)
            {
                lock (SocketCustomErrorEvent)
                {
                    SocketCustomErrorEvent(socketTcpRoutine,customErrorData);
                }
            }
        }
    }
}
