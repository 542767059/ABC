using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZJY.Framework;

/// <summary>
/// 服务器返回创建角色消息（工具只生成一次）
/// </summary>
public sealed class RoleOperation_CreateRoleReturnHandler
{
    public static void OnRoleOperation_CreateRoleReturn(byte[] buffer)
    {
        RoleOperation_CreateRoleReturnProto proto = RoleOperation_CreateRoleReturnProto.GetProto(buffer);
#if DEBUG_LOG_PROTO
        Debug.Log("<color=#00eaff>接收消息:</color><color=#00ff9c>" + proto.ProtoEnName + " " + proto.ProtoCode + "</color>");
        Debug.Log("<color=#c5e1dc>==>>" + JsonUtility.ToJson(proto) + "</color>");
#endif
        if (proto.IsSuccess)
        {
            Log.Info("创建角色成功");
            GameEntry.Procedure.SetData<VarInt>(Constant.ProcedureData.NextSceneId, 1);
        }
        else
        {
            GameEntry.UI.OpenDialog(new DialogParams()
            {
                Mode = 1,
                Title = "提示",
                Message = "用户名已存在",
            });
        }
    }
}