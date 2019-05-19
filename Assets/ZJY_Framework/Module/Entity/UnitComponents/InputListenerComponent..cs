using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 输入监听组件
    /// </summary>
    public class InputListenerComponent : UnitComponent
    {
        private MoveComponent m_MoveComponent;
        private Vector3 deltaVec;

        private Dictionary<int, int> m_SkillIndex;

        public override void Init()
        {
            base.Init();
            m_MoveComponent = Owner?.GetUnitComponent<MoveComponent>();

            GameEntry.Event.CommonEvent.AddEventListener(InputZoomGameEvent.EventId, OnZoom);
            GameEntry.Event.CommonEvent.AddEventListener(InputMoveGameEvent.EventId, OnMove);
            GameEntry.Event.CommonEvent.AddEventListener(InputPointClickGameEvent.EventId, OnPointClick);
            GameEntry.Event.CommonEvent.AddEventListener(RockerMoveGameEvent.EventId, OnRockerMove);
            GameEntry.Event.CommonEvent.AddEventListener(RockerEndGameEvent.EventId, OnRockerEnd);
            GameEntry.Event.CommonEvent.AddEventListener(RockerInClickGameEvent.EventId, OnRockerInClick);
            GameEntry.Event.CommonEvent.AddEventListener(NormalAttackClickGameEvent.EventId, OnNormalAttakClick);
            GameEntry.Event.CommonEvent.AddEventListener(SkillButtonClickGameEvent.EventId, OnSkillButtonClick);
            GameEntry.Event.CommonEvent.AddEventListener(ShowSkillAreaGameEvent.EventId, OnShowSkillArea);

            m_SkillIndex =  new Dictionary<int, int>();
            m_SkillIndex.Add(1, 10001);
            m_SkillIndex.Add(2, 10002);
            m_SkillIndex.Add(3, 10003);
            m_SkillIndex.Add(4, 10004);
            m_SkillIndex.Add(5, 10005);
            m_SkillIndex.Add(6, 10006);
            m_SkillIndex.Add(7, 10007);
        }



        public override void Shutdown()
        {
            base.Shutdown();
            GameEntry.Event.CommonEvent.RemoveEventListener(InputZoomGameEvent.EventId, OnZoom);
            GameEntry.Event.CommonEvent.RemoveEventListener(InputMoveGameEvent.EventId, OnMove);
            GameEntry.Event.CommonEvent.RemoveEventListener(InputPointClickGameEvent.EventId, OnPointClick);
            GameEntry.Event.CommonEvent.RemoveEventListener(RockerMoveGameEvent.EventId, OnRockerMove);
            GameEntry.Event.CommonEvent.RemoveEventListener(RockerEndGameEvent.EventId, OnRockerEnd);
            GameEntry.Event.CommonEvent.RemoveEventListener(RockerInClickGameEvent.EventId, OnRockerInClick);
            GameEntry.Event.CommonEvent.RemoveEventListener(NormalAttackClickGameEvent.EventId, OnNormalAttakClick);
            GameEntry.Event.CommonEvent.RemoveEventListener(SkillButtonClickGameEvent.EventId, OnSkillButtonClick);
            GameEntry.Event.CommonEvent.RemoveEventListener(ShowSkillAreaGameEvent.EventId, OnShowSkillArea);
        }





        private int index = 1;
        private int powerindex = 5;
        /// <summary>
        /// 普通攻击点击
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void OnNormalAttakClick(GameEventBase gameEventBase)
        {
            Debug.Log("普攻");
            CharacterStateComponent characterStateComponent = Owner.GetUnitComponent<CharacterStateComponent>();
            ActiveSkillComponent activeSkillComponent = Owner.GetUnitComponent<ActiveSkillComponent>();
            if (characterStateComponent.Get(SpecialStateType.NotInControl))
            {
                return;
            }

            int skillId = 0;

            if (characterStateComponent.Get(SpecialStateType.PowerAttack))
            {
                skillId = m_SkillIndex[powerindex];
                powerindex++;
                if (powerindex > 7)
                {
                    powerindex = 5;
                }
            }
            else
            {
                skillId = m_SkillIndex[index];
                index++;
                if (index > 4)
                {
                    index = 1;
                }
            }
            
            

            activeSkillComponent.Verify(skillId, (PlayerBase)Owner, null, Trigskill, null, Complate);
        }

        /// <summary>
        /// 技能攻击点击
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void OnSkillButtonClick(GameEventBase gameEventBase)
        {
            SkillButtonClickGameEvent skillButtonClickGameEvent = (SkillButtonClickGameEvent)gameEventBase;

            ActiveSkillComponent activeSkillComponent = Owner.GetUnitComponent<ActiveSkillComponent>();
            CharacterStateComponent characterStateComponent = Owner.GetUnitComponent<CharacterStateComponent>();
            if (activeSkillComponent == null || characterStateComponent == null)
            {
                return;
            }

            //无法控制状态
            if (characterStateComponent.Get(SpecialStateType.NotInControl))
            {
                return;
            }

            if (skillButtonClickGameEvent.IsNormalClick)
            {
                //skillButtonClickGameEvent.SkillId;
                Debug.Log("原地放技能");
                activeSkillComponent.Verify(skillButtonClickGameEvent.SkillId, (PlayerBase)Owner, null, Trigskill, null, Complate);

            }
            else
            {
                Vector3 targetDir = new Vector3(skillButtonClickGameEvent.Postion.x, 0, skillButtonClickGameEvent.Postion.y);
                targetDir = targetDir.GetRotateY(GameEntry.Camera.MainCamera.transform.eulerAngles.y);
                Owner.SelfTransform.rotation = Quaternion.LookRotation(targetDir);
                Debug.Log("改变方向放技能");
                activeSkillComponent.Verify(skillButtonClickGameEvent.SkillId, (PlayerBase)Owner, null, Trigskill, null, Complate);
            }

        }

        private Skill m_skill;

        /// <summary>
        /// 检验技能完毕 触发技能
        /// </summary>
        /// <param name="skill">触发的技能</param>
        private void Trigskill(Skill skill)
        {
            ActiveSkillComponent activeSkillComponent = Owner.GetUnitComponent<ActiveSkillComponent>();
            if (skill == null)
            {
                return;
            }

            CharacterStateComponent characterStateComponent = Owner.GetUnitComponent<CharacterStateComponent>();
            characterStateComponent.Set(SpecialStateType.NotInControl, true);

            GameEntry.Event.CommonEvent.Dispatch(this, GameEntry.Pool.SpawnClassObject<SkillCDGameEvent>().Fill(skill.SkillData.SkillId, null));

            if (skill.SkillData.SkillId == 10013)
            {
                Owner.GetUnitComponent<BuffComponent>().AddBuff(0);
            }
            activeSkillComponent.HandleCast(skill, 0);

        }

        private void Complate(Skill skill)
        {
            m_skill = null;
            CharacterStateComponent characterStateComponent = Owner.GetUnitComponent<CharacterStateComponent>();
            characterStateComponent.Set(SpecialStateType.NotInControl, false);
            Debug.Log("技能结束");
        }

        /// <summary>
        /// 显示技能指示器
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void OnShowSkillArea(GameEventBase gameEventBase)
        {
            ShowSkillAreaGameEvent showSkillAreaGameEvent = (ShowSkillAreaGameEvent)gameEventBase;

            GameEntry.Entity.ShowSkillArea(showSkillAreaGameEvent.SKillAreaType, Owner);
        }


        /// <summary>
        /// 遥感移动
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void OnRockerMove(GameEventBase gameEventBase)
        {
            RockerMoveGameEvent rockerMoveGameEvent = (RockerMoveGameEvent)gameEventBase;

            deltaVec = new Vector3(rockerMoveGameEvent.Postion.x, 0, rockerMoveGameEvent.Postion.y);

            Vector3 targetDir = deltaVec;
            targetDir = targetDir.GetRotateY(GameEntry.Camera.MainCamera.transform.eulerAngles.y);
            m_MoveComponent.SetInputMoveDirection(targetDir, targetDir.magnitude);
        }

        /// <summary>
        /// 遥感移动结束
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void OnRockerEnd(GameEventBase gameEventBase)
        {
            RockerEndGameEvent rockerEndGameEvent = (RockerEndGameEvent)gameEventBase;
            m_MoveComponent.EndInputMoveDirection();
        }

        /// <summary>
        /// 遥感中心点点击
        /// </summary>
        /// <param name="gameEventBase"></param>
        private void OnRockerInClick(GameEventBase gameEventBase)
        {
            RockerInClickGameEvent rockerInClickGameEvent = (RockerInClickGameEvent)gameEventBase;
            MountsComponent mountsComponent = Owner.GetUnitComponent<MountsComponent>();
            if (mountsComponent == null)
            {
                return;
            }

            if (mountsComponent.IsRide)
            {
                mountsComponent.HideMounts();
            }
            else
            {
                mountsComponent.ShowMounts(UnityEngine.Random.Range(1, 10));
            }
        }

        private void OnMove(GameEventBase gameEventBase)
        {
            InputMoveGameEvent inputMoveGameEvent = (InputMoveGameEvent)gameEventBase;
            switch (inputMoveGameEvent.MoveDir)
            {
                case MoveDir.Left:
                    GameEntry.Camera.SetCameraRotate(0, inputMoveGameEvent.Speed);
                    break;
                case MoveDir.Right:
                    GameEntry.Camera.SetCameraRotate(1, inputMoveGameEvent.Speed);
                    break;
                case MoveDir.Up:
                    GameEntry.Camera.SetCameraUpAndDown(1);
                    break;
                case MoveDir.Down:
                    GameEntry.Camera.SetCameraUpAndDown(0);
                    break;
            }
            Vector3 targetDir = deltaVec;
            targetDir = targetDir.GetRotateY(GameEntry.Camera.MainCamera.transform.eulerAngles.y);

            m_MoveComponent.ChangeSetInputMoveDirection(targetDir);
        }

        private void OnPointClick(GameEventBase gameEventBase)
        {
            UnityEngine.Debug.Log("点击");
        }

        private void OnZoom(GameEventBase gameEventBase)
        {
            InputZoomGameEvent inputZoomGameEvent = (InputZoomGameEvent)gameEventBase;
            switch (inputZoomGameEvent.ZoomType)
            {
                case ZoomType.In:
                    GameEntry.Camera.SetCameraZoom(0);
                    break;
                case ZoomType.Out:
                    GameEntry.Camera.SetCameraZoom(1);
                    break;
            }
        }
    }
}
