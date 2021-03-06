﻿using System;

namespace ZJY.Framework
{
    public enum BuffTargetType
    {
        自身,
        范围内我方角色,
        范围内敌方角色,
        敌方单体,
    }

    public enum RestrictionType
    {
        击退,
        眩晕,
    }

    /// <summary>
    /// 如果这个BUFF是叠加的,当有相同类型,比如同种DOT,同种效果的BUFF,那么重复施放的效果就是叠加BUFF层数
    /// 刷新就是刷新时间
    /// 独立就是该BUFF和其他BUFF是分开的
    /// </summary>
    public enum BuffStackType
    {
        叠加,
        刷新,
        独立
    }

    [Serializable]
    public abstract class BaseBuffData
    {
        //这个string值的意义,是为了可能需要做的,将技能数据层放到热更代码里
        //这样热更的时候修改数值(平衡性更新,客户端一般只改变描述,实际计算在服务器) 完全不影响技能的执行
        public abstract string GetBuffIdType();

        public string buffSignal;//一个BUFF和其他BUFF区别开的标志,所有BUFF彼此之间,这个id都是唯一的

        public BaseBuffData()
        {
            buffSignal = "B_" + GetBuffIdType() + "_" + TimeHelper.ClientNowSeconds().ToString();
        }
    }
}

