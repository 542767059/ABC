//===================================================
//
//===================================================

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ZJY.Framework
{
    /// <summary>
    /// 流程管理器
    /// </summary>
    public class ProcedureManager : ManagerBase
    {
        /// <summary>
        /// 流程状态机
        /// </summary>
        private Fsm<ProcedureManager> m_CurrFsm;

        /// <summary>
        /// 当前流程状态机
        /// </summary>
        public Fsm<ProcedureManager> CurrFsm
        {
            get
            {
                return m_CurrFsm;
            }
        }


        /// <summary>
        /// 获取当前流程
        /// </summary>
        public ProcedureBase CurrentProcedure
        {
            get
            {
                if (m_CurrFsm == null)
                {
                    throw new Exception("You must initialize procedure first.");
                }

                return (ProcedureBase)m_CurrFsm.CurrentState;
            }
        }

        public ProcedureManager()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="procedures">流程管理器包含的流程</param>
        public void Init(params ProcedureBase[] procedures)
        {
            m_CurrFsm = GameEntry.Fsm.CreateFsm("Procedure", this, procedures);
        }

        /// <summary>
        /// 开始流程
        /// </summary>
        /// <param name="procedureType">要开始的流程类型</param>
        public void StartProcedure(Type procedureType)
        {
            if (m_CurrFsm == null)
            {
                throw new Exception("You must initialize procedure first.");
            }

            m_CurrFsm.Start(procedureType);
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState<TState>() where TState : ProcedureBase
        {
            m_CurrFsm.ChangeState<TState>();
        }

        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(ProcedureBase state)
        {
            m_CurrFsm.ChangeState(state.GetType());
        }

        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            m_CurrFsm.OnUpdate(deltaTime, unscaledDeltaTime);
        }

        public override void Dispose()
        {
            if (m_CurrFsm != null)
            {
                GameEntry.Fsm.DestroyFsm(m_CurrFsm);
                m_CurrFsm = null;
            }
            m_CurrFsm = null;
        }
    }

}
