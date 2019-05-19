namespace ZJY.Framework
{
    public class DataTableInfo
    {
        private readonly string m_DataTableName;
        private readonly object m_UserData;

        public DataTableInfo(string dataTableName,object userData)
        {
            m_DataTableName = dataTableName;
            m_UserData = userData;
        }

        public string DataTableName
        {
            get
            {
                return m_DataTableName;
            }
        }
        
        public object UserData
        {
            get
            {
                return m_UserData;
            }
        }
    }
}
