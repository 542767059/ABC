using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZJY.Framework;

/// <summary>
/// 服务器返回删除角色消息（工具只生成一次）
/// </summary>
public sealed class RoleOperation_DeleteRoleReturnHandler
{
    public static void OnRoleOperation_DeleteRoleReturn(byte[] buffer)
    {
        RoleOperation_DeleteRoleReturnProto proto = RoleOperation_DeleteRoleReturnProto.GetProto(buffer);
#if DEBUG_LOG_PROTO
        Debug.Log("<color=#00eaff>接收消息:</color><color=#00ff9c>" + proto.ProtoEnName + " " + proto.ProtoCode + "</color>");
        Debug.Log("<color=#c5e1dc>==>>" + JsonUtility.ToJson(proto) + "</color>");
#endif
        if (proto.IsSuccess)
        {
            GameEntry.UI.OpenDialog(new DialogParams()
            {
                Mode = 1,
                Title = "提示",
                Message = "删除角色成功",
            });
            //删除角色成功
            GameEntry.Event.CommonEvent.Dispatch(GameEntry.Socket.MainSocket, GameEntry.Pool.SpawnClassObject<DeleateRoleSuccessGameEvent>());

        }
        else
        {
            GameEntry.UI.OpenDialog(new DialogParams()
            {
                Mode = 1,
                Title = "提示",
                Message = "删除角色失败",
            });
        }
    }
}