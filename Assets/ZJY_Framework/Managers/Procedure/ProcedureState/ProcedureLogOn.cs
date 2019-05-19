using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// 登录流程
    /// </summary>
    public class ProcedureLogOn : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();

            if (GameEntry.Socket.MainSocket != null && GameEntry.Socket.MainSocket.Connected)
            {
                GameEntry.Socket.MainSocket.Close();
            }

            GameEntry.UI.OpenUIForm(UIFormId.LogOn, this);
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
        }

        public override void OnLeave()
        {
            base.OnLeave();
        }

    }
}