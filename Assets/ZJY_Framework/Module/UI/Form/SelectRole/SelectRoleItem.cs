using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    public class SelectRoleItem : MonoBehaviour
    {
        /// <summary>
        /// 职业编号
        /// </summary>
        private int m_JobId;

        /// <summary>
        /// 角色编号
        /// </summary>
        private int m_RoleId;

        /// <summary>
        /// 职业图片
        /// </summary>
        [SerializeField]
        private Image m_ImageSelection;

        /// <summary>
        /// 等级
        /// </summary>
        [SerializeField]
        private Text m_LblLevel;

        /// <summary>
        /// 昵称
        /// </summary>
        [SerializeField]
        private Text m_LblNickName;

        public Action<int> OnSelectRole;

        public void RoleItemClick()
        {
            if (OnSelectRole != null)
            {
                OnSelectRole(m_RoleId);
            }
        }

        public void SetUI(int roleId, string nickName, int level, int jobId,  Action<int> onSelectRole)
        {
            m_JobId = jobId;
            m_RoleId = roleId;
            m_LblNickName.text = nickName;
            m_LblLevel.text = level.ToString();
            OnSelectRole = onSelectRole;
        }

        /// <summary>
        /// 设置UI是否选中显示
        /// </summary>
        /// <param name="selectRoleId">选中的Id</param>
        private void SetImage(int selectRoleId)
        {
            
            JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();
            JobEntity jobEntity = jobDBModel.Get(m_JobId);
            if (jobEntity == null)
            {
                Log.Warning("Can not load job '{0}' from data table.", m_JobId.ToString());
                return;
            }
            if (selectRoleId == m_RoleId)
            {
                m_ImageSelection.SetImage(AssetUtility.GetCreateRoleImageAsset(jobEntity.HeadSelectAssetName));
            }
            else
            {
                m_ImageSelection.SetImage(AssetUtility.GetCreateRoleImageAsset(jobEntity.HeadNotSelectAssetName));
            }
            
        }
    }
}