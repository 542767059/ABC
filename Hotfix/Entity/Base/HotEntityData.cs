using UnityEngine;

namespace Hotfix
{
    /// <summary>
    /// 热更新层实体数据
    /// </summary>
    public abstract class HotEntityData 
    {
        /// <summary>
        /// 实体编号。
        /// </summary>
        public int Id { get; private set; } = 0;

        /// <summary>
        /// 实体类型编号。
        /// </summary>
        public int TypeId { get; private set; } = 0;

        /// <summary>
        /// 实体位置。
        /// </summary>
        public Vector3 Position { get; set; } = Vector3.zero;

        /// <summary>
        /// 实体朝向。
        /// </summary>
        public Quaternion Rotation { get; set; } = Quaternion.identity;


        public HotEntityData()
        {

        }

        /// <summary>
        /// 填充实体数据
        /// </summary>
        protected void Fill(int id, int typeId)
        {
            Id = id;
            TypeId = typeId;
        }
    }
}

