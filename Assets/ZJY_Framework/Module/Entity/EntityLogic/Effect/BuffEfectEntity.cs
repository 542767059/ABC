using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// Buff特效类
    /// </summary>
    public class BuffEfectEntity : Entity
    {
        [SerializeField]
        private BuffEfectEntityData m_BuffEfectEntityData;
        
        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_BuffEfectEntityData = userData as BuffEfectEntityData;
            if (m_BuffEfectEntityData == null)
            {
                Log.Error("BuffEfectEntity data is invalid.");
                return;
            }

            GameEntry.Entity.AttachEntity(this, m_BuffEfectEntityData.OwnerId, m_BuffEfectEntityData.Point);
            m_BuffEfectEntityData.BaseBuffHandler.Effect = this;
        }

        protected internal override void OnAttachTo(EntityBase parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);

            SelfTransform.RestTransform();
        }
    }
}
