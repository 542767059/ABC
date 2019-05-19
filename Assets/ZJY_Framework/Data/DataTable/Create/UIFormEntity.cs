using System.Collections;
using ZJY.Framework;

namespace ZJY.Framework
{
    /// <summary>
    /// UIForm实体
    /// </summary>
    public partial class UIFormEntity : DataTableEntityBase
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
        /// 界面组名称
        /// </summary>
        public string UIGroupName;

        /// <summary>
        /// 是否允许多个界面实例
        /// </summary>
        public bool AllowMultiInstance;

        /// <summary>
        /// 是否暂停被其覆盖的界面
        /// </summary>
        public bool PauseCoveredUIForm;

    }
}
