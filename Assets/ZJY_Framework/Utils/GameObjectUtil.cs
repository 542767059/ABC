using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using ZJY.Framework;

public static class GameObjectUtil
{
    /// <summary>
    /// 获取或增加组件
    /// </summary>
    /// <typeparam name="T">要获取或增加的组件</typeparam>
    /// <param name="gameObject">目标对象</param>
    /// <returns>获取或增加的组件</returns>
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        T component = gameObject.GetComponent<T>();
        if (component == null)
        {
            component = gameObject.AddComponent<T>();
        }

        return component;
    }

    /// <summary>
    /// 获取或创建组建
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T GetOrCreatComponent<T>(this GameObject obj) where T:MonoBehaviour
    {
        T t = obj.GetComponent<T>();
        if (t == null)
        {
            t = obj.AddComponent<T>();
        }
        return t;
    }

    /// <summary>
    /// 递归设置游戏对象的层次
    /// </summary>
    /// <param name="gameObject"><see cref="UnityEngine.GameObject" /> 对象</param>
    /// <param name="layer">目标层次的编号</param>
    public static void SetLayerRecursively(this GameObject gameObject, int layer)
    {
        Transform[] transforms = gameObject.GetComponentsInChildren<Transform>(true);
        for (int i = 0; i < transforms.Length; i++)
        {
            transforms[i].gameObject.layer = layer;
        }
    }

    /// <summary>
    /// 设置物体的父物体
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="parent"></param>
    public static void SetParent(this GameObject obj, Transform parent)
    {
        obj.transform.SetParent(parent); 
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localScale = Vector3.one;
        obj.transform.localEulerAngles = Vector3.zero;
    }
    
    

    //UI扩展=================================

    /// <summary>
    /// 设置Text值(带动画)
    /// </summary>
    /// <param name="txtObj"></param>
    /// <param name="text"></param>
    public static void SetText(this Text txtObj, string text, bool isAnimation = false, float duration = 0.2f, ScrambleMode scrambleMode = ScrambleMode.None)
    {
        if (txtObj != null)
        {
            if (isAnimation)
            {
                txtObj.text = "";
                txtObj.DOText(text, duration, scrambleMode: scrambleMode);
            }
            else
            {
                txtObj.text = text;
            }
        }
    }

    /// <summary>
    /// 设置滑动条的值
    /// </summary>
    /// <param name="sliderObj"></param>
    /// <param name="value"></param>
    public static void SetSliderValue(this Slider sliderObj, float value)
    {
        if (sliderObj != null)
        {
            sliderObj.value = value;
        }
    }

    /// <summary>
    /// 设置图片名称
    /// </summary>
    /// <param name="imgObj"></param>
    /// <param name="imgName"></param>
    public static void SetImage(this Image imgObj, Sprite sprite)
    {
        if (imgObj != null)
        {
            imgObj.overrideSprite = sprite;
        }
    }

    /// <summary>
    /// 设置图片名称
    /// </summary>
    /// <param name="imgObj"></param>
    /// <param name="assetName">图片资源名称</param>
    public static void SetImage(this Image imgObj, string assetName,bool setNativeSize = false)
    {
        if (imgObj != null)
        {
            GameEntry.Texture2D.SetImage(imgObj, assetName,setNativeSize);
        }
    }

    /// <summary>
    /// 设置状态机
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="assetName">控制器资源名称资源名称</param>
    public static void SetAnimator(this Animator animator, string assetName)
    {
        if (animator != null)
        {
            GameEntry.Controller.SetController(animator, assetName);
        }
    }

    #region Transform
    /// <summary>
    /// 重置自身的所有位置(相当于父物体)
    /// </summary>
    /// <param name="transform"></param>
    public static void RestTransform(this Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    /// <summary>
    /// 设置绝对位置的 x 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="newValue">x 坐标值。</param>
    public static void SetPositionX(this Transform transform, float newValue)
    {
        Vector3 v = transform.position;
        v.x = newValue;
        transform.position = v;
    }

    /// <summary>
    /// 设置绝对位置的 y 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="newValue">y 坐标值。</param>
    public static void SetPositionY(this Transform transform, float newValue)
    {
        Vector3 v = transform.position;
        v.y = newValue;
        transform.position = v;
    }

    /// <summary>
    /// 设置绝对位置的 z 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="newValue">z 坐标值。</param>
    public static void SetPositionZ(this Transform transform, float newValue)
    {
        Vector3 v = transform.position;
        v.z = newValue;
        transform.position = v;
    }

    /// <summary>
    /// 增加绝对位置的 x 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="deltaValue">x 坐标值增量。</param>
    public static void AddPositionX(this Transform transform, float deltaValue)
    {
        Vector3 v = transform.position;
        v.x += deltaValue;
        transform.position = v;
    }

    /// <summary>
    /// 增加绝对位置的 y 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="deltaValue">y 坐标值增量。</param>
    public static void AddPositionY(this Transform transform, float deltaValue)
    {
        Vector3 v = transform.position;
        v.y += deltaValue;
        transform.position = v;
    }

    /// <summary>
    /// 增加绝对位置的 z 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="deltaValue">z 坐标值增量。</param>
    public static void AddPositionZ(this Transform transform, float deltaValue)
    {
        Vector3 v = transform.position;
        v.z += deltaValue;
        transform.position = v;
    }

    /// <summary>
    /// 设置相对位置的 x 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="newValue">x 坐标值。</param>
    public static void SetLocalPositionX(this Transform transform, float newValue)
    {
        Vector3 v = transform.localPosition;
        v.x = newValue;
        transform.localPosition = v;
    }

    /// <summary>
    /// 设置相对位置的 y 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="newValue">y 坐标值。</param>
    public static void SetLocalPositionY(this Transform transform, float newValue)
    {
        Vector3 v = transform.localPosition;
        v.y = newValue;
        transform.localPosition = v;
    }

    /// <summary>
    /// 设置相对位置的 z 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="newValue">z 坐标值。</param>
    public static void SetLocalPositionZ(this Transform transform, float newValue)
    {
        Vector3 v = transform.localPosition;
        v.z = newValue;
        transform.localPosition = v;
    }

    /// <summary>
    /// 增加相对位置的 x 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="deltaValue">x 坐标值。</param>
    public static void AddLocalPositionX(this Transform transform, float deltaValue)
    {
        Vector3 v = transform.localPosition;
        v.x += deltaValue;
        transform.localPosition = v;
    }

    /// <summary>
    /// 增加相对位置的 y 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="deltaValue">y 坐标值。</param>
    public static void AddLocalPositionY(this Transform transform, float deltaValue)
    {
        Vector3 v = transform.localPosition;
        v.y += deltaValue;
        transform.localPosition = v;
    }

    /// <summary>
    /// 增加相对位置的 z 坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="deltaValue">z 坐标值。</param>
    public static void AddLocalPositionZ(this Transform transform, float deltaValue)
    {
        Vector3 v = transform.localPosition;
        v.z += deltaValue;
        transform.localPosition = v;
    }

    /// <summary>
    /// 设置相对尺寸的 x 分量。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="newValue">x 分量值。</param>
    public static void SetLocalScaleX(this Transform transform, float newValue)
    {
        Vector3 v = transform.localScale;
        v.x = newValue;
        transform.localScale = v;
    }

    /// <summary>
    /// 设置相对尺寸的 y 分量。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="newValue">y 分量值。</param>
    public static void SetLocalScaleY(this Transform transform, float newValue)
    {
        Vector3 v = transform.localScale;
        v.y = newValue;
        transform.localScale = v;
    }

    /// <summary>
    /// 设置相对尺寸的 z 分量。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="newValue">z 分量值。</param>
    public static void SetLocalScaleZ(this Transform transform, float newValue)
    {
        Vector3 v = transform.localScale;
        v.z = newValue;
        transform.localScale = v;
    }

    /// <summary>
    /// 增加相对尺寸的 x 分量。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="deltaValue">x 分量增量。</param>
    public static void AddLocalScaleX(this Transform transform, float deltaValue)
    {
        Vector3 v = transform.localScale;
        v.x += deltaValue;
        transform.localScale = v;
    }

    /// <summary>
    /// 增加相对尺寸的 y 分量。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="deltaValue">y 分量增量。</param>
    public static void AddLocalScaleY(this Transform transform, float deltaValue)
    {
        Vector3 v = transform.localScale;
        v.y += deltaValue;
        transform.localScale = v;
    }

    /// <summary>
    /// 增加相对尺寸的 z 分量。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="deltaValue">z 分量增量。</param>
    public static void AddLocalScaleZ(this Transform transform, float deltaValue)
    {
        Vector3 v = transform.localScale;
        v.z += deltaValue;
        transform.localScale = v;
    }

    /// <summary>
    /// 二维空间下使 <see cref="UnityEngine.Transform" /> 指向指向目标点的算法，使用世界坐标。
    /// </summary>
    /// <param name="transform"><see cref="UnityEngine.Transform" /> 对象。</param>
    /// <param name="lookAtPoint2D">要朝向的二维坐标点。</param>
    /// <remarks>假定其 forward 向量为 <see cref="UnityEngine.Vector3.up" />。</remarks>
    public static void LookAt2D(this Transform transform, Vector2 lookAtPoint2D)
    {
        Vector3 vector = lookAtPoint2D.ToVector3() - transform.position;
        vector.y = 0f;

        if (vector.magnitude > 0f)
        {
            transform.rotation = Quaternion.LookRotation(vector.normalized, Vector3.up);
        }
    }

    #endregion Transform
}