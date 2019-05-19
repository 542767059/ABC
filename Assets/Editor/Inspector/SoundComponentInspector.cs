using UnityEditor;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(SoundComponent))]
    public class SoundComponentInspector : UnityEditor.Editor
    {
        private SerializedProperty m_EnablePlaySoundSuccessEvent = null;
        private SerializedProperty m_EnablePlaySoundFailureEvent = null;
        private SerializedProperty m_EnablePlaySoundUpdateEvent = null;
        private SerializedProperty m_EnablePlaySoundDependencyAssetEvent = null;
        private SerializedProperty m_AudioMixer = null;
        private SerializedProperty m_SoundGroupInfos = null;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SoundComponent t = (SoundComponent)target;

            EditorGUILayout.PropertyField(m_EnablePlaySoundSuccessEvent);
            EditorGUILayout.PropertyField(m_EnablePlaySoundFailureEvent);
            EditorGUILayout.PropertyField(m_EnablePlaySoundUpdateEvent);
            EditorGUILayout.PropertyField(m_EnablePlaySoundDependencyAssetEvent);

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            {
                EditorGUILayout.PropertyField(m_AudioMixer);
                EditorGUILayout.PropertyField(m_SoundGroupInfos, true);
            }
            EditorGUI.EndDisabledGroup();

            if (EditorApplication.isPlaying && PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
            {
                EditorGUILayout.LabelField("Sound Group Count", t.SoundGroupCount.ToString());
            }

            serializedObject.ApplyModifiedProperties();

            Repaint();
        }
        

        private void OnEnable()
        {
            m_EnablePlaySoundSuccessEvent = serializedObject.FindProperty("m_EnablePlaySoundSuccessEvent");
            m_EnablePlaySoundFailureEvent = serializedObject.FindProperty("m_EnablePlaySoundFailureEvent");
            m_EnablePlaySoundUpdateEvent = serializedObject.FindProperty("m_EnablePlaySoundUpdateEvent");
            m_EnablePlaySoundDependencyAssetEvent = serializedObject.FindProperty("m_EnablePlaySoundDependencyAssetEvent");
            m_AudioMixer = serializedObject.FindProperty("m_AudioMixer");
            m_SoundGroupInfos = serializedObject.FindProperty("m_SoundGroupInfos");
            
            RefreshTypeNames();
        }

        private void RefreshTypeNames()
        {
            serializedObject.ApplyModifiedProperties();
        }
    }
}