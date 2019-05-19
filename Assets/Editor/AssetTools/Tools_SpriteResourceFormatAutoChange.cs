using UnityEngine;
using System.Collections;
using UnityEditor;

/// <summary>
/// Unity工具
/// 精灵资源格式自动调整
/// 最大尺寸4096(适应于移动端)
/// </summary>
public class Tools_SpriteResourceFormatAutoChange
{
    private static Vector2 pivotPreSet = new Vector2(0.5f, 0.5f);//预先设置的中心点
    private static int pixelPerUnitPreSet = 100;//预先设置的单位像素值

    /// <summary>
    /// 调整选中的图片
    /// </summary>
    [MenuItem("Assets/Tools/图片格式自动转换为精灵/转换选中的图片")]
    static void ChangeSelectedSprites()
    {
        Object[] selectedObjects = Selection.GetFiltered(typeof(Texture2D), SelectionMode.Assets);//只获取选中的图片
        int spriteNumber = 0;
        for (int i = 0; i < selectedObjects.Length; i++)
        {
            if (selectedObjects[i] is Texture2D)
            {
                if (selectedObjects.Length > 0)
                {
                    EditorUtility.DisplayProgressBar("精灵格式调整", AssetDatabase.GetAssetPath(selectedObjects[i]), i / (float)selectedObjects.Length);
                }
                AdjustTexture(selectedObjects[i] as Texture2D);
                spriteNumber++;
            }
        }
        EditorUtility.ClearProgressBar();
        Debug.Log(spriteNumber + "张精灵图片格式处理完成");
    }

    /// <summary>
    /// 调整选中的图片,包括子文件夹下的所有图片
    /// </summary>
    [MenuItem("Assets/Tools/图片格式自动转换为精灵/转换选中的图片及子文件夹中的图片")]
    static void ChangeSelectedSpritesIncludingSubfolder()
    {
        Object[] selectedObjects = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);//获取包括所选中子文件中的图片
        int spriteNumber = 0;
        for (int i = 0; i < selectedObjects.Length; i++)
        {
            if (selectedObjects[i] is Texture2D)
            {
                if (selectedObjects.Length > 0)
                {
                    EditorUtility.DisplayProgressBar("精灵格式调整", AssetDatabase.GetAssetPath(selectedObjects[i]), i / (float)selectedObjects.Length);
                }
                AdjustTexture(selectedObjects[i] as Texture2D);
                spriteNumber++;
            }
        }
        EditorUtility.ClearProgressBar();
        Debug.Log(spriteNumber + "张精灵图片格式处理完成");
    }

    /// <summary>
    /// 调整图片
    /// </summary>
    /// <param name="targetTexture">目标图片</param>
    private static void AdjustTexture(Texture2D targetTexture)
    {
        //首先获取图片的原始尺寸(不超过4096)
        TextureImporter textureImporter = (TextureImporter)TextureImporter.GetAtPath(AssetDatabase.GetAssetPath(targetTexture));
        textureImporter.maxTextureSize = 4096;//将图片最大尺寸设置为4096
        //AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(targetTexture));//保存格式更改
        //设置图片格式
        textureImporter.textureType = TextureImporterType.Sprite;//图片类型设置为精灵
        textureImporter.spritePivot = pivotPreSet;
        textureImporter.spritePixelsPerUnit = pixelPerUnitPreSet;
        textureImporter.mipmapEnabled = false;
        textureImporter.filterMode = FilterMode.Point;
        textureImporter.spriteImportMode = SpriteImportMode.Single;
        textureImporter.textureFormat = TextureImporterFormat.AutomaticTruecolor;
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(targetTexture));//保存格式更改
        int minSizePow = 5;
        int propertySize = 32;
        int textureWidth = targetTexture.width;
        int textureHeight = targetTexture.height;
        for (int i = minSizePow; i <= 12; i++)//2^12=4096
        {
            propertySize = (int)Mathf.Pow(2, i);
            if (propertySize >= textureWidth && propertySize >= textureHeight)
            {
                break;
            }
        }
        textureImporter.maxTextureSize = propertySize;//设置图片最大大小
        AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(targetTexture));//保存格式更改
    }
}
