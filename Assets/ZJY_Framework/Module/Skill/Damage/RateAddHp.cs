using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZJY.Framework
{
    /// <summary>
    /// 当前生命的百分比
    /// </summary>
    public class RateAddHp : IDamage
    {
        public int Handle(Skill skill)
        {
            //todo
            Debug.Log("返回百分比之后的值");
            return 1;
        }
    }
}
