using System;
using System.Collections.Generic;
using UnityEngine;
using ZJY.Framework;

namespace Hotfix
{
    /// <summary>
    /// 热更新层入口
    /// </summary>
    public class HotfixEntry
    {
        private static readonly LinkedList<IHotfixComponent> m_GameComponentList = new LinkedList<IHotfixComponent>();

        /// <summary>
        /// 实体
        /// </summary>
        public static DataTableComponent DataTable
        {
            get;
            private set;
        }

        /// <summary>
        /// 实体
        /// </summary>
        public static EntityComponent Entity
        {
            get;
            private set;
        }

        /// <summary>
        /// 实体
        /// </summary>
        public static EventComponent Event
        {
            get;
            private set;
        }

        /// <summary>
        /// 实体
        /// </summary>
        public static FsmComponent Fsm
        {
            get;
            private set;
        }

        /// <summary>
        /// 对象池
        /// </summary>
        public static PoolComponent Pool
        {
            get;
            private set;
        }

        public void Start()
        {
            Debug.Log("热更新层启动!");
            //热修复
            //Fiaxed.Init();

            //todo 初始化组件在这里进行
            DataTable = GetComponent<DataTableComponent>();
            Entity = GetComponent<EntityComponent>();
            Event = GetComponent<EventComponent>();
            Fsm = GetComponent<FsmComponent>();
            Pool = GetComponent<PoolComponent>();

            SocketProtoListener.AddProtoListener();
            HotfixEntry.Event.AddEventListener(LoadDataTableSuccessGameEvent.EventId, OnLoadDataTableSuccess);
            HotfixEntry.Event.AddEventListener(LoadDataTableFailureGameEvent.EventId, OnLoadDataTableFailure);
            //GameEntry.Event.CommonEvent.AddEventListener(ZJY.Framework.LoadDataTableSuccessGameEvent.EventId, OK);
            //HotfixEntry.Event.AddEventListener(LoadDataTableSuccessGameEvent.EventId, OK1);
        }

        //private void OK1(GameEventBase gameEventBase)
        //{
        //    LoadDataTableSuccessGameEvent loadDataTableSuccessGameEvent = (LoadDataTableSuccessGameEvent)gameEventBase;
        //    Debug.Log(loadDataTableSuccessGameEvent.DataTableAssetName);
        //    Debug.Log(loadDataTableSuccessGameEvent.Duration);
        //    Debug.Log(loadDataTableSuccessGameEvent.UserData);
        //}

        //private void OK(ZJY.Framework.GameEventBase gameEventBase)
        //{
        //    ZJY.Framework.LoadDataTableSuccessGameEvent loadDataTableSuccessGameEvent = (ZJY.Framework.LoadDataTableSuccessGameEvent)gameEventBase;
        //    Debug.Log(loadDataTableSuccessGameEvent.DataTableAssetName);
        //    Debug.Log(loadDataTableSuccessGameEvent.Duration);
        //    Debug.Log(loadDataTableSuccessGameEvent.UserData);
        //}



        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="deltaTime">逻辑流逝时间，以秒为单位</param>
        /// <param name="unscaledDeltaTime">真实流逝时间，以秒为单位</param>
        public void Update(float deltaTime, float unscaledDeltaTime)
        {
            for (LinkedListNode<IHotfixComponent> curr = m_GameComponentList.First; curr != null; curr = curr.Next)
            {
                curr.Value.OnUpdate(deltaTime, unscaledDeltaTime);
            }


            //if (Input.GetKeyUp(KeyCode.B))
            //{
            //    GameEntry.Resource.LoadAsset("Assets/DownLoad/Prefab/CreateRole/104000.prefab", typeof(GameObject), 0,
            // new LoadAssetCallbacks((assetName, asset, duration, userData) =>
            // {
            //     Debug.Log(assetName);
            //     UnityEngine.Object.Instantiate(asset);
            //     Debug.Log(duration);
            //     Debug.Log(userData);
            // },
            // (string assetName,string sdsd, object userData) =>
            // {

            // },
            // (string assetName, float progress, object userData) =>
            // {

            // }),1);
            //}

            //if (Input.GetKeyUp(KeyCode.C))
            //{
            //    HotfixEntry.Entity.ShowEntity<TestEntity>(0, "Assets/DownLoad/Prefab/CreateRole/104000.prefab", "ABC", 0, "123456789");
            //}

            //if (Input.GetKeyUp(KeyCode.E))
            //{
            //    HotfixEntry.Entity.HideEntity(0);
            //}
            //if (Input.GetKeyUp(KeyCode.D))
            //{
            //    TestEntity testEntity = (TestEntity)HotfixEntry.Entity.GetEntity(0);
            //    if (testEntity!=null)
            //    {
            //        Debug.Log("获取到了！");
            //    }
            //}

            //if (Input.GetKeyUp(KeyCode.B))
            //{
            //    int id = GameEntry.UI.OpenUIForm("Assets/DownLoad/UI/UIPrefab/SelectRole/SelectRoleForm.prefab", "Default");
            //    //GameEntry.UI.CloseUIForm(id);
            //}

            //if (Input.GetKeyUp(KeyCode.B))
            //{
            //    GameEntry.DataTable.LoadDataTable<ZJY.Framework.ChapterDBModel>("Assets/DownLoad/DataTable/Chapter.bytes", 0, 132);
            //}
            //if (Input.GetKeyUp(KeyCode.B))
            //{
            //    HotfixEntry.DataTable.LoadDataTable<ChapterDBModel>("Assets/DownLoad/DataTable/Chapter.bytes", 0, 132);
            //}
        }

