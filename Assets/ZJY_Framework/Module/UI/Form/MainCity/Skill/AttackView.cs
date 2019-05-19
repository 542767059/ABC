using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ZJY.Framework
{
    public class AttackView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        [SerializeField]
        private Animation m_Animation;

        private bool m_IsPress = false;

        private void Update()
        {
            if (m_IsPress)
            {
                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<NormalAttackClickGameEvent>());
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<NormalAttackClickGameEvent>());
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            m_IsPress = true;
            m_Animation.Play();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            m_IsPress = false;
        }
    }
}