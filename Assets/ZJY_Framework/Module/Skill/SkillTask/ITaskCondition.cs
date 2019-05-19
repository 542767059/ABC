using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 任务的抽象条件
    /// </summary>
    public interface ITaskCondition
    {
        void Start();
        bool IsFinish();
        string Name();

        void Handle();
    }
}
