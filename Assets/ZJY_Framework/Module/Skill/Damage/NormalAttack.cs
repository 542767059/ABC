using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 普通攻击伤害
    /// </summary>
    public class NormalAttack : IDamage
    {
        public int Handle(Skill skill)
        {
            //todo
            Debug.Log("普通攻击伤害");
            return 0;

        }
    }
}