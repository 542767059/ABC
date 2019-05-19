using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ZJY.Framework
{
    public class CancelView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private Image m_Cancel;

        public Action CancelEnter;
        public Action CancelExit;

        public void OnPointerEnter(PointerEventData eventData)
        {
            ChangeColor(true);
            if (CancelEnter != null)
            {
                CancelEnter();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            ChangeColor(false);
            if (CancelEnter != null)
            {
                CancelExit();
            }
        }

        private void OnEnable()
        {
            ChangeColor(false);
        }

        private void ChangeColor(bool isred)
        {
            if (isred)
            {
                m_Cancel.color = Color.red;
            }
            else
            {
                m_Cancel.color = Color.white;
            }
        }
    }
}