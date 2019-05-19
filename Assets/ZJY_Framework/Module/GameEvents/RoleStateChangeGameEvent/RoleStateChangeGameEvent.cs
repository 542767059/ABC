using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZJY.Framework
{
    /// <summary>
    /// 角色状态改变事件
    /// </summary>
    public class RoleStateChangeGameEvent:GameEventBase
    {
        /// <summary>
        /// 角色状态改变事件编号
        /// </summary>
        public static readonly int EventId = typeof(RoleStateChangeGameEvent).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// 改变的角色
        /// </summary>
        public Entity Owner
        {
            get;
            private set;
        }

        /// <summary>
        /// 改变的状态
        /// </summary>
        public SpecialStateType SpecialStateType
        {
            get;
            private set;
        }

        /// <summary>
        /// 改变的值
        /// </summary>
        public bool Value
        {
            get;
            private set;
        }

        public RoleStateChangeGameEvent Fill(Entity owner,SpecialStateType specialStateType,bool value)
        {
            Owner = owner;
            SpecialStateType = specialStateType;
            Value = value;
            return this;
        }
    }
}
