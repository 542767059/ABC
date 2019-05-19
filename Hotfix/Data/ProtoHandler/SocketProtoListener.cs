using ZJY.Framework;

namespace Hotfix
{
    /// <summary>
    /// Socket协议监听（工具生成）
    /// </summary>
    public sealed class SocketProtoListener
    {
        /// <summary>
        /// 添加协议监听
        /// </summary>
        public static void AddProtoListener()
        {
            GameEntry.Event.SocketEvent.AddEventListener(ProtoCodeDef.GameLevel_EnterReturn, GameLevel_EnterReturnHandler.OnGameLevel_EnterReturn);
        }

        /// <summary>
        /// 移除协议监听
        /// </summary>
        public static void RemoveProtoListener()
        {
            GameEntry.Event.SocketEvent.RemoveEventListener(ProtoCodeDef.GameLevel_EnterReturn, GameLevel_EnterReturnHandler.OnGameLevel_EnterReturn);
        }
    }
}
