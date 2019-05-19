using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 附属物实体
    /// </summary>
    public class AccessoryObjectEntity : Entity
    {
        [SerializeField]
        private AccessoryObjectData m_AccessoryObjectData;

        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_AccessoryObjectData = userData as AccessoryObjectData;
            if (m_AccessoryObjectData == null)
            {
                Log.Error("Accessoryobject data is invalid.");
                return;
            }
        }

        protected internal override void OnAttachTo(EntityBase parentEntity, Transform parentTransform, object userData)
        {
            base.OnAttachTo(parentEntity, parentTransform, userData);
            gameObject.SetLayerRecursively(SelfTransform.parent.gameObject.layer);

            SelfTransform.RestTransform();
        }
    }
}
