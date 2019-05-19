using System.Collections.Generic;
using UnityEditor;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(TimeComponent))]
    public class TimeComponentInspector : UnityEditor.Editor
    {
        private HashSet<TimeAction> m_OpenedItems = new HashSet<TimeAction>();


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            TimeComponent t = (TimeComponent)target;

            if (!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Available during runtime only.", MessageType.Info);
                return;
            }

            EditorGUILayout.LabelField("GameTime", t.GameTime.ToString());
            EditorGUILayout.LabelField("RealGameTime", t.RealGameTime.ToString());

            if (EditorApplication.isPlaying && PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
            {
                EditorGUILayout.LabelField("TimeActionCount", t.TimeActionCount.ToString());

                TimeAction[] timeActions = t.GetAllTimeAction();
                foreach (TimeAction timeAction in timeActions)
                {
                    DrawTimeAction(timeAction);
                }
            }


            serializedObject.ApplyModifiedProperties();

            Repaint();
        }

        private void OnEnable()
        {
        }

        private void DrawTimeAction(TimeAction timeAction)
        {
            bool lastState = m_OpenedItems.Contains(timeAction);
            bool currentState = EditorGUILayout.Foldout(lastState, timeAction.TimeActionName);
            if (currentState != lastState)
            {
                if (currentState)
                {
                    m_OpenedItems.Add(timeAction);
                }
                else
                {
                    m_OpenedItems.Remove(timeAction);
                }
            }

            if (currentState)
            {
                EditorGUILayout.BeginVertical("box");
                {
                    EditorGUILayout.LabelField("TimeActionName", timeAction.TimeActionName);
                    EditorGUILayout.LabelField("IsRunning", timeAction.IsRuning.ToString());
                    EditorGUILayout.LabelField("IsPause", timeAction.IsPause.ToString());
                    EditorGUILayout.LabelField("PauseTime", timeAction.PauseTime.ToString());
                    EditorGUILayout.LabelField("StartTime", timeAction.StartTime >= 0 ? timeAction.StartTime.ToString() : "Not Running");
                    EditorGUILayout.LabelField("OnceRunTime", timeAction.OnceTime >= 0 ? timeAction.OnceTime.ToString() : "Not Running");
                    EditorGUILayout.LabelField("CurrRunTime", timeAction.CurrRunTime.ToString());
                    EditorGUILayout.LabelField("Delaytime", timeAction.Delaytime.ToString());
                    EditorGUILayout.LabelField("Interval", timeAction.Interval.ToString());
                    EditorGUILayout.LabelField("CurrLoop", timeAction.CurrLoop.ToString());
                    EditorGUILayout.LabelField("Loop", timeAction.Loop.ToString());
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.Separator();
            }
        }
    }
}
