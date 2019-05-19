using UnityEngine;
using UnityEngine.UI;
using ZJY.Framework;

namespace Hotfix
{
    public class SelectRoleFormView : HotUIForm
    {
        /// <summary>
        /// 窗口控制器
        /// </summary>
        private SelectRoleFormCtrl m_SelectRoleFormCtrl;

        #region 组件
        /// <summary>
        /// 返回登录按钮
        /// </summary>
        public Button btnToLogOn
        {
            get;
            private set;
        }

        /// <summary>
        /// 描述1
        /// </summary>
        public Image imgMiaoShu1
        {
            get;
            private set;
        }

        /// <summary>
        /// 描述2
        /// </summary>
        public Image imgMiaoShu2
        {
            get;
            private set;
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        public Button btnDeleteRole
        {
            get;
            private set;
        }

        /// <summary>
        /// 开始游戏按钮
        /// </summary>
        public Button btnStart
        {
            get;
            private set;
        }

        /// <summary>
        /// 角色1
        /// </summary>
        public Transform RoleItemView1
        {
            get;
            private set;
        }

        /// <summary>
        /// 角色2
        /// </summary>
        public Transform RoleItemView2
        {
            get;
            private set;
        }

        /// <summary>
        /// 角色3
        /// </summary>
        public Transform RoleItemView3
        {
            get;
            private set;
        }

        /// <summary>
        /// 角色4
        /// </summary>
        public Transform RoleItemView4
        {
            get;
            private set;
        }

        /// <summary>
        /// 创建1
        /// </summary>
        public Button ButtonCreateRole1
        {
            get;
            private set;
        }

        /// <summary>
        /// 创建2
        /// </summary>
        public Button ButtonCreateRole2
        {
            get;
            private set;
        }

        /// <summary>
        /// 创建3
        /// </summary>
        public Button ButtonCreateRole3
        {
            get;
            private set;
        }

        /// <summary>
        /// 创建4
        /// </summary>
        public Button ButtonCreateRole4
        {
            get;
            private set;
        }

        #endregion

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="uiForm">真正的UI窗口</param>
        /// <param name="userData">用户数据</param>
        public override void OnInit(HotfixForm uiForm, object userData)
        {
            base.OnInit(uiForm, userData);
            btnToLogOn = uiForm.GetTransType(0) as Button;
            imgMiaoShu1 = uiForm.GetTransType(1) as Image;
            imgMiaoShu2 = uiForm.GetTransType(2) as Image;
            btnDeleteRole = uiForm.GetTransType(3) as Button;
            btnStart = uiForm.GetTransType(4) as Button;
            RoleItemView1 = uiForm.GetTransType(5) as Transform;
            RoleItemView2 = uiForm.GetTransType(6) as Transform;
            RoleItemView3 = uiForm.GetTransType(7) as Transform;
            RoleItemView4 = uiForm.GetTransType(8) as Transform;
            ButtonCreateRole1 = uiForm.GetTransType(9) as Button;
            ButtonCreateRole2 = uiForm.GetTransType(10) as Button;
            ButtonCreateRole3 = uiForm.GetTransType(11) as Button;
            ButtonCreateRole4 = uiForm.GetTransType(12) as Button;
            m_SelectRoleFormCtrl = new SelectRoleFormCtrl();
            m_SelectRoleFormCtrl.OnInit(this, userData);
        }

        /// <summary>
        /// 界面打开
        /// </summary>
        /// <param name="userData">用户数据</param>
        public override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_SelectRoleFormCtrl.OnOpen(userData);
        }

        /// <summary>
        /// 界面关闭
        /// </summary>
        /// <param name="userData">用户数据</param>
        public override void OnClose(object userData)
        {
            base.OnClose(userData);
            m_SelectRoleFormCtrl.OnClose(userData);
        }

        /// <summary>
        /// 界面暂停
        /// </summary>
        public override void OnPause()
        {
            base.OnPause();
            m_SelectRoleFormCtrl.OnPause();
        }

        /// <summary>
        /// 界面暂停恢复
        /// </summary>
        /// <param name="userData">用户数据</param>
        public override void OnResume(object userData)
        {
            base.OnResume(userData);
            m_SelectRoleFormCtrl.OnResume(userData);
        }

        /// <summary>
        /// 界面遮挡
        /// </summary>
        /// <param name="userData">用户数据</param>
        public override void OnCover(object userData)
        {
            base.OnCover(userData);
            m_SelectRoleFormCtrl.OnCover(userData);
        }

        /// <summary>
        /// 界面遮挡恢复
        /// </summary>
        public override void OnReveal()
        {
            base.OnReveal();
            m_SelectRoleFormCtrl.OnReveal();
        }

        /// <summary>
        /// 界面激活
        /// </summary>
        /// <param name="userData">用户数据</param>
        public override void OnRefocus(object userData)
        {
            base.OnRefocus(userData);
            m_SelectRoleFormCtrl.OnRefocus(userData);
        }

        /// <summary>
        /// 界面轮询
        /// </summary>
        /// <param name="deltaTime">逻辑流逝时间，以秒为单位</param>
        /// <param name="unscaledDeltaTime">真实流逝时间，以秒为单位</param>
        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            m_SelectRoleFormCtrl.OnUpdate(deltaTime, unscaledDeltaTime);
        }

        /// <summary>
        /// 界面深度改变
        /// </summary>
        /// <param name="uiGroupDepth">界面组深度</param>
        /// <param name="depthInUIGroup">界面在界面组中的深度</param>
        public override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {
            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);
            m_SelectRoleFormCtrl.OnDepthChanged(uiGroupDepth, depthInUIGroup);
        }
    }
}
