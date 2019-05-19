using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 坐骑
    /// </summary>
    public  class Mounts :Entity
    {
        [SerializeField]
        private MountsData m_MountsData;

        [SerializeField]
        private PlayerBase m_Owner;

        [SerializeField]
        private CharacterController m_CharacterController;

        public CharacterController CharacterController
        {
            get
            {
                return m_CharacterController;
            }
        }

        public AnimatorComponent animatorComponent;

        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);
            
            m_MountsData = userData as MountsData;

            if (m_MountsData == null)
            {
                GameEntry.Entity.HideEntity(this);
                Log.Error("Mounts data is invalid.");
                return;
            }

            m_CharacterController = gameObject.GetOrAddComponent<CharacterController>();
            m_CharacterController.center = new Vector3(0, 1, 0);
            m_CharacterController.height = 2f;
            m_CharacterController.radius = 0.5f;
            m_CharacterController.stepOffset = 0.5f;

            animatorComponent = GetOrAddUnitComponent<AnimatorComponent>();

            m_Owner = (PlayerBase)GameEntry.Entity.GetEntity(m_MountsData.OwnerId);
            
            if (m_Owner == null || !m_Owner.IsAvailable)
            {
                GameEntry.Entity.HideEntity(this);
                return;
            }
            
            MountsComponent mountsComponent = m_Owner.GetUnitComponent<MountsComponent>();

            if (mountsComponent == null || mountsComponent.IsRide)
            {
                GameEntry.Entity.HideEntity(this);
                return;
            }

            this.gameObject.SetLayerRecursively(m_Owner.gameObject.layer);
            SelfTransform.position = m_Owner.SelfTransform.position;
            SelfTransform.rotation = m_Owner.SelfTransform.rotation;

            RideEntity rideEntity = GameEntry.DataTable.GetDataTable<RideDBModel>().Get(m_MountsData.TypeId);
            GameEntry.Entity.AttachEntity(m_Owner, this, rideEntity.Point);
            
        }

        protected internal override void OnAttached(EntityBase childEntity, Transform parentTransform, object userData)
        {
            base.OnAttached(childEntity, parentTransform, userData);

            AnimatorComponent owneranimatorComponent = m_Owner.GetOrAddUnitComponent<AnimatorComponent>();
            owneranimatorComponent.SetBoolValue(Constant.AnimatorParam.IsRide, true);
            RideEntity rideEntity = GameEntry.DataTable.GetDataTable<RideDBModel>().Get(m_MountsData.TypeId);
            owneranimatorComponent.SetIntValue(Constant.AnimatorParam.RideType, rideEntity.RideType);

            m_Owner.GetOrAddUnitComponent<AnimatorComponent>().SetBoolValue(Constant.AnimatorParam.IsRide, true);
            MountsComponent mountsComponent = m_Owner.GetUnitComponent<MountsComponent>();
            mountsComponent.IsRide = true;
            mountsComponent.Mounts = this;
        }

        protected internal override void OnDetached(EntityBase childEntity, object userData)
        {
            base.OnDetached(childEntity, userData);
           
            m_Owner.GetOrAddUnitComponent<AnimatorComponent>().SetBoolValue(Constant.AnimatorParam.IsRide, false);
        }

        protected internal override void OnHide(object userData)
        {
            base.OnHide(userData);
            animatorComponent = null;
        }
    }
}
