using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    public class KneadFaceForm : UIForm
    {
        [SerializeField]
        private InputField m_TxtNickName;

        private int m_CurrSelectJobId = 0;

        protected internal override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            RandomName();
            m_CurrSelectJobId = (int)userData;
        }

        /// <summary>
        /// 随机名字
        /// </summary>
        public void RandomName()
        {
            m_TxtNickName.text = GameUtil.RandomName();
        }

        /// <summary>
        /// 创建角色按钮点击
        /// </summary>
        public void CreateRoleButtonClick()
        {
            if (string.IsNullOrEmpty(m_TxtNickName.text))
            {
                GameEntry.UI.OpenDialog(new DialogParams()
                {
                    Mode = 1,
                    Title = "提示",
                    Message = "请输入您的昵称",
                });
                return;
            }

            RoleOperation_CreateRoleProto proto = new RoleOperation_CreateRoleProto();
            proto.JobId = (byte)m_CurrSelectJobId;
            proto.RoleNickName = m_TxtNickName.text;

            GameEntry.Socket.SendProtoMessage(proto);
        }
    }
}