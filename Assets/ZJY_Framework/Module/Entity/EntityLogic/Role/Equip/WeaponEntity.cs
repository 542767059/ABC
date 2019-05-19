using System;
using UnityEngine;

namespace ZJY.Framework
{
    public class WeaponEntity : Entity
    {
        [SerializeField]
        private WeaponData m_WeaponData;

        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_WeaponData = userData as WeaponData;
            if (m_WeaponData == null)
            {
                Log.Error("Weapon data is invalid.");
                return;
            }
            
            GameEntry.Entity.AttachEntity(this, m_WeaponData.OwnerId, m_WeaponData.WeaponPoint);
        }

        protected internal override void OnAttachTo(EntityBase parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            Name = TextUtil.Format("Weapon of {0}", parentEntity.Name);
            SelfTransform.localPosition = Vector3.zero;
        }
    }

}
