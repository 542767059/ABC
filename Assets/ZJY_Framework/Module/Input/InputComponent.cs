using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

namespace ZJY.Framework
{
    /// <summary>
    /// 输入组件
    /// </summary>
    public class InputComponent : GameBaseComponent
    {
        /// <summary>
        /// 是否启用鼠标输入
        /// </summary>
        [SerializeField]
        private bool m_EnableMouseInput = true;

        /// <summary>
        /// 是否启用重力感应
        /// </summary>
        [SerializeField]
        private bool m_EnableGravityInduction = true;

        /// <summary>
        /// 是否接受touch输入
        /// </summary>
        [SerializeField]
        private bool m_EnableTouch = true;

        /// <summary>
        /// 重力方向
        /// </summary>
        private Vector3 m_GravityDir = Vector3.zero;

        [SerializeField]
        private Dictionary<int, TouchInfo> m_Fingers = new Dictionary<int, TouchInfo>();//按在UI上的手势

        /// <summary>
        /// 手指滑动方向
        /// </summary>
        private Vector2 m_FingerDir;

        private bool m_IsChangeSize = false;

        private Vector2 m_OldFinger1Pos;
        private Vector2 m_OldFinger2Pos;

        /// <summary>
        /// 手指鼠标的位置
        /// </summary>
        private Vector2 m_OldMousePos;

        /// <summary>
        /// 是否处于按下状态
        /// </summary>
        private bool m_EligibleForClick = false;

        private bool m_ClickFlag = false;

        /// <summary>
        /// 获取或设置是否接受重力感应
        /// </summary>
        public bool EnableMouseInput
        {
            get
            {
                return m_EnableMouseInput;
            }
            set
            {
                m_EnableMouseInput = value;
            }
        }


        /// <summary>
        /// 获取或设置是否接受touch输入
        /// </summary>
        public bool EnableTouch
        {
            get
            {
                return m_EnableTouch;
            }
            set
            {
                m_EnableTouch = value;
            }
        }

        /// <summary>
        /// 获取或设置是否接受重力感应
        /// </summary>
        public bool EnableGravityInduction
        {
            get
            {
                return m_EnableGravityInduction;
            }
            set
            {
                m_EnableGravityInduction = value;
            }
        }

        
        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);

#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            if (m_EnableMouseInput && Input.mousePresent)
            {
                UpdateMouseInput();
            }
#endif

#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID)
            if (m_EnableTouch)//如果能接受输入
            {
                UpdateTouch();//更新Touch输入
            }


