using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ZJY.Framework;
using System;

namespace ZJY.Editor
{
    [CustomEditor(typeof(AvtarComponent))]
    public class AvtarComponentInspector : UnityEditor.Editor
    {
        private SerializedProperty m_AutoClearInetrval = null;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            AvtarComponent t = (AvtarComponent)target;

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
                EditorGUILayout.LabelField("Avtar Use Count", t.AvtarInfos.Count.ToString());

                Dictionary<Entity, AvtarManager.AvtarInfo> avtarInfos = t.AvtarInfos;
                EditorGUILayout.BeginVertical("box");
                {
                    foreach (var avtarInfo in avtarInfos)
                    {
                        EditorGUILayout.BeginVertical("box");
                        {
                            EditorGUILayout.LabelField("EntityName", avtarInfo.Key.Name);
                            EditorGUILayout.LabelField("AvtarCount", avtarInfo.Value.AvtarAssetInfos.Count.ToString());
                            if (avtarInfo.Value.AvtarAssetInfos.Count > 0)
                            {
                                foreach (var avtarAssetInfo in avtarInfo.Value.AvtarAssetInfos)
                                {

                                    EditorGUILayout.LabelField("AvtarName", avtarAssetInfo.Value.Name);
                                }
                            }
                            else
                            {
                                GUILayout.Label("Avtar is Empty ...");
                            }

                            EditorGUILayout.EndVertical();
                        }
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