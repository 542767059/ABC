using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// 世界地图流程
    /// </summary>
    public class ProcedureWorldMap : ProcedureBase
    {
        public override void OnEnter()
        {
            base.OnEnter();

            if (ManiUI.Instance == null)
            {
                GameEntry.UI.OpenUIForm(UIFormId.MainUI);
            }
            GameEntry.Entity.ShowMainPlayer();
            //todo 显示其他玩家
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate( deltaTime,  unscaledDeltaTime);
        }

        public override void OnLeave()
        {
            base.OnLeave();
        }

        public override void OnDestory()
        {
            base.OnDestory();
        }
    }
}