            if (m_EnableGravityInduction)
            {
                UpdateGravity();//更新重力感应
            }
#endif
        }

        #region UpdateMouseInput 更新鼠标输入
        /// <summary>
        /// 更新鼠标输入
        /// </summary>
        private void UpdateMouseInput()
        {
            #region 滚轮
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputZoomGameEvent>().Fill(ZoomType.Out));
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputZoomGameEvent>().Fill(ZoomType.In));
            }
            #endregion

            #region 鼠标点击
            if (Input.GetMouseButtonDown(0))
            {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    m_EligibleForClick = false;
                    //点在了UI上
                    //Debug.Log("点在了UI上" + (Vector2)Input.mousePosition);
                    GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputPointDownGameEvent>().Fill(-1, Input.mousePosition, FingerType.UIFinger));
                }
                else
                {
                    //点在了场景
                    //Debug.Log("点在了场景" + (Vector2)Input.mousePosition);
                    GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputPointDownGameEvent>().Fill(-1, Input.mousePosition, FingerType.SceneFinger));
                    m_EligibleForClick = true;
                    m_ClickFlag = true;
                    m_OldMousePos = Input.mousePosition;
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (m_ClickFlag)
                {
                    GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputPointClickGameEvent>().Fill(-1, Input.mousePosition));
                }
                //Debug.Log("抬起");
                if (m_EligibleForClick)
                {
                    GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputPointUpGameEvent>().Fill(-1, Input.mousePosition, FingerType.SceneFinger));
                }
                else
                {
                    GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputPointUpGameEvent>().Fill(-1, Input.mousePosition, FingerType.UIFinger));
                }
                m_EligibleForClick = false;
                m_ClickFlag = false;
            }

            if (m_EligibleForClick)
            {
                m_FingerDir = (Vector2)Input.mousePosition - m_OldMousePos;

                if (m_FingerDir.sqrMagnitude < 0.01f)
                {
                    return;
                }
                m_ClickFlag = false;
                if (m_FingerDir.y < m_FingerDir.x && m_FingerDir.y > -m_FingerDir.x)
                {
                    //向右
                    GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputMoveGameEvent>().Fill(MoveDir.Right, m_FingerDir.x));
                }
                else if (m_FingerDir.y > m_FingerDir.x && m_FingerDir.y < -m_FingerDir.x)
                {
                    //向左
                    GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputMoveGameEvent>().Fill(MoveDir.Left, -m_FingerDir.x));
                }
                else if (m_FingerDir.y > m_FingerDir.x && m_FingerDir.y > -m_FingerDir.x)
                {
                    //向上
                    GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputMoveGameEvent>().Fill(MoveDir.Up, m_FingerDir.y));
                }
                else
                {
                    //向下
                    GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputMoveGameEvent>().Fill(MoveDir.Down, -m_FingerDir.y));
                }
                m_OldMousePos = Input.mousePosition;
            }

            #endregion
        }
        #endregion

        #region UpdateGravity 更新重力感应
        private void UpdateGravity()
        {
            m_GravityDir.x = Input.acceleration.x;
            m_GravityDir.z = Input.acceleration.y;
            m_GravityDir.y = Input.acceleration.z;


            if (m_GravityDir.x < 0)
            {
                //Debug.Log("向左 速度 = " + m_GravityDir.x);
                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputGravityMoveGameEvent>().Fill(MoveDir.Left, m_GravityDir.x));
            }
            else
            {
                //Debug.Log("向右 速度 = " + m_GravityDir.x);
                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputGravityMoveGameEvent>().Fill(MoveDir.Right, m_GravityDir.x));
            }

            if (m_GravityDir.z < 0)
            {
                //Debug.Log("向下 速度 = " + m_GravityDir.z);
                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputGravityMoveGameEvent>().Fill(MoveDir.Down, m_GravityDir.z));
            }
            else
            {
                //Debug.Log("向上 速度 = " + m_GravityDir.z);
                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputGravityMoveGameEvent>().Fill(MoveDir.Up, m_GravityDir.z));
            }

        }
        #endregion


        #region  UpdateTouch 更新Touch输入
        private void UpdateTouch()
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Touch input = Input.GetTouch(i);
                    TouchInfo touchInfo = GetTouchInfo(input.fingerId);
                    if (touchInfo.IsUseing && touchInfo.TouchType == TouchType.UITouch)
                    {//如果是按在UI上了 
                     //如果是UI上的 并且是取消了 
                        if (input.phase == TouchPhase.Ended || input.phase == TouchPhase.Canceled)
                        {
                            touchInfo.IsUseing = false;
                            touchInfo.TouchType = TouchType.UnKnow;
                            touchInfo.TouchUpPostion = input.position;
                            touchInfo.TouchPostion = input.position;
                            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputPointUpGameEvent>().Fill(input.fingerId, Input.mousePosition, FingerType.UIFinger));
                        }
                        continue;//跳过在UI上的这个手势的判断
                    }

                    //按下的时候
                    if (input.phase == TouchPhase.Began)
                    {
                        touchInfo.IsUseing = true;
                        touchInfo.TouchPostion = input.position;
                        touchInfo.TouchDownPostion = input.position;

                        //如果点在了UI上
                        if (IsPointerOverGameObject(input.position))
                        {
                            //Debug.Log("点击在了UI上,位置=" + input.position + "    手势Id= " + input.fingerId);
                            touchInfo.TouchType = TouchType.UITouch;
                            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputPointDownGameEvent>().Fill(input.fingerId, Input.mousePosition, FingerType.UIFinger));
                        }
                        else
                        {//没有点在UI上 
                            //Debug.Log("没有点在UI上,位置=" + input.position + "    手势Id= " + input.fingerId);
                            touchInfo.TouchType = TouchType.SceneTouch;
                            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputPointDownGameEvent>().Fill(input.fingerId, Input.mousePosition, FingerType.SceneFinger));
                        }
                    }
                    else if (input.phase == TouchPhase.Ended || input.phase == TouchPhase.Canceled)
                    {//结束了输入
                        touchInfo.IsUseing = false;
                        touchInfo.TouchPostion = input.position;
                        touchInfo.TouchUpPostion = input.position;
                        touchInfo.TouchType = TouchType.UnKnow;

                        if (touchInfo.TouchDownPostion == touchInfo.TouchUpPostion)
                        {
                            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputPointClickGameEvent>().Fill(input.fingerId, Input.mousePosition));
                        }
                        GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputPointUpGameEvent>().Fill(input.fingerId, Input.mousePosition,FingerType.SceneFinger));
                    }


                    if (input.phase == TouchPhase.Moved)
                    {//移动中

                        //有2个及以上在屏幕中的手指
                        if (GetSceneUseingTouchCount() >= 2)
                        {
                            m_IsChangeSize = true;
                        }
                        else
                        {//只有一个

                            m_FingerDir = input.position - touchInfo.TouchPostion;
                            if (m_FingerDir.y < m_FingerDir.x && m_FingerDir.y > -m_FingerDir.x)
                            {
                                //向右
                                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputMoveGameEvent>().Fill(MoveDir.Right, m_FingerDir.x));
                            }
                            else if (m_FingerDir.y > m_FingerDir.x && m_FingerDir.y < -m_FingerDir.x)
                            {
                                //向左
                                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputMoveGameEvent>().Fill(MoveDir.Left, -m_FingerDir.x));
                            }
                            else if (m_FingerDir.y > m_FingerDir.x && m_FingerDir.y > -m_FingerDir.x)
                            {
                                //向上
                                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputMoveGameEvent>().Fill(MoveDir.Up, m_FingerDir.y));
                            }
                            else
                            {
                                //向下
                                GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputMoveGameEvent>().Fill(MoveDir.Down, -m_FingerDir.y));
                            }
                            touchInfo.TouchPostion = input.position;
                        }

                    }
                }

                UpdateMoveTouch();
            }
        }

        /// <summary>
        /// 更新在移动中的touch
        /// </summary>
        private void UpdateMoveTouch()
        {
            if (m_IsChangeSize)
            {
                TouchInfo touchInfo1 = null;
                TouchInfo touchInfo2 = null;
                bool first = true;
                foreach (var finger in m_Fingers)
                {
                    if (first)
                    {
                        if (finger.Value.TouchType == TouchType.SceneTouch)
                        {
                            touchInfo1 = finger.Value;
                            first = false;
                        }
                    }
                    else
                    {
                        if (finger.Value.TouchType == TouchType.SceneTouch)
                        {
                            touchInfo2 = finger.Value;
                            break;
                        }
                    }
                }

                if (touchInfo1 != null && touchInfo2 != null)
                {
                    if (Vector2.Distance(m_OldFinger1Pos, m_OldFinger2Pos) < Vector2.Distance(touchInfo1.TouchPostion, touchInfo2.TouchPostion))
                    {
                        //放大
                        GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputZoomGameEvent>().Fill(ZoomType.In));
                    }
                    else
                    {
                        //缩小
                        GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<InputZoomGameEvent>().Fill(ZoomType.Out));
                    }
                    m_OldFinger1Pos = touchInfo1.TouchPostion;
                    m_OldFinger2Pos = touchInfo2.TouchPostion;
                }
                m_IsChangeSize = false;
            }
        }
        #endregion

        #region IsPointerOverGameObject 移动端判断是否点击在UI上
        /// <summary>
        /// 点击判断结果
        /// </summary>
        List<RaycastResult> results = new List<RaycastResult>();

        /// <summary>
        /// 移动端判断是否点击在UI上
        /// </summary>
        /// <param name="screenPosition">点击的屏幕坐标</param>
        /// <returns></returns>
        public bool IsPointerOverGameObject(Vector2 screenPosition)
        {
            //实例化点击事件
            PointerEventData eventDataCurrPosition = new PointerEventData(UnityEngine.EventSystems.EventSystem.current);
            //将点击位置的屏幕坐标赋值给点击事件
            eventDataCurrPosition.position = new Vector2(screenPosition.x, screenPosition.y);

            results.Clear();
            //向点击处发射射线
            EventSystem.current.RaycastAll(eventDataCurrPosition, results);

            return results.Count > 0;
        }

        #endregion

        
        private TouchInfo GetTouchInfo(int touchId)
        {
            TouchInfo touchInfo = null;
            if (!m_Fingers.TryGetValue(touchId, out touchInfo))
            {
                touchInfo = new TouchInfo();
                m_Fingers.Add(touchId, touchInfo);
            }
            return touchInfo;
        }

        private int GetSceneUseingTouchCount()
        {
            int count = 0;
            foreach (var finger in m_Fingers)
            {
                if (finger.Value.IsUseing && finger.Value.TouchType == TouchType.SceneTouch)
                {
                    count++;
                }
            }
            return count;
        }

        [Serializable]
        private class TouchInfo
        {
            /// <summary>
            /// 手势是否使用中
            /// </summary>
            public bool IsUseing;

            /// <summary>
            /// 手势类型
            /// </summary>
            public TouchType TouchType;

            /// <summary>
            /// 手势按下位置
            /// </summary>
            public Vector2 TouchDownPostion;

            /// <summary>
            /// 手势抬起位置
            /// </summary>
            public Vector2 TouchUpPostion;

            /// <summary>
            /// 手势位置
            /// </summary>
            public Vector2 TouchPostion;
        }

        private enum TouchType
        {
            /// <summary>
            /// 未知
            /// </summary>
            UnKnow,
            /// <summary>
            /// 场景中的手势
            /// </summary>
            SceneTouch,
            /// <summary>
            /// UI中的手势
            /// </summary>
            UITouch,
        }
    }
}