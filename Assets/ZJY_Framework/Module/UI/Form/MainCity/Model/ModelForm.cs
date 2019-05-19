using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    public class ModelForm : UIForm
    {
        [SerializeField]
        private Image[] m_Toggles;

        public void ModeClick(int id)
        {
            Close();
            Debug.Log("模式" + id + "todo 发消息改变");
        }

        protected internal override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            for (int i = 0; i < m_Toggles.Length; i++)
            {
                m_Toggles[i].gameObject.SetActive(i == 0);
            }
        }
    }
}