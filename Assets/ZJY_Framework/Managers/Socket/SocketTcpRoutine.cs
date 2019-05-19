using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;


namespace ZJY.Framework
{
    /// <summary>
    /// SocketTcp访问器
    /// </summary>
    public class SocketTcpRoutine
    {
        /// <summary>
        /// 压缩数组的长度界限
        /// </summary>
        private const int m_CompressLen = 200;

        private readonly string m_Name;
        private readonly Queue<byte[]> m_SendQueue;
        private readonly Queue<byte[]> m_ReceiveQueue;
        private NetworkType m_NetworkType;
        private Socket m_Socket;
        private int m_SentPacketCount;
        private int m_ReceivedPacketCount;
        private byte[] m_ReceiveBuffer;
        private MMO_MemoryStream m_ReceiveMS = new MMO_MemoryStream();
        private MMO_MemoryStream m_SocketSendMS = new MMO_MemoryStream();
        private MMO_MemoryStream m_SocketReceiveMS = new MMO_MemoryStream();


        /// <summary>
        /// 每帧处理数量
        /// </summary>
        private int m_ReceiveCount = 0;

        /// <summary>
        /// 这一帧发送了多少
        /// </summary>
        private int m_SendCount = 0;

        private bool m_Active;

        public Action<SocketTcpRoutine> SocketConnected;
        public Action<SocketTcpRoutine> SocketClosed;
        public Action<SocketTcpRoutine, NetworkErrorCode, string> SocketError;
        public Action<SocketTcpRoutine, object> SocketCustomError;

        /// <summary>
        /// 初始化Socket
        /// </summary>
        /// <param name="name">Socket名称</param>
        public SocketTcpRoutine(string name)
        {
            m_ReceiveBuffer = new byte[1024];

            m_Name = name ?? string.Empty;
            m_SendQueue = new Queue<byte[]>();
            m_ReceiveQueue = new Queue<byte[]>();
            m_NetworkType = NetworkType.Unknown;
            m_Socket = null;
            m_ReceiveMS = new MMO_MemoryStream();
            m_SocketSendMS = new MMO_MemoryStream();
            m_SocketReceiveMS = new MMO_MemoryStream();
            m_SentPacketCount = 0;
            m_ReceivedPacketCount = 0;
            m_Active = false;

            SocketConnected = null;
            SocketClosed = null;
            SocketError = null;
            SocketCustomError = null;
        }

        /// <summary>
        /// 获取网络频道名称
        /// </summary>
        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        /// <summary>
        /// 获取是否已连接
        /// </summary>
        public bool Connected
        {
            get
            {
                if (m_Socket != null)
                {
                    return m_Socket.Connected;
                }

                return false;
            }
        }

        /// <summary>
        /// 获取网络类型
        /// </summary>
        public NetworkType NetworkType
        {
            get
            {
                return m_NetworkType;
            }
        }

        /// <summary>
        /// 获取本地终结点的 IP 地址
        /// </summary>
        public IPAddress LocalIPAddress
        {
            get
            {
                if (m_Socket == null)
                {
                    throw new Exception("You must connect first.");
                }

                IPEndPoint ipEndPoint = (IPEndPoint)m_Socket.LocalEndPoint;
                if (ipEndPoint == null)
                {
                    throw new Exception("Local end point is invalid.");
                }

                return ipEndPoint.Address;
            }
        }

        /// <summary>
        /// 获取本地终结点的端口号
        /// </summary>
        public int LocalPort
        {
            get
            {
                if (m_Socket == null)
                {
                    throw new Exception("You must connect first.");
                }

                IPEndPoint ipEndPoint = (IPEndPoint)m_Socket.LocalEndPoint;
                if (ipEndPoint == null)
                {
                    throw new Exception("Local end point is invalid.");
                }

                return ipEndPoint.Port;
            }
        }

