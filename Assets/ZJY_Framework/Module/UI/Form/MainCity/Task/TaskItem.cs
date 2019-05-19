using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    public class TaskItem : MonoBehaviour
    {
        [SerializeField]
        private Button m_Button;

        [SerializeField]
        private Image m_TaskType;

        [SerializeField]
        private Text m_TaskName;

        [SerializeField]
        private Text m_TaskConent;


        /// <summary>
        /// 点击事件
        /// </summary>
        public Action OnClick;


        private void Awake()
        {
            m_Button.onClick.AddListener(BtnClick);
        }

        private void BtnClick()
        {
            if (OnClick != null)
            {
                OnClick();
            }
        }

        public void SetUI(string imageAssetname, string taskname, string taskconent)
        {
            m_TaskType.SetImage(imageAssetname);
            m_TaskName.text = taskname;
            m_TaskConent.text = taskconent;
        }
    }
}