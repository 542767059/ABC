using System;
using System.Collections.Generic;
using ZJY.Framework;

namespace Hotfix
{
    /// <summary>
    /// 状态机管理器
    /// </summary>
    public class FsmManager 
    {
        /// <summary>
        /// 状态机字典
        /// </summary>
        private Dictionary<string, FsmBase> m_Fsms;

        public FsmManager()
        {
            m_Fsms = new Dictionary<string, FsmBase>();
        }

        /// <summary>
        /// 获取有限状态机数量
        /// </summary>
        public int Count
        {
            get
            {
                return m_Fsms.Count;
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
            return InternalHasFsm(TextUtil.GetFullName<T>(name));
        }

        /// <summary>
        /// 检查是否存在有限状态机
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型</param>
        /// <param name="name">有限状态机名称</param>
        /// <returns>是否存在有限状态机</returns>
        public bool HasFsm(Type ownerType, string name)
        {
            if (ownerType == null)
            {
                throw new Exception("Owner type is invalid.");
            }

            return InternalHasFsm(TextUtil.GetFullName(ownerType, name));
        }
        
        /// <summary>
        /// 获取有限状态机
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型</typeparam>
        /// <param name="name">有限状态机名称</param>
        /// <returns>要获取的有限状态机</returns>
        public Fsm<T> GetFsm<T>(string name) where T : class
        {
            return (Fsm<T>)InternalGetFsm(TextUtil.GetFullName<T>(name));
        }

        /// <summary>
        /// 获取有限状态机
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型</param>
        /// <param name="name">有限状态机名称</param>
        /// <returns>要获取的有限状态机</returns>
        public FsmBase GetFsm(Type ownerType, string name)
        {
            if (ownerType == null)
            {
                throw new Exception("Owner type is invalid.");
            }

            return InternalGetFsm(TextUtil.GetFullName(ownerType, name));
        }

        /// <summary>
        /// 获取所有有限状态机
        /// </summary>
        /// <returns>所有有限状态机</returns>
        public FsmBase[] GetAllFsms()
        {
            int index = 0;
            FsmBase[] results = new FsmBase[m_Fsms.Count];
            foreach (KeyValuePair<string, FsmBase> fsm in m_Fsms)
            {
                results[index++] = fsm.Value;
            }

            return results;
        }

        /// <summary>
        /// 获取所有有限状态机
        /// </summary>
        /// <param name="results">所有有限状态机</param>
        public void GetAllFsms(List<FsmBase> results)
        {
            if (results == null)
            {
                throw new Exception("Results is invalid.");
            }

            results.Clear();
            foreach (KeyValuePair<string, FsmBase> fsm in m_Fsms)
            {
                results.Add(fsm.Value);
            }
        }

        /// <summary>
        /// 创建状态机
        /// </summary>
        /// <typeparam name="T">拥有者的类型</typeparam>
        /// <param name="name">有限状态机名称</param>
        /// <param name="owner">拥有者</param>
        /// <param name="states">状态数组</param>
        /// <returns></returns>
        public Fsm<T> CreateFsm<T> (string name ,T owner, FsmState<T>[] states) where T : class
        {
            if (HasFsm<T>(name))
            {
                throw new Exception(TextUtil.Format("Already exist FSM '{0}'.", TextUtil.GetFullName<T>(name)));
            }
            Fsm<T> fsm = new Fsm<T>(name, owner, states);
            m_Fsms.Add(TextUtil.GetFullName<T>(name), fsm);
            return fsm;
        }

        
        /// <summary>
        /// 销毁有限状态机
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型</typeparam>
        /// <param name="name">要销毁的有限状态机名称</param>
        /// <returns>是否销毁有限状态机成功</returns>
        public bool DestroyFsm<T>(string name) where T : class
        {
            return InternalDestroyFsm(TextUtil.GetFullName<T>(name));
        }

        /// <summary>
        /// 销毁有限状态机
        /// </summary>
        /// <param name="ownerType">有限状态机持有者类型</param>
        /// <param name="name">要销毁的有限状态机名称</param>
        /// <returns>是否销毁有限状态机成功</returns>
        public bool DestroyFsm(Type ownerType, string name)
        {
            if (ownerType == null)
            {
                throw new Exception("Owner type is invalid.");
            }

            return InternalDestroyFsm(TextUtil.GetFullName(ownerType, name));
        }

        /// <summary>
        /// 销毁有限状态机
        /// </summary>
        /// <typeparam name="T">有限状态机持有者类型</typeparam>
        /// <param name="fsm">要销毁的有限状态机</param>
        /// <returns>是否销毁有限状态机成功</returns>
        public bool DestroyFsm<T>(Fsm<T> fsm) where T : class
        {
            if (fsm == null)
            {
                throw new Exception("FSM is invalid.");
            }

            return InternalDestroyFsm(TextUtil.GetFullName<T>(fsm.Name));
        }

        /// <summary>
        /// 销毁有限状态机
        /// </summary>
        /// <param name="fsm">要销毁的有限状态机</param>
        /// <returns>是否销毁有限状态机成功</returns>
        public bool DestroyFsm(FsmBase fsm)
        {
            if (fsm == null)
            {
                throw new Exception("FSM is invalid.");
            }

            return InternalDestroyFsm(TextUtil.GetFullName(fsm.OwnerType, fsm.Name));
        }

        /// <summary>
        /// 销毁状态机
        /// </summary>
        /// <typeparam name="T">状态机持有者类型</typeparam>
        /// <param name="fsm">要销毁的状态机</param>
        public bool DestoryFsm<T>(Fsm<T> fsm) where T :  class
        {
            if (fsm == null)
            {
                throw new Exception("FSM is invalid.");
            }

            return InternalDestroyFsm(TextUtil.GetFullName<T>(fsm.Name));
        }

        
        public  void Shutdown()
        {
            var enumerator = m_Fsms.GetEnumerator();
            while (enumerator.MoveNext())
            {
                enumerator.Current.Value.Shutdown();
            }
            m_Fsms.Clear();
        }

        private bool InternalHasFsm(string fullName)
        {
            return m_Fsms.ContainsKey(fullName);
        }

        private FsmBase InternalGetFsm(string fullName)
        {
            FsmBase fsm = null;
            if (m_Fsms.TryGetValue(fullName, out fsm))
            {
                return fsm;
            }

            return null;
        }


        private bool InternalDestroyFsm(string fullName)
        {
            FsmBase fsm = null;
            if (m_Fsms.TryGetValue(fullName, out fsm))
            {
                fsm.Shutdown();
                return m_Fsms.Remove(fullName);
            }

            return false;
        }
    }
}
