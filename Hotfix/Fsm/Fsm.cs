using System;
using System.Collections.Generic;
using ZJY.Framework;

namespace Hotfix
{
    /// <summary>
    /// 状态机
    /// </summary>
    /// <typeparam name="T">有限状态机持有者类型</typeparam>
    public class Fsm<T> : FsmBase where T : class
    {
        /// <summary>
        /// 状态机是否被销毁
        /// </summary>
        private bool m_IsDestroyed;

        /// <summary>
        /// 当前状态的持续时间
        /// </summary>
        private float m_CurrentStateTime;

        /// <summary>
        /// 状态机拥有者
        /// </summary>
        private readonly T m_Owner;

        /// <summary>
        /// 当前状态
        /// </summary>
        private FsmState<T> m_CurrentState;

        /// <summary>
        /// 状态字典
        /// </summary>
        private Dictionary<string, FsmState<T>> m_States;

        /// <summary>
        /// 参数字典
        /// </summary>
        private readonly Dictionary<string, VariableBase> m_Datas;

        /// <summary>
        /// 获取有限状态机是否正在运行
        /// </summary>
        public override bool IsRunning
        {
            get
            {
                return m_CurrentState != null;
            }
        }

        /// <summary>
        /// 获取当前有限状态机状态持续时间。
        /// </summary>
        public override float CurrentStateTime
        {
            get
            {
                return m_CurrentStateTime;
            }
        }

        /// <summary>
        /// 获取有限状态机是否被销毁
        /// </summary>
        public override bool IsDestroyed
        {
            get
            {
                return m_IsDestroyed;
            }
        }

        /// <summary>
        /// 获取当前有限状态机状态
        /// </summary>
        public FsmState<T> CurrentState
        {
            get
            {
                return m_CurrentState;
            }
        }

