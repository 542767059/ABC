using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    /// <summary>
    /// 注册窗口
    /// </summary>
    public class RegForm : UIForm
    {
        [SerializeField]
        private InputField m_InputFieldUserName;

        [SerializeField]
        private InputField m_InputFieldPasswork;

        [SerializeField]
        private CanvasGroup m_ErrorTipCanvasGroup = null;

        [SerializeField]
        private Text m_ErrorTipText = null;

        protected internal override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            m_InputFieldUserName.text = string.Empty;
            m_InputFieldPasswork.text = string.Empty;
            m_InputFieldUserName.onValueChanged.AddListener(HideErrorTip);
            m_InputFieldPasswork.onValueChanged.AddListener(HideErrorTip);
            ShowOrHideErrorTip(false);
        }


        protected internal override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);

            if (m_ErrorTipCanvasGroup.gameObject.activeSelf)
            {
                m_ErrorTipCanvasGroup.alpha = 0.5f + 0.5f * Mathf.Sin(Mathf.PI * Time.time);
            }
        }

        protected internal override void OnClose(object userData)
        {
            base.OnClose(userData);

            m_InputFieldUserName.onValueChanged.RemoveAllListeners();
            m_InputFieldPasswork.onValueChanged.RemoveAllListeners();
            ShowOrHideErrorTip(false);
        }

        private void ShowOrHideErrorTip(bool isShow, string errorMessage = null)
        {
            m_ErrorTipCanvasGroup.gameObject.SetActive(isShow);
            if (errorMessage != null)
            {
                m_ErrorTipText.text = errorMessage;
            }
        }

        private void HideErrorTip(string arg0)
        {
            ShowOrHideErrorTip(false);
        }

        public void ToLogOn()
        {
            Close();
            GameEntry.UI.OpenUIForm(UIFormId.LogOn);
        }

        public void RegAccount()
        {
            if (string.IsNullOrEmpty(m_InputFieldUserName.text))
            {
                ShowOrHideErrorTip(true, "请输入用户名");
                return;
            }

            if (string.IsNullOrEmpty(m_InputFieldPasswork.text))
            {
                ShowOrHideErrorTip(true, "请输入密码");
                return;
            }


            Dictionary<string, object> dic = GameEntry.Pool.SpawnClassObject<Dictionary<string, object>>();
            dic.Clear();
            dic["Type"] = 0;
            dic["UserName"] = m_InputFieldUserName.text;
            dic["Pwd"] = m_InputFieldPasswork.text;
            dic["ChannelId"] = 0;

            string url = GameEntry.Http.RealWebAccountUrl + "/api/Account";
            GameEntry.Http.SendData(url, OnWebAccountReg, true, dic);
        }

        private void OnWebAccountReg(HttpCallBackArgs args)
        {
            if (args.HasError)
            {
                ShowOrHideErrorTip(true, "用户名已存在");
                Log.Error(args.Value);
            }
            else
            {
                LitJson.JsonData data = LitJson.JsonMapper.ToObject(args.Value);

                LitJson.JsonData config = LitJson.JsonMapper.ToObject(data["Value"].ToString());
                GameEntry.Data.UserData.AccountId = int.Parse(config["Id"].ToString());
                //GameEntry.Data.SystemData.Ip = config["Ip"].ToString();
                //GameEntry.Data.SystemData.Port = int.Parse(config["Port"].ToString());
                //todo 正式使用需要服务器返回 这里直接使用目标机
                GameEntry.Data.SystemData.Ip = GameEntry.Http.RealWebAccountUrl.Replace("http://", "");
                GameEntry.Data.SystemData.Ip = GameEntry.Data.SystemData.Ip.Replace(":8080", "");
                GameEntry.Data.SystemData.Port = 1038;
                Debug.Log(GameEntry.Data.UserData.AccountId);
                Close();
                GameEntry.UI.OpenUIForm(UIFormId.LogIn);
            }
        }
    }
}
