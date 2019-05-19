using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using ZJY.Framework;

namespace Hotfix
{
    public class SelectRoleFormCtrl
    {
        /// <summary>
        /// 控制的窗口
        /// <summary>
        private SelectRoleFormView m_SelectRoleFormView;

        private Button[] m_CreateRoleButtons;
        private Transform[] m_RoleLists;

        /// <summary>
        /// 当前选择的角色编号
        /// </summary>
        private int m_CurrSelectRoleId = 0;


        /// <summary>
        /// 界面初始化
        /// <summary>
        /// <param name="view">控制的窗口</param>
        /// <param name="userData">用户数据</param>
        public void OnInit(SelectRoleFormView view, object userData)
        {
            m_SelectRoleFormView = view;
            m_CreateRoleButtons = new Button[4];
            m_CreateRoleButtons[0] = m_SelectRoleFormView.ButtonCreateRole1;
            m_CreateRoleButtons[1] = m_SelectRoleFormView.ButtonCreateRole2;
            m_CreateRoleButtons[2] = m_SelectRoleFormView.ButtonCreateRole3;
            m_CreateRoleButtons[3] = m_SelectRoleFormView.ButtonCreateRole4;
            for (int i = 0; i < m_CreateRoleButtons.Length; i++)
            {
                m_CreateRoleButtons[i].onClick.AddListener(CreateRole);
            }

            m_RoleLists = new Transform[4];
            m_RoleLists[0] = m_SelectRoleFormView.RoleItemView1;
            m_RoleLists[1] = m_SelectRoleFormView.RoleItemView2;
            m_RoleLists[2] = m_SelectRoleFormView.RoleItemView3;
            m_RoleLists[3] = m_SelectRoleFormView.RoleItemView4;
            for (int i = 0; i < m_RoleLists.Length; i++)
            {
                ButtonHelper buttonHelper = m_RoleLists[i].GetComponent<ButtonHelper>();
                m_RoleLists[i].GetComponent<Button>().onClick.AddListener(buttonHelper.OnClickEvent);
                buttonHelper.OnClick = SetSelectRole;
            }

            m_SelectRoleFormView.btnStart.onClick.AddListener(EnterGame);
            m_SelectRoleFormView.btnDeleteRole.onClick.AddListener(DeleateRole);
            m_SelectRoleFormView.btnToLogOn.onClick.AddListener(GoToLogOn);
        }

        /// <summary>
        /// 界面打开
        /// <summary>
        /// <param name="userData">用户数据</param>
        public void OnOpen(object userData)
        {
            m_CurrSelectRoleId = 0;

            SetUI(GameEntry.Data.UserData.RoleLists);
            SetSelectRole(GameEntry.Data.UserData.RoleLists[0].RoleId);
            GameEntry.Event.CommonEvent.AddEventListener(DeleateRoleSuccessGameEvent.EventId, OnDeleateRoleSuccess);
        }



        /// <summary>
        /// 界面关闭
        /// </summary>
        /// <param name="userData">用户数据</param>
        public void OnClose(object userData)
        {
            GameEntry.Event.CommonEvent.RemoveEventListener(DeleateRoleSuccessGameEvent.EventId, OnDeleateRoleSuccess);
        }

        /// <summary>
        /// 界面暂停
        /// </summary>
        public void OnPause()
        {
        }

        /// <summary>
        /// 界面暂停恢复
        /// </summary>
        /// <param name="userData">用户数据</param>
        public void OnResume(object userData)
        {
        }

        /// <summary>
        /// 界面遮挡
        /// </summary>
        /// <param name="userData">用户数据</param>
        public void OnCover(object userData)
        {
        }

        /// <summary>
        /// 界面遮挡恢复
        /// </summary>
        public void OnReveal()
        {
        }

        /// <summary>
        /// 界面激活
        /// </summary>
        /// <param name="userData">用户数据</param>
        public void OnRefocus(object userData)
        {
        }

        /// <summary>
        /// 界面轮询
        /// </summary>
        /// <param name="deltaTime">逻辑流逝时间，以秒为单位</param>
        /// <param name="unscaledDeltaTime">真实流逝时间，以秒为单位</param>
        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
        }

