using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// Sound数据管理
    /// </summary>
    public partial class SoundDBModel : DataTableDBModelBase<SoundDBModel, SoundEntity>
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public override string DataTableName { get { return "Sound"; } }
    
        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                SoundEntity entity = new SoundEntity();
                entity.Id = ms.ReadInt();
                entity.Desc = ms.ReadUTF8String();
                entity.AssetName = ms.ReadUTF8String();
                entity.Priority = ms.ReadInt();
                entity.Loop = ms.ReadBool();
                entity.Volume = ms.ReadFloat();
                entity.SpatialBlend = ms.ReadFloat();
                entity.MaxDistance = ms.ReadFloat();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}
