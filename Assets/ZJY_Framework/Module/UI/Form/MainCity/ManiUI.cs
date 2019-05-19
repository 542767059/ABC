using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    /// <summary>
    /// 主UI
    /// </summary>
    public class ManiUI : UIForm
    {
        public static ManiUI Instance = null;
        
        protected internal override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            Instance = this;
            SetSmallMap(GameEntry.Data.CacheData.CurrentSceneId);
        }

        protected internal override void OnClose(object userData)
        {
            base.OnClose(userData);
            Instance = null;
        }


        #region 左下角和底部信息
        [SerializeField]
        private Text m_Timetxt;

        [SerializeField]
        private Image m_Battery;

        [SerializeField]
        private Image m_Exp;

        #region 设置系统信息
        /// <summary>
        /// 设置网络状态
        /// </summary>
        private void SetNetworkStatus()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {

            }
            else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                //wifi
            }
            else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                //流量
            }
        }

        /// <summary>
        /// 设置时间
        /// </summary>
        private void SetTime()
        {
            m_Timetxt.text = System.DateTime.Now.ToString("HH:mm");
        }

        /// <summary>
        /// 设置电量
        /// </summary>
        private void SetBattery()
        {
#if UNITY_EDITOR
            m_Battery.fillAmount = 0.75f;
#elif UNITY_ANDROID
            try
            {
                //string CapacityString = System.IO.File.ReadAllText("/sys/class/power_supply/battery/capacity");
                //int myint= int.Parse(CapacityString);
                m_Battery.fillAmount = SystemInfo.batteryLevel;
            }
            catch (Exception e)
            {
                Debug.Log("Failed to read battery power; " + e.Message);
            }
#elif UNITY_IOS
            try
            {
                m_Battery.fillAmount = SystemInfo.batteryLevel;
            }
            catch (Exception e)
            {
                Debug.Log("Failed to read battery power; " + e.Message);
            }
#endif
        }
        #endregion
        #endregion

        #region 右下角信息

        [SerializeField]
        private Transform m_SkillAnchor;

        [SerializeField]
        private Transform m_MenuRight;

        [SerializeField]
        private Transform m_MenuBottom;

        private bool m_IsBusy = false;
        private bool m_IsShowSkill = true;

        public void ChangeRightBottomMenuState()
        {
            if (m_IsBusy) return;
            m_IsBusy = true;

            KillRightBottomAllTransMove();

            m_IsShowSkill = !m_IsShowSkill;

            if (m_IsShowSkill)
            {
                m_MenuRight.localPosition = new Vector3(80, 0, 0);
                m_MenuBottom.localPosition = new Vector3(-90, -380, 0);
                m_SkillAnchor.DOLocalMoveX(0, 0.6f).OnComplete(() =>
                {
                    m_IsBusy = false;
                });
            }
            else
            {
                m_SkillAnchor.localPosition = new Vector3(450, 0, 0);
                m_MenuBottom.DOLocalMoveY(0, 0.6f);
                m_MenuRight.DOLocalMoveX(0, 0.6f).OnComplete(() =>
                {
                    m_IsBusy = false;
                });
            }
        }

        private void KillRightBottomAllTransMove()
        {
            m_MenuRight.DOKill();
            m_MenuBottom.DOKill();
            m_SkillAnchor.DOKill();
        }

        /// <summary>
        /// 显示技能页面(如果已经在动画或者已经是技能页面则不会执行)
        /// </summary>
        /// <param name="useAnimation">是否需要动画显示</param>
        public void ShowSkillView(bool useAnimation = false)
        {
            if (useAnimation)
            {
                if (m_IsBusy && !m_IsShowSkill)
                {
                    m_IsBusy = false;
                    ChangeRightBottomMenuState();
                }
            }
            else
            {
                KillRightBottomAllTransMove();
                m_IsBusy = false;
                m_IsShowSkill = true;
                m_MenuRight.localPosition = new Vector3(80, 0, 0);
                m_MenuBottom.localPosition = new Vector3(-90, -380, 0);
                m_SkillAnchor.localPosition = Vector3.zero;
            }
        }
        #endregion

        /// <summary>
        /// 旋转自身目标
        /// </summary>
        /// <param name="trans">要旋转的目标</param>
        public void RotateSelf(Transform trans)
        {
            trans.DOKill();
            trans.rotation = Quaternion.identity;
            trans.DORotate(new Vector3(0, 0, -180), 1f);
        }

        #region 右上角信息

        #region 菜单

        [SerializeField]
        private GameObject m_btnshouqi;

        [SerializeField]
        private GameObject m_btnxianshi;

        [SerializeField]
        private GameObject m_TopMenu;

        [SerializeField]
        private GameObject m_HuodongMenu;

        [SerializeField]
        private GameObject m_PuTongMenu;

        /// <summary>
        /// 显示顶部信息
        /// </summary>
        public void ShowTopMenu()
        {
            m_btnshouqi.gameObject.SetActive(true);
            m_btnxianshi.gameObject.SetActive(false);
            m_TopMenu.SetActive(true);
        }

        /// <summary>
        /// 隐藏顶部信息
        /// </summary>
        public void HideTopMenu()
        {
            m_btnshouqi.gameObject.SetActive(false);
            m_btnxianshi.gameObject.SetActive(true);
            m_TopMenu.SetActive(false);
        }

        public void ChangeTopMenuState()
        {
            m_HuodongMenu.gameObject.SetActive(!m_HuodongMenu.activeSelf);
            m_PuTongMenu.gameObject.SetActive(!m_PuTongMenu.activeSelf);
        }
        #endregion

        #region 小地图

        [SerializeField]
        private Image m_SmallMap;

        [SerializeField]
        private Image m_SmallMapArr;

        /// <summary>
        /// 设置小地图
        /// </summary>
        /// <param name="smallMapAsset">场景Id</param>
        public void SetSmallMap(int sceneId)
        {
            SceneEntity sceneEntity = GameEntry.DataTable.GetDataTable<SceneDBModel>().Get(sceneId);
            if (sceneEntity == null)
            {
                Log.Error("Can not load scene smallmap id '{0}' form scene datatable", sceneId);
                return;
            }
            if (string.IsNullOrEmpty(sceneEntity.SmallMapImageAssets))
            {
                Log.Error("smallmap name is invalid !");
                return;
            }

            string smallmapname = AssetUtility.GetSmallMapAsset(sceneEntity.SmallMapImageAssets);
            m_SmallMap.SetImage(smallmapname, true);
            GameEntry.Data.CacheData.CurrentSmallMapSize = sceneEntity.SmallMapSize;
        }

        /// <summary>
        /// 自动设置小地图(每帧调用)
        /// </summary>
        /// <param name="target">小地图跟随的目标</param>
        public void AutoSmallMap(Transform target)
        {
            if (SmallMapHelper.Instance == null)
            {
                return;
            }

            SmallMapHelper.Instance.transform.position = target.position;

            m_SmallMap.transform.localPosition = new Vector3(SmallMapHelper.Instance.transform.localPosition.x * -GameEntry.Data.CacheData.CurrentSmallMapSize, SmallMapHelper.Instance.transform.localPosition.z * -GameEntry.Data.CacheData.CurrentSmallMapSize, 0);

            m_SmallMapArr.transform.localEulerAngles = new Vector3(0, 0, 360 - target.eulerAngles.y + 146);
        }

        #endregion

        #endregion
    }
}