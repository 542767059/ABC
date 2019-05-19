using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// Trump数据管理
    /// </summary>
    public partial class TrumpDBModel : DataTableDBModelBase<TrumpDBModel, TrumpEntity>
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public override string DataTableName { get { return "Trump"; } }
    
        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                TrumpEntity entity = new TrumpEntity();
                entity.Id = ms.ReadInt();
                entity.AssetName = ms.ReadUTF8String();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}
