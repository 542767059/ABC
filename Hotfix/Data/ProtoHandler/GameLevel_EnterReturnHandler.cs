using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hotfix
{
    /// <summary>
    /// 服务器返回进入关卡消息（工具只生成一次）
    /// </summary>
    public sealed class GameLevel_EnterReturnHandler
    {
        public static void OnGameLevel_EnterReturn(byte[] buffer)
        {
            GameLevel_EnterReturnProto proto = GameLevel_EnterReturnProto.GetProto(buffer);
#if DEBUG_LOG_PROTO
            Debug.Log("<color=#00eaff>接收消息:</color><color=#00ff9c>" + proto.ProtoEnName + " " + proto.ProtoCode + "</color>");
            Debug.Log("<color=#c5e1dc>==>>" + JsonUtility.ToJson(proto) + "</color>");
#endif
        }
    }
}