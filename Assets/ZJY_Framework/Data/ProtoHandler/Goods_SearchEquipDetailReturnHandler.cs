using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 服务器返回查询装备详情消息（工具只生成一次）
/// </summary>
public sealed class Goods_SearchEquipDetailReturnHandler
{
    public static void OnGoods_SearchEquipDetailReturn(byte[] buffer)
    {
        Goods_SearchEquipDetailReturnProto proto = Goods_SearchEquipDetailReturnProto.GetProto(buffer);
#if DEBUG_LOG_PROTO
        Debug.Log("<color=#00eaff>接收消息:</color><color=#00ff9c>" + proto.ProtoEnName + " " + proto.ProtoCode + "</color>");
        Debug.Log("<color=#c5e1dc>==>>" + JsonUtility.ToJson(proto) + "</color>");
#endif
    }
}