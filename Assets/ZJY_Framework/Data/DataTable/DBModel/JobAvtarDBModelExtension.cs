namespace ZJY.Framework
{
    public partial class JobAvtarDBModel
    {
        /// <summary>
        /// 根据职业Id和时装Id获取实体
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="avtarId"></param>
        /// <returns></returns>
        public JobAvtarEntity Get(int jobId, int avtarId)
        {
            for (int i = 0; i < m_List.Count; i++)
            {
                if (m_List[i].JobId == jobId && m_List[i].AvtarId == avtarId)
                {
                    return m_List[i];
                }
            }
            return null;
        }

    }
}
