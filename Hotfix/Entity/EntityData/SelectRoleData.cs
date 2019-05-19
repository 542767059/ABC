namespace Hotfix
{
    public class SelectRoleData : HotEntityData
    {
        /// <summary>
        /// 角色职业Id
        /// </summary>
        public int JobId
        {
            get;
            private  set;
        }

        /// <summary>
        /// 武器类型Id
        /// </summary>
        public int WeaponId
        {
            get;
            private set;
        }

        /// <summary>
        /// 翅膀类型Id
        /// </summary>
        public int WingId
        {
            get;
            private set;
        }

        /// <summary>
        /// 时装类型Id
        /// </summary>
        public int AvtarId
        {
            get;
            private set;
        }

        /// <summary>
        /// 法宝类型Id
        /// </summary>
        public int TrumpId
        {
            get;
            private set;
        }

        public SelectRoleData Fill(int id,int typeId, int jobId, int weaponId, int wingId, int avtarId, int trumpId)
        {
            Fill(id, typeId);
            JobId = jobId;
            WeaponId = weaponId;
            WingId = wingId;
            AvtarId = avtarId;
            TrumpId = trumpId;
            return this;
        }
    }
}
