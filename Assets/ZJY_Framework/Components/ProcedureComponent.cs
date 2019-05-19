using System;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 流程组件
    /// </summary>
    public class ProcedureComponent : GameBaseComponent
    {
        private ProcedureBase m_EntranceProcedure = null;

        [SerializeField]
        private string[] m_AvailableProcedureTypeNames = null;

        [SerializeField]
        private string m_EntranceProcedureTypeName = null;

        /// <summary>
        /// 流程管理器
        /// </summary>
        private ProcedureManager m_ProcedureManager;

        /// <summary>
        /// 当前流程状态
        /// </summary>
        public ProcedureBase CurrentProcedure
        {
            get
            {
                return m_ProcedureManager.CurrentProcedure;
            }
        }

        /// <summary>
        /// 获取游戏框架模块优先级
        /// </summary>
        /// <remarks>优先级较高的模块会优先轮询，并且关闭操作会后进行</remarks>
        internal override int Priority
        {
            get
            {
                return -10;
            }
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            m_ProcedureManager = new ProcedureManager();
        }

        protected override void OnStart()
        {
            base.OnStart();

            ProcedureBase[] procedures = new ProcedureBase[m_AvailableProcedureTypeNames.Length];
            for (int i = 0; i < m_AvailableProcedureTypeNames.Length; i++)
            {
                Type procedureType = AssemblyUtil.GetType(m_AvailableProcedureTypeNames[i]);
                if (procedureType == null)
                {
                    Log.Error("Can not find procedure type '{0}'.", m_AvailableProcedureTypeNames[i]);
                    return;
                }

                procedures[i] = (ProcedureBase)Activator.CreateInstance(procedureType);
                if (procedures[i] == null)
                {
                    Log.Error("Can not create procedure instance '{0}'.", m_AvailableProcedureTypeNames[i]);
                    return;
                }

                if (m_EntranceProcedureTypeName == m_AvailableProcedureTypeNames[i])
                {
                    m_EntranceProcedure = procedures[i];
                }
            }

            if (m_EntranceProcedure == null)
            {
                Log.Error("Entrance procedure is invalid.");
                return;
            }

            //要在Start时候初始化
            m_ProcedureManager.Init(procedures);
            m_ProcedureManager.StartProcedure(m_EntranceProcedure.GetType());
        }

        /// <summary>
        /// 设置参数值
        /// </summary>
        /// <typeparam name="TData">泛型类型</typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetData<TData>(string key, TData value) where TData : VariableBase
        {
            m_ProcedureManager.CurrFsm.SetData<TData>(key, value);
        }

        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public TData GetData<TData>(string key) where TData : VariableBase
        {
            return m_ProcedureManager.CurrFsm.GetData<TData>(key);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(ProcedureBase state)
        {
            m_ProcedureManager.ChangeState(state);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState<TState>() where TState : ProcedureBase
        {
            m_ProcedureManager.ChangeState<TState>();
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
            m_ProcedureManager.OnUpdate(deltaTime, unscaledDeltaTime);
        }

        public override void Shutdown()
        {
            base.Shutdown();
            m_ProcedureManager.Dispose();
        }


    }
}
