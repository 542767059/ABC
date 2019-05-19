using System;
using UnityEngine;

namespace ZJY.Framework
{
    [Serializable]
    public class WingData : AccessoryObjectData
    {
        [SerializeField]
        private int m_WingFighting;

        [SerializeField]
        private string m_WingPoint;

        [SerializeField]
        private string m_WingControllerAssetName;

        public WingData(int entityId, int typeId, int jobId, int ownerId)
             : base(entityId, typeId, jobId,ownerId)
        {
            JobWingsDBModel jobWingsDBModel = GameEntry.DataTable.GetDataTable<JobWingsDBModel>();
            JobWingsEntity jobWingsEntity = jobWingsDBModel.Get(jobId, typeId);
            if (jobWingsEntity == null)
            {
                return;
            }
            
            m_WingFighting = jobWingsEntity.WingFighting;
            Fill(AssetUtility.GetWingAsset(jobWingsEntity.AssetName));

            JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();
            JobEntity jobEntity = jobDBModel.Get(jobId);
            if (jobEntity == null)
            {
                Log.Warning("Can not load job wingpoint id '{0}' from data table.", jobId.ToString());
                return;
            }

            m_WingPoint = jobEntity.WingPoint;
            m_WingControllerAssetName = AssetUtility.GetWingControllerAsset(jobEntity.WingController);
        }

        /// <summary>
        /// 翅膀战力
        /// </summary>
        public int WingFighting
        {
            get
            {
                return m_WingFighting;
            }
        }

        /// <summary>
        /// 翅膀挂点
        /// </summary>
        public string WingPoint
        {
            get
            {
                return m_WingPoint;
            }
        }

        /// <summary>
        /// 翅膀控制器资源名称
        /// </summary>
        public string WingControllerAssetName
        {
            get
            {
                return m_WingControllerAssetName;
            }
        }
        
    }

}
