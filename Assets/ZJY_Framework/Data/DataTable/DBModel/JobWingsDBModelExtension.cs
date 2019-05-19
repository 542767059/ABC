namespace ZJY.Framework
{
    public partial class JobWingsDBModel
    {
        /// <summary>
        /// 根据职业Id和翅膀Id获取实体
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="wingId"></param>
        /// <returns></returns>
        public JobWingsEntity Get(int jobId, int wingId)
        {
            for (int i = 0; i < m_List.Count; i++)
            {
                if (m_List[i].JobId == jobId && m_List[i].WingId == wingId)
                {
                    return m_List[i];
                }
            }
            return null;
        }

    }
}
