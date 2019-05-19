using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

/// <summary>
/// Unity工具
/// 从精灵图片中创建动画片段
/// </summary>
public class Tools_CreateAnimationClipUsingSprites : EditorWindow
{
    static List<Sprite> selectedSpritesList;
    static List<Sprite> SelectedSpritesList { get { selectedSpritesList = selectedSpritesList ?? new List<Sprite>(); return selectedSpritesList; } }//选中的精灵列表

    static bool isSingle;

    /// <summary>
    /// 在目标目录下创建动画片段
    /// </summary>
    [MenuItem("Assets/Tools/创建动画片段/从多张图片中创建动画")]
    static void CreateAnimationClipInTargetDirectoryBySinglePics()
    {
        EditorWindow.GetWindow(typeof(Tools_CreateAnimationClipUsingSprites), true, "创建动画片段");
        isSingle = true;
        Selection.selectionChanged += RefreshSpriteList;
        RefreshSpriteList();
    }

    /// <summary>
    /// 在目标目录下创建动画片段
    /// </summary>
    [MenuItem("Assets/Tools/创建动画片段/从单张图片分割的精灵中创建动画")]
    static void CreateAnimationClipInTargetDirectoryByMultiplyPic()
    {
        EditorWindow.GetWindow(typeof(Tools_CreateAnimationClipUsingSprites), true, "创建动画片段");
        isSingle = false;
        Selection.selectionChanged += RefreshSpriteListInSlicedPic;
        RefreshSpriteListInSlicedPic();
    }

    private string frameStr;
    private int frameCount;
    private bool isAnimationLoop;
    private string savingPathBuffer;
    private bool isAbleToCreateAnimation;

    Vector2 _scrollPos;

    void OnGUI()
    {
        isAbleToCreateAnimation = SelectedSpritesList.Count != 0;
        GUILayout.BeginVertical();
        GUI.skin.label.fontSize = 12;
        GUI.skin.label.fontStyle = FontStyle.Normal;
        GUILayout.Space(12);
        GUILayout.EndVertical();
        //绘制帧数输入框
        GUI.skin.label.normal.textColor = Color.black;
        GUILayout.BeginHorizontal();
        GUILayout.Label("FPS:");
        Rect rectForFrame = new Rect(40, 16, 100, 14);
        frameStr = EditorGUI.TextField(rectForFrame, frameStr);
        try
        {
            frameCount = int.Parse(frameStr);
        }
        catch (System.Exception)
        {
            isAbleToCreateAnimation = false;
            GUI.skin.label.normal.textColor = Color.red;
            GUILayout.Space(-60);
            GUILayout.Label("输入数字");
        }
        //绘制循环选项
        GUI.skin.label.normal.textColor = Color.black;
        GUILayout.Space(12);
        Rect rectForLoopToggle = new Rect(250, 14, 100, 16);
        isAnimationLoop = GUI.Toggle(rectForLoopToggle, isAnimationLoop, "Loop");
        GUILayout.EndHorizontal();
        //绘制保存按钮
        GUILayout.BeginVertical();
        GUILayout.Space(10);
        GUILayout.EndVertical();
        GUILayout.BeginHorizontal();
        GUI.enabled = isAbleToCreateAnimation;
        if (GUILayout.Button("保存动画"))
        {
            SaveAnimation();
        }
        GUILayout.EndHorizontal();
        //绘制精灵列表
        GUI.enabled = true;
        GUILayout.BeginVertical();
        GUILayout.Space(10);
        GUILayout.Label(string.Format("精灵列表:（选中{0}张精灵）", SelectedSpritesList.Count));
        GUILayout.EndVertical();
        _scrollPos = GUILayout.BeginScrollView(_scrollPos);
        for (int i = 0; i < SelectedSpritesList.Count; i++)
        {
            GUILayout.Label((i + 1).ToString() + ".  " + SelectedSpritesList[i].name);
        }
        GUILayout.EndScrollView();
    }

    private void SaveAnimation()
    {
        string savingPath = EditorUtility.SaveFilePanelInProject("保存动画片段", SelectedSpritesList[0].name + ".anim", "anim", "Select Path To Save AnimationClip", savingPathBuffer);
        if (savingPath.Length > 0)
        {
            savingPathBuffer = savingPath;
            AnimationClip clip = new AnimationClip();
            EditorCurveBinding curveBinding = new EditorCurveBinding();
            curveBinding.type = typeof(SpriteRenderer);
            curveBinding.path = "";
            curveBinding.propertyName = "m_Sprite";
            ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[SelectedSpritesList.Count];
            float frameTime = 1f / frameCount;
            for (int i = 0; i < SelectedSpritesList.Count; i++)
            {
                keyFrames[i] = new ObjectReferenceKeyframe();
                keyFrames[i].time = frameTime * i;
                keyFrames[i].value = SelectedSpritesList[i];
            }
            clip.frameRate = frameCount;
            AnimationClipSettings clipSetting = AnimationUtility.GetAnimationClipSettings(clip);
            clipSetting.loopTime = isAnimationLoop;
            AnimationUtility.SetAnimationClipSettings(clip, clipSetting);
            AnimationUtility.SetObjectReferenceCurve(clip, curveBinding, keyFrames);
            AssetDatabase.CreateAsset(clip, savingPath);
            AssetDatabase.SaveAssets();
            Debug.Log(savingPath + "创建成功");
        }
    }

    /// <summary>
    /// 刷新精灵列表
    /// </summary>
    private static void RefreshSpriteList()
    {
        SelectedSpritesList.Clear();
        Object[] selectedObjects = Selection.GetFiltered(typeof(Texture2D), SelectionMode.Assets);
        foreach (Object objectSelection in selectedObjects)
        {
            Object[] spriteObjects = AssetDatabase.LoadAllAssetsAtPath(AssetDatabase.GetAssetPath(objectSelection));
            for (int i = 0; i < spriteObjects.Length; i++)
            {
                if (spriteObjects[i] is Sprite)
                {
                    SelectedSpritesList.Add(spriteObjects[i] as Sprite);
                }
            }
        }
        SelectedSpritesList.Sort(delegate (Sprite lhs, Sprite rhs)
        {
            return lhs.name.CompareTo(rhs.name);
        });
    }

    /// <summary>
    /// 刷新分割的图片中的精灵列表
    /// </summary>
    private static void RefreshSpriteListInSlicedPic()
    {
        SelectedSpritesList.Clear();
        Object[] selectedObjects = Selection.GetFiltered(typeof(Sprite), SelectionMode.Deep);
        foreach (Object objectSelection in selectedObjects)
        {
            if (objectSelection is Sprite)
            {
                SelectedSpritesList.Add(objectSelection as Sprite);
            }
        }
        SelectedSpritesList.Sort(delegate (Sprite lhs, Sprite rhs)
        {
            return lhs.name.CompareTo(rhs.name);
        });
    }

    void OnDestroy()
    {
        if (isSingle)
        {
            Selection.selectionChanged -= RefreshSpriteList;
        }
        else
        {
            Selection.selectionChanged -= RefreshSpriteListInSlicedPic;
        }
    }
}
