﻿namespace ZJY.Framework
{
    /// <summary>
    /// 加载场景成功事件
    /// </summary>
    public sealed class LoadSceneSuccessGameEvent : GameEventBase
    {
        /// <summary>
        /// 加载场景成功事件编号
        /// </summary>
        public static readonly int EventId = typeof(LoadSceneSuccessGameEvent).GetHashCode();

        /// <summary>
        /// 获取加载场景成功事件编号
        /// </summary>
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 获取场景资源名称
        /// </summary>
        public string SceneAssetName
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取加载持续时间
        /// </summary>
        public float Duration
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取用户自定义数据
        /// </summary>
        public object UserData
        {
            get;
            private set;
        }


        /// <summary>
        /// 填充加载场景成功事件
        /// </summary>
        /// <param name="sceneAssetName">场景资源名称</param>
        /// <param name="duration">加载持续时间</param>
        /// <param name="userData">用户自定义数据</param>
        /// <returns>加载场景成功事件</returns>
        public LoadSceneSuccessGameEvent Fill(string sceneAssetName, float duration, object userData)
        {
            SceneAssetName = sceneAssetName;
            Duration = duration;
            UserData = userData;

            return this;
        }
    }
}
