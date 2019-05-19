using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ZJY.Framework
{
    public class RockerIn : Button, IDragHandler
    {
        [SerializeField]
        private RockerView m_RockerView;

        private bool clickfalg;
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);
            m_RockerView.OnInDown();
            clickfalg = true;
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);
            m_RockerView.OnPointerUp(eventData);
            if (clickfalg)
            {
                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<RockerInClickGameEvent>());
            }
        }


        public void OnDrag(PointerEventData eventData)
        {
            m_RockerView.OnDrag(eventData);
            clickfalg = false;
        }

      
    }
}