        /// <summary>
        /// 获取远程终结点的 IP 地址
        /// </summary>
        public IPAddress RemoteIPAddress
        {
            get
            {
                if (m_Socket == null)
                {
                    throw new Exception("You must connect first.");
                }

                IPEndPoint ipEndPoint = (IPEndPoint)m_Socket.RemoteEndPoint;
                if (ipEndPoint == null)
                {
                    throw new Exception("Remote end point is invalid.");
                }

                return ipEndPoint.Address;
            }
        }

        /// <summary>
        /// 获取远程终结点的端口号
        /// </summary>
        public int RemotePort
        {
            get
            {
                if (m_Socket == null)
                {
                    throw new Exception("You must connect first.");
                }

                IPEndPoint ipEndPoint = (IPEndPoint)m_Socket.RemoteEndPoint;
                if (ipEndPoint == null)
                {
                    throw new Exception("Remote end point is invalid.");
                }

                return ipEndPoint.Port;
            }
        }

        /// <summary>
        /// 获取要发送的消息包数量
        /// </summary>
        public int SendPacketCount
        {
            get
            {
                lock (m_SendQueue)
                {
                    return m_SendQueue.Count;
                }
            }
        }

        /// <summary>
        /// 获取累计发送的消息包数量
        /// </summary>
        public int SentPacketCount
        {
            get
            {
                return m_SentPacketCount;
            }
        }

        /// <summary>
        /// 获取已接收未处理的消息包数量
        /// </summary>
        public int ReceivePacketCount
        {
            get
            {
                lock (m_ReceiveQueue)
                {
                    return m_ReceiveQueue.Count;
                }
            }
        }

        /// <summary>
        /// 获取累计已接收的消息包数量
        /// </summary>
        public int ReceivedPacketCount
        {
            get
            {
                return m_ReceivedPacketCount;
            }
        }


        /// <summary>
        /// 获取或设置接收缓冲区字节数
        /// </summary>
        public int ReceiveBufferSize
        {
            get
            {
                if (m_Socket == null)
                {
                    throw new Exception("You must connect first.");
                }

                return m_Socket.ReceiveBufferSize;
            }
            set
            {
                if (m_Socket == null)
                {
                    throw new Exception("You must connect first.");
                }

                m_Socket.ReceiveBufferSize = value;
            }
        }

        /// <summary>
        /// 获取或设置发送缓冲区字节数
        /// </summary>
        public int SendBufferSize
        {
            get
            {
                if (m_Socket == null)
                {
                    throw new Exception("You must connect first.");
                }

                return m_Socket.SendBufferSize;
            }
            set
            {
                if (m_Socket == null)
                {
                    throw new Exception("You must connect first.");
                }

                m_Socket.SendBufferSize = value;
            }
        }

        /// <summary>
        /// Socket轮询
        /// </summary>
        /// <param name="deltaTime"></param>
        /// <param name="unscaledDeltaTime"></param>
        internal void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            if (m_Socket == null || !m_Active)
            {
                return;
            }
            
            CheckSendQueue();

