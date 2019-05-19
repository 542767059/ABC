using System;
using System.Collections.Generic;
using ZJY.Framework;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// 选人流程
    /// </summary>
    public class ProcedureSelectRole : ProcedureBase
    {

        private Transform tranCam;
        public Transform TranCam
        {
            get
            {
                if (tranCam == null)
                {
                    tranCam = GameObject.Find("trsCam").transform;
                }
                return tranCam;
            }
        }


        public override void OnEnter()
        {
            base.OnEnter();

            GameEntry.Event.CommonEvent.AddEventListener(LogOnGameServerReturnGameEvent.EventId, OnLogOnGameServerReturn);
            GameEntry.Event.CommonEvent.AddEventListener(ReturnSelectRoleGameEvent.EventId, OnReturnSelectRole);
            GameEntry.Event.CommonEvent.AddEventListener(InputMoveGameEvent.EventId, OnSceneMove);

            RoleOperation_LogOnGameServerProto proto = new RoleOperation_LogOnGameServerProto();
            proto.AccountId = GameEntry.Data.UserData.AccountId;
            GameEntry.Socket.SendProtoMessage(proto);
        }



        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);
        }

        public override void OnLeave()
        {
            base.OnLeave();
            GameEntry.Event.CommonEvent.RemoveEventListener(LogOnGameServerReturnGameEvent.EventId, OnLogOnGameServerReturn);
            GameEntry.Event.CommonEvent.RemoveEventListener(ReturnSelectRoleGameEvent.EventId, OnReturnSelectRole);
            GameEntry.Event.CommonEvent.RemoveEventListener(InputMoveGameEvent.EventId, OnSceneMove);
        }


        private void OnSceneMove(GameEventBase gameEventBase)
        {
            InputMoveGameEvent inputMoveGameEvent = (InputMoveGameEvent)gameEventBase;
            switch (inputMoveGameEvent.MoveDir)
            {
                case MoveDir.Left:
                    if (TranCam != null)
                    {
                        TranCam.Rotate(0, -inputMoveGameEvent.Speed * Time.deltaTime, 0);
                        if (TranCam.localEulerAngles.y > 180)
                        {
                            TranCam.localEulerAngles = new Vector3(0, Mathf.Clamp(TranCam.localEulerAngles.y, 330f, 360f), 0);
                        }
                        else
                        {
                            TranCam.localEulerAngles = new Vector3(0, Mathf.Clamp(TranCam.localEulerAngles.y, 0, 30f), 0);
                        }
                    }

                    break;
                case MoveDir.Right:
                    if (TranCam != null)
                    {
                        TranCam.Rotate(0, inputMoveGameEvent.Speed * Time.deltaTime, 0);
                        if (TranCam.localEulerAngles.y > 180)
                        {
                            TranCam.localEulerAngles = new Vector3(0, Mathf.Clamp(TranCam.localEulerAngles.y, 330f, 360f), 0);
                        }
                        else
                        {
                            TranCam.localEulerAngles = new Vector3(0, Mathf.Clamp(TranCam.localEulerAngles.y, 0, 30f), 0);
                        }
                    }
                    break;
                case MoveDir.Up:
                    break;
                case MoveDir.Down:
                    break;
            }
        }


        private void OnLogOnGameServerReturn(GameEventBase gameEventBase)
        {
            LogOnGameServerReturnGameEvent logOnGameServerReturnGameEvent = (LogOnGameServerReturnGameEvent)gameEventBase;
            if (logOnGameServerReturnGameEvent.RoleCount == 0)
            {
                GameEntry.UI.OpenUIForm(UIFormId.CreateRole);
            }
            else
            {
                GameEntry.UI.OpenUIForm(UIFormId.SelectRole);
            }
        }


        private void OnReturnSelectRole(GameEventBase gameEventBase)
        {
            if (GameEntry.Data.UserData.RoleLists == null || GameEntry.Data.UserData.RoleLists.Count == 0)
            {
                CurrFsm.SetData<VarInt>(Constant.ProcedureData.NextSceneId, (int)SceneType.LogOn);
                GameEntry.UI.OpenUIForm(UIFormId.Loading);
            }
            else
            {
                GameEntry.UI.OpenUIForm(UIFormId.SelectRole);
            }
        }
    }
}