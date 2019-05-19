using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ZJY.Framework;
using System;
using UnityEngine.UI;

namespace ZJY.Editor
{
    [CustomEditor(typeof(HotfixForm))]
    public class HotfixFormInspcetor : UnityEditor.Editor
    {
        private Transform m_AddTransform;
        private Color blueColor = new Color(0f, 0.7f, 1f, 1f);
        private Color greenColor = new Color(0.4f, 1f, 0f, 1f);
        private bool remove = false;
        private bool add = false;
        private bool change = false;
        private int removeId = 0;

        private SerializedProperty m_HotFormInfos = null;

        private List<HotFormInfo> m_CurrentHotFormInfos = null;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            {
                HotfixForm t = (HotfixForm)target;

                GUILayout.BeginVertical("box");
                {
                    GUILayout.BeginHorizontal("box");
                    {
                        GUILayout.Space(30);

                        GUILayout.Label("Notes", GUILayout.MaxWidth(150));
                        GUILayout.Label("Name", GUILayout.MaxWidth(150));
                        GUILayout.Label("Widget", GUILayout.MinWidth(80));
                        GUILayout.Label("GameObjectType");
                    }
                    GUILayout.EndHorizontal();

                    remove = false;
                    add = false;
                    change = false;

                    DrawAllHotFormInfo();

                    GUI.backgroundColor = blueColor;
                }
                GUILayout.EndVertical();

                EditorGUILayout.Separator();

                GUILayout.BeginHorizontal("box");
                {
                    if (GUILayout.Button("+", GUILayout.Width(20f), GUILayout.Height(16f)))
                    {
                        add = true;
                    }
                    m_AddTransform = (Transform)EditorGUILayout.ObjectField(m_AddTransform, typeof(Transform), true, GUILayout.MinWidth(100f));
                }
                GUILayout.EndHorizontal();

                if (remove)
                {
                    m_CurrentHotFormInfos.RemoveAt(removeId);
                    DrawAllHotFormInfo();
                    change = true;
                }

                if (add)
                {
                    AddItem();
                    change = true;
                }

                if (change)
                {
                    WriteHotFormInfo();
                }
                GUI.backgroundColor = Color.white;
            }
            EditorGUI.EndDisabledGroup();

            serializedObject.ApplyModifiedProperties();
            Repaint();
        }

        private void AddItem()
        {
            bool invalid = true;
            string errorMseeage = string.Empty;
            HotFormInfo hotFormInfo = new HotFormInfo();
            if (m_AddTransform == null)
            {
                invalid = false;
                errorMseeage = "Add transform is invalid!";
            }
            else
            {
                string transname = m_AddTransform.name;
                for (int i = 0; i < m_CurrentHotFormInfos.Count; i++)
                {
                    if (transname == m_CurrentHotFormInfos[i].TransformName)
                    {
                        errorMseeage = "Transform name is already exist!";
                        invalid = false;
                        break;
                    }
                }

                if (invalid)
                {
                    hotFormInfo.TransformName = transname;
                    hotFormInfo.Trans = m_AddTransform;

                    if (m_AddTransform.GetComponent<Dropdown>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.Dropdown;
                    }
                    else if (m_AddTransform.GetComponent<InputField>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.InputField;
                    }
                    else if (m_AddTransform.GetComponent<Mask>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.Mask;
                    }
                    else if (m_AddTransform.GetComponent<Toggle>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.Toggle;
                    }
                    else if (m_AddTransform.GetComponent<ScrollRect>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.ScrollRect;
                    }
                    else if (m_AddTransform.GetComponent<Scrollbar>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.Scrollbar;
                    }
                    else if (m_AddTransform.GetComponent<Slider>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.Slider;
                    }
                    else if (m_AddTransform.GetComponent<LocalizationText>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.LocalizationText;
                    }
                    else if (m_AddTransform.GetComponent<LocalizationImage>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.LocalizationImage;
                    }
                    else if (m_AddTransform.GetComponent<Button>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.Button;
                    }
                    else if (m_AddTransform.GetComponent<RawImage>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.RawImage;
                    }
                    else if (m_AddTransform.GetComponent<Image>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.Image;
                    }
                    else if (m_AddTransform.GetComponent<Text>() != null)
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.Text;
                    }
                    else
                    {
                        hotFormInfo.HotAttributeType = HotAttributeType.Unknow;
                    }
                }
            }

