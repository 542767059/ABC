using System.Collections.Generic;

namespace ZJY.Framework
{
    public class CharacterStateComponent:UnitComponent
    {
        public readonly Dictionary<int, bool> StateDic = new Dictionary<int, bool>();

        public override void Init()
        {
            // 这里初始化base值
            Set(SpecialStateType.PowerAttack, false);
            Set(SpecialStateType.UnStoppable, false);
            Set(SpecialStateType.NotInControl, false);
            Set(SpecialStateType.Invincible, false);
            Set(SpecialStateType.CantDoAction, false);
            Set(SpecialStateType.InBattle, true);
            Set(SpecialStateType.Die, false);
        }

        public void Set(SpecialStateType st, bool value)
        {
            StateDic[(int)st] = value;
            GameEntry.Event.CommonEvent.Dispatch(this,GameEntry.Pool.SpawnClassObject<RoleStateChangeGameEvent>().Fill(Owner,st, value));
        }

        public bool Get(SpecialStateType st)
        {
            return StateDic[(int)st];
        }
    }
}
