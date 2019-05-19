using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// Skill数据管理
    /// </summary>
    public partial class SkillDBModel : DataTableDBModelBase<SkillDBModel, SkillEntity>
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public override string DataTableName { get { return "Skill"; } }
    
        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                SkillEntity entity = new SkillEntity();
                entity.Id = ms.ReadInt();
                entity.SkillName = ms.ReadUTF8String();
                entity.SkillDesc = ms.ReadUTF8String();
                entity.SkillIcon = ms.ReadUTF8String();
                entity.SkillIndex = ms.ReadInt();
                entity.SkillNeedTime = ms.ReadInt();
                entity.Skill_Effect_Name = ms.ReadUTF8String();
                entity.Skill_Effect_Time = ms.ReadFloat();
                entity.SoundId = ms.ReadInt();
                entity.LevelLimit = ms.ReadInt();
                entity.IsPhyAttack = ms.ReadInt();
                entity.AttackTargetCount = ms.ReadInt();
                entity.AttackRange = ms.ReadFloat();
                entity.AreaAttackRadius = ms.ReadFloat();
                entity.ShowHurtEffectDelaySecond = ms.ReadFloat();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}
