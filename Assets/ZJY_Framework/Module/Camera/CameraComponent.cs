using Colorful;
using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace ZJY.Framework
{
    public enum CameraEfffectType
    {
        /// <summary>
        /// 屏幕提亮特效
        /// </summary>
        BloomOptimized,
        /// <summary>
        /// 景深特效
        /// </summary>
        DepthOfField,
        /// <summary>
        /// 黑白特效
        /// </summary>
        SepiaTone,
        /// <summary>
        /// 突出人物特效
        /// </summary>
        FastVignette,
        /// <summary>
        /// 场景过场动画特效
        /// </summary>
        SceneSplash,
        /// <summary>
        /// 水波纹动画特效
        /// </summary>
        WaterWave,
    }

    public class CameraComponent : GameBaseComponent
    {
        [SerializeField]
        private BloomOptimized m_BloomOptimized;

        [SerializeField]
        private DepthOfField m_DepthOfField;

        [SerializeField]
        private SepiaTone m_SepiaTone;

        [SerializeField]
        private FastVignette m_FastVignette;

        [SerializeField]
        private SceneSplash m_SceneSplash;

        [SerializeField]
        private CameraEffect m_CameraEffect;

        [SerializeField]
        private Camera m_MainCamera;

        /// <summary>
        /// 控制摄像机上下
        /// </summary>
        [SerializeField]
        private Transform m_CameraUpAndDown;

        /// <summary>
        /// 摄像机缩放父物体
        /// </summary>
        [SerializeField]
        private Transform m_CameraZoomContainer;

        /// <summary>
        /// 摄像机容器
        /// </summary>
        [SerializeField]
        private Transform m_CameraContainer;

        [Range(0, 200)]
        [SerializeField]
        private float m_RotateSpeed = 20f;

        [Range(0, 200)]
        [SerializeField]
        private float m_UpAndDownSpeed = 60f;

        [Range(-40, 0)]
        [SerializeField]
        private float m_MinUpAndDown = -40f;

        [Range(0, 80)]
        [SerializeField]
        private float m_MaxUpAndDown = 80f;


        [Range(0, 200)]
        [SerializeField]
        private float m_ZoomSpeed = 30f;

        [Range(2, 100)]
        [SerializeField]
        private float m_ZoomMaxValue = 15f;

        [SerializeField]
        private bool m_EnableLookTrans = false;

        [SerializeField]
        private Vector3 m_Offest = new Vector3(0, 1.5f, 0);

        /// <summary>
        /// 和目标的距离
        /// </summary>
        private float m_TargetDistance = 8.1f;

        protected override void OnAwake()
        {
            base.OnAwake();
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
        }

        private void LateUpdate()
        {
            if (LookedTrans != null && m_EnableLookTrans)
            {
                transform.position = LookedTrans.position + m_Offest;

                float? distanceGround = null;
                float? distanceWall = null;

                Vector3 dir = m_CameraContainer.position - (LookedTrans.position + m_Offest);
                Vector3 camerapostion = LookedTrans.position + m_Offest + dir.normalized * m_TargetDistance;

                RaycastHit hitGround;
                if (Physics.Linecast(LookedTrans.position + m_Offest, camerapostion, out hitGround, 1 << Constant.Leyer.GroundLayerId))
                {
                    distanceGround = Vector3.Distance(LookedTrans.position + m_Offest, hitGround.point);
                }

                RaycastHit hitWall;
                if (Physics.Linecast(LookedTrans.position + m_Offest, camerapostion, out hitWall, 1 << Constant.Leyer.WallLayerId))
                {
                    distanceWall = Vector3.Distance(LookedTrans.position, hitWall.point);
                }

                if (distanceGround.HasValue && distanceWall.HasValue)
                {
                    if (distanceGround.Value > distanceWall.Value)
                    {
                        float value = Mathf.Clamp(distanceWall.Value - 0.9f, 1, m_ZoomMaxValue);
                        m_CameraZoomContainer.localPosition = new Vector3(value, 0, 0);

                    }
                    else
                    {
                        float value = Mathf.Clamp(distanceGround.Value - 0.9f, 1, m_ZoomMaxValue);
                        m_CameraZoomContainer.localPosition = new Vector3(value, 0, 0);
                    }
                }
                else if (distanceGround.HasValue)
                {
                    float value = Mathf.Clamp(distanceGround.Value - 0.9f,1, m_ZoomMaxValue);
                    m_CameraZoomContainer.localPosition = new Vector3(value, 0, 0);
                }
                else if (distanceWall.HasValue)
                {
                    float value = Mathf.Clamp(distanceWall.Value - 0.9f, 1, m_ZoomMaxValue);
                    m_CameraZoomContainer.localPosition = new Vector3(value, 0, 0);
                }
                else
                {
                    if (m_CameraZoomContainer.localPosition.x < m_TargetDistance)
                    {
                        m_CameraZoomContainer.localPosition += Vector3.right * Time.deltaTime * m_ZoomSpeed;
                        m_CameraZoomContainer.localPosition = new Vector3(Mathf.Clamp(m_CameraZoomContainer.localPosition.x, 1, m_ZoomMaxValue), 0, 0);
                    }
                }


                //this.transform.position = LookedTrans.position + m_Offest;
                //if (Mathf.Abs(m_TargetDistance - m_CameraContainer.localPosition.z) > 0.1f)
                //{
                //    m_CameraContainer.Translate(Vector3.forward * m_ZoomSpeed * Time.deltaTime * (m_TargetDistance < m_CameraContainer.localPosition.z ? -1 : 1));
                //}

                AutoLookAt(LookedTrans.position + m_Offest);
            }
        }

        /// <summary>
        /// 获取主摄像机
        /// </summary>
        public Camera MainCamera
        {
            get
            {
                return m_MainCamera;
            }
        }

        /// <summary>
        /// 获取UI摄像机
        /// </summary>
        public Camera UICamera
        {
            get
            {
                return GameEntry.UI.UICamera;
            }
        }

        /// <summary>
        /// 获取或者设置摄像机左右旋转速率
        /// </summary>
        public float RotateSpeed
        {
            get
            {
                return m_RotateSpeed;
            }
            set
            {
                m_RotateSpeed = Mathf.Clamp(value, 0, 200);
            }
        }

        /// <summary>
        /// 获取或者设置摄像机上下移动速率
        /// </summary>
        public float UpAndDownSpeed
        {
            get
            {
                return m_UpAndDownSpeed;
            }
            set
            {
                m_UpAndDownSpeed = Mathf.Clamp(value, 0, 200);
            }
        }

        /// <summary>
        /// 获取或者设置摄像机上下移动最小值
        /// </summary>
        public float MinUpAndDown
        {
            get
            {
                return m_MinUpAndDown;
            }
            set
            {
                m_MinUpAndDown = Mathf.Clamp(value, -40, 0);
            }
        }

        /// <summary>
        /// 获取或者设置摄像机上下移动最大值
        /// </summary>
        public float MaxUpAndDown
        {
            get
            {
                return m_MaxUpAndDown;
            }
            set
            {
                m_MaxUpAndDown = Mathf.Clamp(value, 0, 80);
            }
        }

        /// <summary>
        /// 获取或者设置摄像机缩放速率
        /// </summary>
        public float ZoomSpeed
        {
            get
            {
                return m_ZoomSpeed;
            }
            set
            {
                m_ZoomSpeed = Mathf.Clamp(value, 0, 100);
            }
        }

        /// <summary>
        /// 获取或者设置摄像机缩放距离最大值
        /// </summary>
        public float ZoomMaxValue
        {
            get
            {
                return m_ZoomMaxValue;
            }
            set
            {
                m_ZoomMaxValue = Mathf.Clamp(value, 2, 100);
            }
        }

        /// <summary>
        /// 获取或者设置是否启用实时观看目标
        /// </summary>
        public bool EnableLookTrans
        {
            get
            {
                return m_EnableLookTrans;
            }
            set
            {
                m_EnableLookTrans = value;
            }
        }

        /// <summary>
        /// 获取或者设置观测点偏移
        /// </summary>
        public Vector3 Offest
        {
            get
            {
                return m_Offest;
            }
            set
            {
                m_Offest = value;
            }
        }

        /// <summary>
        /// 获取或者设置被实时观看的目标
        /// </summary>
        public Transform LookedTrans
        {
            get;
            set;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            m_CameraUpAndDown.transform.localEulerAngles = new Vector3(0, 0, Mathf.Clamp(m_CameraUpAndDown.transform.localEulerAngles.z, 35f, 80f));
        }

        /// <summary>
        /// 设置摄像机旋转 0=左 1=右
        /// </summary>
        /// <param name="type">0=左 1=右</param>
        /// <param name="speed">拖动速度</param>
        public void SetCameraRotate(int type, float speed)
        {
            transform.Rotate(0, m_RotateSpeed * speed * Time.deltaTime * (type == 0 ? -1 : 1), 0);
        }

        /// <summary>
        /// 设置摄像机上下 0=上 1=下
        /// </summary>
        /// <param name="type"></param>
        public void SetCameraUpAndDown(int type)
        {
            m_CameraUpAndDown.transform.Rotate(0, 0, m_UpAndDownSpeed * Time.deltaTime * (type == 1 ? -1 : 1));
            float angles = m_CameraUpAndDown.transform.localEulerAngles.z;

            if (angles > 90)
            {
                m_CameraUpAndDown.transform.localEulerAngles = new Vector3(0, 0, Mathf.Clamp(m_CameraUpAndDown.transform.localEulerAngles.z, (360f + MinUpAndDown), 360f));
            }
            else
            {
                m_CameraUpAndDown.transform.localEulerAngles = new Vector3(0, 0, Mathf.Clamp(m_CameraUpAndDown.transform.localEulerAngles.z, 0, m_MaxUpAndDown));
            }
        }

        /// <summary>
        /// 设置摄像机缩放 0=拉近 1=拉远
        /// </summary>
        /// <param name="type">0=拉近 1=拉远</param>
        public void SetCameraZoom(int type)
        {
            m_TargetDistance += m_ZoomSpeed * Time.deltaTime * (type == 0 ? -1 : 1);
            m_TargetDistance = Mathf.Clamp(m_TargetDistance, 1, m_ZoomMaxValue);
            m_CameraZoomContainer.localPosition = new Vector3(m_TargetDistance, 0, 0);
        }

        /// <summary>
        /// 看着一个地方
        /// </summary>
        /// <param name="pos">被看着的地方</param>
        public void AutoLookAt(Vector3 pos)
        {
            m_CameraContainer.LookAt(pos);
        }

        /// <summary>
        /// 震屏
        /// </summary>
        /// <param name="delay">延迟时间</param>
        /// <param name="duration">持续时间</param>
        /// <param name="strength">强度</param>
        /// <param name="vibrato">震幅</param>
        public void CameraShake(float delay = 0, float duration = 0.5f, float strength = 1, int vibrato = 10)
        {
            StopAllCoroutines();
            StartCoroutine(DoCameraShake(delay, duration, strength, vibrato));
        }

        /// <summary>
        /// 震屏
        /// </summary>
        /// <param name="delay">延迟时间</param>
        /// <param name="duration">持续时间</param>
        /// <param name="strength">强度</param>
        /// <param name="vibrato">震幅</param>
        /// <returns></returns>
        private IEnumerator DoCameraShake(float delay = 0, float duration = 0.5f, float strength = 1, int vibrato = 10)
        {
            yield return new WaitForSeconds(delay);

            m_CameraContainer.DOShakePosition(0.3f, 1f, 100);
        }


        #region 屏幕后处理特效
        /// <summary>
        /// 重置所有屏幕特效
        /// </summary>
        public void RestCameraEffect()
        {
            ShowOrHideBloomOptimized(false);
            ShowOrHideDepthOfField(false);
            ShowOrHideSepiaTone(false);
            ShowOrHideFastVignette(false);
            ShowOrHideSceneSplash(false);
            ShowOrHideWaterwave(false);
        }

        /// <summary>
        /// 显示或者隐藏屏幕特效
        /// </summary>
        /// <param name="cameraEfffectType">屏幕特效类型</param>
        /// <param name="isShow">是否显示</param>
        public void ShowOrHideCameraEffect(CameraEfffectType cameraEfffectType, bool isShow)
        {
            switch (cameraEfffectType)
            {
                case CameraEfffectType.BloomOptimized:
                    ShowOrHideBloomOptimized(isShow);
                    break;
                case CameraEfffectType.DepthOfField:
                    ShowOrHideDepthOfField(isShow);
                    break;
                case CameraEfffectType.SepiaTone:
                    ShowOrHideSepiaTone(isShow);
                    break;
                case CameraEfffectType.FastVignette:
                    ShowOrHideFastVignette(isShow);
                    break;
                case CameraEfffectType.SceneSplash:
                    ShowOrHideSceneSplash(isShow);
                    break;
                case CameraEfffectType.WaterWave:
                    ShowOrHideWaterwave(isShow);
                    break;
            }
        }

        /// <summary>
        /// 显示或者隐藏屏幕提亮特效
        /// </summary>
        /// <param name="isShow">是否显示</param>
        public void ShowOrHideBloomOptimized(bool isShow)
        {
            m_BloomOptimized.enabled = isShow;
        }

        /// <summary>
        /// 显示或者隐藏景深特效
        /// </summary>
        /// <param name="isShow">是否显示</param>
        public void ShowOrHideDepthOfField(bool isShow)
        {
            m_DepthOfField.enabled = isShow;
        }

        /// <summary>
        /// 显示或者隐藏黑白特效
        /// </summary>
        /// <param name="isShow">是否显示</param>
        public void ShowOrHideSepiaTone(bool isShow)
        {
            m_SepiaTone.enabled = isShow;
        }

        /// <summary>
        /// 显示或者隐藏突出人物特效
        /// </summary>
        /// <param name="isShow">是否显示</param>
        public void ShowOrHideFastVignette(bool isShow)
        {
            m_FastVignette.enabled = isShow;
        }

        /// <summary>
        /// 显示或者隐藏场景过场动画特效
        /// </summary>
        /// <param name="isShow">是否显示</param>
        public void ShowOrHideSceneSplash(bool isShow)
        {
            m_SceneSplash.enabled = isShow;
        }

        /// <summary>
        /// 显示或者隐藏水波纹动画特效
        /// </summary>
        /// <param name="isShow">是否显示</param>
        public void ShowOrHideWaterwave(bool isShow)
        {
            m_CameraEffect.enabled = isShow;
        }
        #endregion
    }
}