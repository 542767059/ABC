using UnityEditor;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(LocalizationComponent))]
    public class LocalizationInspector : UnityEditor.Editor
    {
        //当前语言 属性
        private SerializedProperty m_CurrLanguage = null;

        private void OnEnable()
        {
            //建立属性关系
            m_CurrLanguage = serializedObject.FindProperty("m_CurrLanguage");

            serializedObject.ApplyModifiedProperties();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_CurrLanguage);
            serializedObject.ApplyModifiedProperties();
        }
    }
}