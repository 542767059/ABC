using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

/// <summary>
/// 客户端发送查询任务消息
/// </summary>
public struct Task_SearchTaskProto : IProto
{
    public ushort ProtoCode { get { return 15001; } }
    public string ProtoEnName { get { return "Task_SearchTask"; } }


    public byte[] ToArray()
    {
        MMO_MemoryStream ms = GameEntry.Socket.SocketSendMS;
        ms.SetLength(0);
        ms.WriteUShort(ProtoCode);


        return ms.ToArray();
    }

    public static Task_SearchTaskProto GetProto(byte[] buffer)
    {
        Task_SearchTaskProto proto = new Task_SearchTaskProto();
        MMO_MemoryStream ms = GameEntry.Socket.SocketReceiveMS;
        ms.SetLength(0);
        ms.Write(buffer, 0, buffer.Length);
        ms.Position = 0;


        return proto;
    }
}