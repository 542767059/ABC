using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 特效类
    /// </summary>
    public class EffectEntity : Entity
    {
        [SerializeField]
        private EffectEntityData m_EffectEntityData;

        private float m_ElapseSeconds = 0f;

        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_EffectEntityData = userData as EffectEntityData;
            if (m_EffectEntityData == null)
            {
                Log.Error("EffectEntity data is invalid.");
                return;
            }

            m_ElapseSeconds = 0f;
        }

        protected internal override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);

            m_ElapseSeconds += unscaledDeltaTime;
            if (m_ElapseSeconds >= m_EffectEntityData.KeepTime)
            {
                GameEntry.Entity.HideEntity(this);
            }
        }
    }
}
