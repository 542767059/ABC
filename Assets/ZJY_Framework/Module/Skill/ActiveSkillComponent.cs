using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    public delegate void TrigSkill(Skill skill);

    /// <summary>
    /// 主动技能组件
    /// </summary>
    public class ActiveSkillComponent : UnitComponent
    {
        private SkillTaskManager m_SkillTaskManager;

        /// <summary>
        /// 需要根据需要初始化技能数据
        /// </summary>
        private Dictionary<int, SkillData> m_Skills;

        public override void Init()
        {
            base.Init();
            m_SkillTaskManager = GameEntry.Pool.SpawnClassObject<SkillTaskManager>();
            m_SkillTaskManager.RemoveAllTask();


            m_Skills = GameEntry.Pool.SpawnClassObject<Dictionary<int, SkillData>>();
            m_Skills.Clear();

            m_Skills[10001] = new SkillData()
            {
                SkillId = 10001,
                IsNormalAttack = 1,
                SkillAnimatorIndex = 1,
                Skill_effect_name = "skill_mxz_attack1",
                Skill_effect_time = 1f,
                SoundId = 10001,
                SkillNeedTime = 0.7f,
            };

            m_Skills[10002] = new SkillData()
            {
                SkillId = 10002,
                IsNormalAttack = 1,
                SkillAnimatorIndex = 2,
                Skill_effect_name = "skill_mxz_attack2",
                Skill_effect_time = 1.333f,
                SoundId = 10002,
                SkillNeedTime = 1.033f,
            };

            m_Skills[10003] = new SkillData()
            {
                SkillId = 10003,
                IsNormalAttack = 1,
                SkillAnimatorIndex = 3,
                Skill_effect_name = "skill_mxz_attack3",
                Skill_effect_time = 1f,
                SoundId = 10003,
                SkillNeedTime = 0.7f,
            };

            m_Skills[10004] = new SkillData()
            {
                SkillId = 10004,
                IsNormalAttack = 1,
                SkillAnimatorIndex = 4,
                Skill_effect_name = "skill_mxz_attack4",
                Skill_effect_time = 1.3f,
                SoundId = 10004,
                SkillNeedTime = 1f,
            };

            m_Skills[10005] = new SkillData()
            {
                SkillId = 10005,
                IsNormalAttack = 1,
                SkillAnimatorIndex = 5,
                Skill_effect_name = "skill_mxz_204_1",
                Skill_effect_time = 0.933f,
                SoundId = 10016,
                SkillNeedTime = 0.633f,
            };

            m_Skills[10006] = new SkillData()
            {
                SkillId = 10006,
                IsNormalAttack = 1,
                SkillAnimatorIndex = 6,
                Skill_effect_name = "skill_mxz_204_2",
                Skill_effect_time = 0.933f,
                SoundId = 10017,
                SkillNeedTime = 0.633f,
            };

            m_Skills[10007] = new SkillData()
            {
                SkillId = 10007,
                IsNormalAttack = 1,
                SkillAnimatorIndex = 7,
                Skill_effect_name = "skill_mxz_204_3",
                Skill_effect_time = 1.667f,
                SoundId = 10018,
                SkillNeedTime = 1.367f,
            };

          
            m_Skills[10008] = new SkillData()
            {
                SkillId = 10008,
                IsNormalAttack = 0,
                SkillAnimatorIndex = 7,
                Skill_effect_name = "skill_mxz_104",
                Skill_effect_time = 1.2f,
                SoundId = 10013,
                SkillNeedTime = 0.9f,
            };

            m_Skills[10009] = new SkillData()
            {
                SkillId = 10009,
                IsNormalAttack = 0,
                SkillAnimatorIndex = 8,
                Skill_effect_name = "skill_mxz_201",
                Skill_effect_time = 1.113f,
                SoundId = 10014,
                SkillNeedTime = 0.913f,
            };

            m_Skills[10010] = new SkillData()
            {
                SkillId = 10010,
                IsNormalAttack = 0,
                SkillAnimatorIndex = 4,
                Skill_effect_name = "skill_mxz_103_1",
                Skill_effect_time = 1.167f,
                SoundId = 10010,
                SkillNeedTime = 0.867f,
            };

            m_Skills[10011] = new SkillData()
            {
                SkillId = 10011,
                IsNormalAttack = 0,
                SkillAnimatorIndex = 5,
                Skill_effect_name = "skill_mxz_103_2",
                Skill_effect_time = 1.167f,
                SoundId = 10011,
                SkillNeedTime = 0.867f,
            };

            m_Skills[10012] = new SkillData()
            {
                SkillId = 10012,
                IsNormalAttack = 0,
                SkillAnimatorIndex = 6,
                Skill_effect_name = "skill_mxz_103_3",
                Skill_effect_time = 1.467f,
                SoundId = 10012,
                SkillNeedTime = 1.167f,
            };

            m_Skills[10013] = new SkillData()
            {
                SkillId = 10013,
                IsNormalAttack = 0,
                SkillAnimatorIndex = 12,
                Skill_effect_name = "skill_mxz_204",
                Skill_effect_time = 1,
                SoundId = 10019,
                SkillNeedTime = 0.7f,
            };
            //todo
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            m_SkillTaskManager.OnUpdate(deltaTime, unscaledDeltaTime);
        }

        public override void Shutdown()
        {
            base.Shutdown();

            GameEntry.Pool.UnSpawnClassObject(m_SkillTaskManager);
            m_SkillTaskManager = null;

            GameEntry.Pool.UnSpawnClassObject(m_Skills);
            m_Skills.Clear();
            m_Skills = null;
        }

        /// <summary>
        /// 技能的合法性验证， 通过TrigSkill返回触发的技能
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="caster">施法者</param>
        /// <param name="target">目标</param>
        /// <param name="trig">技能触发</param>
        /// <param name="effectpos">特效位置</param>
        /// <param name="complate">技能完成回掉</param>
        public void Verify(int skillId, PlayerBase caster, PlayerBase target, TrigSkill trig,VarVector3 effectpos, SkillComplate complate)
        {
            //查阅技能
            if (!m_Skills.ContainsKey(skillId))
            {
                throw new KeyNotFoundException(string.Format("{0} 不在技能表", skillId));
            }
            SkillData skilldata = m_Skills[skillId];

            //使用技能属性初始化技能[这里后续使用对象池获取对象，暂时直接new]
            Skill skill = new Skill();
            skill.Init(caster, target, skilldata, effectpos,complate);

            //检查释放条件
            //蓝耗检查
            if (skilldata.SpendMP > 0)
            {
                if (!skill.IsValid(new MpVerify()))
                {
                    trig(null);
                    return;
                }
            }
            //to-do其他检查
            trig(skill);
        }

        /// <summary>
        /// 用于检查技能结束的时候释放
        /// </summary>
        /// <param name="skill"></param>
        public void Fire(Skill skill)
        {
            //伤害计算
            DamageCondtion dmgCond = new DamageCondtion(skill, delegate (int result) { HandleCast(skill, result); });
            SkillTask dmgTask = new SkillTask("伤害检查", dmgCond);
            m_SkillTaskManager.AddTask(dmgTask);
            //启动任务队列
            m_SkillTaskManager.Start(">>>技能伤害计算流程");
        }

        /// <summary>
        /// 处理施法(用于 直接释放技能)
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="result"></param>
        public void HandleCast(Skill skill, int result)
        {
            //技能结束时间
            float skillOverTime = Time.time + skill.SkillData.SkillNeedTime;

            //播放动作
            SkillTask motionTask = new SkillTask("播放动作", new MotionCondition(skill));
            m_SkillTaskManager.AddTask(motionTask);

            //播放声音
            SkillTask soundTask = new SkillTask("播放声音", new SoundCondition(skill));
            m_SkillTaskManager.AddTask(soundTask);

            //释放特效
            SkillTask emitTask = new SkillTask("释放特效", new CastCondition(skill));
            m_SkillTaskManager.AddTask(emitTask);

            SkillTask skillTimeTask = new SkillTask("技能时长", new TimeAfterCondtion(skillOverTime));
            m_SkillTaskManager.AddTask(skillTimeTask);
            //打击效果
            //SkillTask hitTask = new SkillTask("打击效果", new HitCondition(skill, result, skill.SkillData.HurtDealy));
            //m_SkillTaskManager.AddTask(hitTask);

            //启动任务队列
            m_SkillTaskManager.Start(">>>技能施法流程", delegate ()
            {
                skill.End();
            });
        }
    }
}
