using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 数据组件
    /// </summary>
    public class DataComponent : GameBaseComponent
    {
        [SerializeField]
        private CacheData m_CacheData;

        [SerializeField]
        private SystemData m_SystemData;

        [SerializeField]
        private UserData m_UserData;

        [SerializeField]
        private PVEMapData m_PVEMapData;

        /// <summary>
        /// 获取临时缓存数据
        /// </summary>
        public CacheData CacheData
        {
            get
            {
                return m_CacheData;
            }
        }

        /// <summary>
        /// 获取系统数据
        /// </summary>
        public SystemData SystemData
        {
            get
            {
                return m_SystemData;
            }
        }

        /// <summary>
        /// 获取用户数据
        /// </summary>
        public UserData UserData
        {
            get
            {
                return m_UserData;
            }
        }

        /// <summary>
        /// 获取关卡地图数据
        /// </summary>
        public PVEMapData PVEMapData
        {
            get
            {
                return m_PVEMapData;
            }
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            m_CacheData = new CacheData();
            m_SystemData = new SystemData();
            m_UserData = new UserData();
            m_PVEMapData = new PVEMapData();
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            m_SystemData.OnUpdate(deltaTime, unscaledDeltaTime);
        }

        public override void Shutdown()
        {
            base.Shutdown();
            m_CacheData.Clear();
            m_SystemData.Clear();
            m_UserData.Clear();
            m_PVEMapData.Clear();
        }
    }
}