            if (invalid)
            {
                m_CurrentHotFormInfos.Add(hotFormInfo);
                DrawAllHotFormInfo();
                m_AddTransform = null;
            }
            else
            {
                Error(errorMseeage);
            }

        }

        private void DrawAllHotFormInfo()
        {
            GUI.backgroundColor = greenColor;
            for (int i = 0; i < m_CurrentHotFormInfos.Count; i++)
            {
                DrawILFormInfo(m_CurrentHotFormInfos[i], i);
            }
            GUI.backgroundColor = Color.white;
        }

        private void DrawILFormInfo(HotFormInfo iLFormInfo, int id)
        {
            GUILayout.BeginHorizontal("box");
            {
                if (GUILayout.Button("", "ToggleMixed", GUILayout.Width(20f), GUILayout.Height(16f)))
                {
                    remove = true;
                    removeId = id;
                }

                GUILayout.BeginVertical("box");
                {
                    string oldname = iLFormInfo.Name;
                    iLFormInfo.Name = EditorGUILayout.TextField(iLFormInfo.Name, GUILayout.MinWidth(30f), GUILayout.MaxWidth(150f));
                    if (oldname != iLFormInfo.Name)
                    {
                        change = true;
                    }
                }
                GUILayout.EndVertical();

                GUILayout.BeginVertical("box");
                {
                    string newtransname = EditorGUILayout.TextField(iLFormInfo.TransformName, GUILayout.MinWidth(30f), GUILayout.MaxWidth(150f));
                    if (newtransname != iLFormInfo.TransformName)
                    {
                        bool nameinvalid = true;
                        for (int i = 0; i < m_CurrentHotFormInfos.Count; i++)
                        {
                            if (newtransname == m_CurrentHotFormInfos[i].TransformName)
                            {
                                nameinvalid = false;
                                break;
                            }
                        }
                        if (nameinvalid)
                        {
                            iLFormInfo.TransformName = newtransname;
                            change = true;
                        }
                        else
                        {
                            Error("Transform name is already exist!");
                        }
                    }
                }
                GUILayout.EndVertical();

                GUILayout.BeginVertical("box");
                {
                    Transform oldtransform = iLFormInfo.Trans;
                    iLFormInfo.Trans = (Transform)EditorGUILayout.ObjectField(iLFormInfo.Trans, typeof(Transform), true, GUILayout.MinWidth(40f));
                    if (oldtransform != iLFormInfo.Trans)
                    {
                        change = true;
                    }
                }
                GUILayout.EndVertical();

                GUILayout.BeginVertical("box");
                {
                    HotAttributeType oldhotAttributeType = iLFormInfo.HotAttributeType;
                    iLFormInfo.HotAttributeType = (HotAttributeType)EditorGUILayout.EnumPopup(iLFormInfo.HotAttributeType, GUILayout.MinWidth(70f));
                    if (oldhotAttributeType != iLFormInfo.HotAttributeType)
                    {
                        change = true;
                    }
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();
        }


        private void WriteHotFormInfo()
        {
            m_HotFormInfos.ClearArray();
            int count = m_CurrentHotFormInfos.Count;
            for (int i = 0; i < count; i++)
            {
                m_HotFormInfos.InsertArrayElementAtIndex(i);
                m_HotFormInfos.GetArrayElementAtIndex(i).FindPropertyRelative("m_Name").stringValue = m_CurrentHotFormInfos[i].Name;
                m_HotFormInfos.GetArrayElementAtIndex(i).FindPropertyRelative("m_TransformName").stringValue = m_CurrentHotFormInfos[i].TransformName;
                m_HotFormInfos.GetArrayElementAtIndex(i).FindPropertyRelative("m_HotAttributeType").enumValueIndex = (int)m_CurrentHotFormInfos[i].HotAttributeType;
                m_HotFormInfos.GetArrayElementAtIndex(i).FindPropertyRelative("m_Transform").objectReferenceValue = m_CurrentHotFormInfos[i].Trans;

            }
        }

        private void OnEnable()
        {
            m_HotFormInfos = serializedObject.FindProperty("m_HotFormInfos");

            RefreshTypeNames();
        }

        private void RefreshTypeNames()
        {
            m_CurrentHotFormInfos = new List<HotFormInfo>();
            for (int i = 0; i < m_HotFormInfos.arraySize; i++)
            {
                HotFormInfo iLFormInfo = new HotFormInfo();
                iLFormInfo.Name = m_HotFormInfos.GetArrayElementAtIndex(i).FindPropertyRelative("m_Name").stringValue;
                iLFormInfo.TransformName = m_HotFormInfos.GetArrayElementAtIndex(i).FindPropertyRelative("m_TransformName").stringValue;
                iLFormInfo.HotAttributeType = (HotAttributeType)m_HotFormInfos.GetArrayElementAtIndex(i).FindPropertyRelative("m_HotAttributeType").enumValueIndex;
                iLFormInfo.Trans = (Transform)m_HotFormInfos.GetArrayElementAtIndex(i).FindPropertyRelative("m_Transform").objectReferenceValue;

                m_CurrentHotFormInfos.Add(iLFormInfo);
            }
        }

        private void Error(string errorMessage)
        {
            UnityEditor.EditorUtility.DisplayDialog("Warning", errorMessage, "OK");
        }
    }
}