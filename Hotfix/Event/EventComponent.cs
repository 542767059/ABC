namespace Hotfix
{
    /// <summary>
    /// 事件组件
    /// </summary>
    public class EventComponent : IHotfixComponent
    {
        /// <summary>
        /// 事件管理器
        /// </summary>
        private EventManager m_EventManager;

        public void Init()
        {
            m_EventManager = new EventManager();
        }

        public void Shutdown()
        {
            m_EventManager.Shutdown();
        }

        /// <summary>
        /// 事件轮询
        /// </summary>
        /// <param name="deltaTime">逻辑流逝时间，以秒为单位</param>
        /// <param name="unscaledDeltaTime">真实流逝时间，以秒为单位</param>
        public void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            m_EventManager.OnUpdate(deltaTime, unscaledDeltaTime);
        }

        /// <summary>
        /// 添加监听
        /// </summary>
        /// <param name="key">事件的Id</param>
        /// <param name="handler">事件处理</param>
        public void AddEventListener(int key, OnActionHandler handler)
        {
            m_EventManager.AddEventListener(key, handler);
        }

        /// <summary>
        /// 移除监听
        /// </summary>
        /// <param name="key">事件的Id</param>
        /// <param name="handler">事件处理</param>
        public void RemoveEventListener(int key, OnActionHandler handler)
        {
            m_EventManager.RemoveEventListener(key, handler);
        }

        /// <summary>
        /// 立刻派发事件，这不是线程安全的
        /// </summary>
        /// <param name="sender">事件发送者，一般填this即可</param>
        /// <param name="gameEventBase">事件内容</param>
        public void DispatchNow(object sender, GameEventBase gameEventBase)
        {
            m_EventManager.DispatchNow(sender, gameEventBase);
        }


        /// <summary>
        /// 派发事件，这是线程安全的
        /// </summary>
        /// <param name="sender">事件发送者，一般填this即可</param>
        /// <param name="gameEventBase"></param>
        public void Dispatch(object sender, GameEventBase gameEventBase)
        {
            m_EventManager.Dispatch(sender, gameEventBase);
        }
    }
}
    