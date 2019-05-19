using UnityEngine;

namespace ZJY.Framework {

    /// <summary>
    /// OBB区域
    /// </summary>
    public struct OBBArea
    {
        public Vector2 center;
        public Vector2 extents;
        public float angle;
    }

    /// <summary>
    /// AABB区域
    /// </summary>
    public struct AABBArea
    {
        public Vector2 center;
        public Vector2 extents;
    }

    /// <summary>
    /// 多边形区域。
    /// </summary>
    public struct PolygonArea
    {
        public Vector2[] vertexes;
    }

    /// <summary>
    /// 扇形区间。
    /// </summary>
    public struct SectorArea
    {
        public Vector2 o;//圆心
        public float r;//半径
        public Vector2 direction;//开始方向
        public float angle;//角度
    }

    /// <summary>
    /// 胶囊体
    /// </summary>
    public struct CapsuleArea
    {
        public Vector2 X0;
        public Vector2 U;
        public float d;
    }

    /// <summary>
    /// 圆形区间
    /// </summary>
    public struct CircleArea
    {
        public Vector2 o;
        public float r;
    }

    /// <summary>
    /// 碰撞盒相关
    /// </summary>
    public static class ColliderUtil
    {
        /// <summary>
        /// 判断线段是否有交点(线段ab  和  cd)
        /// </summary>
        /// <param name="a">ab线段的a点</param>
        /// <param name="b">ab线段的b点</param>
        /// <param name="c">cd线段的c点</param>
        /// <param name="d">cd线段的d点</param>
        /// <returns>是否相交</returns>
        public static bool IsIntersection(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
        {
            var crossA = Mathf.Sign(Vector3.Cross(d - c, a - c).y);
            var crossB = Mathf.Sign(Vector3.Cross(d - c, b - c).y);

            if (Mathf.Approximately(crossA, crossB)) return false;

            var crossC = Mathf.Sign(Vector3.Cross(b - a, c - a).y);
            var crossD = Mathf.Sign(Vector3.Cross(b - a, d - a).y);

            if (Mathf.Approximately(crossC, crossD)) return false;

            return true;
        }

        /// <summary>
        /// 获取线段ab 和 cd的交点
        /// </summary>
        /// <param name="a">ab线段的a点</param>
        /// <param name="b">ab线段的b点</param>
        /// <param name="c">cd线段的c点</param>
        /// <param name="d">cd线段的d点</param>
        /// <param name="contractPoint">获得的交点</param>
        /// <returns>0表示无交点  1表示相交  -1表示相交但不在线段上</returns>
        public static int GetIntersection(Vector3 a, Vector3 b, Vector3 c, Vector3 d, out Vector3 contractPoint)
        {
            contractPoint = new Vector3(0, 0);

            if (Mathf.Abs(b.z - a.z) + Mathf.Abs(b.x - a.x) + Mathf.Abs(d.z - c.z)
                    + Mathf.Abs(d.x - c.x) == 0)
            {
                if ((c.x - a.x) + (c.z - a.z) == 0)
                {
                    //Debug.Log("ABCD是同一个点！");
                }
                else
                {
                    //Debug.Log("AB是一个点，CD是一个点，且AC不同！");
                }
                return 0;
            }

            if (Mathf.Abs(b.z - a.z) + Mathf.Abs(b.x - a.x) == 0)
            {
                if ((a.x - d.x) * (c.z - d.z) - (a.z - d.z) * (c.x - d.x) == 0)
                {
                    //Debug.Log("A、B是一个点，且在CD线段上！");
                }
                else
                {
                    //Debug.Log("A、B是一个点，且不在CD线段上！");
                }
                return 0;
            }
            if (Mathf.Abs(d.z - c.z) + Mathf.Abs(d.x - c.x) == 0)
            {
                if ((d.x - b.x) * (a.z - b.z) - (d.z - b.z) * (a.x - b.x) == 0)
                {
                    //Debug.Log("C、D是一个点，且在AB线段上！");
                }
                else
                {
                    //Debug.Log("C、D是一个点，且不在AB线段上！");
                }
                return 0;
            }

            if ((b.z - a.z) * (c.x - d.x) - (b.x - a.x) * (c.z - d.z) == 0)
            {
                //Debug.Log("线段平行，无交点！");
                return 0;
            }

            contractPoint.x = ((b.x - a.x) * (c.x - d.x) * (c.z - a.z) -
                    c.x * (b.x - a.x) * (c.z - d.z) + a.x * (b.z - a.z) * (c.x - d.x)) /
                    ((b.z - a.z) * (c.x - d.x) - (b.x - a.x) * (c.z - d.z));
            contractPoint.z = ((b.z - a.z) * (c.z - d.z) * (c.x - a.x) - c.z
                    * (b.z - a.z) * (c.x - d.x) + a.z * (b.x - a.x) * (c.z - d.z))
                    / ((b.x - a.x) * (c.z - d.z) - (b.z - a.z) * (c.x - d.x));

            if ((contractPoint.x - a.x) * (contractPoint.x - b.x) <= 0
                    && (contractPoint.x - c.x) * (contractPoint.x - d.x) <= 0
                    && (contractPoint.z - a.z) * (contractPoint.z - b.z) <= 0
                    && (contractPoint.z - c.z) * (contractPoint.z - d.z) <= 0)
            {

                //Debug.Log("线段相交于点(" + contractPoint.x + "," + contractPoint.z + ")！");
                return 1; // '相交  
            }
            else
            {
                //Debug.Log("线段相交于虚交点(" + contractPoint.x + "," + contractPoint.z + ")！");
                return -1; // '相交但不在线段上  
            }
        }
        
        /// <summary>
        /// 线段与点的最短距离。(平方)
        /// </summary>
        /// <param name="x0">线段起点</param>
        /// <param name="u">线段向量</param>
        /// <param name="x">求解点</param>
        /// <returns>返回的是线段的平方</returns>
        public static float SegmentPointSqrDistance(Vector2 x0, Vector2 u, Vector2 x)
        {
            float t = Vector2.Dot(x - x0, u) / u.sqrMagnitude;
            return (x - (x0 + Mathf.Clamp01(t) * u)).sqrMagnitude;
        }

        /// <summary>
        /// 判断OBB与圆形相交
        /// </summary>
        /// <param name="oBBArea"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool OBB(OBBArea oBBArea, CircleArea target)
        {
            Vector2 p = oBBArea.center - target.o;
            p = Quaternion.AngleAxis(-oBBArea.angle, Vector3.forward) * p;
            Vector2 v = Vector2.Max(p, -p);
            Vector2 u = Vector2.Max(v - oBBArea.extents, Vector2.zero);
            return u.sqrMagnitude < target.r * target.r;
        }

        /// <summary>
        /// 判断AABB与圆形相交
        /// </summary>
        /// <param name="aABBArea"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool AABB(AABBArea aABBArea, CircleArea target)
        {
            Vector2 v = Vector2.Max(aABBArea.center - target.o, -(aABBArea.center - target.o));
            Vector2 u = Vector2.Max(v - aABBArea.extents, Vector2.zero);
            return u.sqrMagnitude < target.r * target.r;
        }

        /// <summary>
        /// 判断多边形与圆形相交
        /// </summary>
        /// <param name="polygonArea"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool PolygonS(PolygonArea polygonArea, CircleArea target)
        {
            if (polygonArea.vertexes.Length < 3)
            {
                Debug.Log("多边形边数小于3.");
                return false;
            }
            #region 定义临时变量
            //圆心
            Vector2 circleCenter = target.o;
            //半径的平方
            float sqrR = target.r * target.r;
            //多边形顶点
            Vector2[] polygonVertexes = polygonArea.vertexes;
            //圆心指向顶点的向量数组
            Vector2[] directionBetweenCenterAndVertexes = new Vector2[polygonArea.vertexes.Length];
            //多边形的边
            Vector2[] polygonEdges = new Vector2[polygonArea.vertexes.Length];
            for (int i = 0; i < polygonArea.vertexes.Length; i++)
            {
                directionBetweenCenterAndVertexes[i] = polygonVertexes[i] - circleCenter;
                polygonEdges[i] = polygonVertexes[i] - polygonVertexes[(i + 1) % polygonArea.vertexes.Length];
            }
            #endregion

            #region 以下为圆心处于多边形内的判断。
            //总夹角
            float totalAngle = Vector2.SignedAngle(directionBetweenCenterAndVertexes[polygonVertexes.Length - 1], directionBetweenCenterAndVertexes[0]);
            for (int i = 0; i < polygonVertexes.Length - 1; i++)
                totalAngle += Vector2.SignedAngle(directionBetweenCenterAndVertexes[i], directionBetweenCenterAndVertexes[i + 1]);
            if (Mathf.Abs(Mathf.Abs(totalAngle) - 360f) < 0.1f)
                return true;
            #endregion
            #region 以下为多边形的边与圆形相交的判断。
            for (int i = 0; i < polygonEdges.Length; i++)
                if (SegmentPointSqrDistance(polygonVertexes[i], polygonEdges[i], circleCenter) < sqrR)
                    return true;
            #endregion
            return false;
        }


        /// <summary>
        /// 判断圆形与扇形相交。
        /// </summary>
        /// <param name="sectorArea"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool Sector(SectorArea sectorArea, CircleArea target)
        {
            Vector2 tempDistance = target.o - sectorArea.o;
            float halfAngle = Mathf.Deg2Rad * sectorArea.angle / 2;
            if (tempDistance.sqrMagnitude < (sectorArea.r + target.r) * (sectorArea.r + target.r))
            {
                if (Vector3.Angle(tempDistance, sectorArea.direction) < sectorArea.angle / 2)
                {
                    return true;
                }
                else
                {
                    Vector2 targetInSectorAxis = new Vector2(Vector2.Dot(tempDistance,
                        sectorArea.direction), Mathf.Abs(Vector2.Dot(tempDistance, new Vector2(-sectorArea.direction.y, sectorArea.direction.x))));
                    Vector2 directionInSectorAxis = sectorArea.r * new Vector2(Mathf.Cos(halfAngle), Mathf.Sin(halfAngle));
                    return SegmentPointSqrDistance(Vector2.zero, directionInSectorAxis, targetInSectorAxis) <= target.r * target.r;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断胶囊体与圆形相交
        /// </summary>
        /// <param name="capsuleArea"></param>
        /// <param name="circleArea"></param>
        /// <returns></returns>
        public static bool Capsule(CapsuleArea capsuleArea, CircleArea circleArea)
        {
            float sqrD = SegmentPointSqrDistance(capsuleArea.X0, capsuleArea.U, circleArea.o);
            return sqrD < (circleArea.r + capsuleArea.d) * (circleArea.r + capsuleArea.d);
        }

        /// <summary>
        /// 判断圆形与圆形相交
        /// </summary>
        /// <param name="circleArea">判断圆</param>
        /// <param name="target">目标圆</param>
        /// <returns></returns>
        public static bool Circle(CircleArea circleArea, CircleArea target)
        {
            return (circleArea.o - target.o).sqrMagnitude < (circleArea.r + target.r) * (circleArea.r + target.r);
        }
    }
    
}