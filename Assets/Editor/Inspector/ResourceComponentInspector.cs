using UnityEditor;
using System.Reflection;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(ResourceComponent))]
    public class ResourceComponentInspector : UnityEditor.Editor
    {
        private static readonly string[] ResourceModeNames = new string[] { "Package", "Updatable" };

        private SerializedProperty m_UnloadUnusedAssetsInterval = null;
        private SerializedProperty m_AssetAutoReleaseInterval = null;
        private SerializedProperty m_AssetExpireTime = null;
        private SerializedProperty m_ResourceAutoReleaseInterval = null;
        private SerializedProperty m_ResourceExpireTime = null;
        private SerializedProperty m_ResourceLoaderCount = null;
        private SerializedProperty m_ResourceMode = null;
        private SerializedProperty m_EditorResourceMode = null;
        private SerializedProperty m_UpdatePrefixUri = null;
        private SerializedProperty m_UpdateFileCacheLength = null;
        private SerializedProperty m_GenerateReadWriteListLength = null;
        private SerializedProperty m_UpdateRetryCount = null;

        private int m_ResourceModeIndex = 0;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            ResourceComponent t = (ResourceComponent)target;

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            {
                m_EditorResourceMode.boolValue = EditorGUILayout.BeginToggleGroup("Editor Resource Mode", m_EditorResourceMode.boolValue);
                {
                    EditorGUILayout.HelpBox("Editor resource mode option is only for editor mode. Game Framework will use editor resource files, which you should validate first.", MessageType.Warning);
                }
                EditorGUILayout.EndToggleGroup();

            }
            EditorGUI.EndDisabledGroup();

            if (t.EditorResourceMode)
            {
                EditorGUILayout.HelpBox("Editor resource mode is enabled. Some options are disabled.", MessageType.Warning);
            }

            float unloadUnusedAssetsInterval = EditorGUILayout.Slider("Unload Unused Assets Interval", m_UnloadUnusedAssetsInterval.floatValue, 0f, 3600f);

            if (unloadUnusedAssetsInterval != m_UnloadUnusedAssetsInterval.floatValue)
            {
                if (EditorApplication.isPlaying)
                {
                    t.UnloadUnusedAssetsInterval = unloadUnusedAssetsInterval;
                }
                else
                {
                    m_UnloadUnusedAssetsInterval.floatValue = unloadUnusedAssetsInterval;
                }
            }

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            {
                if (EditorApplication.isPlaying && PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
                {
                    EditorGUILayout.EnumPopup("Resource Mode", t.ResourceMode);
                }
                else
                {
                    int selectedIndex = EditorGUILayout.Popup("Resource Mode", m_ResourceModeIndex, ResourceModeNames);
                    if (selectedIndex != m_ResourceModeIndex)
                    {
                        m_ResourceModeIndex = selectedIndex;
                        m_ResourceMode.enumValueIndex = selectedIndex + 1;
                    }
                }

                float assetAutoReleaseInterval = EditorGUILayout.DelayedFloatField("Asset Auto Release Interval", m_AssetAutoReleaseInterval.floatValue);
                if (assetAutoReleaseInterval != m_AssetAutoReleaseInterval.floatValue)
                {
                    if (EditorApplication.isPlaying)
                    {
                        t.AssetAutoReleaseInterval = assetAutoReleaseInterval;
                    }
                    else
                    {
                        m_AssetAutoReleaseInterval.floatValue = assetAutoReleaseInterval;
                    }
                }

                float assetExpireTime = EditorGUILayout.DelayedFloatField("Asset Expire Time", m_AssetExpireTime.floatValue);
                if (assetExpireTime != m_AssetExpireTime.floatValue)
                {
                    if (EditorApplication.isPlaying)
                    {
                        t.AssetExpireTime = assetExpireTime;
                    }
                    else
                    {
                        m_AssetExpireTime.floatValue = assetExpireTime;
                    }
                }

                float resourceAutoReleaseInterval = EditorGUILayout.DelayedFloatField("Resource Auto Release Interval", m_ResourceAutoReleaseInterval.floatValue);
                if (resourceAutoReleaseInterval != m_ResourceAutoReleaseInterval.floatValue)
                {
                    if (EditorApplication.isPlaying)
                    {
                        t.ResourceAutoReleaseInterval = resourceAutoReleaseInterval;
                    }
                    else
                    {
                        m_ResourceAutoReleaseInterval.floatValue = resourceAutoReleaseInterval;
                    }
                }
                
                float resourceExpireTime = EditorGUILayout.DelayedFloatField("Resource Expire Time", m_ResourceExpireTime.floatValue);
                if (resourceExpireTime != m_ResourceExpireTime.floatValue)
                {
                    if (EditorApplication.isPlaying)
                    {
                        t.ResourceExpireTime = resourceExpireTime;
                    }
                    else
                    {
                        m_ResourceExpireTime.floatValue = resourceExpireTime;
                    }
                }

                if (m_ResourceModeIndex == 1)
                {
                    string updatePrefixUri = EditorGUILayout.DelayedTextField("Update Prefix Uri", m_UpdatePrefixUri.stringValue);
                    if (updatePrefixUri != m_UpdatePrefixUri.stringValue)
                    {
                        if (EditorApplication.isPlaying)
                        {
                            t.UpdatePrefixUri = updatePrefixUri;
                        }
                        else
                        {
                            m_UpdatePrefixUri.stringValue = updatePrefixUri;
                        }
                    }

                    int updateFileCacheLength = EditorGUILayout.DelayedIntField("Update File Cache Length", m_UpdateFileCacheLength.intValue);
                    if (updateFileCacheLength != m_UpdateFileCacheLength.intValue)
                    {
                        if (EditorApplication.isPlaying)
                        {
                            t.UpdateFileCacheLength = updateFileCacheLength;
                        }
                        else
                        {
                            m_UpdateFileCacheLength.intValue = updateFileCacheLength;
                        }
                    }

                    int generateReadWriteListLength = EditorGUILayout.DelayedIntField("Generate Read Write List Length", m_GenerateReadWriteListLength.intValue);
                    if (generateReadWriteListLength != m_GenerateReadWriteListLength.intValue)
                    {
                        if (EditorApplication.isPlaying)
                        {
                            t.GenerateReadWriteListLength = generateReadWriteListLength;
                        }
                        else
                        {
                            m_GenerateReadWriteListLength.intValue = generateReadWriteListLength;
                        }
                    }

                    int updateRetryCount = EditorGUILayout.DelayedIntField("Update Retry Count", m_UpdateRetryCount.intValue);
                    if (updateRetryCount != m_UpdateRetryCount.intValue)
                    {
                        if (EditorApplication.isPlaying)
                        {
                            t.UpdateRetryCount = updateRetryCount;
                        }
                        else
                        {
                            m_UpdateRetryCount.intValue = updateRetryCount;
                        }
                    }
                }
                

                m_ResourceLoaderCount.intValue = EditorGUILayout.IntSlider("Load ResourceLoader Count", m_ResourceLoaderCount.intValue, 1, 64);
            }
            EditorGUI.EndDisabledGroup();

            if (EditorApplication.isPlaying && PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
            {
                EditorGUILayout.LabelField("Read Only Path", t.ReadOnlyPath.ToString());
                EditorGUILayout.LabelField("Read Write Path", t.ReadWritePath.ToString());


                EditorGUILayout.LabelField("Asset Count", m_EditorResourceMode.boolValue ? "N/A" : t.AssetCount.ToString());
                EditorGUILayout.LabelField("Resource Count", m_EditorResourceMode.boolValue ? "N/A" : t.ResourceCount.ToString());

                if (m_ResourceModeIndex == 1)
                {
                    EditorGUILayout.LabelField("Update Waiting Count", m_EditorResourceMode.boolValue ? "N/A" : t.UpdateWaitingCount.ToString());
                    EditorGUILayout.LabelField("Update Failure Count", m_EditorResourceMode.boolValue ? "N/A" : t.UpdateFailureCount.ToString());
                    EditorGUILayout.LabelField("Updating Count", m_EditorResourceMode.boolValue ? "N/A" : t.UpdatingCount.ToString());
                }

                EditorGUILayout.LabelField("Load Total Loader Count", m_EditorResourceMode.boolValue ? "N/A" : t.LoadTotalAgentCount.ToString());
                EditorGUILayout.LabelField("Load Free Loader Count", m_EditorResourceMode.boolValue ? "N/A" : t.FreeLoaderCount.ToString());
                EditorGUILayout.LabelField("Load Working Loader Count", m_EditorResourceMode.boolValue ? "N/A" : t.WorkingLoaderCount.ToString());
                EditorGUILayout.LabelField("Load Waiting Task Count", m_EditorResourceMode.boolValue ? "N/A" : t.LoadWaitingTaskCount.ToString());
            }

            serializedObject.ApplyModifiedProperties();
            
            Repaint();
        }

        private void OnEnable()
        {
            m_EditorResourceMode = serializedObject.FindProperty("m_EditorResourceMode");
            m_UnloadUnusedAssetsInterval = serializedObject.FindProperty("m_UnloadUnusedAssetsInterval");
            m_AssetAutoReleaseInterval = serializedObject.FindProperty("m_AssetAutoReleaseInterval");
            m_AssetExpireTime = serializedObject.FindProperty("m_AssetExpireTime");
            m_ResourceAutoReleaseInterval = serializedObject.FindProperty("m_ResourceAutoReleaseInterval");
            m_ResourceExpireTime = serializedObject.FindProperty("m_ResourceExpireTime");
            m_ResourceLoaderCount = serializedObject.FindProperty("m_ResourceLoaderCount");
            m_ResourceMode = serializedObject.FindProperty("m_ResourceMode");
            m_UpdatePrefixUri = serializedObject.FindProperty("m_UpdatePrefixUri");
            m_UpdateFileCacheLength = serializedObject.FindProperty("m_UpdateFileCacheLength");
            m_GenerateReadWriteListLength = serializedObject.FindProperty("m_GenerateReadWriteListLength");
            m_UpdateRetryCount = serializedObject.FindProperty("m_UpdateRetryCount");

            RefreshModes();
        }

        private void RefreshModes()
        {
            m_ResourceModeIndex = (m_ResourceMode.enumValueIndex > 0 ? m_ResourceMode.enumValueIndex - 1 : 0);
        }
    }
}