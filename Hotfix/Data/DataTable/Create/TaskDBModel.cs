using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

namespace Hotfix
{
    /// <summary>
    /// Task数据管理
    /// </summary>
    public partial class TaskDBModel : DataTableDBModelBase<TaskDBModel, TaskEntity>
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public override string DataTableName { get { return "Task"; } }
    
        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                TaskEntity entity = new TaskEntity();
                entity.Id = ms.ReadInt();
                entity.Name = ms.ReadUTF8String();
                entity.Status = ms.ReadInt();
                entity.Content = ms.ReadUTF8String();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}
