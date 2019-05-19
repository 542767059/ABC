using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(DataComponent))]
    public class DataComponentInspector : UnityEditor.Editor
    {

        public override void OnInspectorGUI()
        {
            if (!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Available during runtime only.", MessageType.Info);
                return;
            }
            base.OnInspectorGUI();
        }
    }
}
