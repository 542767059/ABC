using System;
using UnityEngine;

namespace ZJY.Framework
{
    [Serializable]
    public class MagicData : AccessoryObjectData
    {
        [SerializeField]
        private string m_MagicPoint;

        public MagicData(int entityId, int typeId,int jobId, int ownerId)
            : base(entityId, typeId, jobId, ownerId)
        {
            TrumpDBModel trumpDBModel = GameEntry.DataTable.GetDataTable<TrumpDBModel>();
            TrumpEntity trumpEntity = trumpDBModel.Get(typeId);
            if (trumpEntity == null)
            {
                return;
            }
            
            Fill(AssetUtility.GetMagicAsset(trumpEntity.AssetName));

            JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();
            JobEntity jobEntity = jobDBModel.Get(jobId);
            if (jobEntity == null)
            {
                Log.Warning("Can not load job magicpoint id '{0}' from data table.", jobId.ToString());
                return;
            }

            m_MagicPoint = jobEntity.TrumpPoint;
        }

        /// <summary>
        /// 翅膀挂点
        /// </summary>
        public string MagicPoint
        {
            get
            {
                return m_MagicPoint;
            }
        }
    }
}
