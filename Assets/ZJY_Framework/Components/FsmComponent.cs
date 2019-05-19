using System;
using System.Collections.Generic;

namespace ZJY.Framework
{
    /// <summary>
    /// 状态机组件
    /// </summary>
    public class FsmComponent : GameBaseComponent
    {
        /// <summary>
        /// 状态机管理器
        /// </summary>
        private FsmManager m_FsmManager;
        

        protected override void OnAwake()
        {
            base.OnAwake();
            m_FsmManager = new FsmManager();
        }

        /// <summary>
        /// 获取游戏框架模块优先级
        /// </summary>
        /// <remarks>优先级较高的模块会优先轮询，并且关闭操作会后进行</remarks>
        internal override int Priority
        {
            get
            {
                return 60;
            }
        }

        /// <summary>
        /// 获取有限状态机数量
        /// </summary>
        public int Count
        {
            get
            {
                return m_FsmManager.Count;
            }
        }
        
        /// <summary>
        /// 检查是否存在有限状态机
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型</typeparam>
        /// <param name="name">有限状态机名称</param>
        /// <returns>是否存在有限状态机</returns>
        public bool HasFsm<T>(string name) where T : class
        {
            return m_FsmManager.HasFsm<T>(name);
        }

        /// <summary>
        /// 检查是否存在有限状态机
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型</param>
        /// <param name="name">有限状态机名称</param>
        /// <returns>是否存在有限状态机</returns>
        public bool HasFsm(Type ownerType, string name)
        {
            return m_FsmManager.HasFsm(ownerType, name);
        }
        
        /// <summary>
        /// 获取有限状态机
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型</typeparam>
        /// <param name="name">有限状态机名称</param>
        /// <returns>要获取的有限状态机</returns>
        public Fsm<T> GetFsm<T>(string name) where T : class
        {
            return m_FsmManager.GetFsm<T>(name);
        }

        /// <summary>
        /// 获取有限状态机
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型</param>
        /// <param name="name">有限状态机名称</param>
        /// <returns>要获取的有限状态机</returns>
        public FsmBase GetFsm(Type ownerType, string name)
        {
            return m_FsmManager.GetFsm(ownerType, name);
        }

        /// <summary>
        /// 获取所有有限状态机
        /// </summary>
        public FsmBase[] GetAllFsms()
        {
            return m_FsmManager.GetAllFsms();
        }

        /// <summary>
        /// 获取所有有限状态机
        /// </summary>
        /// <param name="results">所有有限状态机</param>
        public void GetAllFsms(List<FsmBase> results)
        {
            m_FsmManager.GetAllFsms(results);
        }

        /// <summary>
        /// 创建有限状态机
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型</typeparam>
        /// <param name="name">有限状态机名称</param>
        /// <param name="owner">有限状态机持有者</param>
        /// <param name="states">有限状态机状态集合</param>
        /// <returns>要创建的有限状态机</returns>
        public Fsm<T> CreateFsm<T>(string name, T owner, params FsmState<T>[] states) where T : class
        {
            return m_FsmManager.CreateFsm(name, owner, states);
        }

        /// <summary>
        /// 销毁有限状态机
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型</typeparam>
        /// <param name="name">要销毁的有限状态机名称</param>
        /// <returns>是否销毁有限状态机成功</returns>
        public bool DestroyFsm<T>(string name) where T : class
        {
            return m_FsmManager.DestroyFsm<T>(name);
        }

        /// <summary>
        /// 销毁有限状态机
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型</param>
        /// <param name="name">要销毁的有限状态机名称</param>
        /// <returns>是否销毁有限状态机成功</returns>
        public bool DestroyFsm(Type ownerType, string name)
        {
            return m_FsmManager.DestroyFsm(ownerType, name);
        }

        /// <summary>
        /// 销毁有限状态机
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型</typeparam>
        /// <param name="fsm">要销毁的有限状态机</param>
        /// <returns>是否销毁有限状态机成功</returns>
        public bool DestroyFsm<T>(Fsm<T> fsm) where T : class
        {
            return m_FsmManager.DestroyFsm(fsm);
        }

        /// <summary>
        /// 销毁有限状态机
        /// </summary>
        /// <param name="fsm">要销毁的有限状态机</param>
        /// <returns>是否销毁有限状态机成功</returns>
        public bool DestroyFsm(FsmBase fsm)
        {
            return m_FsmManager.DestroyFsm(fsm);
        }

        public override void Shutdown()
        {
            base.Shutdown();
            m_FsmManager.Dispose();
        }
    }
}