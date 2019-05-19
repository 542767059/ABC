namespace ZJY.Framework
{
    public partial class JobWeaponDBModel
    {
        /// <summary>
        /// 根据职业Id和武器Id获取实体
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="weaponId"></param>
        /// <returns></returns>
        public JobWeaponEntity Get(int jobId, int weaponId)
        {
            for (int i = 0; i < m_List.Count; i++)
            {
                if (m_List[i].JobId == jobId && m_List[i].WeaponId == weaponId)
                {
                    return m_List[i];
                }
            }
            return null;
        }

    }
}
