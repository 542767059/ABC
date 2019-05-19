using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// Job数据管理
    /// </summary>
    public partial class JobDBModel : DataTableDBModelBase<JobDBModel, JobEntity>
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public override string DataTableName { get { return "Job"; } }
    
        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                JobEntity entity = new JobEntity();
                entity.Id = ms.ReadInt();
                entity.Name = ms.ReadUTF8String();
                entity.CreateRoleAssetName = ms.ReadUTF8String();
                entity.AssetName = ms.ReadUTF8String();
                entity.Sex = ms.ReadInt();
                entity.HeadNotSelectAssetName = ms.ReadUTF8String();
                entity.HeadSelectAssetName = ms.ReadUTF8String();
                entity.DescImageAssetName = ms.ReadUTF8String();
                entity.DescAllAssetName = ms.ReadUTF8String();
                entity.DescSpecificAssetName = ms.ReadUTF8String();
                entity.Attack = ms.ReadInt();
                entity.Defense = ms.ReadInt();
                entity.Hit = ms.ReadInt();
                entity.Dodge = ms.ReadInt();
                entity.Cri = ms.ReadInt();
                entity.Res = ms.ReadInt();
                entity.UsedPhyAttackIds = ms.ReadUTF8String();
                entity.UsedSkillIds = ms.ReadUTF8String();
                entity.RoleController = ms.ReadUTF8String();
                entity.WeaponPointCount = ms.ReadInt();
                entity.WeaponPoint1 = ms.ReadUTF8String();
                entity.WeaponPoint2 = ms.ReadUTF8String();
                entity.WeaponPoint3 = ms.ReadUTF8String();
                entity.WeaponPoint4 = ms.ReadUTF8String();
                entity.WingPoint = ms.ReadUTF8String();
                entity.WingController = ms.ReadUTF8String();
                entity.TrumpPoint = ms.ReadUTF8String();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}
