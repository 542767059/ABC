using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 小地图帮助
    /// </summary>
    public class SmallMapHelper : MonoBehaviour
    {
        public static SmallMapHelper Instance;
        
        void Awake()
        {
            Instance = this;
        }

    }
}