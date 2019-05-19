using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace ZJY.Framework
{
    /// <summary>
    /// 初始化窗口
    /// </summary>
    public class InitForm : MonoBehaviour
    {
        public static InitForm Instance;

        [SerializeField]
        private Text m_TxtMessage;

        [SerializeField]
        private Text m_TxtProgress;

        [SerializeField]
        private Image m_SplashImg;

        [SerializeField]
        private CanvasGroup m_CanvasGroup;

        [SerializeField]
        private VideoPlayer m_VideoPlayer;

        private bool IsInit = false;

        public Action HideCG;


        private void Awake()
        {
            Instance = this;
            m_VideoPlayer.prepareCompleted += prepareMovie;
        }

        private void prepareMovie(VideoPlayer source)
        {
            IsInit = true;
        }

        public void ShowDialog(string title, string message)
        {

        }

        private void Update()
        {
            if (IsInit)
            {
                if (!m_VideoPlayer.isPlaying)
                {
                    InitCheckVersion();
                }
            }
        }

        /// <summary>
        /// 显示进度
        /// </summary>
        /// <param name="message">进度信息</param>
        /// <param name="value">进度值</param>
        public void ShowProgress(string message, float value)
        {
            m_TxtMessage.text = message;
            m_TxtProgress.text = TextUtil.Format("{0}%", (int)(value * 100));
        }

        /// <summary>
        /// 删除自身
        /// </summary>
        public void DestroySelf()
        {
            m_TxtMessage = null;
            m_TxtProgress = null;
            Instance = null;
            Destroy(this.gameObject);
        }

        /// <summary>
        /// 显示Splash动画
        /// </summary>
        /// <param name="time">时间</param>
        public void ShowSplash(float time)
        {
            m_SplashImg.gameObject.SetActive(true);
            if (time < 0.5f)
            {
                m_CanvasGroup.alpha = 0;
            }
            else if (time < 1.5f)
            {
                m_CanvasGroup.alpha = Mathf.Lerp(0, 1, (time - 0.5f));
            }
            else if (time < 4f)
            {
                m_CanvasGroup.alpha = 1;
            }
            else if (time > 4f)
            {
                m_CanvasGroup.alpha = Mathf.Lerp(1, 0, (time - 4f));
            }
        }

        /// <summary>
        /// 隐藏Splash动画
        /// </summary>
        public void HideSplash()
        {
            m_SplashImg.gameObject.SetActive(false);
            m_VideoPlayer.gameObject.SetActive(true);
        }

        /// <summary>
        /// CG按钮点击 开始初始化
        /// </summary>
        public void InitCheckVersion()
        {
            m_VideoPlayer.gameObject.SetActive(false);
            if (HideCG != null)
            {
                HideCG();
            }
            IsInit = false;
        }
    }
}