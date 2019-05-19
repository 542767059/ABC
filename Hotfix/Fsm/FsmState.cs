using System;
using ZJY.Framework;

namespace Hotfix
{
    /// <summary>
    /// 状态机的状态
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class FsmState<T> where T : class
    {
        /// <summary>
        /// 状态对应的状态机
        /// </summary>
        public Fsm<T> CurrFsm
        {
            get;
            set;
        }

        /// <summary>
        /// 初始化状态
        /// </summary>
        public virtual void OnInit() { }

        /// <summary>
        /// 进入状态
        /// </summary>
        public virtual void OnEnter() { }
        
        /// <summary>
        /// 执行状态
        /// </summary>
        public virtual void OnUpdate(float deltaTime, float unscaledDeltaTime) { }

        /// <summary>
        /// 离开状态
        /// </summary>
        public virtual void OnLeave() { }

        /// <summary>
        /// 状态机销毁时候调用
        /// </summary>
        public virtual void OnDestory() { }

        /// <summary>
        /// 切换当前有限状态机状态
        /// </summary>
        /// <typeparam name="TState">要切换到的有限状态机状态类型</typeparam>
        protected void ChangeState<TState>() where TState : FsmState<T>
        {
            if (CurrFsm == null)
            {
                throw new Exception("FSM is invalid.");
            }

            CurrFsm.ChangeState<TState>();
        }

        /// <summary>
        /// 切换当前有限状态机状态
        /// </summary>
        /// <param name="fsm">有限状态机引用</param>
        /// <param name="stateType">要切换到的有限状态机状态类型</param>
        protected void ChangeState(Type stateType)
        {
            if (CurrFsm == null)
            {
                throw new Exception("FSM is invalid.");
            }

            if (stateType == null)
            {
                throw new Exception("State type is invalid.");
            }

            if (!typeof(FsmState<T>).IsAssignableFrom(stateType))
            {
                throw new Exception(TextUtil.Format("State type '{0}' is invalid.", stateType.FullName));
            }

            CurrFsm.ChangeState(stateType);
        }
    }
}
