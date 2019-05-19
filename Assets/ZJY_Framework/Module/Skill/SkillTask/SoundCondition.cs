using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZJY.Framework
{ 
    /// <summary>
    /// 声音任务
    /// </summary>
    public class SoundCondition:OnceTaskCondition
    {
        public SoundCondition(Skill skill):base(skill)
        {

        }

        public override void Start()
        {
            base.Start();

            UnityEngine.Debug.Log("播放声音");
            
            SkillData skillData = m_Skill.SkillData;
            GameEntry.Sound.PlaySound(skillData.SoundId, m_Skill.Caster);
        }
    }
}
