using System.Collections.Generic;

namespace ZJY.Framework
{
    /// <summary>
    /// buff组件
    /// </summary>
    public class BuffComponent : UnitComponent
    {
        private Dictionary<int, BaseBuffHandler> Buffs = new Dictionary<int, BaseBuffHandler>();
        private readonly List<BaseBuffHandler> m_TempBuffs = new List<BaseBuffHandler>();

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);

            m_TempBuffs.Clear();

            foreach (var buffHandler in Buffs.Values)
            {
                if (buffHandler.BuffTimeType == BuffTimeType.LifeTime)
                {
                    m_TempBuffs.Add(buffHandler);
                }
            }

            foreach (BaseBuffHandler buff in m_TempBuffs)
            {
                buff.OnUpdate(deltaTime, unscaledDeltaTime);
            }

        }

        public void AddBuff(int buffId)
        {
            BufferHandler_Power bufferHandler_Power = new BufferHandler_Power();
            bufferHandler_Power.buffTime = 10f;
            Buffs[buffId] = bufferHandler_Power;

            BuffHandlerVar buffHandlerVar = new BuffHandlerVar();
            buffHandlerVar.source = (PlayerBase)Owner;
            buffHandlerVar.buffId = buffId;
            bufferHandler_Power.AddHandle(buffHandlerVar);
        }


        public void RemoveBuff(int buffId)
        {
            BaseBuffHandler baseBuffHandler = null;
            if (Buffs.TryGetValue(buffId, out baseBuffHandler))
            {
                if (baseBuffHandler is IBuffRemoveHanlder)
                {
                    IBuffRemoveHanlder removeHanlder = (IBuffRemoveHanlder)baseBuffHandler;
                    removeHanlder.Remove(baseBuffHandler.BuffHandlerVar);
                }
                Buffs.Remove(buffId);
            }
        }
    }
}
