using System;
using UnityEngine;

namespace ZJY.Framework
{
    public class MagicEntity : AccessoryObjectEntity
    {
        [SerializeField]
        private MagicData m_MagicData;

        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_MagicData = userData as MagicData;
            if (m_MagicData == null)
            {
                Log.Error("Magic data is invalid.");
                return;
            }

            GameEntry.Entity.AttachEntity(this, m_MagicData.OwnerId, m_MagicData.MagicPoint);
        }

        protected internal override void OnAttachTo(EntityBase parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            Name = TextUtil.Format("Magic of {0}", parentEntity.Name);
        }
    }
}
