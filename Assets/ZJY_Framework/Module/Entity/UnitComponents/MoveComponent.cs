using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ZJY.Framework
{
    /// <summary>
    /// 移动组件
    /// </summary>
    public class MoveComponent : UnitComponent
    {


        public enum MoveType
        {
            None = 0,
            /// <summary>
            /// 朝着方向移动
            /// </summary>
            MoveDirection = 1,
            /// <summary>
            /// 移动到某一点
            /// </summary>
            MoveToPoint = 2,
            /// <summary>
            /// 走向目标
            /// </summary>
            MoveToTarget = 3,
            /// <summary>
            /// 被击退
            /// </summary>
            PushedBack = 4,
            /// <summary>
            /// 被击飞
            /// </summary>
            Launched = 5,
            /// <summary>
            /// 漂浮
            /// </summary>
            Floated = 6,
            /// <summary>
            /// 沉没
            /// </summary>
            Sunk = 7,
            /// <summary>
            /// 吸引
            /// </summary>
            Attract = 8,
        }


        private AnimatorComponent m_AnimatorComponent = null;

        private bool ismoving = false;
        private CharacterController m_CharacterController;

        #region 用户输入相关
        /// <summary>
        /// 输入的方向
        /// </summary>
        private Vector3 m_InputMoveDirection;

        /// <summary>
        /// 输入的朝向
        /// </summary>
        private Quaternion InputRotation;

        /// <summary>
        /// 相当于速度的百分比(遥感输入)
        /// </summary>
        private float m_InputSpeed;

        /// <summary>
        /// 是否输入中
        /// </summary>
        private bool isinput;

        /// <summary>
        /// 能否操作移动
        /// </summary>
        public bool canContrl
        {
            get;
            set;
        }
        #endregion

        #region 强制拉回相关
        /// <summary>
        /// 强制拉回过去的时间
        /// </summary>
        private float forceTime;
        /// <summary>
        /// 强制拉回需要的时间
        /// </summary>
        private float forceNeedTime;
        /// <summary>
        /// 是否强制拉回
        /// </summary>
        private bool isforceBack;

        /// <summary>
        /// 开始的点
        /// </summary>
        private Vector3 startPosition;

        /// <summary>
        /// 目标点
        /// </summary>
        private Vector3 moveTarget;

        #endregion

        /// <summary>
        /// 移动类型
        /// </summary>
        private MoveType m_MoveType;


        /// <summary>
        /// 相当于速度的百分比(用于变速移动)
        /// </summary>
        private float m_PerSpeed;

        /// <summary>
        /// 移动速度
        /// </summary>
        public float Speed
        {
            get;
            set;
        }

        public override void Init()
        {
            //====================测试
            Speed = 10;
            //========

            m_AnimatorComponent = Owner.GetOrAddUnitComponent<AnimatorComponent>();
            m_CharacterController = Owner.gameObject.GetOrAddComponent<CharacterController>();
            m_CharacterController.center = new Vector3(0, 1, 0);
            m_CharacterController.height = 2f;
            m_CharacterController.radius = 0.5f;
            m_CharacterController.stepOffset = 0.5f;

            if (Owner is MainPlayer)
            {
                canContrl = true;
            }
            isinput = false;
            ismoving = false;
            m_MoveType = MoveType.None;
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            if (isforceBack)
            {
                MountsComponent mountsComponent = Owner.GetUnitComponent<MountsComponent>();
                

                forceTime += unscaledDeltaTime;
                if (forceTime > forceNeedTime)
                {
                    isforceBack = false;
                    canContrl = true;
                    if (mountsComponent != null && mountsComponent.IsRide)
                    {
                        mountsComponent.Mounts.transform.position = this.moveTarget;
                        return;
                    }
                    Owner.transform.position = this.moveTarget;
                    return;
                }
                float amount = forceTime * 1f / forceNeedTime;

                if (mountsComponent != null && mountsComponent.IsRide)
                {
                    mountsComponent.Mounts.transform.position = Vector3.Lerp(this.startPosition, this.moveTarget, amount);
                    return;
                }
                Owner.transform.position = Vector3.Lerp(this.startPosition, this.moveTarget, amount);
                
                return;
            }

            UpdateGravity(deltaTime, unscaledDeltaTime);

            if (isinput && canContrl)
            {
                UpdateInput(deltaTime, unscaledDeltaTime);
                return;
            }

            m_AnimatorComponent.SetFloatValue(Constant.AnimatorParam.Speed, 0);
        }

        /// <summary>
        /// 强制拉回(用于同步)
        /// </summary>
        /// <param name="target">强制拉回的目标点</param>
        /// <param name="needtime">强制拉回需要的时间</param>
        public void ForceBack(Vector3 target, float needtime)
        {
            canContrl = false;
            isforceBack = true;
            forceTime = 0;
            forceNeedTime = needtime;
        }

        public override void Shutdown()
        {
            UnityEngine.Object.Destroy(m_CharacterController);
            m_AnimatorComponent = null;
            ismoving = false;
            canContrl = false;
        }

        /// <summary>
        /// 停止移动
        /// </summary>
        public void StopMove()
        {
            ismoving = false;
        }

        /// <summary>
        /// 设置输入移动的 移动方向
        /// </summary>
        /// <param name="inputDirection">移动方向</param>
        /// <param name="inputSpeed">移动的百分比(0,1)</param>
        public void SetInputMoveDirection(Vector3 inputDirection, float inputSpeed)
        {
            InputRotation = Quaternion.LookRotation(inputDirection);
            m_InputMoveDirection = inputDirection;
            m_InputSpeed = inputSpeed;
            isinput = true;
        }

        /// <summary>
        /// 改变输入移动 的移动方向
        /// </summary>
        /// <param name="direction">移动方向</param>
        public void ChangeSetInputMoveDirection(Vector3 inputDirection)
        {
            InputRotation = Quaternion.LookRotation(inputDirection);
            m_InputMoveDirection = inputDirection;
        }

        /// <summary>
        /// 结束输入移动
        /// </summary>
        /// <param name="direction">移动方向</param>
        public void EndInputMoveDirection()
        {
            isinput = false;
            MountsComponent mountsComponent = Owner.GetUnitComponent<MountsComponent>();
            if (mountsComponent != null && mountsComponent.IsRide)
            {
                mountsComponent.SetRun(false);
            }
        }

        /// <summary>
        /// 更新输入
        /// </summary>
        private void UpdateInput(float deltaTime, float unscaledDeltaTime)
        {
            MountsComponent mountsComponent = Owner.GetUnitComponent<MountsComponent>();
            if (mountsComponent != null && mountsComponent.IsRide)
            {
                mountsComponent.Mounts.transform.rotation = Quaternion.Slerp(Owner.transform.rotation, InputRotation, deltaTime * 15f);
                mountsComponent.Mounts.CharacterController.Move(m_InputMoveDirection * Speed * m_InputSpeed * deltaTime);
                mountsComponent.SetRun(true);
                return;
            }

            Owner.transform.rotation = Quaternion.Slerp(Owner.transform.rotation, InputRotation, deltaTime * 15f);
            m_CharacterController.Move(m_InputMoveDirection * Speed * m_InputSpeed * deltaTime);
            m_AnimatorComponent.SetFloatValue(Constant.AnimatorParam.Speed, Speed * m_InputSpeed);
        }

        private void UpdateGravity(float deltaTime, float unscaledDeltaTime)
        {
            MountsComponent mountsComponent = Owner.GetUnitComponent<MountsComponent>();
            if (mountsComponent != null && mountsComponent.IsRide)
            {
                mountsComponent.Mounts.CharacterController.Move(Vector3.down * 9.8f * deltaTime);
                return;
            }
            if (m_CharacterController.isGrounded)
            {
                return;
            }
            m_CharacterController.Move(Vector3.down * 9.8f * deltaTime);
        }
    }
}