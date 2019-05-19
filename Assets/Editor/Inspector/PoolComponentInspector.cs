using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ZJY.Framework;
using System.IO;
using System.Text;
using System;

namespace ZJY.Editor
{
    [CustomEditor(typeof(PoolComponent))]
    public class PoolComponentInspector : UnityEditor.Editor
    {
        private HashSet<string> m_OpenedItems = new HashSet<string>();


        //释放间隔 属性
        private SerializedProperty m_ClearCalssObjectInterval = null;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            PoolComponent poolComponent = (PoolComponent)target;

            EditorGUI.BeginDisabledGroup(EditorApplication.isPlayingOrWillChangePlaymode);
            {
                //绘制滑动条
                int clearInterval = (int)EditorGUILayout.Slider("Auto clear object pool interval", m_ClearCalssObjectInterval.floatValue, 10, 1800);
                if (clearInterval != m_ClearCalssObjectInterval.floatValue)
                {

                    m_ClearCalssObjectInterval.floatValue = clearInterval;
                    serializedObject.ApplyModifiedProperties();
                }
            }
            EditorGUI.EndDisabledGroup();

            if (!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Available during runtime only.", MessageType.Info);
                return;
            }

            //===================类对象池开始============================
            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Class name", GUILayout.MinWidth(50));
            GUILayout.Label("Count in pool", GUILayout.Width(100));
            GUILayout.Label("Permanent count", GUILayout.Width(100));
            GUILayout.EndHorizontal();


            foreach (var item in poolComponent.ClassObjetPoolDic)
            {
                string fullName = item.Key;
                GUILayout.BeginHorizontal("box");
                GUILayout.Label(fullName, GUILayout.MinWidth(50));
                GUILayout.Label(item.Value.Count.ToString(), GUILayout.Width(100));

                byte resideCount = 0;
                poolComponent.ClassObjectCount.TryGetValue(fullName, out resideCount);

                GUILayout.Label(resideCount.ToString(), GUILayout.Width(100));
                GUILayout.EndHorizontal();
            }

            GUILayout.EndVertical();
            //===================类对象池结束============================


            //===================变量计数开始============================
            GUILayout.Space(10);
            GUILayout.BeginVertical("box");
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("Var object type");
            GUILayout.Label("Count in pool", GUILayout.Width(100));
            GUILayout.EndHorizontal();

            if (poolComponent != null)
            {
                foreach (var item in poolComponent.VarObjectDic)
                {
                    GUILayout.BeginHorizontal("box");
                    GUILayout.Label(item.Key.Name);
                    GUILayout.Label(item.Value.ToString(), GUILayout.Width(50));
                    GUILayout.EndHorizontal();
                }
            }
            GUILayout.EndVertical();
            //===================变量计数结束============================



            if (PrefabUtility.GetPrefabType(poolComponent.gameObject) != PrefabType.Prefab)
            {
                EditorGUILayout.LabelField("Object Pool Count", poolComponent.Count.ToString());

                ObjectPoolBase[] objectPools = poolComponent.GetAllObjectPools(true);
                foreach (ObjectPoolBase objectPool in objectPools)
                {
                    DrawObjectPool(objectPool);
                }
            }

            serializedObject.ApplyModifiedProperties();
            //重绘面板
            Repaint();
        }

        private void OnEnable()
        {
            //建立属性关系
            m_ClearCalssObjectInterval = serializedObject.FindProperty("m_ClearCalssObjectInterval");

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawObjectPool(ObjectPoolBase objectPool)
        {
            bool lastState = m_OpenedItems.Contains(objectPool.FullName);
            bool currentState = EditorGUILayout.Foldout(lastState, objectPool.FullName);
            if (currentState != lastState)
            {
                if (currentState)
                {
                    m_OpenedItems.Add(objectPool.FullName);
                }
                else
                {
                    m_OpenedItems.Remove(objectPool.FullName);
                }
            }

            if (currentState)
            {
                EditorGUILayout.BeginVertical("box");
                {
                    EditorGUILayout.LabelField("Name", objectPool.Name);
                    EditorGUILayout.LabelField("Type", objectPool.ObjectType.FullName);
                    EditorGUILayout.LabelField("Auto Release Interval", objectPool.AutoReleaseInterval.ToString());
                    EditorGUILayout.LabelField("Capacity", objectPool.Capacity.ToString());
                    EditorGUILayout.LabelField("Used Count", objectPool.Count.ToString());
                    EditorGUILayout.LabelField("Can Release Count", objectPool.CanReleaseCount.ToString());
                    EditorGUILayout.LabelField("Expire Time", objectPool.ExpireTime.ToString());
                    EditorGUILayout.LabelField("Priority", objectPool.Priority.ToString());
                    ObjectInfo[] objectInfos = objectPool.GetAllObjectInfos();
                    if (objectInfos.Length > 0)
                    {
                        foreach (ObjectInfo objectInfo in objectInfos)
                        {
                            EditorGUILayout.LabelField(objectInfo.Name, TextUtil.Format("{0}, {1}, {2}, {3}", objectInfo.Locked.ToString(), objectPool.AllowMultiSpawn ? objectInfo.SpawnCount.ToString() : objectInfo.IsInUse.ToString(), objectInfo.Priority.ToString(), objectInfo.LastUseTime.ToString("yyyy-MM-dd HH:mm:ss")));
                        }

                        if (GUILayout.Button("Release"))
                        {
                            objectPool.Release();
                        }

                        if (GUILayout.Button("Release All Unused"))
                        {
                            objectPool.ReleaseAllUnused();
                        }

                        if (GUILayout.Button("Export CSV Data"))
                        {
                            string exportFileName = EditorUtility.SaveFilePanel("Export CSV Data", string.Empty, TextUtil.Format("Object Pool Data - {0}.csv", objectPool.Name), string.Empty);
                            try
                            {
                                int index = 0;
                                string[] data = new string[objectInfos.Length + 1];
                                data[index++] = TextUtil.Format("Name,Locked,{0},Custom Can Release Flag,Priority,Last Use Time", objectPool.AllowMultiSpawn ? "Count" : "In Use");
                                foreach (ObjectInfo objectInfo in objectInfos)
                                {
                                    data[index++] = TextUtil.Format("{0},{1},{2},{3},{4},{5}", objectInfo.Name, objectInfo.Locked.ToString(), objectPool.AllowMultiSpawn ? objectInfo.SpawnCount.ToString() : objectInfo.IsInUse.ToString(), objectInfo.CustomCanReleaseFlag.ToString(), objectInfo.Priority.ToString(), objectInfo.LastUseTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                }

                                File.WriteAllLines(exportFileName, data, Encoding.UTF8);
                                Debug.Log(TextUtil.Format("Export CSV data to '{0}' success.", exportFileName));
                            }
                            catch (Exception exception)
                            {
                                Debug.LogError(TextUtil.Format("Export CSV data to '{0}' failure, exception is '{1}'.", exportFileName, exception.Message));
                            }
                        }
                    }
                    else
                    {
                        GUILayout.Label("Object Pool is Empty ...");
                    }
                }
                EditorGUILayout.EndVertical();

                EditorGUILayout.Separator();
            }
        }
    }

}