        /// <summary>
        /// 关闭热更新
        /// </summary>
        public void ShutDown()
        {
            HotfixEntry.Event.RemoveEventListener(LoadDataTableSuccessGameEvent.EventId, OnLoadDataTableSuccess);
            HotfixEntry.Event.RemoveEventListener(LoadDataTableFailureGameEvent.EventId, OnLoadDataTableFailure);

            Debug.Log("热更新关闭!");
            for (LinkedListNode<IHotfixComponent> curr = m_GameComponentList.First; curr != null; curr = curr.Next)
            {
                curr.Value.Shutdown();
            }

            SocketProtoListener.RemoveProtoListener();
        }

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <typeparam name="T">要获取的组件类型</typeparam>
        /// <returns>获取到的组件类型</returns>
        public static T GetComponent<T>() where T : IHotfixComponent
        {
            Type type = typeof(T);
            return (T)GetComponent(type);
        }

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <typeparam name="componentType">要获取的组件类型</typeparam>
        /// <returns>获取到的组件类型</returns>
        private static IHotfixComponent GetComponent(Type componentType)
        {
            foreach (IHotfixComponent hotfixComponent in m_GameComponentList)
            {
                if (hotfixComponent.GetType() == componentType)
                {
                    return hotfixComponent;
                }
            }

            return CreateComponent(componentType);
        }

        /// <summary>
        /// 创建组件
        /// </summary>
        /// <param name="componentType">要创建的组件类型</param>
        /// <returns>要创建的组件类型</returns>
        private static IHotfixComponent CreateComponent(Type componentType)
        {
            IHotfixComponent hotfixComponent = (IHotfixComponent)Activator.CreateInstance(componentType);
            if (hotfixComponent == null)
            {
                throw new Exception(TextUtil.Format("Can not create component '{0}'.", componentType.FullName));
            }
            hotfixComponent.Init();
            LinkedListNode<IHotfixComponent> current = m_GameComponentList.First;

            m_GameComponentList.AddLast(hotfixComponent);

            return hotfixComponent;
        }


        #region 预加载

        private int m_PreloadCount = 0;
        private int m_TotalCount = 0;

        /// <summary>
        /// 预加载
        /// </summary>
        public void Preload()
        {
            m_PreloadCount = 0;
            m_TotalCount = 0;
            PreloadDataTable();
        }

        private static readonly string[] DataTableNames = new string[]
        {
            "Task",

        };

        /// <summary>
        /// 预加载表格
        /// </summary>
        public void PreloadDataTable()
        {
            foreach (string dataTableName in DataTableNames)
            {
                m_TotalCount++;
                LoadTable(dataTableName);
            }
        }

        private void LoadTable(string dataTableName)
        {
            HotfixEntry.DataTable.LoadDataTable(dataTableName, this);
        }

        private void OnLoadDataTableSuccess(GameEventBase gameEventBase)
        {
            LoadDataTableSuccessGameEvent loadDataTableSuccessGameEvent = (LoadDataTableSuccessGameEvent)gameEventBase;
            if (loadDataTableSuccessGameEvent.UserData != this)
            {
                return;
            }
            
            Log.Info("Load data table '{0}' OK.", loadDataTableSuccessGameEvent.DataTableName);
            m_PreloadCount++;
            if (m_PreloadCount >= m_TotalCount)
            {
                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<ILRuntimePreloadGameEvent>().Fill(true, this));
            }
        }

        private void OnLoadDataTableFailure(GameEventBase gameEventBase)
        {
            LoadDataTableFailureGameEvent loadDataTableFailureGameEvent = (LoadDataTableFailureGameEvent)gameEventBase;
            if (loadDataTableFailureGameEvent.UserData != this)
            {
                return;
            }
            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<ILRuntimePreloadGameEvent>().Fill(false, this));
            Log.Error("Can not load data table '{0}' from '{1}' with error message '{2}'.", loadDataTableFailureGameEvent.DataTableName, loadDataTableFailureGameEvent.DataTableAssetName, loadDataTableFailureGameEvent.ErrorMessage);
        }
        #endregion
    }
}

