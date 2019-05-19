using UnityEditor;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(EntityComponent))]
    public class EntityComponentInspector : UnityEditor.Editor
    {
        private SerializedProperty m_EnableShowEntitySuccessEvent = null;
        private SerializedProperty m_EnableShowEntityFailureEvent = null;
        private SerializedProperty m_EnableShowEntityUpdateEvent = null;
        private SerializedProperty m_EnableShowEntityDependencyAssetEvent = null;
        private SerializedProperty m_EnableHideEntityCompleteEvent = null;
        private SerializedProperty m_EntityGroupInfos = null;


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EntityComponent t = (EntityComponent)target;

            EditorGUILayout.PropertyField(m_EnableShowEntitySuccessEvent);
            EditorGUILayout.PropertyField(m_EnableShowEntityFailureEvent);
            EditorGUILayout.PropertyField(m_EnableShowEntityUpdateEvent);
            EditorGUILayout.PropertyField(m_EnableShowEntityDependencyAssetEvent);
            EditorGUILayout.PropertyField(m_EnableHideEntityCompleteEvent);

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            {
                EditorGUILayout.PropertyField(m_EntityGroupInfos, true);
            }
            EditorGUI.EndDisabledGroup();

            if (EditorApplication.isPlaying && PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
            {
                EditorGUILayout.LabelField("Entity Group Count", t.EntityGroupCount.ToString());
                EditorGUILayout.LabelField("Entity Count (Total)", t.EntityCount.ToString());
                EntityGroup[] entityGroups = t.GetAllEntityGroups();
                foreach (EntityGroup entityGroup in entityGroups)
                {
                    EditorGUILayout.LabelField(TextUtil.Format("Entity Count ({0})", entityGroup.Name), entityGroup.EntityCount.ToString());
                }
            }

            serializedObject.ApplyModifiedProperties();

            Repaint();
        }

        private void OnEnable()
        {
            m_EnableShowEntitySuccessEvent = serializedObject.FindProperty("m_EnableShowEntitySuccessEvent");
            m_EnableShowEntityFailureEvent = serializedObject.FindProperty("m_EnableShowEntityFailureEvent");
            m_EnableShowEntityUpdateEvent = serializedObject.FindProperty("m_EnableShowEntityUpdateEvent");
            m_EnableShowEntityDependencyAssetEvent = serializedObject.FindProperty("m_EnableShowEntityDependencyAssetEvent");
            m_EnableHideEntityCompleteEvent = serializedObject.FindProperty("m_EnableHideEntityCompleteEvent");
            m_EntityGroupInfos = serializedObject.FindProperty("m_EntityGroupInfos");

        }
    }
}