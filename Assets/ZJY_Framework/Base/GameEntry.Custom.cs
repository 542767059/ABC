using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    public partial class GameEntry
    {
        /// <summary>
        /// Avtar组件
        /// </summary>
        public static AvtarComponent Avtar
        {
            get;
            private set;
        }

        /// <summary>
        /// 摄像机组件
        /// </summary>
        public static CameraComponent Camera
        {
            get;
            private set;
        }

        /// <summary>
        /// 动画控制器组件
        /// </summary>
        public static ControllerComponent Controller
        {
            get;
            private set;
        }

        /// <summary>
        /// 输入组件
        /// </summary>
        public static InputComponent Input
        {
            get;
            private set;
        }


        /// <summary>
        /// 阴影组件
        /// </summary>
        public static ShadowComponent Shadow
        {
            get;
            private set;
        }

        /// <summary>
        /// 设置图片组件
        /// </summary>
        public static Texture2DComponent Texture2D
        {
            get;
            private set;
        }

        /// <summary>
        /// 初始化组件
        /// </summary>
        private void InitCustomComponents()
        {
            Avtar = GetBaseComponent<AvtarComponent>();
            Controller = GetBaseComponent<ControllerComponent>();
            Input = GetBaseComponent<InputComponent>();
            Camera = GetBaseComponent<CameraComponent>();
            Texture2D = GetBaseComponent<Texture2DComponent>();
            Shadow = GetBaseComponent<ShadowComponent>();
        }
    }
}
