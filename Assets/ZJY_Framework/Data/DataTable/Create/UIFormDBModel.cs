using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// UIForm数据管理
    /// </summary>
    public partial class UIFormDBModel : DataTableDBModelBase<UIFormDBModel, UIFormEntity>
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public override string DataTableName { get { return "UIForm"; } }
    
        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                UIFormEntity entity = new UIFormEntity();
                entity.Id = ms.ReadInt();
                entity.Desc = ms.ReadUTF8String();
                entity.AssetName = ms.ReadUTF8String();
                entity.UIGroupName = ms.ReadUTF8String();
                entity.AllowMultiInstance = ms.ReadBool();
                entity.PauseCoveredUIForm = ms.ReadBool();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}
