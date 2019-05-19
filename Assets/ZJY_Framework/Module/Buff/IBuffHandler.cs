using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZJY.Framework
{
    public abstract class BaseBuffHandler
    {
        public float buffTime;

        public BuffHandlerVar BuffHandlerVar;

        public Entity Effect;

        public abstract BuffTimeType BuffTimeType
        {
            get;
        }


        public abstract void OnUpdate(float deltaTime, float unscaledDeltaTime);
    }


    public struct BuffHandlerVar
    {
        public int buffId;
        public BaseBuffData data; // 对应的Buff数据
        public PlayerBase source; // 来源方
        public float playSpeed;// 技能,特效等的播放速度
        public int skillId;
        public int skillLevel;//技能等级,用以处理一些数值需要跟随技能等级变动的情况
    }

    public enum BuffTimeType
    {
        /// <summary>
        /// 瞬发
        /// </summary>
        Prompt,
        /// <summary>
        /// 永久
        /// </summary>
        Forever,
        /// <summary>
        /// 有生存时间
        /// </summary>
        LifeTime,
    }

    /// <summary>
    /// 增加时触发
    /// </summary>
    public interface IBuffAddHanlder
    {
        void AddHandle(BuffHandlerVar buffHandlerVar);
    }

    /// <summary>
    /// 移除时触发
    /// </summary>
    public interface IBuffRemoveHanlder
    {
        void Remove(BuffHandlerVar buffHandlerVar);//主动中断/打断或者正常的效果移除之类,会调用该方法
    }


    /// <summary>
    /// 一直更新
    /// </summary>
    public interface IBuffUpdateHanlder
    {
        void Update(BuffHandlerVar buffHandlerVar);//一些buff的效果更新/刷新. 用这个
    }
}
