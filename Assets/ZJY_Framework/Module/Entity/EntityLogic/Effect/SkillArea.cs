
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 技能区域指示器
    /// </summary>
    public class SkillArea : Entity
    {
        [SerializeField]
        private SkillAreaData m_SkillAreaData;

        [SerializeField]
        private Entity m_Owner = null;

        [SerializeField]
        private Vector3 deltaVec = Vector3.zero;

        [SerializeField]
        private Transform m_InerElement;

        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_SkillAreaData = userData as SkillAreaData;
            if (m_SkillAreaData == null)
            {
                Log.Error("killAreaEntity data is invalid.");
                return;
            }

            m_Owner = m_SkillAreaData.Owner;
            m_InerElement = transform.Find("InerElement");
            SelfTransform.position = m_Owner.SelfTransform.position;
            if (m_InerElement!=null)
            {
                m_InerElement.LookAt(m_Owner.SelfTransform.forward + SelfTransform.position);
            }

            GameEntry.Event.CommonEvent.AddEventListener(ChangeSkillAreaGameEvent.EventId, OnChangeSkillArea);
            GameEntry.Event.CommonEvent.AddEventListener(HideSkillAreaGameEvent.EventId, OnHideSkillArea);
        }

        protected internal override void OnHide(object userData)
        {
            base.OnHide(userData);
            deltaVec = Vector3.zero;
            m_Owner = null;
            if (m_InerElement != null)
            {
                m_InerElement.localPosition = Vector3.zero;
                m_InerElement.rotation = Quaternion.identity;
            }

            m_InerElement = null;

            GameEntry.Event.CommonEvent.RemoveEventListener(ChangeSkillAreaGameEvent.EventId, OnChangeSkillArea);
            GameEntry.Event.CommonEvent.RemoveEventListener(HideSkillAreaGameEvent.EventId, OnHideSkillArea);
        }

        protected internal override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            if (m_Owner != null)
            {
                SelfTransform.position = m_Owner.transform.position;
            }

            if (m_InerElement != null)
            {
                switch (m_SkillAreaData.SKillAreaType)
                {
                    case SKillAreaType.OuterCircle:
                        break;
                    case SKillAreaType.Circle:
                        Vector3 targetDir = deltaVec * 10;
                        float y = GameEntry.Camera.MainCamera.transform.rotation.eulerAngles.y;
                        targetDir = Quaternion.Euler(0, y, 0) * targetDir;
                        m_InerElement.localPosition = targetDir;
                        break;
                    case SKillAreaType.Cube:
                    case SKillAreaType.Sector:
                        m_InerElement.LookAt(GetCubeSectorLookAt());
                        break;
                }

            }
        }

        /// <summary>
        /// 改变技能指示器位置
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void OnChangeSkillArea(GameEventBase gameEventBase)
        {
            ChangeSkillAreaGameEvent changeSkillAreaGameEvent = (ChangeSkillAreaGameEvent)gameEventBase;

            deltaVec = new Vector3(changeSkillAreaGameEvent.Postion.x, 0, changeSkillAreaGameEvent.Postion.y);
        }

        /// <summary>
        /// 影藏技能指示器
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void OnHideSkillArea(GameEventBase gameEventBase)
        {
            GameEntry.Entity.HideEntity(this);
        }

        /// <summary>
        /// 获取Cube、Sector元素朝向
        /// </summary>
        /// <returns></returns>
        private Vector3 GetCubeSectorLookAt()
        {
            Vector3 targetDir = deltaVec;

            float y = GameEntry.Camera.MainCamera.transform.rotation.eulerAngles.y;
            targetDir = Quaternion.Euler(0, y, 0) * targetDir;

            return targetDir + SelfTransform.position;
        }
    }
}
