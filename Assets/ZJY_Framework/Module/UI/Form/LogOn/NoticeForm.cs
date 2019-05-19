using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.Text;

namespace ZJY.Framework
{
    public class NoticeForm : UIForm
    {
        [SerializeField]
        private Transform m_PageContent;

        [SerializeField]
        private NoticePageItem m_NoticePageItem;

        [SerializeField]
        private Text m_Txttitle;

        [SerializeField]
        private Text m_TxtContent;

        private  static readonly string[] Titles = new string[]
        {
            "停服维护公告",
            "新服公告",
        };

        private static readonly string[] Contents = new string[]
        {
            "充值拿大礼！上线缉拿手打阿松_充值拿大礼！上线缉拿手打阿松充值拿大礼！上线缉拿手打阿松充值拿大礼！上线缉拿手打阿松充值拿大礼！上线缉拿手打阿松充值拿大礼！上线缉手打阿松充值拿大礼！上线缉拿手打阿松拿手打阿松充值拿大礼！上线缉拿手打阿松充值拿大礼！上线缉拿手打阿松充值拿大礼！上线缉拿手打阿松充值拿大礼！上线缉拿手打阿松拿手打阿松充值拿大礼！上线缉拿手打阿松充值拿大礼！上线缉拿手打阿松充值拿大礼！上线缉拿手打阿松充值拿大礼！上线缉拿手打阿松",
            "充值拿大礼！上线缉拿手打阿松_大概大是大非萨达是个我打死多告诉对方水电费艾斯德斯大概大是大非萨达是个我打死多告诉对方水电费艾斯德斯大概大是大非萨达是个我打死多告诉对方水电费艾斯德斯_大概大是大非萨达是个我打死多告诉对方水电费艾斯德斯大概大是大非萨达是个我打死多告诉对方水电费艾斯德斯",
        };

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            for (int i = 0; i < Titles.Length; i++)
            {
                CreatePageItem(i);
            }
        }

        protected internal override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            PageIetmClick(0);
        }

        private NoticePageItem CreatePageItem(int index)
        {
            NoticePageItem noticePageItem = null;
            noticePageItem = Instantiate(m_NoticePageItem);
            noticePageItem.Index = index;
            noticePageItem.PageClick = PageIetmClick;
            noticePageItem.SetUI(Titles[index]);

            Transform transform = noticePageItem.GetComponent<Transform>();
            transform.SetParent(m_PageContent);

            return noticePageItem;
        }

        private void PageIetmClick(int index)
        {
            m_Txttitle.text = Titles[index];
            m_TxtContent.text = TextUtil.Format("\r\n\r\n\r\n{0}", GetConent(index));
        }

        private string GetConent(int index)
        {
            StringBuilder sbr = new StringBuilder();
            string[] arrs = Contents[index].Split('_');
            for (int i = 0; i < arrs.Length; i++)
            {
                sbr.AppendFormat("活动{0}：{1}\r\n", i+1, arrs[i]);
                sbr.Append("\r\n");
            }
            return sbr.ToString();
        }
    }
}
