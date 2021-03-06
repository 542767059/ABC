﻿

using System;
using UnityEngine;

namespace ZJY.Framework
{
    public class EntityInstanceObject : ObjectBase
    {
        private readonly UnityEngine.Object m_EntityAsset;

        public EntityInstanceObject(string name, UnityEngine.Object entityAsset, object entityInstance)
            : base(name, entityInstance)
        {
            if (entityAsset == null)
            {
                throw new Exception("Entity asset is invalid.");
            }

            m_EntityAsset = entityAsset;
        }

        protected internal override void Release(bool isShutdown)
        {
            if (m_EntityAsset != null)
            {
                GameEntry.Resource.UnloadAsset(m_EntityAsset);
            }
           
            UnityEngine.Object.Destroy((UnityEngine.Object)Target);
        }
    }
}
