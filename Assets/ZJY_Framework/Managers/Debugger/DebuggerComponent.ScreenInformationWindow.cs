﻿
using UnityEngine;
using ZJY;

namespace ZJY.Framework
{
    public partial class DebuggerComponent
    {
        private sealed class ScreenInformationWindow : ScrollableDebuggerWindowBase
        {
            protected override void OnDrawScrollableWindow()
            {
                GUILayout.Label("<b>Screen Information</b>");
                GUILayout.BeginVertical("box");
                {
                    DrawItem("Current Resolution", GetResolutionString(Screen.currentResolution));
                    DrawItem("Screen Width", TextUtil.Format("{0} px / {1} in / {2} cm", Screen.width.ToString(), ConverterUtil.GetInchesFromPixels(Screen.width).ToString("F2"), ConverterUtil.GetCentimetersFromPixels(Screen.width).ToString("F2")));
                    DrawItem("Screen Height", TextUtil.Format("{0} px / {1} in / {2} cm", Screen.height.ToString(), ConverterUtil.GetInchesFromPixels(Screen.height).ToString("F2"), ConverterUtil.GetCentimetersFromPixels(Screen.height).ToString("F2")));
                    DrawItem("Screen DPI", Screen.dpi.ToString("F2"));
                    DrawItem("Screen Orientation", Screen.orientation.ToString());
                    DrawItem("Is Full Screen", Screen.fullScreen.ToString());
#if UNITY_2018_1_OR_NEWER
                    DrawItem("Full Screen Mode", Screen.fullScreenMode.ToString());
#endif
                    DrawItem("Sleep Timeout", GetSleepTimeoutDescription(Screen.sleepTimeout));
                    DrawItem("Cursor Visible", Cursor.visible.ToString());
                    DrawItem("Cursor Lock State", Cursor.lockState.ToString());
                    DrawItem("Auto Landscape Left", Screen.autorotateToLandscapeLeft.ToString());
                    DrawItem("Auto Landscape Right", Screen.autorotateToLandscapeRight.ToString());
                    DrawItem("Auto Portrait", Screen.autorotateToPortrait.ToString());
                    DrawItem("Auto Portrait Upside Down", Screen.autorotateToPortraitUpsideDown.ToString());
#if UNITY_2017_2_OR_NEWER && !UNITY_2017_2_0
                    DrawItem("Safe Area", Screen.safeArea.ToString());
#endif
                    DrawItem("Support Resolutions", GetResolutionsString(Screen.resolutions));
                }
                GUILayout.EndVertical();
            }

            private string GetSleepTimeoutDescription(int sleepTimeout)
            {
                if (sleepTimeout == SleepTimeout.NeverSleep)
                {
                    return "Never Sleep";
                }

                if (sleepTimeout == SleepTimeout.SystemSetting)
                {
                    return "System Setting";
                }

                return sleepTimeout.ToString();
            }

            private string GetResolutionString(Resolution resolution)
            {
                return TextUtil.Format("{0} x {1} @ {2}Hz", resolution.width.ToString(), resolution.height.ToString(), resolution.refreshRate.ToString());
            }

            private string GetResolutionsString(Resolution[] resolutions)
            {
                string[] resolutionStrings = new string[resolutions.Length];
                for (int i = 0; i < resolutions.Length; i++)
                {
                    resolutionStrings[i] = GetResolutionString(resolutions[i]);
                }

                return string.Join("; ", resolutionStrings);
            }
        }
    }
}
