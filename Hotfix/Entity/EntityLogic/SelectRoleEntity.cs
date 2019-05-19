using UnityEngine;
using ZJY.Framework;

namespace Hotfix
{
    /// <summary>
    /// 选择角色实体
    /// </summary>
    public class SelectRoleEntity : HotEntityBase
    {
        private SelectRoleData m_SelectRoleData = null;

        private Animator m_Animator;

        public override void OnInit(HotEntity entity, object userData)
        {
            base.OnInit(entity, userData);
            m_Animator = entity.gameObject.GetOrAddComponent<Animator>();
        }

        public override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_SelectRoleData = userData as SelectRoleData;
            if (m_SelectRoleData == null)
            {
                Log.Error("SelectRole data is invalid.");
                return;
            }

            JobAvtarDBModel jobAvtarDBModel = GameEntry.DataTable.GetDataTable<JobAvtarDBModel>();
            JobAvtarEntity jobAvtarEntity = jobAvtarDBModel.Get(m_SelectRoleData.JobId, m_SelectRoleData.AvtarId);
            if (jobAvtarEntity == null)
            {
                Log.Warning("Can not load jobavatar id '{0}' from data table.", m_SelectRoleData.JobId.ToString());
                return;
            }
            GameEntry.Avtar.ChangeSkinnedMesh(Entity, ZJY.Framework.AssetUtility.GetRoleAsset(jobAvtarEntity.AssetName));

            JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();
            JobEntity jobEntity = jobDBModel.Get(m_SelectRoleData.JobId);
            if (jobEntity == null)
            {
                Log.Warning("Can not load job controller id '{0}' from data table.", m_SelectRoleData.JobId.ToString());
                return;
            }
            GameEntry.Controller.SetController(m_Animator, ZJY.Framework.AssetUtility.GetRoleControllerAsset(jobEntity.RoleController));

            GameEntry.Entity.ShowWing(Entity, m_SelectRoleData.JobId, m_SelectRoleData.WingId);
            GameEntry.Entity.ShowWeapon(Entity, m_SelectRoleData.JobId, m_SelectRoleData.WingId);
            GameEntry.Entity.ShowMagic(Entity, m_SelectRoleData.JobId, m_SelectRoleData.WingId);
        }
    }
}