        /// <summary>
        /// 获取当前有限状态机状态名称
        /// </summary>
        public override string CurrentStateName
        {
            get
            {
                return m_CurrentState != null ? m_CurrentState.GetType().FullName : null;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">有限状态机名称</param>
        /// <param name="owner">拥有者</param>
        /// <param name="states">状态数组</param>
        public Fsm(string name, T owner, FsmState<T>[] states) : base(name)
        {
            if (owner == null)
            {
                throw new Exception("FSM owner is invalid.");
            }

            if (states == null || states.Length < 1)
            {
                throw new Exception("FSM states is invalid.");
            }

            m_Owner = owner;
            m_States = new Dictionary<string, FsmState<T>>();
            m_Datas = new Dictionary<string, VariableBase>();

            //把状态加入字典
            foreach (FsmState<T> state in states)
            {
                if (state == null)
                {
                    throw new Exception("FSM states is invalid.");
                }

                string stateName = state.GetType().FullName;
                if (m_States.ContainsKey(stateName))
                {
                    throw new Exception(TextUtil.Format("FSM '{0}' state '{1}' is already exist.", TextUtil.GetFullName<T>(name), stateName));
                }

                m_States.Add(stateName, state);
                state.CurrFsm = this;
                state.OnInit();
            }

            m_CurrentStateTime = 0f;
            m_CurrentState = null;
            m_IsDestroyed = false;
        }


        /// <summary>
        /// 获取有限状态机持有者
        /// </summary>
        public T Owner
        {
            get
            {
                return m_Owner;
            }
        }

        /// <summary>
        /// 获取有限状态机持有者类型
        /// </summary>
        public override Type OwnerType
        {
            get
            {
                return typeof(T);
            }
        }

        /// <summary>
        /// 获取有限状态机中状态的数量
        /// </summary>
        public override int FsmStateCount
        {
            get
            {
                return m_States.Count;
            }
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        /// <param name="stateType">要获取的有限状态机状态类型</param>
        /// <returns>要获取的有限状态机状态</returns>
        public FsmState<T> GetState(Type stateType)
        {
            if (stateType == null)
            {
                throw new Exception("State type is invalid.");
            }

            if (!typeof(FsmState<T>).IsAssignableFrom(stateType))
            {
                throw new Exception(TextUtil.Format("State type '{0}' is invalid.", stateType.FullName));
            }

            FsmState<T> state = null;
            if (m_States.TryGetValue(stateType.FullName, out state))
            {
                return state;
            }
            return null;
        }

        /// <summary>
        /// 开始有限状态机
        /// </summary>
        /// <param name="stateType">要开始的有限状态机状态类型</param>
        public void Start(Type stateType)
        {
            if (IsRunning)
            {
                throw new Exception("FSM is running, can not start again.");
            }

            if (stateType == null)
            {
                throw new Exception("State type is invalid.");
            }

            FsmState<T> state = GetState(stateType);
            if (state == null)
            {
                throw new Exception("FSM  can not start state .");
            }

            m_CurrentStateTime = 0f;
            m_CurrentState = state;
            m_CurrentState.OnEnter();
        }


        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            if (m_CurrentState != null)
            {
                m_CurrentStateTime += deltaTime;
                m_CurrentState.OnUpdate(deltaTime, unscaledDeltaTime);
            }
        }

        /// <summary>
        /// 切换当前有限状态机状态
        /// </summary>
        /// <typeparam name="TState">要切换到的有限状态机状态类型</typeparam>
        public void ChangeState<TState>() where TState : FsmState<T>
        {
            ChangeState(typeof(TState));
        }

        /// <summary>
        /// 切换当前有限状态机状态
        /// </summary>
        /// <typeparam name="stateType">要切换到的有限状态机状态类型</typeparam>
        public void ChangeState(Type stateType)
        {
            if (m_CurrentState == null)
            {
                throw new Exception("Current state is invalid.");
            }

            FsmState<T> state = GetState(stateType);
            if (state == null)
            {
                throw new Exception(TextUtil.Format("FSM '{0}' can not change state to '{1}' which is not exist.", TextUtil.GetFullName<T>(Name), stateType.FullName));
            }

            m_CurrentState.OnLeave();
            m_CurrentStateTime = 0f;
            m_CurrentState = state;
            m_CurrentState.OnEnter();
        }

        /// <summary>
        /// 是否存在有限状态机数据。
        /// </summary>
        /// <param name="name">有限状态机数据名称。</param>
        /// <returns>有限状态机数据是否存在。</returns>
        public bool HasData(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Data name is invalid.");
            }

            return m_Datas.ContainsKey(name);
        }

        /// <summary>
        /// 获取有限状态机数据。
        /// </summary>
        /// <typeparam name="TData">要获取的有限状态机数据的类型。</typeparam>
        /// <param name="name">有限状态机数据名称。</param>
        /// <returns>要获取的有限状态机数据。</returns>
        public TData GetData<TData>(string name) where TData : VariableBase
        {
            return (TData)GetData(name);
        }

        /// <summary>
        /// 获取有限状态机数据。
        /// </summary>
        /// <param name="name">有限状态机数据名称。</param>
        /// <returns>要获取的有限状态机数据。</returns>
        public VariableBase GetData(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Data name is invalid.");
            }

            VariableBase data = null;
            if (m_Datas.TryGetValue(name, out data))
            {
                return data;
            }

            return null;
        }

        /// <summary>
        /// 设置有限状态机数据。
        /// </summary>
        /// <typeparam name="TData">要设置的有限状态机数据的类型。</typeparam>
        /// <param name="name">有限状态机数据名称。</param>
        /// <param name="data">要设置的有限状态机数据。</param>
        public void SetData<TData>(string name, TData data) where TData : VariableBase
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Data name is invalid.");
            }

            m_Datas[name] = data;
        }

        /// <summary>
        /// 设置有限状态机数据。
        /// </summary>
        /// <param name="name">有限状态机数据名称。</param>
        /// <param name="data">要设置的有限状态机数据。</param>
        public void SetData(string name, VariableBase data)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Data name is invalid.");
            }

            m_Datas[name] = data;
        }

        /// <summary>
        /// 移除有限状态机数据。
        /// </summary>
        /// <param name="name">有限状态机数据名称。</param>
        /// <returns>是否移除有限状态机数据成功。</returns>
        public bool RemoveData(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Data name is invalid.");
            }

            return m_Datas.Remove(name);
        }


        /// <summary>
        /// 关闭状态机
        /// </summary>
        public override void Shutdown()
        {
            if (m_CurrentState != null)
            {
                m_CurrentState.OnLeave();
                m_CurrentState = null;
            }
            var enumerator = m_States.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Value.OnDestory();
            }

            m_States.Clear();
            m_Datas.Clear();

            m_IsDestroyed = true;
        }
    }
}
