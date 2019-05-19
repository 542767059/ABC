using System;
using UnityEngine;

namespace ZJY.Framework
{
    [Serializable]
    public class WeaponData : AccessoryObjectData
    {
        [SerializeField]
        private int m_WeaponFighting;

        [SerializeField]
        private string m_WeaponPoint;

        public WeaponData(int entityId, int typeId, int jobId, int ownerId, string weaponPoint)
             : base(entityId, typeId, jobId, ownerId)
        {
            JobWeaponDBModel jobWeaponDBModel = GameEntry.DataTable.GetDataTable<JobWeaponDBModel>();
            JobWeaponEntity jobWeaponEntity = jobWeaponDBModel.Get(jobId, typeId);
            if (jobWeaponEntity == null)
            {
                return;
            }


            m_WeaponFighting = jobWeaponEntity.WeaponFighting;
            Fill(AssetUtility.GetWeaponAsset(jobWeaponEntity.AssetName));

            m_WeaponPoint = weaponPoint;
        }

        /// <summary>
        /// 武器战力
        /// </summary>
        public int WeaponFighting
        {
            get
            {
                return m_WeaponFighting;
            }
        }

        /// <summary>
        /// 武器挂点
        /// </summary>
        public string WeaponPoint
        {
            get
            {
                return m_WeaponPoint;
            }
        }
    }

}
