using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 服务器返回背包物品更新消息（工具只生成一次）
/// </summary>
public sealed class Backpack_GoodsChangeReturnHandler
{
    public static void OnBackpack_GoodsChangeReturn(byte[] buffer)
    {
        Backpack_GoodsChangeReturnProto proto = Backpack_GoodsChangeReturnProto.GetProto(buffer);
#if DEBUG_LOG_PROTO
        Debug.Log("<color=#00eaff>接收消息:</color><color=#00ff9c>" + proto.ProtoEnName + " " + proto.ProtoCode + "</color>");
        Debug.Log("<color=#c5e1dc>==>>" + JsonUtility.ToJson(proto) + "</color>");
#endif
    }
}