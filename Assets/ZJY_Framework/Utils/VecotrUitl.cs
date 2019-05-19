using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    public static class VecotrUitl
    {
        /// <summary>
        /// 取 <see cref="UnityEngine.Vector3" /> 的 (x, y, z) 转换为 <see cref="UnityEngine.Vector2" /> 的 (x, z)。
        /// </summary>
        /// <param name="vector3">要转换的 Vector3。</param>
        /// <returns>转换后的 Vector2。</returns>
        public static Vector2 ToVector2(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.z);
        }

        /// <summary>
        /// 取 <see cref="UnityEngine.Vector2" /> 的 (x, y) 转换为 <see cref="UnityEngine.Vector3" /> 的 (x, 0, y)。
        /// </summary>
        /// <param name="vector2">要转换的 Vector2。</param>
        /// <returns>转换后的 Vector3。</returns>
        public static Vector3 ToVector3(this Vector2 vector2)
        {
            return new Vector3(vector2.x, 0f, vector2.y);
        }

        /// <summary>
        /// 取 <see cref="UnityEngine.Vector2" /> 的 (x, y) 和给定参数 y 转换为 <see cref="UnityEngine.Vector3" /> 的 (x, 参数 y, y)。
        /// </summary>
        /// <param name="vector2">要转换的 Vector2。</param>
        /// <param name="y">Vector3 的 y 值。</param>
        /// <returns>转换后的 Vector3。</returns>
        public static Vector3 ToVector3(this Vector2 vector2, float y)
        {
            return new Vector3(vector2.x, y, vector2.y);
        }

        /// <summary>
        /// 获取向量夹角(-180,180) 在y平面上
        /// </summary>
        /// <param name="fromVector"></param>
        /// <param name="toVector"></param>
        /// <returns></returns>
        public static float GetAngle(Vector3 fromVector, Vector3 toVector)
        {
            fromVector.y = 0;
            toVector.y = 0;
            float angle = Vector3.Angle(fromVector, toVector); //求出两向量之间的夹角
            Vector3 normal = Vector3.Cross(fromVector, toVector);//叉乘求出法线向量
            angle *= Mathf.Sign(Vector3.Dot(normal, Vector3.up));  //求法线向量与物体上方向向量点乘，结果为1或-1，修正旋转方向
            return angle;
        }

        /// <summary>
        /// 绕x轴旋转一个角度
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="xValue">旋转的角度</param>
        /// <returns></returns>
        public static Vector3 GetRotateX(this Vector3 vector3, float xValue)
        {
            vector3 = Quaternion.Euler(xValue, 0, 0) * vector3;
            return vector3;
        }

        /// <summary>
        /// 绕y轴旋转一个角度
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="yValue">旋转的角度</param>
        /// <returns></returns>
        public static Vector3 GetRotateY(this Vector3 vector3, float yValue)
        {
            vector3 = Quaternion.Euler(0, yValue, 0) * vector3;
            return vector3;
        }

        /// <summary>
        /// 绕z轴旋转一个角度
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="zValue">旋转的角度</param>
        /// <returns></returns>
        public static Vector3 GetRotateZ(this Vector3 vector3, float zValue)
        {
            vector3 = Quaternion.Euler(0, 0, zValue) * vector3;
            return vector3;
        }

        /// <summary>
        /// 绕特定轴旋转指定角度
        /// </summary>
        /// <param name="vector3"></param>
        /// <param name="rotateVector">旋转的轴</param>
        /// <param name="rotateValue">旋转的角度</param>
        /// <returns></returns>
        public static Vector3 GetRotateVecotr(this Vector3 vector3, Vector3 rotateVector, float rotateValue)
        {
            vector3 = Quaternion.AngleAxis(rotateValue, rotateVector) * vector3;
            return vector3;
        }

        /// <summary>
        /// 获取2D的距离
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float GetDistance2D(Vector3 a, Vector3 b)
        {
            a.y = 0;
            b.y = 0;
            return Vector3.Distance(a, b);
        }
    }
}