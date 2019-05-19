
namespace ZJY.Framework
{
    /// <summary>
    /// 强力buff
    /// </summary>
    public class BufferHandler_Power : BaseBuffHandler, IBuffAddHanlder, IBuffRemoveHanlder
    {
        public override BuffTimeType BuffTimeType
        {
            get
            {
                return BuffTimeType.LifeTime;
            }
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            buffTime -= deltaTime;
            if (buffTime <= 0)
            {
                BuffHandlerVar.source.GetUnitComponent<BuffComponent>().RemoveBuff(BuffHandlerVar.buffId);
            }
        }


        public void AddHandle(BuffHandlerVar buffHandlerVar)
        {
            BuffHandlerVar = buffHandlerVar;

            UnityEngine.Debug.Log("增加强力buff");

            buffHandlerVar.source.GetUnitComponent<CharacterStateComponent>().Set(SpecialStateType.PowerAttack, true);
            GameEntry.Entity.ShowBuffEffect("buff_atk_add", buffHandlerVar.source.Id, "S_GC/Top", this);
        }

        public void Remove(BuffHandlerVar buffHandlerVar)
        {
            UnityEngine.Debug.Log("移除强力buff");
            buffHandlerVar.source.GetUnitComponent<CharacterStateComponent>().Set(SpecialStateType.PowerAttack, false);
            if (Effect != null)
            {
                GameEntry.Entity.HideEntity(Effect);
            }
        }
    }
}
