using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZJY.Framework;

/// <summary>
/// 服务器返回登录信息（工具只生成一次）
/// </summary>
public sealed class RoleOperation_LogOnGameServerReturnHandler
{
    public static void OnRoleOperation_LogOnGameServerReturn(byte[] buffer)
    {
        RoleOperation_LogOnGameServerReturnProto proto = RoleOperation_LogOnGameServerReturnProto.GetProto(buffer);
#if DEBUG_LOG_PROTO
        Debug.Log("<color=#00eaff>接收消息:</color><color=#00ff9c>" + proto.ProtoEnName + " " + proto.ProtoCode + "</color>");
        Debug.Log("<color=#c5e1dc>==>>" + JsonUtility.ToJson(proto) + "</color>");
#endif
        
        GameEntry.Data.UserData.RoleLists.Clear();
        int roleCount = proto.RoleCount;
        for (int i = 0; i < roleCount; i++)
        {
            RoleItem roleItem = new RoleItem();
            roleItem.RoleId = proto.RoleList[i].RoleId;
            roleItem.RoleJob = proto.RoleList[i].RoleJob;
            roleItem.RoleLevel = proto.RoleList[i].RoleLevel;
            roleItem.RoleNickName = proto.RoleList[i].RoleNickName;
            GameEntry.Data.UserData.RoleLists.Add(roleItem);
        }
        GameEntry.Event.CommonEvent.Dispatch(GameEntry.Socket.MainSocket, GameEntry.Pool.SpawnClassObject<LogOnGameServerReturnGameEvent>().Fill(roleCount));
    }
}