using UnityEngine;

namespace ZJY.Framework 
{
    /// <summary>
    /// 所有玩家基类(主角和其他玩家)
    /// </summary>
    public abstract class PlayerBase :RoleEntityBase
    {
        [SerializeField]
        private PlayerBaseData m_PlayerBaseData = null;

        [SerializeField]
        private PlayerBase m_Target;

        /// <summary>
        /// 角色的目标
        /// </summary>
        public PlayerBase Target
        {
            get
            {
                return m_Target;
            }
            set
            {
                m_Target = value;
            }
        }

        /// <summary>
        /// 获取玩家数据
        /// </summary>
        public PlayerBaseData PlayerBaseData
        {
            get
            {
                return m_PlayerBaseData;
            }
        }


        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_PlayerBaseData = userData as PlayerBaseData;

            if (m_PlayerBaseData == null)
            {
                Log.Error("PlayerBase data is invalid.");
                return;
            }
            Debug.Log(m_PlayerBaseData.RoleInfoBase.JobId);
            InitRoleUnitComponent();
        }

        protected internal override void OnAttachTo(EntityBase parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            SelfTransform.RestTransform();
        }

        protected internal override void OnDetachFrom(EntityBase parentEntity, object userData)
        {
            base.OnDetachFrom(parentEntity, userData);

            SelfTransform.position = parentEntity.SelfTransform.position;
            SelfTransform.rotation = parentEntity.SelfTransform.rotation;
        }

        private void InitRoleUnitComponent()
        {
            gameObject.SetLayerRecursively(Constant.Leyer.RoleLayerId);
            GetOrAddUnitComponent<AnimatorComponent>();
            GetOrAddUnitComponent<CharacterStateComponent>();
            GetOrAddUnitComponent<MoveComponent>();
            GetOrAddUnitComponent<MountsComponent>();
            GetOrAddUnitComponent<ActiveSkillComponent>();
            GetOrAddUnitComponent<BuffComponent>();
        }


    }
}
