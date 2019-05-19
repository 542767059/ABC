using System;
using UnityEngine;

namespace ZJY.Framework
{
    [Serializable]
    public class CreateRoleData :EntityData
    {
        [SerializeField]
        private int m_JobId = 0;

        public CreateRoleData()
        {

        }

        /// <summary>
        /// 获取或者设置职业编号
        /// </summary>
        public int JobId
        {
            get
            {
                return m_JobId;
            }
            set
            {
                m_JobId = value;
            }
        }

        public CreateRoleData Fill(int id, int typeId,int jobId)
        {
            Fill(id, typeId);
            m_JobId = jobId;
            return this;
        }
    }
}