        /// <summary>
        /// 界面深度改变
        /// </summary>
        /// <param name="uiGroupDepth">界面组深度</param>
        /// <param name="depthInUIGroup">界面在界面组中的深度</param>
        public void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)
        {

        }


        private void CreateRole()
        {
            GameEntry.Entity.HideAllLoadedEntities();
            GameEntry.Entity.HideAllLoadingEntities();
            m_SelectRoleFormView.Close();
            GameEntry.UI.OpenUIForm(UIFormId.CreateRole);
        }

        private void SetUI(List<RoleItem> roleList)
        {
            for (int i = 0; i < roleList.Count; i++)
            {
                JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();
                JobEntity jobEntity = jobDBModel.Get(roleList[i].RoleJob);
                if (jobEntity == null)
                {
                    Log.Warning("Can not load job '{0}' from data table.", roleList[i].RoleJob.ToString());
                    return;
                }
                m_RoleLists[i].GetComponent<ButtonHelper>().Id = roleList[i].RoleId;
                m_RoleLists[i].Find("ImgNotSelection").GetComponent<Image>().SetImage(ZJY.Framework.AssetUtility.GetCreateRoleImageAsset(jobEntity.HeadNotSelectAssetName));
                m_RoleLists[i].Find("ImgSelection").GetComponent<Image>().SetImage(ZJY.Framework.AssetUtility.GetCreateRoleImageAsset(jobEntity.HeadSelectAssetName));
                m_RoleLists[i].Find("txtLevel").GetComponent<Text>().text = roleList[i].RoleLevel.ToString();
                m_RoleLists[i].Find("txtName").GetComponent<Text>().text = roleList[i].RoleNickName;
            }

            for (int i = 0; i < 4; i++)
            {
                bool showRoleList = i < roleList.Count;
                m_CreateRoleButtons[i].gameObject.SetActive(!showRoleList);
                m_RoleLists[i].gameObject.SetActive(showRoleList);
            }
        }


        /// <summary>
        /// 设置选择的角色
        /// </summary>
        /// <param name="roleId"></param>
        private void SetSelectRole(int roleId)
        {
            if (m_CurrSelectRoleId == roleId)
            {
                return;
            }

            m_CurrSelectRoleId = roleId;

            GameEntry.Entity.HideAllLoadedEntities();
            GameEntry.Entity.HideAllLoadingEntities();

            for (int i = 0; i < m_RoleLists.Length; i++)
            {
                if (m_RoleLists[i].GetComponent<ButtonHelper>().Id == roleId)
                {
                    m_RoleLists[i].Find("ImgSelection").gameObject.SetActive(true);
                    continue;
                }
                m_RoleLists[i].Find("ImgSelection").gameObject.SetActive(false);
            }
            RoleItem item = GetRoleItem(roleId);

            JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();
            JobEntity jobEntity = jobDBModel.Get(item.RoleJob);
            if (jobEntity == null)
            {
                Log.Warning("Can not load job '{0}' from data table.", item.RoleJob.ToString());
                return;
            }
            m_SelectRoleFormView.imgMiaoShu1.SetImage(ZJY.Framework.AssetUtility.GetCreateRoleImageAsset(jobEntity.DescAllAssetName));
            m_SelectRoleFormView.imgMiaoShu2.SetImage(ZJY.Framework.AssetUtility.GetCreateRoleImageAsset(jobEntity.DescSpecificAssetName));

            HotfixEntry.Entity.ShowSelectRoleEntity(new SelectRoleData().Fill(roleId, item.RoleJob, item.RoleJob, UnityEngine.Random.Range(1,10), UnityEngine.Random.Range(1, 10), UnityEngine.Random.Range(1, 10), UnityEngine.Random.Range(1, 10)));
        }

        /// <summary>
        /// 根据角色编号获取已有角色项
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        private RoleItem GetRoleItem(int roleId)
        {
            if (GameEntry.Data.UserData.RoleLists != null)
            {
                for (int i = 0; i < GameEntry.Data.UserData.RoleLists.Count; i++)
                {
                    if (GameEntry.Data.UserData.RoleLists[i].RoleId == roleId)
                    {
                        return GameEntry.Data.UserData.RoleLists[i];
                    }
                }
            }
            return default(RoleItem);
        }

        /// <summary>
        /// 进入游戏(发送协议)
        /// </summary>
        private void EnterGame()
        {
            RoleOperation_EnterGameProto proto = new RoleOperation_EnterGameProto();
            proto.RoleId = m_CurrSelectRoleId;
            GameEntry.Socket.SendProtoMessage(proto);
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        private void DeleateRole()
        {
            GameEntry.UI.OpenDialog(new DialogParams()
            {
                Mode = 2,
                Title = "删除角色",
                Message = TextUtil.Format("您确定要删除 <color=#ff0000ff>{0}</color> 吗", GetRoleItem(m_CurrSelectRoleId).RoleNickName),
                OnClickConfirm = OnDeleteRoleClickCallBack,
            });
        }

        /// <summary>
        /// 确定删除按钮点击回调
        /// </summary>
        private void OnDeleteRoleClickCallBack(object userData)
        {
            //发送删除角色消息
            RoleOperation_DeleteRoleProto proto = new RoleOperation_DeleteRoleProto();
            proto.RoleId = m_CurrSelectRoleId;
            GameEntry.Socket.SendProtoMessage(proto);
        }

        /// <summary>
        /// 删除角色成功事件
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void OnDeleateRoleSuccess(ZJY.Framework.GameEventBase gameEventBase)
        {
            for (int i = GameEntry.Data.UserData.RoleLists.Count - 1; i >= 0; i--)
            {
                if (GameEntry.Data.UserData.RoleLists[i].RoleId == m_CurrSelectRoleId)
                {
                    GameEntry.Data.UserData.RoleLists.RemoveAt(i);
                }
            }

            if (GameEntry.Data.UserData.RoleLists.Count == 0)
            {
                CreateRole();
            }
            else
            {
                SetUI(GameEntry.Data.UserData.RoleLists);
                SetSelectRole(GameEntry.Data.UserData.RoleLists[0].RoleId);
            }
        }

        /// <summary>
        /// 返回登录
        /// </summary>
        private void GoToLogOn()
        {
            GameEntry.Procedure.SetData<VarInt>(Constant.ProcedureData.NextSceneId, (int)SceneType.LogOn);
            GameEntry.UI.OpenUIForm(UIFormId.Loading);
        }
    }
}
