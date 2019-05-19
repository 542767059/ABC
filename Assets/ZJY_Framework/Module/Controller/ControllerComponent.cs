using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 动画控制器管理
    /// </summary>
    public class ControllerComponent : GameBaseComponent
    {
        [SerializeField]
        private float m_AutoClearInetrval = 60f;

        /// <summary>
        /// 获取或设置自动释放间隔
        /// </summary>
        public float AutoClearInetrval
        {
            get
            {
                return m_ControllerManager.AutoClearInetrval;
            }
            set
            {
                m_ControllerManager.AutoClearInetrval = value;
            }
        }

        /// <summary>
        /// 获取所有控制器信息
        /// </summary>
        public Dictionary<Animator, AssetObject> ControllerInfos
        {
            get
            {
                return m_ControllerManager.ControllerInfos;
            }
        }

        private ControllerManager m_ControllerManager;
        protected override void OnAwake()
        {
            base.OnAwake();
            m_ControllerManager = new ControllerManager();
        }

        protected override void OnStart()
        {
            base.OnStart();
            m_ControllerManager.SetObjectPoolManager();
            m_ControllerManager.AutoClearInetrval = m_AutoClearInetrval;
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            m_ControllerManager.OnUpdate(deltaTime, unscaledDeltaTime);
        }

        public override void Shutdown()
        {
            base.Shutdown();
            m_ControllerManager.Dispose();
        }

        /// <summary>
        /// 设置控制器
        /// </summary>
        /// <param name="entity">要设置的状态机</param>
        /// <param name="assetName">要设置的资源名称</param>
        public void SetController(Animator animator, string assetName)
        {
            m_ControllerManager.SetController(animator, assetName);
        }

        /// <summary>
        /// 设置控制器为空
        /// </summary>
        /// <param name="animator">要设置的状态机</param>
        public void SetControllerEmpty(Animator animator)
        {
            m_ControllerManager.SetControllerEmpty(animator);
        }
    }
}