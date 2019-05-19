using System;
using System.Collections.Generic;
using UnityEngine;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// 预加载流程
    /// </summary>
    public class ProcedurePreload : ProcedureBase
    {
        public static readonly string[] DataTableNames = new string[]
        {
            "Localization",
            "Chapter",
            "ChapterXLSX",
            "Job",
            "Music",
            "Scene",
            "Sound",
            "UIForm",
            "UISound",
            "Loading",
            "JobLevel",
            "JobAvtar",
            "JobWeapon",
            "JobWings",
            "Trump",
            "Ride",
            
         };

        private bool m_HotfixPreload;
        private Dictionary<string, bool> m_LoadedFlag = new Dictionary<string, bool>();

        public override void OnEnter()
        {
            base.OnEnter();

            m_HotfixPreload = false;
            GameEntry.ILRuntime.ILRuntimeReady = ILRuntimeReady;
            GameEntry.Event.CommonEvent.AddEventListener(LoadDataTableSuccessGameEvent.EventId, OnLoadDataTableSuccess);
            GameEntry.Event.CommonEvent.AddEventListener(LoadDataTableFailureGameEvent.EventId, OnLoadDataTableFailure);
            GameEntry.Event.CommonEvent.AddEventListener(ILRuntimePreloadGameEvent.EventId, OnILRuntimePreload);

            GameEntry.ILRuntime.InitILRuntime();
            PreloadResources();
        }



        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);


            if (!m_HotfixPreload)
            {
                return;
            }

            IEnumerator<bool> iter = m_LoadedFlag.Values.GetEnumerator();
            while (iter.MoveNext())
            {
                if (!iter.Current)
                {
                    return;
                }
            }

            CurrFsm.SetData<VarInt>(Constant.ProcedureData.NextSceneId,(int)SceneType.LogOn);
            ChangeState<ProcedureChangeScene>();
        }

        public override void OnLeave()
        {
            GameEntry.Event.CommonEvent.RemoveEventListener(LoadDataTableSuccessGameEvent.EventId, OnLoadDataTableSuccess);
            GameEntry.Event.CommonEvent.RemoveEventListener(LoadDataTableFailureGameEvent.EventId, OnLoadDataTableFailure);
            GameEntry.Event.CommonEvent.RemoveEventListener(ILRuntimePreloadGameEvent.EventId, OnILRuntimePreload);
            GameEntry.ILRuntime.ILRuntimeReady = null;

            base.OnLeave();
        }

        private void ILRuntimeReady()
        {
            HotfixPreload();
        }

        /// <summary>
        /// 预加载热更里资源
        /// </summary>
        private void HotfixPreload()
        {
            Debug.Log("预加载热更里资源");
            GameEntry.ILRuntime.DoAction("Preload");
        }

        private void PreloadResources()
        {
            foreach (string dataTableName in DataTableNames)
            {
                LoadDataTable(dataTableName);
            }
        }


        private void LoadDataTable(string dataTableName)
        {
            m_LoadedFlag.Add(TextUtil.Format("DataTable.{0}", dataTableName), false);
            GameEntry.DataTable.LoadDataTable(dataTableName, this);
        }



        private void OnLoadDataTableSuccess(GameEventBase gameEventBase)
        {
            LoadDataTableSuccessGameEvent loadDataTableSuccessGameEvent = (LoadDataTableSuccessGameEvent)gameEventBase;
            if (loadDataTableSuccessGameEvent.UserData != this)
            {
                return;
            }

            m_LoadedFlag[TextUtil.Format("DataTable.{0}", loadDataTableSuccessGameEvent.DataTableName)] = true;
            Log.Info("Load data table '{0}' OK.", loadDataTableSuccessGameEvent.DataTableName);
        }

        private void OnLoadDataTableFailure(GameEventBase gameEventBase)
        {
            LoadDataTableFailureGameEvent loadDataTableFailureGameEvent = (LoadDataTableFailureGameEvent)gameEventBase;
            if (loadDataTableFailureGameEvent.UserData != this)
            {
                return;
            }

            Log.Error("Can not load data table '{0}' from '{1}' with error message '{2}'.", loadDataTableFailureGameEvent.DataTableName, loadDataTableFailureGameEvent.DataTableAssetName, loadDataTableFailureGameEvent.ErrorMessage);
        }

        private void OnILRuntimePreload(GameEventBase gameEventBase)
        {
            ILRuntimePreloadGameEvent ilRuntimePreloadGameEvent = (ILRuntimePreloadGameEvent)gameEventBase;
            if (ilRuntimePreloadGameEvent.Success)
            {
                m_HotfixPreload = true;
                Log.Info("Hotfix preload complete");
            }
            else
            {
                Log.Error("Hotfix preload error");
            }

        }
    }
}
