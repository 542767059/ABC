using UnityEditor;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(DataTableComponent))]
    public class DataTableComponentInspectror : UnityEditor.Editor
    {
        private SerializedProperty m_EnableLoadDataTableSuccessEvent = null;
        private SerializedProperty m_EnableLoadDataTableFailureEvent = null;
        private SerializedProperty m_EnableLoadDataTableUpdateEvent = null;
        private SerializedProperty m_EnableLoadDataTableDependencyAssetEvent = null;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DataTableComponent t = (DataTableComponent)target;

            EditorGUILayout.PropertyField(m_EnableLoadDataTableSuccessEvent);
            EditorGUILayout.PropertyField(m_EnableLoadDataTableFailureEvent);
            EditorGUILayout.PropertyField(m_EnableLoadDataTableUpdateEvent);
            EditorGUILayout.PropertyField(m_EnableLoadDataTableDependencyAssetEvent);

            if (EditorApplication.isPlaying && PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
            {
                EditorGUILayout.LabelField("Data Table Count", t.DataTablesCount.ToString());

                IDataTable[] dataTables = t.GetAllDataTables();
                foreach (IDataTable dataTable in dataTables)
                {
                    DrawDataTable(dataTable);
                }
            }



            serializedObject.ApplyModifiedProperties();

            Repaint();
        }


        private void DrawDataTable(IDataTable dataTable)
        {
            EditorGUILayout.LabelField(dataTable.Type.FullName, dataTable.EntityCount.ToString());
        }

        private void OnEnable()
        {
            m_EnableLoadDataTableSuccessEvent = serializedObject.FindProperty("m_EnableLoadDataTableSuccessEvent");
            m_EnableLoadDataTableFailureEvent = serializedObject.FindProperty("m_EnableLoadDataTableFailureEvent");
            m_EnableLoadDataTableUpdateEvent = serializedObject.FindProperty("m_EnableLoadDataTableUpdateEvent");
            m_EnableLoadDataTableDependencyAssetEvent = serializedObject.FindProperty("m_EnableLoadDataTableDependencyAssetEvent");
        }
    }
}
