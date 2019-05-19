using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(ControllerComponent))]
    public class ControllerComponentInspector : UnityEditor.Editor
    {
        private SerializedProperty m_AutoClearInetrval = null;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            ControllerComponent t = (ControllerComponent)target;

            int autoClearInetrval = (int)EditorGUILayout.Slider("Auto Clear Inetrval", m_AutoClearInetrval.floatValue, 10, 180);
            if (autoClearInetrval != m_AutoClearInetrval.floatValue)
            {
                if (EditorApplication.isPlaying)
                {
                    t.AutoClearInetrval = autoClearInetrval;
                }
                else
                {
                    m_AutoClearInetrval.floatValue = autoClearInetrval;
                }
            }

            serializedObject.ApplyModifiedProperties();

            if (!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Available during runtime only.", MessageType.Info);
                return;
            }

            if (PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
            {
                EditorGUILayout.LabelField("AnimatorController Count", t.ControllerInfos.Count.ToString());
                EditorGUILayout.BeginVertical("box");
                {
                    foreach (var controllerInfos in t.ControllerInfos)
                    {
                        EditorGUILayout.BeginVertical("box");
                        {
                            EditorGUILayout.LabelField("Animator Owner", controllerInfos.Key == null ? "Empty" : controllerInfos.Key.gameObject.name);
                            EditorGUILayout.LabelField("RuntimeAnimatorController", controllerInfos.Key == null ? "Empty" : controllerInfos.Value.Name);
                        }
                        EditorGUILayout.EndVertical();

                       
                    }
                }
                EditorGUILayout.EndVertical();
            }

            serializedObject.ApplyModifiedProperties();
            //重绘面板
            Repaint();
        }

        private void OnEnable()
        {
            //建立属性关系
            m_AutoClearInetrval = serializedObject.FindProperty("m_AutoClearInetrval");

            serializedObject.ApplyModifiedProperties();
        }
    }
}
