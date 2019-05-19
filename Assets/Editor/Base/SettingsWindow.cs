using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityGameFramework.Editor;

namespace ZJY.Editor
{
    public class SettingsWindow : EditorWindow
    {
        private List<MacorItem> m_List = new List<MacorItem>();
        private Dictionary<string, bool> m_Dic = new Dictionary<string, bool>();
        private string m_Macor = null;

        void OnEnable()
        {
            m_Macor = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

            m_List.Clear();
            m_List.Add(new MacorItem() { Name = "ENABLE_LOG", DisplayName = "ENABLE_LOG" });
            m_List.Add(new MacorItem() { Name = "DEBUG_LOG_PROTO", DisplayName = "DEBUG_LOG_PROTO" });
            m_List.Add(new MacorItem() { Name = "HOTFIX_ENABLE", DisplayName = "HOTFIX_ENABLE" });

            for (int i = 0; i < m_List.Count; i++)
            {
                if (!string.IsNullOrEmpty(m_Macor) && m_Macor.IndexOf(m_List[i].Name) != -1)
                {
                    m_Dic[m_List[i].Name] = true;
                }
                else
                {
                    m_Dic[m_List[i].Name] = false;
                }
            }
        }


        void OnGUI()
        {
            for (int i = 0; i < m_List.Count; i++)
            {
                EditorGUILayout.BeginHorizontal("box");
                m_Dic[m_List[i].Name] = GUILayout.Toggle(m_Dic[m_List[i].Name], m_List[i].DisplayName);
                EditorGUILayout.EndHorizontal();
            }

            //开启一行
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Save", GUILayout.Width(100)))
            {
                SaveMacor();
            }
            EditorGUILayout.EndHorizontal();
        }

        private void SaveMacor()
        {
            m_Macor = string.Empty;
            foreach (var item in m_Dic)
            {
                if (item.Value)
                {
                    m_Macor += string.Format("{0};", item.Key);
                }
            }
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WSA, m_Macor);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.WebGL, m_Macor);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android, m_Macor);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, m_Macor);
            PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone, m_Macor);
        }

        /// <summary>
        /// 宏项目
        /// </summary>
        public class MacorItem
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string Name;

            /// <summary>
            /// 显示的名称
            /// </summary>
            public string DisplayName;
        }
    }
}