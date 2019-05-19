namespace ZJY.Framework
{
    /// <summary>
    /// 坐骑组件
    /// </summary>
    public class MountsComponent : UnitComponent
    {
        public bool IsRide;

        /// <summary>
        /// 坐骑
        /// </summary>
        public Mounts Mounts;

        public override void Init()
        {
            base.Init();
            IsRide = false;
        }

        

        /// <summary>
        /// 显示坐骑
        /// </summary>
        /// <param name="mouttsId">坐骑Id</param>
        public void ShowMounts(int mouttsId)
        {
            if (IsRide)
            {
                return;
            }
            GameEntry.Entity.ShowMounts(Owner, mouttsId);
        }

        /// <summary>
        /// 隐藏坐骑
        /// </summary>
        public void HideMounts()
        {
            if (!IsRide)
            {
                return;
            }
            if (Mounts!=null)
            {
                IsRide = false;
                GameEntry.Entity.DetachEntity(Owner.Id);
                GameEntry.Entity.HideEntity(Mounts);
                Mounts = null;
            }
        }

        /// <summary>
        /// 设置跑
        /// </summary>
        /// <param name="IsRun">是否跑</param>
        public void SetRun(bool IsRun)
        {
            Mounts.animatorComponent.SetBoolValue(Constant.AnimatorParam.Run, IsRun);
        }
    }
}
