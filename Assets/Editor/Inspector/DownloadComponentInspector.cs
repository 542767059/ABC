using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using ZJY;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(DownloadComponent))]
    public class DownloadComponentInspector : UnityEditor.Editor
    {

        private SerializedProperty m_DownloadAgentCount = null;
        private SerializedProperty m_Timeout = null;
        private SerializedProperty m_FlushSize = null;
        private SerializedProperty m_DownloadType = null;


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DownloadComponent t = (DownloadComponent)target;

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            {
                EditorGUILayout.PropertyField(m_DownloadType);
                m_DownloadAgentCount.intValue = EditorGUILayout.IntSlider("Download Agent Helper Count", m_DownloadAgentCount.intValue, 1, 16);
            }
            EditorGUI.EndDisabledGroup();

            float timeout = EditorGUILayout.Slider("Timeout", m_Timeout.floatValue, 0f, 120f);
            if (timeout != m_Timeout.floatValue)
            {
                if (EditorApplication.isPlaying)
                {
                    t.Timeout = timeout;
                }
                else
                {
                    m_Timeout.floatValue = timeout;
                }
            }

            int flushSize = EditorGUILayout.DelayedIntField("Flush Size", m_FlushSize.intValue);
            if (flushSize != m_FlushSize.intValue)
            {
                if (EditorApplication.isPlaying)
                {
                    t.FlushSize = flushSize;
                }
                else
                {
                    m_FlushSize.intValue = flushSize;
                }
            }

            if (EditorApplication.isPlaying && PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
            {
                EditorGUILayout.LabelField("Total Agent Count", t.TotalAgentCount.ToString());
                EditorGUILayout.LabelField("Free Agent Count", t.FreeAgentCount.ToString());
                EditorGUILayout.LabelField("Working Agent Count", t.WorkingAgentCount.ToString());
                EditorGUILayout.LabelField("Waiting Task Count", t.WaitingTaskCount.ToString());
                EditorGUILayout.LabelField("Current Speed", t.CurrentSpeed.ToString());
            }

            serializedObject.ApplyModifiedProperties();

            Repaint();
        }

        private void OnEnable()
        {
            m_Timeout = serializedObject.FindProperty("m_Timeout");
            m_FlushSize = serializedObject.FindProperty("m_FlushSize");
            m_DownloadAgentCount = serializedObject.FindProperty("m_DownloadAgentCount");
            m_DownloadType = serializedObject.FindProperty("m_DownloadType");
        }
    }
}