            #region 从队列中获取数据
            while (true)
            {
                if (m_ReceiveCount < GameEntry.Socket.MaxReceiveCount)
                {
                    m_ReceiveCount++;
                    lock (m_ReceiveQueue)
                    {
                        if (m_ReceiveQueue.Count > 0)
                        {
                            //得到队列中的数据包
                            byte[] buffer = m_ReceiveQueue.Dequeue();

                            //异或之后的数组
                            byte[] bufferNew = new byte[buffer.Length - 3];

                            bool isCompress = false;
                            ushort crc = 0;

                            MMO_MemoryStream ms = m_SocketReceiveMS;
                            ms.SetLength(0);
                            ms.Write(buffer, 0, buffer.Length);
                            ms.Position = 0;

                            isCompress = ms.ReadBool();
                            crc = ms.ReadUShort();
                            ms.Read(bufferNew, 0, bufferNew.Length);


                            //先crc
                            int newCrc = Crc16.CalculateCrc16(bufferNew);

                            if (newCrc == crc)
                            {
                                //异或 得到原始数据
                                bufferNew = SecurityUtil.Xor(bufferNew);

                                if (isCompress)
                                {
                                    bufferNew = ZipUtil.Decompress(bufferNew);
                                }

                                ushort protoCode = 0;
                                byte[] protoContent = new byte[bufferNew.Length - 2];

                                ms.SetLength(0);
                                ms.Write(bufferNew, 0, bufferNew.Length);
                                ms.Position = 0;


                                //协议编号
                                protoCode = ms.ReadUShort();
                                ms.Read(protoContent, 0, protoContent.Length);
                                m_ReceivedPacketCount++;
                                GameEntry.Event.SocketEvent.Dispatch(protoCode, protoContent);

                            }
                            else
                            {
                                if (SocketCustomError != null)
                                {
                                    SocketCustomError(this, "解析Crc错误");
                                }
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    m_ReceiveCount = 0;
                    break;
                }
            }
            #endregion
        }

        /// <summary>
        /// 关闭网络频道
        /// </summary>
        public void Shutdown()
        {
            Close();
        }


        /// <summary>
        /// 连接到socket服务器
        /// </summary>
        /// <param name="ip">ip</param>
        /// <param name="port">端口号</param>
        public void Connect(string ip, int port)
        {
            if (m_Socket != null)
            {
                Close();
                m_Socket = null;
            }
            IPAddress ipAddress = IPAddress.Parse(ip);

            switch (ipAddress.AddressFamily)
            {
                case AddressFamily.InterNetwork:
                    m_NetworkType = NetworkType.IPv4;
                    break;
                case AddressFamily.InterNetworkV6:
                    m_NetworkType = NetworkType.IPv6;
                    break;
                default:
                    string errorMessage = TextUtil.Format("Not supported address family '{0}'.", ipAddress.AddressFamily.ToString());
                    if (SocketError != null)
                    {
                        SocketError(this, NetworkErrorCode.AddressFamilyError, errorMessage);
                        return;
                    }

                    throw new Exception(errorMessage);
            }

            m_Socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            if (m_Socket == null)
            {
                string errorMessage = "Initialize socket failure.";
                if (SocketError != null)
                {
                    SocketError(this, NetworkErrorCode.SocketError, errorMessage);
                    return;
                }

                throw new Exception(errorMessage);
            }

            try
            {
                m_Socket.BeginConnect(ipAddress, port, ConnectCallBack, m_Socket);
            }
            catch (Exception exception)
            {
                if (SocketError != null)
                {
                    SocketError(this, NetworkErrorCode.ConnectError, exception.Message);
                    return;
                }

                throw;
            }
        }

        private void ConnectCallBack(IAsyncResult ar)
        {
            try
            {
                m_Socket.EndConnect(ar);
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (Exception exception)
            {
                m_Active = false;
                Debug.Log("socket连接失败 + " + exception.ToString());

                throw;
            }

            m_Active = true;
            m_SentPacketCount = 0;
            m_ReceivedPacketCount = 0;

            if (SocketConnected != null)
            {
                SocketConnected(this);
            }

            Debug.Log("连接成功");

            ReceiveMsg();
        }


        /// <summary>
        /// 关闭连接并释放所有相关资源
        /// </summary>
        public void Close()
        {
            lock (this)
            {
                if (m_Socket == null)
                {
                    return;
                }

                lock (m_SendQueue)
                {
                    m_SendQueue.Clear();
                }

                lock (m_ReceiveQueue)
                {
                    m_ReceiveQueue.Clear();
                }

                m_Active = false;
                m_SentPacketCount = 0;
                m_ReceivedPacketCount = 0;
                try
                {
                    m_Socket.Shutdown(SocketShutdown.Both);
                }
                catch
                {
                }
                finally
                {
                    m_Socket.Close();
                    m_Socket = null;

                    if (SocketClosed != null)
                    {
                        SocketClosed(this);
                    }
                }
            }
        }

        #region CheckSendQueue 检查发送队列
        /// <summary>
        /// 检查发送队列
        /// </summary>
        private void CheckSendQueue()
        {
            if (m_SendCount >= GameEntry.Socket.MaxSendCount)
            {
                //等待下一帧发送
                m_SendCount = 0;
                return;
            }

            lock (m_SendQueue)
            {
                if (m_SendQueue.Count > 0)
                {
                    int smallCount = 0;

                    MMO_MemoryStream ms = m_SocketSendMS;
                    ms.SetLength(0);
                    
                    while (true)
                    {
                        if (m_SendQueue.Count == 0)
                        {
                            break;
                        }

                        //取出一个字节数组
                        byte[] buffer = m_SendQueue.Dequeue();

                        ms.Write(buffer, 0, buffer.Length);
                        smallCount++;
                        m_SentPacketCount++;
                        if ((buffer.Length + ms.Length) >= GameEntry.Socket.MaxSendByteCount)
                        {
                            break;//一定要跳出 不能取完队列！
                        }
                    }
                    
                    m_SendCount++;
                    Send(ms.ToArray());
                    CheckSendQueue();
                }
            }
        }
        #endregion

        #region MakeData 封装数据包
        /// <summary>
        /// 封装数据包
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private byte[] MakeData(byte[] data)
        {
            byte[] retBuffer = null;

            //1.如果数据包的长度 大于了m_CompressLen 则进行压缩
            bool isCompress = data.Length > m_CompressLen ? true : false;
            if (isCompress)
            {
                data = ZipUtil.Compress(data);
            }

            //2.异或
            data = SecurityUtil.Xor(data);

            //3.Crc校验 压缩后的
            ushort crc = Crc16.CalculateCrc16(data);

            MMO_MemoryStream ms = m_SocketSendMS;
            ms.SetLength(0);
            ms.WriteUShort((ushort)(data.Length + 3));
            ms.WriteBool(isCompress);
            ms.WriteUShort(crc);
            ms.Write(data, 0, data.Length);

            retBuffer = ms.ToArray();

            return retBuffer;
        }
        #endregion

        #region SendMsg 发送消息 把消息加入队列
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="buffer"></param>
        public void SendProtoMessage(byte[] buffer)
        {
            if (m_Socket == null)
            {
                string errorMessage = "You must connect first.";
                if (SocketError != null)
                {
                    SocketError(this, NetworkErrorCode.SendError, errorMessage);
                    return;
                }

                throw new Exception(errorMessage);
            }

            if (!m_Active)
            {
                string errorMessage = "Socket is not active.";
                if (SocketError != null)
                {
                    SocketError(this, NetworkErrorCode.SendError, errorMessage);
                    return;
                }

                throw new Exception(errorMessage);
            }

            if (buffer == null)
            {
                string errorMessage = "Send buffer is invalid.";
                if (SocketError != null)
                {
                    SocketError(this, NetworkErrorCode.SendError, errorMessage);
                    return;
                }

                throw new Exception(errorMessage);
            }

            //得到封装后的数据包
            byte[] sendBuffer = MakeData(buffer);

            lock (m_SendQueue)
            {
                //把数据包加入队列
                m_SendQueue.Enqueue(sendBuffer);
            }
        }
        #endregion

        #region Send 真正发送数据包到服务器
        /// <summary>
        /// 真正发送数据包到服务器
        /// </summary>
        /// <param name="buffer"></param>
        private void Send(byte[] buffer)
        {
            m_Socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCallBack, m_Socket);
        }
        #endregion

        #region SendCallBack 发送数据包的回调
        /// <summary>
        /// 发送数据包的回调
        /// </summary>
        /// <param name="ar"></param>
        private void SendCallBack(IAsyncResult ar)
        {
            m_Socket.EndSend(ar);

        }
        #endregion

        //====================================================

        #region ReceiveMsg 接收数据
        /// <summary>
        /// 接收数据
        /// </summary>
        private void ReceiveMsg()
        {
            //异步接收数据
            m_Socket.BeginReceive(m_ReceiveBuffer, 0, m_ReceiveBuffer.Length, SocketFlags.None, ReceiveCallBack, m_Socket);
        }
        #endregion

        #region ReceiveCallBack 接收数据回调
        /// <summary>
        /// 接收数据回调
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveCallBack(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int len = 0;
            try
            {
                len = socket.EndReceive(ar);
            }
            catch (ObjectDisposedException)
            {
                return;
            }
            catch (Exception exception)
            {
                m_Active = false;
                if (SocketError != null)
                {
                    SocketError(this, NetworkErrorCode.ReceiveError, exception.Message);
                    return;
                }

                throw;
            }

            if (len > 0)
            {
                //已经接收到数据

                //把接收到数据 写入缓冲数据流的尾部
                m_ReceiveMS.Position = m_ReceiveMS.Length;

                //把指定长度的字节 写入数据流
                m_ReceiveMS.Write(m_ReceiveBuffer, 0, len);

                //如果缓存数据流的长度>2 说明至少有个不完整的包过来了
                //为什么这里是2 因为我们客户端封装数据包 用的ushort 长度就是2
                if (m_ReceiveMS.Length > 2)
                {
                    //进行循环 拆分数据包
                    while (true)
                    {
                        //把数据流指针位置放在0处
                        m_ReceiveMS.Position = 0;

                        //currMsgLen = 包体的长度
                        int currMsgLen = m_ReceiveMS.ReadUShort();

                        //currFullMsgLen 总包的长度=包头长度+包体长度
                        int currFullMsgLen = 2 + currMsgLen;

                        //如果数据流的长度>=整包的长度 说明至少收到了一个完整包
                        if (m_ReceiveMS.Length >= currFullMsgLen)
                        {
                            //至少收到一个完整包

                            //定义包体的byte[]数组
                            byte[] buffer = new byte[currMsgLen];

                            //把数据流指针放到2的位置 也就是包体的位置
                            m_ReceiveMS.Position = 2;

                            //把包体读到byte[]数组
                            m_ReceiveMS.Read(buffer, 0, currMsgLen);

                            lock (m_ReceiveQueue)
                            {
                                m_ReceiveQueue.Enqueue(buffer);
                            }
                            //==============处理剩余字节数组===================

                            //剩余字节长度
                            int remainLen = (int)m_ReceiveMS.Length - currFullMsgLen;
                            if (remainLen > 0)
                            {
                                //把指针放在第一个包的尾部
                                m_ReceiveMS.Position = currFullMsgLen;

                                //定义剩余字节数组
                                byte[] remainBuffer = new byte[remainLen];

                                //把数据流读到剩余字节数组
                                m_ReceiveMS.Read(remainBuffer, 0, remainLen);

                                //清空数据流
                                m_ReceiveMS.Position = 0;
                                m_ReceiveMS.SetLength(0);

                                //把剩余字节数组重新写入数据流
                                m_ReceiveMS.Write(remainBuffer, 0, remainBuffer.Length);

                                remainBuffer = null;
                            }
                            else
                            {
                                //没有剩余字节

                                //清空数据流
                                m_ReceiveMS.Position = 0;
                                m_ReceiveMS.SetLength(0);

                                break;
                            }
                        }
                        else
                        {
                            //还没有收到完整包
                            break;
                        }
                    }
                }

                //进行下一次接收数据包
                ReceiveMsg();
            }
            else
            {
                Close();
                //客户端断开连接
            }
        }
        #endregion

    }
}