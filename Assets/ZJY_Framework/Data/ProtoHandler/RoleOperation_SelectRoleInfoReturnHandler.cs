using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZJY.Framework;

/// <summary>
/// 服务器返回角色信息（工具只生成一次）
/// </summary>
public sealed class RoleOperation_SelectRoleInfoReturnHandler
{
    public static void OnRoleOperation_SelectRoleInfoReturn(byte[] buffer)
    {
        RoleOperation_SelectRoleInfoReturnProto proto = RoleOperation_SelectRoleInfoReturnProto.GetProto(buffer);
#if DEBUG_LOG_PROTO
        Debug.Log("<color=#00eaff>接收消息:</color><color=#00ff9c>" + proto.ProtoEnName + " " + proto.ProtoCode + "</color>");
        Debug.Log("<color=#c5e1dc>==>>" + JsonUtility.ToJson(proto) + "</color>");
#endif
        
        Debug.Log("设置角色信息");
        if (proto.IsSuccess)
        {
            //todo
            GameEntry.Data.CacheData.LastInWorldMapId = proto.LastInWorldMapId;
            GameEntry.Data.CacheData.LastInWorldMapPos = proto.LastInWorldMapPos;
            if (string.IsNullOrEmpty(proto.LastInWorldMapPos))
            {
                GameEntry.Data.CacheData.NextWorldMapPos = GameEntry.DataTable.GetDataTable<SceneDBModel>().Get(proto.LastInWorldMapId).RoleBirthPos;
            }

            GameEntry.Data.UserData.RoleInfo = new RoleInfo(proto);

            GameEntry.Procedure.SetData<VarInt>(Constant.ProcedureData.NextSceneId, proto.LastInWorldMapId);
            GameEntry.UI.OpenUIForm(UIFormId.Loading);
        }
        else
        {
            //todo
        }
    }
}