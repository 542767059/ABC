using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    public static class EntityExtension
    {
        // 关于 EntityId 的约定：
        // 0 为无效
        // 正值用于和服务器通信的实体（如玩家角色、NPC、怪等，服务器只产生正值）
        // 负值用于本地生成的临时实体（如特效、FakeObject等）
        private static int s_SerialId = 0;

        /// <summary>
        /// 显示创建角色
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <param name="jobId">职业Id</param>
        public static void ShowCreateRole(this EntityComponent entityComponent, int jobId)
        {
            JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();
            JobEntity jobEntity = jobDBModel.Get(jobId);
            if (jobEntity == null)
            {
                Log.Warning("Can not load createrole entity id '{0}' from data table.", jobId.ToString());
                return;
            }
            int entityId = jobId * -10000;
            entityComponent.ShowEntity(entityId, typeof(CreateRoleEntity), AssetUtility.GetCreateRoleAsset(jobEntity.CreateRoleAssetName), "Role", Constant.AssetPriority.CreateRoleAsset, new CreateRoleData().Fill(entityId, jobEntity.Id, jobId));
        }

        /// <summary>
        /// 显示翅膀
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <param name="Owner"></param>
        /// <param name="jobId"></param>
        /// <param name="wingTypeId"></param>
        public static void ShowWing(this EntityComponent entityComponent, Entity owner, int jobId, int wingTypeId)
        {
            entityComponent.ShowEntity(typeof(WingEntity), "Wing", Constant.AssetPriority.WingAsset, new WingData(entityComponent.GenerateSerialId(), wingTypeId, jobId, owner.Id));
        }

        /// <summary>
        /// 显示法宝
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <param name="Owner"></param>
        /// <param name="jobId"></param>
        /// <param name="wingTypeId"></param>
        public static void ShowMagic(this EntityComponent entityComponent, Entity owner, int jobId, int wingTypeId)
        {
            entityComponent.ShowEntity(typeof(MagicEntity), "Magic", Constant.AssetPriority.WingAsset, new MagicData(entityComponent.GenerateSerialId(), wingTypeId, jobId, owner.Id));
        }

        /// <summary>
        /// 显示武器
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <param name="Owner"></param>
        /// <param name="jobId"></param>
        /// <param name="wingTypeId"></param>
        public static void ShowWeapon(this EntityComponent entityComponent, Entity owner, int jobId, int wingTypeId)
        {
            JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();
            JobEntity jobEntity = jobDBModel.Get(jobId);
            if (jobEntity == null)
            {
                Log.Warning("Can not load job wapon id '{0}' from data table.", jobId.ToString());
                return;
            }
            if (jobEntity.WeaponPointCount == 1)
            {
                entityComponent.ShowEntity(typeof(WeaponEntity), "Weapon", Constant.AssetPriority.WingAsset, new WeaponData(entityComponent.GenerateSerialId(), wingTypeId, jobId, owner.Id, jobEntity.WeaponPoint1));
            }
            else if (jobEntity.WeaponPointCount == 2)
            {
                entityComponent.ShowEntity(typeof(WeaponEntity), "Weapon", Constant.AssetPriority.WingAsset, new WeaponData(entityComponent.GenerateSerialId(), wingTypeId, jobId, owner.Id, jobEntity.WeaponPoint1));
                entityComponent.ShowEntity(typeof(WeaponEntity), "Weapon", Constant.AssetPriority.WingAsset, new WeaponData(entityComponent.GenerateSerialId(), wingTypeId, jobId, owner.Id, jobEntity.WeaponPoint2));
            }

        }

        /// <summary>
        /// 显示坐骑
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <param name="Owner"></param>
        /// <param name="jobId"></param>
        /// <param name="wingTypeId"></param>
        public static void ShowMounts(this EntityComponent entityComponent, Entity owner, int mountsId)
        {
            RideDBModel rideDBModel = GameEntry.DataTable.GetDataTable<RideDBModel>();
            RideEntity rideEntity = rideDBModel.Get(mountsId);
            if (rideEntity == null)
            {
                Log.Warning("Can not load ride id '{0}' from data table.", mountsId.ToString());
                return;
            }
            int entityId = entityComponent.GenerateSerialId();

            entityComponent.ShowEntity(entityId, typeof(Mounts), AssetUtility.GetRideAsset(rideEntity.AssetName), "Ride", Constant.AssetPriority.RideAsset, new MountsData(entityId, mountsId, owner.Id));

        }

        /// <summary>
        /// 显示技能特效
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <param name="owner"></param>
        /// <param name="effectname"></param>
        /// <param name="effecttime"></param>
        public static void ShowSkillEffect(this EntityComponent entityComponent, Entity owner, string effectname, float effecttime)
        {
            int entityId = entityComponent.GenerateSerialId();
            entityComponent.ShowEntity(entityId, typeof(EffectEntity), AssetUtility.GetSkillEffectAsset(effectname), "Effect", Constant.AssetPriority.EffectAsset, new EffectEntityData(entityId, owner.Id, effecttime)
            {
                Position = owner.SelfTransform.position,
                Rotation = owner.SelfTransform.rotation
            });
        }

        /// <summary>
        /// 显示Buff特效
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <param name="effectname"></param>
        /// <param name="owner"></param>
        /// <param name="point"></param>
        public static void ShowBuffEffect(this EntityComponent entityComponent, string effectname,int ownerId, string point, BaseBuffHandler baseBuffHandler)
        {
            int entityId = entityComponent.GenerateSerialId();
            entityComponent.ShowEntity(entityId, typeof(BuffEfectEntity), AssetUtility.GetBuffEffectAsset(effectname), "Effect", Constant.AssetPriority.EffectAsset, new BuffEfectEntityData(entityId, ownerId,point, ownerId, baseBuffHandler));
        }

        /// <summary>
        /// 显示主玩家
        /// </summary>
        /// <param name="entityComponent"></param>
        public static void ShowMainPlayer(this EntityComponent entityComponent)
        {
            RoleInfo roleInfo = GameEntry.Data.UserData.RoleInfo;
            if (roleInfo == null)
            {
                Log.Error("Roleinfo is invalid.");
                return;
            }

            JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();
            JobEntity jobEntity = jobDBModel.Get(roleInfo.JobId);
            if (jobEntity == null)
            {
                Log.Warning("Can not load createrole entity id '{0}' from data table.", roleInfo.JobId.ToString());
                return;
            }
            int entityId = roleInfo.RoleId;
            entityComponent.ShowEntity(entityId, typeof(MainPlayer), AssetUtility.GetRoleAsset(jobEntity.AssetName), "Role", Constant.AssetPriority.RolePlayerAsset, new ManiPlayerData().Fill(roleInfo));
        }

        /// <summary>
        /// 显示技能指示器
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <param name="sKillAreaType">区域类型</param>
        /// <param name="owner">拥有者</param>
        public static void ShowSkillArea(this EntityComponent entityComponent, SKillAreaType sKillAreaType, Entity owner)
        {
            int entityId = entityComponent.GenerateSerialId();
            string assetname = string.Empty;
            switch (sKillAreaType)
            {
                case SKillAreaType.OuterCircle:
                    assetname = "Assets/DownLoad/Prefab/SkillArea/OutCri.prefab";
                    break;
                case SKillAreaType.Circle:
                    assetname = "Assets/DownLoad/Prefab/SkillArea/QuanGongji.prefab";
                    break;
                case SKillAreaType.Cube:
                    break;
                case SKillAreaType.Sector:
                    assetname = "Assets/DownLoad/Prefab/SkillArea/Sector.prefab";
                    break;
            }
            entityComponent.ShowEntity(entityId, typeof(SkillArea), assetname, "Effect", Constant.AssetPriority.EffectAsset, new SkillAreaData(entityId, (int)sKillAreaType, owner, sKillAreaType));
        }

        private static void ShowEntity(this EntityComponent entityComponent, Type entityType, string entityGroup, int priority, AccessoryObjectData data)
        {
            if (data == null)
            {
                Log.Warning("Data is invalid.");
                return;
            }

            entityComponent.ShowEntity(data.Id, entityType, data.AssetName, entityGroup, priority, data);
        }

        /// <summary>
        /// 自动生成实体序列号(本地实体)
        /// </summary>
        /// <param name="entityComponent"></param>
        /// <returns></returns>
        public static int GenerateSerialId(this EntityComponent entityComponent)
        {
            return --s_SerialId;
        }


    }
}
