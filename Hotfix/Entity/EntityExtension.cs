using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZJY.Framework;

namespace Hotfix
{
    public static class EntityExtension
    {
        public static void ShowSelectRoleEntity(this Hotfix.EntityComponent entityComponent, SelectRoleData data)
        {
            JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();
            JobEntity jobEntity = jobDBModel.Get(data.JobId);
            if (jobEntity == null)
            {
                Log.Warning("Can not load createrole entity id '{0}' from data table.", data.JobId.ToString());
                return;
            }

            SceneDBModel sceneDBModel = GameEntry.DataTable.GetDataTable<SceneDBModel>();
            SceneEntity sceneEntity = sceneDBModel.Get((int)SceneType.SelectRole);
            if (sceneEntity == null)
            {
                Log.Warning("Can not load scene data id '{0}' from data table.", data.JobId.ToString());
                return;
            }
            
            Vector3 postion = Vector3.zero;
            Quaternion rotation = Quaternion.identity;

            if (GameUtil.GetRoleBornPos(sceneEntity.RoleBirthPos,out postion,out rotation))
            {
                data.Position = postion;
                data.Rotation = rotation;
            }
            

            entityComponent.ShowEntity(data.Id, typeof(SelectRoleEntity), ZJY.Framework.AssetUtility.GetRoleAsset(jobEntity.AssetName), "Role", Constant.AssetPriority.RolePlayerAsset, data);
        }

        
    }
}
