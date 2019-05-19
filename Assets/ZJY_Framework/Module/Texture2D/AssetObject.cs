namespace ZJY.Framework
{
    /// <summary>
    /// 资源对象
    /// </summary>
    public sealed class AssetObject : ObjectBase
    {
        public AssetObject(string name, object target)
            : base(name, target)
        {

        }

        protected internal override void OnUnspawn()
        {
            base.OnUnspawn();

        }

        protected internal override void Release(bool isShutdown)
        {
            UnityEngine.Object unityObject = Target as UnityEngine.Object;
            if (unityObject != null)
            {
                GameEntry.Resource.UnloadAsset(unityObject);
            }
        }
    }
}


