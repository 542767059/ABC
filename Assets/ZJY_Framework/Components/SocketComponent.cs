using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// Socket组件
    /// </summary>
    public class SocketComponent : GameBaseComponent
    {
        [SerializeField]
        private int m_MaxSendCount = 5;

        [SerializeField]
        private int m_MaxSendByteCount = 1024;

        [SerializeField]
        private int m_MaxReceiveCount = 5;

        [SerializeField]
        private float m_HeartbeatInterval = 10f;

        [SerializeField]
        private int m_PingValue;

        [SerializeField]
        private long m_GameServerTime;

        [SerializeField]
        private float m_CheckServerTime;

        private float m_PreHeartbeatTime = 0f;
        


        /// <summary>
        /// 是否已经连接到了主Socket
        /// </summary>
        private bool m_IsConnectToMainSocket = false;

        /// <summary>
        /// 发送用的MemoryStream
        /// </summary>
        public MMO_MemoryStream SocketSendMS
        {
            get;
            private set;
        }

        /// <summary>
        /// 接收用的MemoryStream
        /// </summary>
        public MMO_MemoryStream SocketReceiveMS
        {
            get;
            private set;
        }


        private SocketManager m_SocketManager;

        protected override void OnAwake()
        {
            base.OnAwake();
            m_SocketManager = new SocketManager();
            SocketReceiveMS = new MMO_MemoryStream();
            SocketSendMS = new MMO_MemoryStream();
            m_SocketManager.SocketConnectedEvent += OnSocketConnected;
            m_SocketManager.SocketClosedEvent += OnSocketClosed;
            m_SocketManager.SocketErrorEvent += OnSocketError;
            m_SocketManager.SocketCustomErrorEvent += OnSocketCustomError;
        }

        protected override void OnStart()
        {
            base.OnStart();
            m_MainSocket = CreateSocketTcpRoutine("MainSocket");
            SocketProtoListener.AddProtoListener();
        }



        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            m_SocketManager.OnUpdate(deltaTime, unscaledDeltaTime);

            if (m_IsConnectToMainSocket)
            {
                if (Time.realtimeSinceStartup > m_PreHeartbeatTime + m_HeartbeatInterval)
                {
                    m_PreHeartbeatTime = Time.realtimeSinceStartup;

                    //发送心跳包
                    System_HeartbeatProto proto = new System_HeartbeatProto();
                    proto.LocalTime = Time.realtimeSinceStartup * 1000;
                    m_CheckServerTime = Time.realtimeSinceStartup;
                    SendProtoMessage(proto);
                }
            }
        }

        public override void Shutdown()
        {
            base.Shutdown();

            m_IsConnectToMainSocket = false;

            m_SocketManager.Dispose();
            SocketProtoListener.RemoveProtoListener();

            SocketReceiveMS.Dispose();
            SocketSendMS.Dispose();

            SocketReceiveMS.Close();
            SocketSendMS.Close();

            SocketReceiveMS = null;
            SocketSendMS = null;
        }

        /// <summary>
        /// 获取Socket数量
        /// </summary>
        public int SocketTcpRoutineCount
        {
            get
            {
                return m_SocketManager.SocketTcpRoutineCount;
            }
        }

        /// <summary>
        /// 获取或设置每帧心跳包间隔
        /// </summary>
        public float HeartbeatInterval
        {
            get
            {
                return m_HeartbeatInterval;
            }
            set
            {
                m_HeartbeatInterval = value;
            }
        }

        /// <summary>
        /// 获取或设置每帧发送最大数量
        /// </summary>
        public int MaxSendCount
        {
            get
            {
                return m_MaxSendCount;
            }
            set
            {
                m_MaxSendCount = value;
            }
        }

        /// <summary>
        /// 获取或设置每次发包最大字节长度
        /// </summary>
        public int MaxSendByteCount
        {
            get
            {
                return m_MaxSendByteCount;
            }
            set
            {
                m_MaxSendByteCount = value;
            }
        }

        /// <summary>
        /// 获取或设置每帧最大处理包数量
        /// </summary>
        public int MaxReceiveCount
        {
            get
            {
                return m_MaxReceiveCount;
            }
            set
            {
                m_MaxReceiveCount = value;
            }
        }

        /// <summary>
        /// 获取或设置Ping值
        /// </summary>
        public int PingValue
        {
            get
            {
                return m_PingValue;
            }
            set
            {
                m_PingValue = value;
            }
        }

        /// <summary>
        /// 获取或设置游戏服务器时间
        /// </summary>
        public long GameServerTime
        {
            get
            {
                return m_GameServerTime;
            }
            set
            {
                m_GameServerTime = value;
            }
        }

        /// <summary>
        /// 获取或设置服务器对表时刻
        /// </summary>
        public float CheckServerTime
        {
            get
            {
                return m_CheckServerTime;
            }
            set
            {
                m_CheckServerTime = value;
            }
        }

        /// <summary>
        /// 检查是否存在Socket
        /// </summary>
        /// <param name="name">Socket名称</param>
        /// <returns>是否存在Socket</returns>
        public bool HasSocketTcp(string name)
        {
            return m_SocketManager.HasSocketTcp(name);
        }

        /// <summary>
        /// 获取Socket
        /// </summary>
        /// <param name="name">Socket名称</param>
        /// <returns>要获取的Socket</returns>
        public SocketTcpRoutine GetSocketTcpRoutine(string name)
        {
            return m_SocketManager.GetSocketTcpRoutine(name);
        }

        /// <summary>
        /// 获取所有Socket
        /// </summary>
        /// <returns>所有Socket</returns>
        public SocketTcpRoutine[] GetAllSocketTcpRoutines()
        {
            return m_SocketManager.GetAllSocketTcpRoutines();
        }

        /// <summary>
        /// 获取所有Socket
        /// </summary>
        /// <param name="results">所有Socket</param>
        public void GetAllSocketTcpRoutines(List<SocketTcpRoutine> results)
        {
            m_SocketManager.GetAllSocketTcpRoutines(results);
        }

        /// <summary>
        /// 创建SocketTcp访问器
        /// </summary>
        /// <param name="name">SocketTcp名称</param>
        /// <returns></returns>
        public SocketTcpRoutine CreateSocketTcpRoutine(string name)
        {
            return m_SocketManager.CreateSocketTcpRoutine(name); ;
        }

        /// <summary>
        /// 销毁网络频道
        /// </summary>
        /// <param name="name">网络频道名称</param>
        /// <returns>是否销毁网络频道成功</returns>
        public bool DestroySocketTcpRoutine(string name)
        {
            return m_SocketManager.DestroySocketTcpRoutine(name);
        }



        //=====================主Socket========================


        /// <summary>
        /// 主Socket
        /// </summary>
        private SocketTcpRoutine m_MainSocket;

        /// <summary>
        /// 获取主Socket
        /// </summary>
        public SocketTcpRoutine MainSocket
        {
            get
            {
                return m_MainSocket;
            }
        }

        /// <summary>
        /// 连接主Socket
        /// </summary>
        /// <param name="ip">Ip地址</param>
        /// <param name="port">端口号</param>
        public void ConnectToMainSocket(string ip, int port)
        {
            m_MainSocket.Connect(ip, port);
        }

        /// <summary>
        /// 连断开主Socket
        /// </summary>
        public void CloseMainSocket()
        {
            m_MainSocket.Close();
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="buffer">消息2进制数组</param>
        public void SendProtoMessage(byte[] buffer)
        {
            m_MainSocket.SendProtoMessage(buffer);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="proto">协议内容</param>
        public void SendProtoMessage(IProto proto)
        {
#if DEBUG_LOG_PROTO
            Debug.Log("<color=#ffa200>发送消息:</color><color=#00ff9c>" + proto.ProtoEnName + " " + proto.ProtoCode + "</color>");
            Debug.Log("<color=#ffdeb3>==>>" + JsonUtility.ToJson(proto) + "</color>");
#endif
            m_MainSocket.SendProtoMessage(proto.ToArray());
        }
        //==========================================

        private void OnSocketConnected(SocketTcpRoutine socketTcpRoutine)
        {
            //已经建立了连接
            if (socketTcpRoutine.Name.Equals("MainSocket") && socketTcpRoutine.Connected)
            {
                m_IsConnectToMainSocket = true;
            }
            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<SocketConnectedGameEvent>().Fill(socketTcpRoutine));
        }

        private void OnSocketClosed(SocketTcpRoutine socketTcpRoutine)
        {
            if (socketTcpRoutine.Name.Equals("MainSocket") && !socketTcpRoutine.Connected)
            {
                m_IsConnectToMainSocket = false;
            }
            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<SocketClosedGameEvent>().Fill(socketTcpRoutine));
        }


        private void OnSocketError(SocketTcpRoutine socketTcpRoutine, NetworkErrorCode errorCode, string errorMessage)
        {
            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<SocketErrorGameEvent>().Fill(socketTcpRoutine, errorCode, errorMessage));
            Debug.LogError(errorMessage);
        }

        private void OnSocketCustomError(SocketTcpRoutine socketTcpRoutine, object customErrorData)
        {
            Debug.LogError(customErrorData);
            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<SocketCustomErrorGameEvent>().Fill(socketTcpRoutine, customErrorData));
        }
    }
}
