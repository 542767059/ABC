using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// Sound实体
    /// </summary>
    public partial class SoundEntity : DataTableEntityBase
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc;

        /// <summary>
        /// 资源名称
        /// </summary>
        public string AssetName;

        /// <summary>
        /// 优先级（默认0，128最高，-128最低）
        /// </summary>
        public int Priority;

        /// <summary>
        /// 是否循环
        /// </summary>
        public bool Loop;

        /// <summary>
        /// 音量（0~1）
        /// </summary>
        public float Volume;

        /// <summary>
        /// 声音空间混合量（0为2D，1为3D，中间值混合效果）
        /// </summary>
        public float SpatialBlend;

        /// <summary>
        /// 声音最大距离
        /// </summary>
        public float MaxDistance;

    }
}
