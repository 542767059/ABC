using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

/// <summary>
/// 服务器返回进入关卡消息
/// </summary>
public struct GameLevel_EnterReturnProto : Hotfix.IProto
{
    public ushort ProtoCode { get { return 12002; } }
    public string ProtoEnName { get { return "GameLevel_EnterReturn"; } }

    public bool IsSuccess; //是否成功
    public int MsgCode; //消息码

    public byte[] ToArray()
    {
        MMO_MemoryStream ms = GameEntry.Socket.SocketSendMS;
        ms.SetLength(0);
        ms.WriteUShort(ProtoCode);

        ms.WriteBool(IsSuccess);
        if (!IsSuccess)
        {
            ms.WriteInt(MsgCode);
        }

        return ms.ToArray();
    }

    public static GameLevel_EnterReturnProto GetProto(byte[] buffer)
    {
        GameLevel_EnterReturnProto proto = new GameLevel_EnterReturnProto();
        MMO_MemoryStream ms = GameEntry.Socket.SocketReceiveMS;
        ms.SetLength(0);
        ms.Write(buffer, 0, buffer.Length);
        ms.Position = 0;

        proto.IsSuccess = ms.ReadBool();
        if (!proto.IsSuccess)
        {
            proto.MsgCode = ms.ReadInt();
        }

        return proto;
    }
}