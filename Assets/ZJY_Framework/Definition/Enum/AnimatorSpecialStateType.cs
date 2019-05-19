using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZJY.Framework
{
    /// <summary>
    /// 状态机特殊状态参数
    /// </summary>
    public enum AnimatorSpecialStateType
    {
        /// <summary>
        /// (演示)采集物品之类的
        /// </summary>
        Cast = 0,

        /// <summary>
        /// 眩晕
        /// </summary>
        Stun = 1,

        /// <summary>
        /// 击倒
        /// </summary>
        Knockdown = 2,
    }
}
