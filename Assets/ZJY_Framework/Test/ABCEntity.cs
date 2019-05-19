using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZJY;
using ZJY.Framework;

public class ABCEntity : Entity
{
    Animator Animator;
    protected override void OnInit(object userData)
    {
        base.OnInit(userData);
        Debug.Log(userData);
        Debug.Log("初始化");
    }

    protected internal override void OnShow(object userData)
    {
        base.OnShow(userData);
        Debug.Log(userData);
        Debug.Log("显示");
        Animator = gameObject.GetOrAddComponent<Animator>();
        GameEntry.Controller.SetController(Animator, "Assets/DownLoad/Prefab/Roles/Controller/mxz_00.controller");
        GameEntry.Camera.LookedTrans = this.transform;
        GameEntry.Event.CommonEvent.AddEventListener(InputZoomGameEvent.EventId, OnZoom);
        GameEntry.Event.CommonEvent.AddEventListener(InputMoveGameEvent.EventId, OnMove);
        GameEntry.Event.CommonEvent.AddEventListener(InputPointClickGameEvent.EventId, OnPointClick);
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

    protected internal override void OnHide(object userData)
    {
        base.OnHide(userData);
        Debug.Log(userData);
        Debug.Log("隐藏");
    }

    protected internal override void OnAttached(EntityBase childEntity, Transform parentTransform, object userData)
    {
        base.OnAttached(childEntity, parentTransform, userData);
        Debug.Log("父附加");
    }

    protected internal override void OnAttachTo(EntityBase parentEntity, Transform parentTransform, object userData)
    {
        base.OnAttachTo(parentEntity, parentTransform, userData);
        Debug.Log("子附加");
    }

    protected internal override void OnDetached(EntityBase childEntity, object userData)
    {
        base.OnDetached(childEntity, userData);
        Debug.Log("父解除");
    }

    protected internal override void OnDetachFrom(EntityBase parentEntity, object userData)
    {
        base.OnDetachFrom(parentEntity, userData);
        Debug.Log("子解除");
    }

    protected internal override void OnUpdate(float deltaTime, float unscaledDeltaTime)
    {
        base.OnUpdate(deltaTime, unscaledDeltaTime);
        if (Input.GetKeyUp(KeyCode.A))
        {
            GameEntry.Avtar.AddSkinnedMesh(this, "Assets/DownLoad/Prefab/Roles/Player/mxz/mxz_00.prefab");
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            GameEntry.Avtar.AddSkinnedMesh(this, "Assets/DownLoad/Prefab/Roles/Player/mxz/mxz_01.prefab");
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            GameEntry.Avtar.RemoveSkinnedMesh(this, "Assets/DownLoad/Prefab/Roles/Player/mxz/mxz_01.prefab");
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            GameEntry.Avtar.ChangeSkinnedMesh(this, "Assets/DownLoad/Prefab/Roles/Player/mxz/mxz_02.prefab");
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Animator.SetLayerWeight(0, 0.5f);
            //GameEntry.Avtar.RemoveAllSkinnedMesh(this);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            Animator.SetLayerWeight(1, 0.5f);
            //GameEntry.Controller.SetController(Animator, "Assets/DownLoad/Prefab/Roles/Controller/sds.overrideController");
        }
    }
}
