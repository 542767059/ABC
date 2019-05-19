//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using UnityEditor;
using UnityEngine;

namespace UnityGameFramework.Editor
{
    /// <summary>
    /// 帮助相关的实用函数
    /// </summary>
    public static class Help
    {
        public static void ShowComponentHelp(string componentName)
        {
            ShowHelp(Utility.Text.Format("http://gameframework.cn/archives/category/module/buildin/{0}/", componentName));
        }

        private static void ShowHelp(string uri)
        {
            Application.OpenURL(uri);
        }
    }
}
