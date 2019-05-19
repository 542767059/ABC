using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    /// <summary>
    /// loading窗口
    /// </summary>
    public class LoadingForm : UIForm
    {
        [SerializeField]
        private RawImage m_LoadingBG = null;

        [SerializeField]
        private Image m_Imgvalue = null;

        [SerializeField]
        private Text m_Txtvalue = null;

        [SerializeField]
        private Text m_TitleText = null;

        private float m_ProgressValue = 0;
        private int m_CurrentProgressValue = 0;
        private bool m_IsChangeSceneComplete = false;

        private bool m_IsLoadingScene = false;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
        }

        protected internal override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            GameEntry.UI.CloseDefaultUIForm();
            m_CurrentProgressValue = 0;
            m_ProgressValue = 0;
            m_IsChangeSceneComplete = false;
            m_IsLoadingScene = false;
            SetProressValue(m_CurrentProgressValue);

            int id = Random.Range(1, 5);
            LoadingEntity loadingEntity = GameEntry.DataTable.GetDataTable<LoadingDBModel>().Get(id);
            if (loadingEntity == null)
            {
                Log.Warning("Can not load loadinginfo '{0}' from data table.", id.ToString());
                return;
            }
            m_TitleText.text = loadingEntity.Tips;
            GameEntry.Texture2D.SetRawImg(m_LoadingBG, AssetUtility.GetLoadingBGAsset(loadingEntity.AssetName));

            GameEntry.Event.CommonEvent.AddEventListener(LoadSceneSuccessGameEvent.EventId, OnLoadSceneSuccess);
            GameEntry.Event.CommonEvent.AddEventListener(LoadSceneFailureGameEvent.EventId, OnLoadSceneFailure);
            GameEntry.Event.CommonEvent.AddEventListener(LoadSceneUpdateGameEvent.EventId, OnLoadSceneUpdate);
            GameEntry.Event.CommonEvent.AddEventListener(LoadSceneDependencyAssetGameEvent.EventId, OnLoadSceneDependencyAsset);


        }

        protected internal override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            m_CurrentProgressValue++;
            if (m_CurrentProgressValue < 10)
            {
                return;
            }
            if (!m_IsLoadingScene)
            {
                m_IsLoadingScene = true;
                GameEntry.Procedure.ChangeState<ProcedureChangeScene>();
            }
            //if ((m_CurrentProgressValue * 0.01f) < m_ProgressValue)
            //{
            //    m_CurrentProgressValue = (int)(m_ProgressValue * 100);
            //}
            m_CurrentProgressValue = Mathf.Clamp(m_CurrentProgressValue, 0, 99);
            SetProressValue(m_CurrentProgressValue);
            if (m_IsChangeSceneComplete && m_CurrentProgressValue >= 99)
            {
                Close();
            }
        }


        protected internal override void OnClose(object userData)
        {
            base.OnClose(userData);

            m_Txtvalue.text = string.Empty;
            m_TitleText.text = string.Empty;

            GameEntry.Event.CommonEvent.RemoveEventListener(LoadSceneSuccessGameEvent.EventId, OnLoadSceneSuccess);
            GameEntry.Event.CommonEvent.RemoveEventListener(LoadSceneFailureGameEvent.EventId, OnLoadSceneFailure);
            GameEntry.Event.CommonEvent.RemoveEventListener(LoadSceneUpdateGameEvent.EventId, OnLoadSceneUpdate);
            GameEntry.Event.CommonEvent.RemoveEventListener(LoadSceneDependencyAssetGameEvent.EventId, OnLoadSceneDependencyAsset);
        }

        private void SetProressValue(int value)
        {
            m_Imgvalue.fillAmount = value * 0.01f;
            m_Txtvalue.text = TextUtil.Format("{0}%", value);
        }

        private void OnLoadSceneSuccess(GameEventBase gameEventBase)
        {
            LoadSceneSuccessGameEvent ne = (LoadSceneSuccessGameEvent)gameEventBase;

            //todo
            m_IsChangeSceneComplete = true;
        }

        private void OnLoadSceneFailure(GameEventBase gameEventBase)
        {
            LoadSceneFailureGameEvent ne = (LoadSceneFailureGameEvent)gameEventBase;
            //todo
        }

        private void OnLoadSceneUpdate(GameEventBase gameEventBase)
        {
            LoadSceneUpdateGameEvent ne = (LoadSceneUpdateGameEvent)gameEventBase;
            m_ProgressValue = ne.Progress;
        }

        private void OnLoadSceneDependencyAsset(GameEventBase gameEventBase)
        {
            LoadSceneDependencyAssetGameEvent ne = (LoadSceneDependencyAssetGameEvent)gameEventBase;
            //todo
        }
    }
}