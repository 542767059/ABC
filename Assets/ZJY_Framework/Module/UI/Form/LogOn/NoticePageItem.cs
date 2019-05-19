using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoticePageItem : MonoBehaviour
{
    /// <summary>
    /// 编号
    /// </summary>
    public int Index
    {
        get;
        set;
    }

    [SerializeField]
    private Text m_PageName;

    public Action<int> PageClick;

    public void BtnClick()
    {
        if (PageClick!=null)
        {
            PageClick(Index);
        }
    }

    public void SetUI(string pageName)
    {
        m_PageName.text = pageName;
    }
}
