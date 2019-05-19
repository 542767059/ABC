using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ZJY.Framework
{
    public class RockerView : Button, IDragHandler
    {
        [SerializeField]
        private Image m_RockerViewBG = null;

        [SerializeField]
        private Image m_RockerOut = null;

        [SerializeField]
        private Image m_RockerIn = null;

        [SerializeField]
        private RectTransform m_Trans = null;

        [SerializeField]
        private float m_Range = 100;

        private bool m_IsPress = false;
        private Vector2 startPos;
        private Vector2 localpos;
        protected override void Start()
        {
            base.Start();
            m_RockerViewBG = transform.GetComponent<Image>();
        }

        //void Update()
        //{
        //    if (m_IsPress)
        //    {
        //        if (m_RockerIn.transform.localPosition != Vector3.zero)
        //        {
        //            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<RockerMoveGameEvent>().Fill(m_RockerIn.transform.localPosition / m_Range));
        //        }
        //    }
        //}

        /// <summary>
        /// 中心点按下
        /// </summary>
        public void OnInDown()
        {
            Begin();
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            startPos = eventData.position;


            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(m_Trans, startPos, GameEntry.UI.UICamera, out localpos))
            {
                localpos.x = Mathf.Clamp(localpos.x, -110, 200);
                localpos.y = Mathf.Clamp(localpos.y, -50, 120);
                transform.localPosition = localpos;
            }

            Begin();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            transform.localPosition = Vector3.zero;
            m_RockerIn.transform.localPosition = Vector3.zero;
            End();
            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<RockerEndGameEvent>());
        }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 touchPos;
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(m_RockerOut.rectTransform, eventData.position, GameEntry.UI.UICamera, out touchPos))
            {
                if (Vector2.Distance(touchPos, Vector2.zero) < m_Range)
                    m_RockerIn.transform.localPosition = touchPos;
                else
                    m_RockerIn.transform.localPosition = touchPos.normalized * m_Range;
            }
            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<RockerMoveGameEvent>().Fill(m_RockerIn.transform.localPosition / m_Range));
        }

        private void Begin()
        {
            m_IsPress = true;
            SetAlpha(0.8f);
            m_RockerOut.raycastTarget = false;
            m_RockerViewBG.raycastTarget = false;
        }

        private void End()
        {
            m_IsPress = false;
            SetAlpha(0.3f);
            m_RockerOut.raycastTarget = true;
            m_RockerViewBG.raycastTarget = true;
        }

        private void SetAlpha(float alphaValue)
        {
            Color outc = m_RockerOut.color;
            outc.a = alphaValue;
            m_RockerOut.color = outc;

            Color inc = m_RockerIn.color;
            inc.a = alphaValue;
            m_RockerIn.color = inc;
        }
    }
}