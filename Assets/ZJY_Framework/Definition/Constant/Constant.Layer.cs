using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 常量
    /// </summary>
    public static partial class Constant
    {
        /// <summary>
        /// 层
        /// </summary>
		public static class Leyer
        {
            public const string DefaultLayerName = "Default";
            /// <summary>
            /// Default层
            /// </summary>
            public static readonly int DefaultLayerId = LayerMask.NameToLayer(DefaultLayerName);



            public const string UILayerName = "UI";
            /// <summary>
            /// UI层
            /// </summary>
            public static readonly int UILayerId = LayerMask.NameToLayer(UILayerName);



            public const string UIModelLayerName = "UIModel";
            /// <summary>
            /// UIModel层
            /// </summary>
            public static readonly int UIModelLayerId = LayerMask.NameToLayer(UIModelLayerName);



            public const string WallLayerName = "Wall";
            /// <summary>
            /// Wall层
            /// </summary>
            public static readonly int WallLayerId = LayerMask.NameToLayer(WallLayerName);



            public const string GroundLayerName = "Ground";
            /// <summary>
            /// Ground层
            /// </summary>
            public static readonly int GroundLayerId = LayerMask.NameToLayer(GroundLayerName);



            public const string RoleLayerName = "Role";
            /// <summary>
            /// Role层
            /// </summary>
            public static readonly int RoleLayerId = LayerMask.NameToLayer(RoleLayerName);



            public const string PlayerLayerName = "Player";
            /// <summary>
            /// Player层
            /// </summary>
            public static readonly int PlayerLayerId = LayerMask.NameToLayer(PlayerLayerName);
        }

    }
}
