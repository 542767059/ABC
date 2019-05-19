using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    public class CreateRoleForm : UIForm
    {
        [SerializeField]
        private Toggle[] m_ToggleJob;

        [SerializeField]
        private Image m_ImageArr;

        [SerializeField]
        private Image m_ImageMiaoShu1;

        [SerializeField]
        private Image m_ImageMiaoShu2;

        [SerializeField]
        private Image m_Sex0;

        [SerializeField]
        private Image m_Sex1;

        private int m_CurrentSelectJobId = 0;
        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            m_CurrentSelectJobId = 1;
        }

        protected internal override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            if (m_CurrentSelectJobId > 0)
            {
                SetSelectJob();
            }
        }

        public void OnReturnButtonClick()
        {
            Close();
            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<ReturnSelectRoleGameEvent>());
        }

        public void ButtonNextClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.KneadFace, m_CurrentSelectJobId);
        }

        public void SelectRole(int index)
        {
            if (!m_ToggleJob[index - 1].isOn)
            {
                return;
            }
            if (m_CurrentSelectJobId == index)
            {
                return;
            }

            m_CurrentSelectJobId = index;
            SetSelectJob();
        }

        private void SetSelectJob()
        {
            GameEntry.Entity.HideAllLoadedEntities();
            GameEntry.Entity.HideAllLoadingEntities();
            GameEntry.Entity.ShowCreateRole(m_CurrentSelectJobId);
            JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();

            JobEntity jobEntity = jobDBModel.Get(m_CurrentSelectJobId);
            if (jobEntity == null)
            {
                Log.Warning("Can not load job '{0}' from data table.", m_CurrentSelectJobId.ToString());
                return;
            }

            //更新选择的职业信息
            m_ImageArr.SetImage(AssetUtility.GetCreateRoleImageAsset(jobEntity.DescImageAssetName));
            m_ImageMiaoShu1.SetImage(AssetUtility.GetCreateRoleImageAsset(jobEntity.DescAllAssetName));
            m_ImageMiaoShu2.SetImage(AssetUtility.GetCreateRoleImageAsset(jobEntity.DescSpecificAssetName));
            if (jobEntity.Sex == 0)
            {
                m_Sex0.gameObject.SetActive(true);
                m_Sex1.gameObject.SetActive(false);
            }
            else
            {
                m_Sex0.gameObject.SetActive(false);
                m_Sex1.gameObject.SetActive(true);
            }
        }
    }
}