using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 创建角色实体
    /// </summary>
    public class CreateRoleEntity : Entity
    {
        [SerializeField]
        private CreateRoleData m_CreateRoleData = null;

        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_CreateRoleData = userData as CreateRoleData;
            if (m_CreateRoleData == null)
            {
                Log.Error("CreateRole data is invalid.");
                return;
            }
        }
    }
}
