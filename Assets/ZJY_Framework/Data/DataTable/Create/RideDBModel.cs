using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// Ride数据管理
    /// </summary>
    public partial class RideDBModel : DataTableDBModelBase<RideDBModel, RideEntity>
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public override string DataTableName { get { return "Ride"; } }
    
        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                RideEntity entity = new RideEntity();
                entity.Id = ms.ReadInt();
                entity.AssetName = ms.ReadUTF8String();
                entity.RideType = ms.ReadInt();
                entity.Point = ms.ReadUTF8String();
                entity.RideName = ms.ReadUTF8String();
                entity.RideFighting = ms.ReadInt();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}
