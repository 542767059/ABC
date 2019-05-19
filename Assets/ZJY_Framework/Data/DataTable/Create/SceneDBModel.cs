using System.Collections;
using System.Collections.Generic;
using System;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// Scene数据管理
    /// </summary>
    public partial class SceneDBModel : DataTableDBModelBase<SceneDBModel, SceneEntity>
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public override string DataTableName { get { return "Scene"; } }
    
        /// <summary>
        /// 加载列表
        /// </summary>
        protected override void LoadList(MMO_MemoryStream ms)
        {
            int rows = ms.ReadInt();
            int columns = ms.ReadInt();

            for (int i = 0; i < rows; i++)
            {
                SceneEntity entity = new SceneEntity();
                entity.Id = ms.ReadInt();
                entity.Desc = ms.ReadUTF8String();
                entity.AssetName = ms.ReadUTF8String();
                entity.BackgroundMusicId = ms.ReadInt();
                entity.RoleBirthPos = ms.ReadUTF8String();
                entity.SmallMapImageAssets = ms.ReadUTF8String();
                entity.SmallMapSize = ms.ReadInt();

                m_List.Add(entity);
                m_Dic[entity.Id] = entity;
            }
        }
    }
}
