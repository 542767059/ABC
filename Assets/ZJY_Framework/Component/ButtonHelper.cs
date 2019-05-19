using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    public class ButtonHelper : MonoBehaviour
    {

        public int Id
        {
            get;
            set;
        }

        public Action<int> OnClick;

        /// <summary>
        /// 执行Button事件
        /// </summary>
        public void OnClickEvent()
        {
            if (OnClick != null)
            {
                OnClick(Id);
            }
        }
    }
}
