using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// ChapterXLSX数据管理
    /// </summary>
    public partial class ChapterXLSXDBModel : DataTableDBModelBase<ChapterXLSXDBModel, ChapterXLSXEntity>
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public override string DataTableName { get { return "ChapterXLSX"; } }
    
        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                ChapterXLSXEntity entity = new ChapterXLSXEntity();
                entity.Id = ms.ReadInt();
                entity.ChapterName = ms.ReadUTF8String();
                entity.GameLevelCount = ms.ReadInt();
                entity.BG_Pic = ms.ReadUTF8String();
                entity.Uvx = ms.ReadFloat();
                entity.Uvy = ms.ReadFloat();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}
