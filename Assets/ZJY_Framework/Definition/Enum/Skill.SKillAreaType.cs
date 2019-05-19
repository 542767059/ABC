namespace ZJY.Framework
{
    /// <summary>
    /// 技能范围类型
    /// </summary>
    public enum SKillAreaType
    {
        /// <summary>
        /// 外圆(即自身周围)
        /// </summary>
        OuterCircle = 1,
        /// <summary>
        /// 圆形(即目标点周围)
        /// </summary>
        Circle = 2,
        /// <summary>
        /// 矩形(长条)
        /// </summary>
        Cube = 3,           
        /// <summary>
        /// 扇形
        /// </summary>
        Sector = 4,       
    }
}