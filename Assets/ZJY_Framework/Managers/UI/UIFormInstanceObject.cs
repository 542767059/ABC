using System;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 界面实例对象
    /// </summary>
    public sealed class UIFormInstanceObject : ObjectBase
    {
        private readonly UnityEngine.Object m_UIFormAsset;

        public UIFormInstanceObject(string name, UnityEngine.Object uiFormAsset, object uiFormInstance)
            : base(name, uiFormInstance)
        {
            if (uiFormAsset == null)
            {
                throw new Exception("UI form asset is invalid.");
            }
            
            m_UIFormAsset = uiFormAsset;
        }

        protected internal override void Release(bool isShutdown)
        {
            if (m_UIFormAsset != null)
            {
                GameEntry.Resource.UnloadAsset(m_UIFormAsset);
            }
            UnityEngine.Object.Destroy((UnityEngine.Object)Target);
        }
    }
}
