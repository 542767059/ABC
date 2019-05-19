using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ZJY.Framework
{
    /// <summary>
    /// Animator组件
    /// </summary>
    public class AnimatorComponent : UnitComponent
    {
        private Animator m_Animator;
        private float stopSpeed;
        private bool isStop;

        public override void Init()
        {
            m_Animator = Owner.gameObject.GetOrAddComponent<Animator>();
            if (Owner is PlayerBase)
            {
                int jobId = ((PlayerBase)Owner).PlayerBaseData.RoleInfoBase.JobId;

                JobDBModel jobDBModel = GameEntry.DataTable.GetDataTable<JobDBModel>();
                JobEntity jobEntity = jobDBModel.Get(jobId);
                if (jobEntity == null)
                {
                    Log.Warning("Can not load job controller id '{0}' from data table.", jobId.ToString());
                    return;
                }
                GameEntry.Controller.SetController(m_Animator, AssetUtility.GetRoleControllerAsset(jobEntity.RoleController));
            }
            else
            {
                Debug.Log("其他角色控制器 例如NPC 还没做!");
            }
            m_Animator.speed = 1;
            isStop = false;
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {

        }

        public override void Shutdown()
        {
            m_Animator = null;
        }

        /// <summary>
        /// 是否跟随动作
        /// </summary>
        public bool applyRootMotion
        {
            get
            {
                return m_Animator.applyRootMotion;
            }
            set
            {
                m_Animator.applyRootMotion = value;
            }
        }

        /// <summary>
        /// 暂停状态机
        /// </summary>
        public void PauseAnimator()
        {
            if (this.isStop)
            {
                return;
            }
            this.isStop = true;

            if (this.m_Animator == null)
            {
                return;
            }
            this.stopSpeed = this.m_Animator.speed;
            this.m_Animator.speed = 0;
        }

        /// <summary>
        /// 运行状态机
        /// </summary>
        public void RunAnimator()
        {
            if (!this.isStop)
            {
                return;
            }

            this.isStop = false;

            if (this.m_Animator == null)
            {
                return;
            }
            this.m_Animator.speed = this.stopSpeed;
        }

        public void SetBoolValue(string name, bool state)
        {
            this.m_Animator.SetBool(name, state);
        }

        public void SetFloatValue(string name, float state)
        {
            this.m_Animator.SetFloat(name, state);
        }

        public void SetIntValue(string name, int value)
        {
            this.m_Animator.SetInteger(name, value);
        }

        public void SetTrigger(string name)
        {
            this.m_Animator.SetTrigger(name);
        }

        public void SetAnimatorSpeed(float speed)
        {
            this.stopSpeed = this.m_Animator.speed;
            this.m_Animator.speed = speed;
        }

        public void ResetAnimatorSpeed()
        {
            this.m_Animator.speed = this.stopSpeed;
        }
    }
}