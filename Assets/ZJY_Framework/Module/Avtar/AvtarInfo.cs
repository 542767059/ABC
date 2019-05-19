using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    public partial class AvtarManager
    {
        /// <summary>
        /// 换装信息
        /// </summary>
        public partial class AvtarInfo
        {
            private AvtarManager m_AvtarManager;
            private readonly Dictionary<string, AssetObject> m_AvtarAssetInfos;
            private readonly List<SkinMeshInfo> m_SkinMeshInfo;
            private Entity m_Owner;
            private Transform[] m_AllChildTs;

            /// <summary>
            /// 获取换装信息拥有者
            /// </summary>
            public Entity Owner
            {
                get
                {
                    return m_Owner;
                }
            }

            /// <summary>
            /// 获取所有换装资源信息
            /// </summary>
            public  Dictionary<string, AssetObject> AvtarAssetInfos
            {
                get
                {
                    return m_AvtarAssetInfos;
                }
            }

            public AvtarInfo(Entity owner, AvtarManager avtarManager)
            {
                m_Owner = owner;
                m_AvtarManager = avtarManager;
                m_AvtarAssetInfos = new Dictionary<string, AssetObject>();
                m_SkinMeshInfo = new List<SkinMeshInfo>();
                m_AllChildTs = m_Owner.GetComponentsInChildren<Transform>(true);
            }

            /// <summary>
            /// 是否已经存在蒙皮
            /// </summary>
            /// <param name="assetName">蒙皮资源名称</param>
            /// <returns>是否存在</returns>
            public bool HasSkinnedMesh(string assetName)
            {
                return m_AvtarAssetInfos.ContainsKey(assetName);
            }

            /// <summary>
            /// 清空信息
            /// </summary>
            public void Clear()
            {
                foreach (var skinMeshInfo in m_SkinMeshInfo)
                {
                    m_AvtarManager.m_AssetPool.Unspawn(m_AvtarAssetInfos[skinMeshInfo.skinMeshName]);
                    m_AvtarAssetInfos.Remove(skinMeshInfo.skinMeshName);
                    skinMeshInfo.Clear();
                }
                m_SkinMeshInfo.Clear();
            }

            /// <summary>
            /// 增加蒙皮信息
            /// </summary>
            /// <param name="assetObject">要增加的蒙皮资源</param>
            /// <returns>增加是否成功</returns>
            internal bool AddSkinMeshInfo(AssetObject assetObject)
            {
                SkinnedMeshRenderer sk = ((GameObject)assetObject.Target).GetComponent<SkinnedMeshRenderer>();
                try
                {
                    if (!sk)
                    {
                        sk = ((GameObject)assetObject.Target).GetComponentsInChildren<SkinnedMeshRenderer>(true)[0];
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex.ToString());
                    return false;
                }


                Transform[] trfs = sk.bones;
                int tlen = trfs.Length;
                string[] bonesName = new string[tlen];
                for (int i = 0; i < tlen; i++)
                {
                    bonesName[i] = trfs[i].name;
                }


                SkinMeshInfo info = new SkinMeshInfo();
                info.skinMeshName = assetObject.Name;
                info.mesh = sk.sharedMesh;
                info.materials = sk.sharedMaterials;
                info.bonesName = bonesName;

                m_SkinMeshInfo.Add(info);
                m_AvtarAssetInfos.Add(info.skinMeshName, assetObject);
                Generate();
                return true;
            }

            /// <summary>
            /// 移除蒙皮信息
            /// </summary>
            /// <param name="assetName">要移除的蒙皮资源名称</param>
            /// <returns>移除是否成功</returns>
            internal bool RemoveSkinMeshInfo(string assetName)
            {
                SkinMeshInfo skinMeshInfo = m_SkinMeshInfo.Find(sm => sm.skinMeshName == assetName);
                if (skinMeshInfo != null)
                {
                    m_AvtarManager.m_AssetPool.Unspawn(m_AvtarAssetInfos[skinMeshInfo.skinMeshName]);
                    m_AvtarAssetInfos.Remove(skinMeshInfo.skinMeshName);
                    skinMeshInfo.Clear();
                    m_SkinMeshInfo.Remove(skinMeshInfo);
                    Generate();
                    return true;
                }
                return false;
            }

            List<Transform> bones = new List<Transform>();
            /// <summary>
            /// 重新合成蒙皮信息
            /// </summary>
            private void Generate()
            {
                int len = m_SkinMeshInfo.Count;
                if (len == 0) return;
                SkinnedMeshRenderer sk = m_Owner.GetComponent<SkinnedMeshRenderer>();
                if (!sk)
                {
                    sk = m_Owner.gameObject.AddComponent<SkinnedMeshRenderer>();
                }
                sk.updateWhenOffscreen = true;
                bones.Clear();
                Mesh mesh = null;
                Material[] material = null;
                Transform[] bone = null;
                if (len > 1)
                {
                    List<CombineInstance> combineInstances = new List<CombineInstance>();
                    List<Material> materials = new List<Material>();
                    for (int i = 0; i < len; i++)
                    {
                        SkinMeshInfo sm = m_SkinMeshInfo[i];
                        AddMeshTo(sm, combineInstances);
                        materials.AddRange(sm.materials);
                        AddBoneTo(sm, bones);
                    }
                    bone = bones.ToArray();
                    material = materials.ToArray();
                    mesh = new Mesh();
                    mesh.CombineMeshes(combineInstances.ToArray(), false, false);
                }
                else
                {
                    SkinMeshInfo sm = m_SkinMeshInfo[0];
                    mesh = sm.mesh;
                    material = sm.materials;
                    AddBoneTo(sm, bones);
                    bone = bones.ToArray();
                }
                sk.materials = material;
                sk.bones = bone;
                sk.sharedMesh = mesh;
            }

            private void AddMeshTo(SkinMeshInfo sm, List<CombineInstance> combineInstances)
            {
                CombineInstance ci = new CombineInstance();
                ci.mesh = sm.mesh;
                combineInstances.Add(ci);
            }

            private void AddBoneTo(SkinMeshInfo sm, List<Transform> bones)
            {
                string[] bns = sm.bonesName;
                for (int k = 0, blen = bns.Length; k < blen; k++)
                {
                    for (int j = 0, cLen = m_AllChildTs.Length; j < cLen; j++)
                    {
                        Transform t = m_AllChildTs[j];
                        if (!t || t.name != bns[k]) continue;
                        bones.Add(t);
                        break;
                    }
                }
            }

        }
    }
}
