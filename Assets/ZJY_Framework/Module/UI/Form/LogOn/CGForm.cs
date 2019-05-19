using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace ZJY.Framework
{
    public class CGForm : UIForm
    {
        [SerializeField]
        private VideoPlayer m_VideoPlayer;

        private bool m_ShouwMove = false;

        protected internal override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_ShouwMove = false;
            m_VideoPlayer.prepareCompleted += PrepareMovie;
            GameEntry.Sound.PauseMusic();
        }

        protected internal override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);

            if (m_ShouwMove)
            {
                if (!m_VideoPlayer.isPlaying)
                {
                    Close();
                }
            }
        }

        protected internal override void OnClose(object userData)
        {
            base.OnClose(userData);
            m_VideoPlayer.prepareCompleted -= PrepareMovie;
            GameEntry.Sound.ResumeMusic();
        }

        private void PrepareMovie(VideoPlayer source)
        {
            m_ShouwMove = true;
        }
    }
}