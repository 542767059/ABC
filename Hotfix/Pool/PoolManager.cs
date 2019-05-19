using System;
using System.Collections.Generic;


namespace Hotfix
{
    /// <summary>
    /// 对象池管理器
    /// </summary>
    public class PoolManager 
    {
        private const int DefaultCapacity = int.MaxValue;
        private const float DefaultExpireTime = float.MaxValue;
        private const int DefaultPriority = 0;
        

        public ClassObjectPool ClassObjectPool
        {
            get;
            private set;
        }

        public float ClearClassObjectInterval
        {
            get
            {
                return ClassObjectPool.ClearClassObjectInterval;
            }
            set
            {
                ClassObjectPool.ClearClassObjectInterval = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public PoolManager()
        {
            ClassObjectPool = new ClassObjectPool();
        }
        
        /// <summary>
        /// 对象池管理器轮询
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位</param>
        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            ClassObjectPool.OnUpdate(deltaTime, unscaledDeltaTime);
        }


        /// <summary>
        /// 关闭并清理对象池管理器
        /// </summary>
        public  void Shutdown()
        {
            ClassObjectPool.Dispose();
        }
    }
}
