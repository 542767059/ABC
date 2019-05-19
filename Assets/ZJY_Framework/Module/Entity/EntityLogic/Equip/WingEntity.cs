using System;
using UnityEngine;

namespace ZJY.Framework
{
    public class WingEntity : AccessoryObjectEntity
    {
        [SerializeField]
        private WingData m_WingData;

        private Animator m_Animator;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_Animator = this.gameObject.GetOrAddComponent<Animator>();
        }

        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_WingData = userData as WingData;
            if (m_WingData == null)
            {
                Log.Error("Wing data is invalid.");
                return;
            }

            m_Animator.SetAnimator(m_WingData.WingControllerAssetName);
            GameEntry.Entity.AttachEntity(this, m_WingData.OwnerId, m_WingData.WingPoint);
        }

        protected internal override void OnAttachTo(EntityBase parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            Name = TextUtil.Format("Wing of {0}", parentEntity.Name);
        }
    }
}
