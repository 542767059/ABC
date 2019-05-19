using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 主玩家
    /// </summary>
    public class MainPlayer : PlayerBase
    {
        [SerializeField]
        ManiPlayerData m_ManiPlayerData = null;

        protected internal override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_ManiPlayerData = userData as ManiPlayerData;

            if (m_ManiPlayerData == null)
            {
                Log.Error("ManiPlayer data is invalid.");
                return;
            }
            Init();

            ManiUI.Instance?.SetSmallMap(GameEntry.Data.CacheData.CurrentSceneId);
        }

        protected internal override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);

            ManiUI.Instance?.AutoSmallMap(SelfTransform);
        }

        protected internal override void OnHide(object userData)
        {
            base.OnHide(userData);
            GameEntry.Camera.LookedTrans = null;
            GameEntry.Camera.EnableLookTrans = false;

        }

        private void Init()
        {
            gameObject.SetLayerRecursively(Constant.Leyer.PlayerLayerId);
            GameEntry.Camera.Init();
            GameEntry.Camera.LookedTrans = SelfTransform;
            GameEntry.Camera.EnableLookTrans = true;
            GameEntry.Camera.transform.rotation = SelfTransform.rotation;
            
            GetOrAddUnitComponent<InputListenerComponent>();
        }
    }
}
