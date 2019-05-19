using UnityEditor;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(FsmComponent))]
    internal sealed class FsmComponentInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            if (!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Available during runtime only.", MessageType.Info);
                return;
            }

            FsmComponent t = (FsmComponent)target;

            if (  PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab )
            {
                EditorGUILayout.LabelField("FSM Count", t.Count.ToString());

                FsmBase[] fsms = t.GetAllFsms();
                foreach (FsmBase fsm in fsms)
                {
                    DrawFsm(fsm);
                }
            }

            Repaint();
        }

        private void OnEnable()
        {

        }

        private void DrawFsm(FsmBase fsm)
        {
            EditorGUILayout.LabelField(TextUtil.GetFullName(fsm.OwnerType, fsm.Name), fsm.IsRunning ? TextUtil.Format("{0}, {1} s", fsm.CurrentStateName, fsm.CurrentStateTime.ToString("F1")) : (fsm.IsDestroyed ? "Destroyed" : "Not Running"));
        }
    }
}
