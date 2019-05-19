using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 技能释放结束
    /// </summary>
    /// <param name="skill"></param>
    public delegate void SkillComplate(Skill skill);

    /// <summary>
    /// 技能
    /// </summary>
    public class Skill
    {
        private SkillData m_SkillData;
        private SkillComplate m_Complate;
        private PlayerBase m_Target;
        private PlayerBase m_Caster;

        private VarVector3 m_EffectPos;

        public VarVector3 EffectPos
        {
            get
            {
                return m_EffectPos;
            }
            set
            {
                m_EffectPos = value;
            }
        }


        /// <summary>
        /// 技能数据
        /// </summary>
        public SkillData SkillData
        {
            get
            {
                return m_SkillData;
            }

            set
            {
                m_SkillData = value;
            }
        }

        /// <summary>
        /// 目标
        /// </summary>
        public PlayerBase Target
        {
            get
            {
                return m_Target;
            }

            set
            {
                m_Target = value;
            }
        }

        /// <summary>
        /// 释放者
        /// </summary>
        public PlayerBase Caster
        {
            get
            {
                return m_Caster;
            }

            set
            {
                m_Caster = value;
            }
        }
        /// <summary>
        /// 技能结束
        /// </summary>
        public void End()
        {
            if (this.m_Complate != null)
            {
                this.m_Complate(this);
            }
        }

        public bool IsValid(IVerify verify)
        {
            if (verify != null)
            {
                bool valid = verify.Verify(this.Caster, this.Target, this.SkillData);
                if (!valid)
                {
                    Interrupt(new InterruptValid());
                    return false;
                }
                return true;
            }
            return true;
        }

        public bool IsValid(List<IVerify> verifyList)
        {
            if (verifyList != null && verifyList.Count > 0)
            {
                if (verifyList.Count == 1) return IsValid(verifyList[0]);
                //多余一个的验证条件需要先排序
                verifyList.Sort(delegate (IVerify x, IVerify y)
                {
                    return x.Priority().CompareTo(y.Priority());
                });
                foreach (var verify in verifyList)
                {
                    if (!IsValid(verify))
                    {
                        return false;
                    }
                }
            }
            return true;

        }

        public void Interrupt(IInterrupt interrupt)
        {
            if (interrupt != null)
            {
                interrupt.Handle(this.Caster);
            }
            End();
        }

        public int Caculate(IDamage damage)
        {
            //驱散处理
            //this.m_Caster.GetOrAddUnitComponent<BuffComponent>().Disperse(this.m_SkillData.Mute);
            //处理计算后的返回值
            return damage.Handle(this);
        }

        public void Init<T, U>(T caster, U target, SkillData skillData, VarVector3 effectpos = null, SkillComplate complate = null)
            where T : PlayerBase
            where U : PlayerBase
        {
            this.Target = target;
            this.Caster = caster;
            this.SkillData = skillData;
            this.m_Complate = complate;
            this.m_EffectPos = effectpos;
        }
    }
}
