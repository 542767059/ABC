using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZJY.Framework
{
    /// <summary>
    /// 角色特殊状态
    /// </summary>
    public enum SpecialStateType
    {
        InBattle,//战斗中

        PowerAttack,//强力攻击

        UnStoppable,//无法被打断的状态,比如霸体

        NotInControl,//玩家无法操作的状态

        Invincible, // 无敌

        CantDoAction, // 无法做任何行动

        Die // 死亡
        //后续什么沉默或者其他的状态,都可以在这里加. DEMO的话,这几个足够了
    }
}
