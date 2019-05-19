using System;

[Serializable]
public class CacheData 
{
    /// <summary>
    /// 当前场景Id
    /// </summary>
    public int CurrentSceneId = 0;

    /// <summary>
    /// 当前场景小地图大小
    /// </summary>
    public int CurrentSmallMapSize = 0;

    /// <summary>
    /// 最后进入的世界地图编号
    /// </summary>
    public int LastInWorldMapId;

    /// <summary>
    /// 最后进入的世界地图坐标
    /// </summary>
    public string LastInWorldMapPos;

    /// <summary>
    /// 下一个进入的世界地图坐标
    /// </summary>
    public string NextWorldMapPos;

    /// <summary>
    /// 缓存数据
    /// </summary>
    public CacheData()
    {

    }


    /// <summary>
    /// 清空数据
    /// </summary>
    public void Clear()
    {

    }
    
}
