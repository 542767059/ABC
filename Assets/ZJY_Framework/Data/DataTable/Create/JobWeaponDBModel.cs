using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// JobWeapon数据管理
    /// </summary>
    public partial class JobWeaponDBModel : DataTableDBModelBase<JobWeaponDBModel, JobWeaponEntity>
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public override string DataTableName { get { return "JobWeapon"; } }
    
        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                JobWeaponEntity entity = new JobWeaponEntity();
                entity.Id = ms.ReadInt();
                entity.JobId = ms.ReadInt();
                entity.WeaponId = ms.ReadInt();
                entity.AssetName = ms.ReadUTF8String();
                entity.WeaponFighting = ms.ReadInt();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}
