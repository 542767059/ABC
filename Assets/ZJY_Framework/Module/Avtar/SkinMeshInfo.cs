using UnityEngine;

namespace ZJY.Framework
{
    public partial class AvtarManager
    {
        public partial class AvtarInfo
        {
            /// <summary>
            /// 蒙皮信息
            /// </summary>
            private class SkinMeshInfo
            {
                public string skinMeshName;
                public Material[] materials;
                public Mesh mesh;
                public string[] bonesName;

                public void Clear()
                {
                    skinMeshName = null;
                    materials = null;
                    mesh = null;
                    bonesName = null;
                }
            }
        }
    }
}