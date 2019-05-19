using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 登录游戏界面窗口
    /// </summary>
    public class LogInForm : UIForm
    {
        protected internal override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            GameEntry.Event.CommonEvent.AddEventListener(SocketConnectedGameEvent.EventId, MainSocketConected);
        }

       

        protected internal override void OnClose(object userData)
        {
            base.OnClose(userData);
            GameEntry.Event.CommonEvent.RemoveEventListener(SocketConnectedGameEvent.EventId, MainSocketConected);
        }

        /// <summary>
        /// 播放按钮点击
        /// </summary>
        public void OnPlayButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.CG);
        }

        /// <summary>
        /// 公告按钮点击
        /// </summary>
        public void OnNoticeButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.Notice);
        }

        /// <summary>
        /// 选择区服按钮点击
        /// </summary>
        public void OnSelectServerButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.SelectServerForm);
        }

        /// <summary>
        /// 用户协议按钮点击
        /// </summary>
        public void OnAgreementButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.Agreement);
        }


        /// <summary>
        /// 进入游戏按钮点击
        /// </summary>
        public void OnGameEnterButtonClick()
        {
            GameEntry.Socket.ConnectToMainSocket(GameEntry.Data.SystemData.Ip,GameEntry.Data.SystemData.Port);
        }

        private void MainSocketConected(GameEventBase gameEventBase)
        {
            SocketConnectedGameEvent socketConnectedGameEvent = (SocketConnectedGameEvent)gameEventBase;
            if (socketConnectedGameEvent.Socket != GameEntry.Socket.MainSocket)
            {
                return;
            }
            
            GameEntry.Procedure.SetData<VarInt>(Constant.ProcedureData.NextSceneId, (int)SceneType.SelectRole);
            GameEntry.UI.OpenUIForm(UIFormId.Loading);
        }
    }
}
