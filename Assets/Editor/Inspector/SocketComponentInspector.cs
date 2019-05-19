using UnityEditor;
using UnityEngine;
using ZJY.Framework;

namespace ZJY.Editor
{
    [CustomEditor(typeof(SocketComponent))]
    internal sealed class NetworkComponentInspector : UnityEditor.Editor
    {
        private SerializedProperty m_MaxSendCount = null;
        private SerializedProperty m_MaxSendByteCount = null;
        private SerializedProperty m_MaxReceiveCount = null;
        private SerializedProperty m_HeartbeatInterval = null;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SocketComponent t = (SocketComponent)target;
            EditorGUILayout.BeginVertical("box");
            {
                int maxSendCount = (int)EditorGUILayout.Slider("Send pack count in one frame", m_MaxSendCount.intValue, 1, 60);
                if (maxSendCount != m_MaxSendCount.intValue)
                {
                    if (EditorApplication.isPlaying)
                    {
                        t.MaxSendCount = maxSendCount;
                    }
                    else
                    {
                        m_MaxSendCount.intValue = maxSendCount;
                    }
                }

                int maxSendByteCount = (int)EditorGUILayout.Slider("Send pack Size in one frame", m_MaxSendByteCount.intValue, 200, 2048);
                if (maxSendByteCount != m_MaxSendByteCount.intValue)
                {
                    if (EditorApplication.isPlaying)
                    {
                        t.MaxSendByteCount = maxSendByteCount;
                    }
                    else
                    {
                        m_MaxSendByteCount.intValue = maxSendByteCount;
                    }
                }
                int maxReceiveCount = (int)EditorGUILayout.Slider("Receive pack count in one frame", m_MaxReceiveCount.intValue, 1, 60);
                if (maxReceiveCount != m_MaxReceiveCount.intValue)
                {
                    if (EditorApplication.isPlaying)
                    {
                        t.MaxReceiveCount = maxReceiveCount;
                    }
                    else
                    {
                        m_MaxReceiveCount.intValue = maxReceiveCount;
                    }
                }
                float heartbeatInterval = EditorGUILayout.Slider("HeartbeatInterval", m_HeartbeatInterval.floatValue, 1, 60);
                if (heartbeatInterval != m_HeartbeatInterval.floatValue)
                {
                    if (EditorApplication.isPlaying)
                    {
                        t.HeartbeatInterval = heartbeatInterval;
                    }
                    else
                    {
                        m_HeartbeatInterval.floatValue = heartbeatInterval;
                    }
                }

                EditorGUILayout.LabelField("Ping", t.PingValue.ToString());
                EditorGUILayout.LabelField("GameServerTime", t.GameServerTime.ToString());
                EditorGUILayout.LabelField("CheckServerTime", t.CheckServerTime.ToString());
                serializedObject.ApplyModifiedProperties();
            }
            EditorGUILayout.EndVertical();

            if (!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Available during runtime only.", MessageType.Info);
                return;
            }


            if (PrefabUtility.GetPrefabType(t.gameObject) != PrefabType.Prefab)
            {
                EditorGUILayout.LabelField("Socket Count", t.SocketTcpRoutineCount.ToString());

                SocketTcpRoutine[] socketTcpRoutines = t.GetAllSocketTcpRoutines();
                foreach (SocketTcpRoutine socketTcpRoutine in socketTcpRoutines)
                {
                    DrawSocketTcp(socketTcpRoutine);
                }
            }

            serializedObject.ApplyModifiedProperties();
            Repaint();
        }

        private void OnEnable()
        {
            m_MaxSendCount = serializedObject.FindProperty("m_MaxSendCount");
            m_MaxSendByteCount = serializedObject.FindProperty("m_MaxSendByteCount");
            m_MaxReceiveCount = serializedObject.FindProperty("m_MaxReceiveCount");
            m_HeartbeatInterval = serializedObject.FindProperty("m_HeartbeatInterval");

        }

        private void DrawSocketTcp(SocketTcpRoutine socketTcpRoutine)
        {
            EditorGUILayout.BeginVertical("box");
            {
                EditorGUILayout.LabelField(socketTcpRoutine.Name, socketTcpRoutine.Connected ? "Connected" : "Disconnected");
                EditorGUILayout.LabelField("Network Type", socketTcpRoutine.NetworkType.ToString());
                EditorGUILayout.LabelField("Local Address", socketTcpRoutine.Connected ? TextUtil.Format("{0}:{1}", socketTcpRoutine.LocalIPAddress.ToString(), socketTcpRoutine.LocalPort.ToString()) : "Unavailable");
                EditorGUILayout.LabelField("Remote Address", socketTcpRoutine.Connected ? TextUtil.Format("{0}:{1}", socketTcpRoutine.RemoteIPAddress.ToString(), socketTcpRoutine.RemotePort.ToString()) : "Unavailable");
                EditorGUILayout.LabelField("Send Packet", TextUtil.Format("{0} / {1}", socketTcpRoutine.SendPacketCount.ToString(), socketTcpRoutine.SentPacketCount.ToString()));
                EditorGUILayout.LabelField("Receive Packet", TextUtil.Format("{0} / {1}", socketTcpRoutine.ReceivePacketCount.ToString(), socketTcpRoutine.ReceivedPacketCount.ToString()));
                EditorGUI.BeginDisabledGroup(!socketTcpRoutine.Connected);
                {
                    if (GUILayout.Button("Disconnect"))
                    {
                        socketTcpRoutine.Close();
                    }
                }
                EditorGUI.EndDisabledGroup();
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.Separator();
        }
    }
}
