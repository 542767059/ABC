namespace ZJY.Framework
{
    public abstract class GameBaseComponent : GameComponent, IUpdateComponent
    {
        /// <summary>
        /// 获取游戏框架模块优先级
        /// </summary>
        /// <remarks>优先级较高的模块会优先轮询，并且关闭操作会后进行</remarks>
        internal virtual int Priority
        {
            get
            {
                return 0;
            }
        }

        protected override void OnAwake()
        {
            base.OnAwake();

            //把自己加入基础组件列表
            GameEntry.RegisterBaseComponent(this);
            GameEntry.RegisterUpdateComponent(this);
        }

        /// <summary>
        /// 关闭方法
        /// </summary>
        public virtual void Shutdown()
        {
            GameEntry.RemoveUpdateComponent(this);
        }

        public virtual void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {

        }
    }
}
