using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// UISound实体
    /// </summary>
    public partial class UISoundEntity : DataTableEntityBase
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
        /// 音量（0~1）
        /// </summary>
        public float Volume;

    }
}
