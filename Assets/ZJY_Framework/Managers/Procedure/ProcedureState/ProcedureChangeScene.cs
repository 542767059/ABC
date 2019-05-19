using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// 切换场景流程
    /// </summary>
    public class ProcedureChangeScene : ProcedureBase
    {
        private int m_BackgroundMusicId = 0;
        private int m_NextSceneId = 0;
        private bool m_IsChangeSceneComplete = false;

        public override void OnEnter()
        {
            base.OnEnter();
            m_IsChangeSceneComplete = false;
            m_NextSceneId = 0;

            GameEntry.Event.CommonEvent.AddEventListener(LoadSceneSuccessGameEvent.EventId, OnLoadSceneSuccess);
            GameEntry.Event.CommonEvent.AddEventListener(LoadSceneFailureGameEvent.EventId, OnLoadSceneFailure);
            GameEntry.Event.CommonEvent.AddEventListener(LoadSceneUpdateGameEvent.EventId, OnLoadSceneUpdate);
            GameEntry.Event.CommonEvent.AddEventListener(LoadSceneDependencyAssetGameEvent.EventId, OnLoadSceneDependencyAsset);

            // 停止所有声音
            GameEntry.Sound.StopAllLoadingSounds();
            GameEntry.Sound.StopAllLoadedSounds();

            // 隐藏所有实体
            GameEntry.Entity.HideAllLoadingEntities();
            GameEntry.Entity.HideAllLoadedEntities();

            // 卸载所有场景
            string[] loadedSceneAssetNames = GameEntry.Scene.GetLoadedSceneAssetNames();
            for (int i = 0; i < loadedSceneAssetNames.Length; i++)
            {
                GameEntry.Scene.UnloadScene(loadedSceneAssetNames[i]);
            }

            // 还原游戏速度
            GameEntry.Base.ResetNormalGameSpeed();

            m_NextSceneId = CurrFsm.GetData<VarInt>(Constant.ProcedureData.NextSceneId).Value;

            SceneEntity sceneEntity = GameEntry.DataTable.GetDataTable<SceneDBModel>().Get(m_NextSceneId);
            if (sceneEntity == null)
            {
                Log.Warning("Can not load scene '{0}' from data table.", m_NextSceneId.ToString());
                return;
            }

            GameEntry.Scene.LoadScene(AssetUtility.GetSceneAsset(sceneEntity.AssetName), Constant.AssetPriority.SceneAsset, this);
            m_BackgroundMusicId = sceneEntity.BackgroundMusicId;
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);

            if (!m_IsChangeSceneComplete)
            {
                return;
            }

            GameEntry.Data.CacheData.CurrentSceneId = m_NextSceneId;
            if (m_NextSceneId == (int)SceneType.LogOn)
            {
                ChangeState<ProcedureLogOn>();
            }
            else if (m_NextSceneId == (int)SceneType.SelectRole)
            {
                ChangeState<ProcedureSelectRole>();
            }
            else
            {
                ChangeState<ProcedureWorldMap>();
            }
        }

        public override void OnLeave()
        {
            base.OnLeave();

            GameEntry.Event.CommonEvent.RemoveEventListener(LoadSceneSuccessGameEvent.EventId, OnLoadSceneSuccess);
            GameEntry.Event.CommonEvent.RemoveEventListener(LoadSceneFailureGameEvent.EventId, OnLoadSceneFailure);
            GameEntry.Event.CommonEvent.RemoveEventListener(LoadSceneUpdateGameEvent.EventId, OnLoadSceneUpdate);
            GameEntry.Event.CommonEvent.RemoveEventListener(LoadSceneDependencyAssetGameEvent.EventId, OnLoadSceneDependencyAsset);
        }



        private void OnLoadSceneSuccess(GameEventBase gameEventBase)
        {
            LoadSceneSuccessGameEvent ne = (LoadSceneSuccessGameEvent)gameEventBase;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Info("Load scene '{0}' OK.", ne.SceneAssetName);

            if (m_BackgroundMusicId > 0)
            {
                GameEntry.Sound.PlayMusic(m_BackgroundMusicId);
            }
            if (InitForm.Instance != null)
            {
                InitForm.Instance.DestroySelf();
            }

            m_IsChangeSceneComplete = true;

        }

        private void OnLoadSceneFailure(GameEventBase gameEventBase)
        {
            LoadSceneFailureGameEvent ne = (LoadSceneFailureGameEvent)gameEventBase;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Error("Load scene '{0}' failure, error message '{1}'.", ne.SceneAssetName, ne.ErrorMessage);
        }

        private void OnLoadSceneUpdate(GameEventBase gameEventBase)
        {
            LoadSceneUpdateGameEvent ne = (LoadSceneUpdateGameEvent)gameEventBase;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Info("Load scene '{0}' update, progress '{1}'.", ne.SceneAssetName, ne.Progress.ToString("P2"));
        }

        private void OnLoadSceneDependencyAsset(GameEventBase gameEventBase)
        {
            LoadSceneDependencyAssetGameEvent ne = (LoadSceneDependencyAssetGameEvent)gameEventBase;
            if (ne.UserData != this)
            {
                return;
            }

            Log.Info("Load scene '{0}' dependency asset '{1}', count '{2}/{3}'.", ne.SceneAssetName, ne.DependencyAssetName, ne.LoadedCount.ToString(), ne.TotalCount.ToString());
        }
    }
}