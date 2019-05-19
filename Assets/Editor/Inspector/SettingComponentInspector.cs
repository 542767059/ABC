using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(SettingComponent))]
    public class SettingComponentInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            SettingComponent t = (SettingComponent)target;
            
            if (EditorApplication.isPlaying)
            {
                if (GUILayout.Button("Save Settings"))
                {
                    t.Save();
                }
                if (GUILayout.Button("Remove All Settings"))
                {
                    t.RemoveAllSettings();
                }
            }

            serializedObject.ApplyModifiedProperties();

            Repaint();
        }
    }
}
