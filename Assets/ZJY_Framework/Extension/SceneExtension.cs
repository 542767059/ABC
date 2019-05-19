namespace ZJY.Framework
{
    /// <summary>
    /// 数据表组件扩展
    /// </summary>
    public static class SceneExtension
    {
        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="sceneComponent"></param>
        /// <param name="sceneType">场景类型</param>
        /// <param name="userData">用户数据</param>
        public static void LoadScene(this SceneComponent sceneComponent, SceneType sceneType, object userData = null)
        {
            GameEntry.Scene.LoadScene((int)sceneType, userData);
        }

        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="sceneComponent"></param>
        /// <param name="sceneId">场景编号</param>
        /// <param name="userData">用户数据</param>
        public static void LoadScene(this SceneComponent sceneComponent, int sceneId, object userData = null)
        {
            UnityEngine.Debug.Log(sceneId);
            SceneEntity sceneEntity = GameEntry.DataTable.GetDataTable<SceneDBModel>().Get(sceneId);

            if (sceneEntity == null)
            {
                Log.Warning("Can not load scene '{0}' from data table.", sceneId.ToString());
                return;
            }

            GameEntry.Scene.LoadScene(AssetUtility.GetSceneAsset(sceneEntity.AssetName), Constant.AssetPriority.SceneAsset, userData);
        }
    }
}

