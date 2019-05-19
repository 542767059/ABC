﻿using UnityEditor;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(UIComponent))]
    public class UIComponentInspector : UnityEditor.Editor
    {
        private SerializedProperty m_StandardWidth = null;
        private SerializedProperty m_StandardHeight = null;
        private SerializedProperty m_UICamera = null;
        private SerializedProperty m_CanvasScaler = null;
        private SerializedProperty m_EnableOpenUIFormSuccessEvent = null;
        private SerializedProperty m_EnableOpenUIFormFailureEvent = null;
        private SerializedProperty m_EnableOpenUIFormUpdateEvent = null;
        private SerializedProperty m_EnableOpenUIFormDependencyAssetEvent = null;
        private SerializedProperty m_EnableCloseUIFormCompleteEvent = null;
        private SerializedProperty m_InstanceAutoReleaseInterval = null;
        private SerializedProperty m_InstanceCapacity = null;
        private SerializedProperty m_InstanceExpireTime = null;
        private SerializedProperty m_InstancePriority = null;
        private SerializedProperty m_UIRoot = null;
        private SerializedProperty m_UIGroupInfos = null;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            UIComponent t = (UIComponent)target;
            
            EditorGUILayout.PropertyField(m_EnableOpenUIFormSuccessEvent);
            EditorGUILayout.PropertyField(m_EnableOpenUIFormFailureEvent);
            EditorGUILayout.PropertyField(m_EnableOpenUIFormUpdateEvent);
            EditorGUILayout.PropertyField(m_EnableOpenUIFormDependencyAssetEvent);
            EditorGUILayout.PropertyField(m_EnableCloseUIFormCompleteEvent);

            float instanceAutoReleaseInterval = EditorGUILayout.DelayedFloatField("Instance Auto Release Interval", m_InstanceAutoReleaseInterval.floatValue);
            if (instanceAutoReleaseInterval != m_InstanceAutoReleaseInterval.floatValue)
            {
                if (EditorApplication.isPlaying)
                {
                    t.InstanceAutoReleaseInterval = instanceAutoReleaseInterval;
                }
                else
                {
                    m_InstanceAutoReleaseInterval.floatValue = instanceAutoReleaseInterval;
                }
            }

            int instanceCapacity = EditorGUILayout.DelayedIntField("Instance Capacity", m_InstanceCapacity.intValue);
            if (instanceCapacity != m_InstanceCapacity.intValue)
            {
                if (EditorApplication.isPlaying)
                {
                    t.InstanceCapacity = instanceCapacity;
                }
                else
                {
                    m_InstanceCapacity.intValue = instanceCapacity;
                }
            }

            float instanceExpireTime = EditorGUILayout.DelayedFloatField("Instance Expire Time", m_InstanceExpireTime.floatValue);
            if (instanceExpireTime != m_InstanceExpireTime.floatValue)
            {
                if (EditorApplication.isPlaying)
                {
                    t.InstanceExpireTime = instanceExpireTime;
                }
                else
                {
                    m_InstanceExpireTime.floatValue = instanceExpireTime;
                }
            }

            int instancePriority = EditorGUILayout.DelayedIntField("Instance Priority", m_InstancePriority.intValue);
            if (instancePriority != m_InstancePriority.intValue)
            {
                if (EditorApplication.isPlaying)
                {
                    t.InstancePriority = instancePriority;
                }
                else
                {
                    m_InstancePriority.intValue = instancePriority;
                }
            }

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            {
                EditorGUILayout.PropertyField(m_StandardWidth);
                EditorGUILayout.PropertyField(m_StandardHeight);
                EditorGUILayout.PropertyField(m_UICamera);
                EditorGUILayout.PropertyField(m_CanvasScaler);
                EditorGUILayout.PropertyField(m_UIRoot);
                EditorGUILayout.PropertyField(m_UIGroupInfos, true);
            }
            EditorGUI.EndDisabledGroup();

            if (EditorApplication.isPlaying && PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
            {
                EditorGUILayout.LabelField("UI Group Count", t.UIGroupCount.ToString());
            }

            serializedObject.ApplyModifiedProperties();

            Repaint();
        }


        private void OnEnable()
        {
            m_StandardWidth = serializedObject.FindProperty("m_StandardWidth");
            m_StandardHeight = serializedObject.FindProperty("m_StandardHeight");
            m_UICamera = serializedObject.FindProperty("m_UICamera");
            m_CanvasScaler = serializedObject.FindProperty("m_CanvasScaler");
            m_EnableOpenUIFormSuccessEvent = serializedObject.FindProperty("m_EnableOpenUIFormSuccessEvent");
            m_EnableOpenUIFormFailureEvent = serializedObject.FindProperty("m_EnableOpenUIFormFailureEvent");
            m_EnableOpenUIFormUpdateEvent = serializedObject.FindProperty("m_EnableOpenUIFormUpdateEvent");
            m_EnableOpenUIFormDependencyAssetEvent = serializedObject.FindProperty("m_EnableOpenUIFormDependencyAssetEvent");
            m_EnableCloseUIFormCompleteEvent = serializedObject.FindProperty("m_EnableCloseUIFormCompleteEvent");
            m_InstanceAutoReleaseInterval = serializedObject.FindProperty("m_InstanceAutoReleaseInterval");
            m_InstanceCapacity = serializedObject.FindProperty("m_InstanceCapacity");
            m_InstanceExpireTime = serializedObject.FindProperty("m_InstanceExpireTime");
            m_InstancePriority = serializedObject.FindProperty("m_InstancePriority");
            m_UIRoot = serializedObject.FindProperty("m_UIRoot");
            m_UIGroupInfos = serializedObject.FindProperty("m_UIGroupInfos");
        }

    }
}