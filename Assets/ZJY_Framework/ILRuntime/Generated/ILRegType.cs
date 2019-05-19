
namespace ZJY.Framework
{
    using ILRuntime.Runtime.Enviorment;

    static class ILRegType
    {
        static public void RegisterFunctionDelegate(AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Component, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Component, UnityEngine.Component, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.EntityBase, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.EntityBase, ZJY.Framework.EntityBase, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Exception, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IAsyncResult, System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task[], System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task, System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IAsyncResult, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task[], System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.AnimatorClipInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.AnimatorClipInfo, UnityEngine.AnimatorClipInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.Object, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Single, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Single, System.Single, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector4, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector4, UnityEngine.Vector4, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Matrix4x4, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Matrix4x4, UnityEngine.Matrix4x4, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.UIFormBase, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.UIFormBase, ZJY.Framework.UIFormBase, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.RaycastResult, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.RaycastResult, UnityEngine.EventSystems.RaycastResult, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.GameObject, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.GameObject, UnityEngine.GameObject, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector3, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector3, UnityEngine.Vector3, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color, UnityEngine.Color, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color32, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Color32, UnityEngine.Color32, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector2, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Vector2, UnityEngine.Vector2, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Int32, System.Int32, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.BoneWeight, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.BoneWeight, UnityEngine.BoneWeight, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UIVertex, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UIVertex, UnityEngine.UIVertex, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Rect, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Rect, UnityEngine.Rect, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Selectable, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Selectable, UnityEngine.UI.Selectable, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.RoleItem, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.RoleItem, ZJY.Framework.RoleItem, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UICharInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UICharInfo, UnityEngine.UICharInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UILineInfo, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UILineInfo, UnityEngine.UILineInfo, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<DG.Tweening.Tween, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<DG.Tweening.Tween, DG.Tweening.Tween, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<LitJson.IJsonWrapper>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object, System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.IAsyncResult, System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task[], System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Threading.Tasks.Task, System.String>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.TimeAction, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.TimeAction, ZJY.Framework.TimeAction, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.FsmBase, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.FsmBase, ZJY.Framework.FsmBase, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.IDataTable, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.IDataTable, ZJY.Framework.IDataTable, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.SocketTcpRoutine, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.SocketTcpRoutine, ZJY.Framework.SocketTcpRoutine, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.ObjectPoolBase, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.ObjectPoolBase, ZJY.Framework.ObjectPoolBase, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.String, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.EntityGroup, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.EntityGroup, ZJY.Framework.EntityGroup, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.UIGroup, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.UIGroup, ZJY.Framework.UIGroup, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.SoundGroup, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.SoundGroup, ZJY.Framework.SoundGroup, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.DebuggerComponent.LogNode, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.DebuggerComponent.LogNode, ZJY.Framework.DebuggerComponent.LogNode, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.ChapterEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.ChapterEntity, ZJY.Framework.ChapterEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.ChapterXLSXEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.ChapterXLSXEntity, ZJY.Framework.ChapterXLSXEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.JobAvtarEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.JobAvtarEntity, ZJY.Framework.JobAvtarEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.JobEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.JobEntity, ZJY.Framework.JobEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.JobLevelEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.JobLevelEntity, ZJY.Framework.JobLevelEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.JobWeaponEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.JobWeaponEntity, ZJY.Framework.JobWeaponEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.JobWingsEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.JobWingsEntity, ZJY.Framework.JobWingsEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.LoadingEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.LoadingEntity, ZJY.Framework.LoadingEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.MusicEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.MusicEntity, ZJY.Framework.MusicEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.RideEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.RideEntity, ZJY.Framework.RideEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.SceneEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.SceneEntity, ZJY.Framework.SceneEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.SkillEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.SkillEntity, ZJY.Framework.SkillEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.SoundEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.SoundEntity, ZJY.Framework.SoundEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.TrumpEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.TrumpEntity, ZJY.Framework.TrumpEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.UIFormEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.UIFormEntity, ZJY.Framework.UIFormEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.UISoundEntity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.UISoundEntity, ZJY.Framework.UISoundEntity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object[], System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Object[], System.Object[], System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.DataTableEntityBase, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.DataTableEntityBase, ZJY.Framework.DataTableEntityBase, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.IVerify, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.IVerify, ZJY.Framework.IVerify, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.Entity, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<ZJY.Framework.Entity, ZJY.Framework.Entity, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Type, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.Type, System.Type, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.EventTrigger.Entry, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.EventSystems.EventTrigger.Entry, UnityEngine.EventSystems.EventTrigger.Entry, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Dropdown.OptionData, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.Dropdown.OptionData, UnityEngine.UI.Dropdown.OptionData, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Sprite, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.Sprite, UnityEngine.Sprite, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<System.String, System.Int32, System.Char, System.Char>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.RectMask2D, System.Boolean>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.RectMask2D, UnityEngine.UI.RectMask2D, System.Int32>();
            appdomain.DelegateManager.RegisterFunctionDelegate<UnityEngine.UI.ILayoutElement, System.Single>();

        }

        static public void RegisterDelegateConvertor(AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Component>>((act) =>
            {
                return new System.Predicate<UnityEngine.Component>((obj) =>
                {
                    return ((System.Func<UnityEngine.Component, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Component>>((act) =>
            {
                return new System.Comparison<UnityEngine.Component>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Component, UnityEngine.Component, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadAssetSuccessCallback>((act) =>
            {
                return new ZJY.Framework.LoadAssetSuccessCallback((assetName, asset, duration, userData) =>
                {
                    ((System.Action<System.String, UnityEngine.Object, System.Single, System.Object>)act)(assetName, asset, duration, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadAvtarSuccessEvent>((act) =>
            {
                return new ZJY.Framework.LoadAvtarSuccessEvent((avtarAssetName, asset, duration, userData) =>
                {
                    ((System.Action<System.String, UnityEngine.Object, System.Single, System.Object>)act)(avtarAssetName, asset, duration, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadControllerSuccessEvent>((act) =>
            {
                return new ZJY.Framework.LoadControllerSuccessEvent((controllerAssetName, asset, duration, userData) =>
                {
                    ((System.Action<System.String, UnityEngine.Object, System.Single, System.Object>)act)(controllerAssetName, asset, duration, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadTexture2DSuccessEvent>((act) =>
            {
                return new ZJY.Framework.LoadTexture2DSuccessEvent((textureAssetName, asset, duration, userData) =>
                {
                    ((System.Action<System.String, UnityEngine.Object, System.Single, System.Object>)act)(textureAssetName, asset, duration, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadAssetFailureCallback>((act) =>
            {
                return new ZJY.Framework.LoadAssetFailureCallback((assetName, errorMessage, userData) =>
                {
                    ((System.Action<System.String, System.String, System.Object>)act)(assetName, errorMessage, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadDataTableFailureEvent>((act) =>
            {
                return new ZJY.Framework.LoadDataTableFailureEvent((dataTableAssetName, errorMessage, userData) =>
                {
                    ((System.Action<System.String, System.String, System.Object>)act)(dataTableAssetName, errorMessage, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadAvtarFailureEvent>((act) =>
            {
                return new ZJY.Framework.LoadAvtarFailureEvent((avtarAssetName, errorMessage, userData) =>
                {
                    ((System.Action<System.String, System.String, System.Object>)act)(avtarAssetName, errorMessage, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadControllerFailureEvent>((act) =>
            {
                return new ZJY.Framework.LoadControllerFailureEvent((controllerAssetName, errorMessage, userData) =>
                {
                    ((System.Action<System.String, System.String, System.Object>)act)(controllerAssetName, errorMessage, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadTexture2DFailureEvent>((act) =>
            {
                return new ZJY.Framework.LoadTexture2DFailureEvent((textureAssetName, errorMessage, userData) =>
                {
                    ((System.Action<System.String, System.String, System.Object>)act)(textureAssetName, errorMessage, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadAssetUpdateCallback>((act) =>
            {
                return new ZJY.Framework.LoadAssetUpdateCallback((assetName, progress, userData) =>
                {
                    ((System.Action<System.String, System.Single, System.Object>)act)(assetName, progress, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadDataTableSuccessEvent>((act) =>
            {
                return new ZJY.Framework.LoadDataTableSuccessEvent((dataTableAssetName, duration, userData) =>
                {
                    ((System.Action<System.String, System.Single, System.Object>)act)(dataTableAssetName, duration, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadDataTableUpdateEvent>((act) =>
            {
                return new ZJY.Framework.LoadDataTableUpdateEvent((dataTableAssetName, progress, userData) =>
                {
                    ((System.Action<System.String, System.Single, System.Object>)act)(dataTableAssetName, progress, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadAvtarUpdateEvent>((act) =>
            {
                return new ZJY.Framework.LoadAvtarUpdateEvent((avtarAssetName, progress, userData) =>
                {
                    ((System.Action<System.String, System.Single, System.Object>)act)(avtarAssetName, progress, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadControllerUpdateEvent>((act) =>
            {
                return new ZJY.Framework.LoadControllerUpdateEvent((controllerAssetName, progress, userData) =>
                {
                    ((System.Action<System.String, System.Single, System.Object>)act)(controllerAssetName, progress, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadTexture2DUpdateEvent>((act) =>
            {
                return new ZJY.Framework.LoadTexture2DUpdateEvent((textureAssetName, progress, userData) =>
                {
                    ((System.Action<System.String, System.Single, System.Object>)act)(textureAssetName, progress, userData);
                });
            });






            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.EntityBase>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.EntityBase>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.EntityBase, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.EntityBase>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.EntityBase>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.EntityBase, ZJY.Framework.EntityBase, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Action>((act) =>
            {
                return new System.Action(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction>((act) =>
            {
                return new UnityEngine.Events.UnityAction(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Canvas.WillRenderCanvases>((act) =>
            {
                return new UnityEngine.Canvas.WillRenderCanvases(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Font.FontTextureRebuildCallback>((act) =>
            {
                return new UnityEngine.Font.FontTextureRebuildCallback(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadManifestCompleteCallBack>((act) =>
            {
                return new ZJY.Framework.LoadManifestCompleteCallBack(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.InitResourcesCompleteCallback>((act) =>
            {
                return new ZJY.Framework.InitResourcesCompleteCallback(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.PreLoadShaderSuccess>((act) =>
            {
                return new ZJY.Framework.PreLoadShaderSuccess(() =>
                {
                    ((System.Action)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.EventHandler<System.Threading.Tasks.UnobservedTaskExceptionEventArgs>>((act) =>
            {
                return new System.EventHandler<System.Threading.Tasks.UnobservedTaskExceptionEventArgs>((sender, e) =>
                {
                    ((System.Action<System.Object, System.Threading.Tasks.UnobservedTaskExceptionEventArgs>)act)(sender, e);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.AnimatorClipInfo>>((act) =>
            {
                return new System.Predicate<UnityEngine.AnimatorClipInfo>((obj) =>
                {
                    return ((System.Func<UnityEngine.AnimatorClipInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.AnimatorClipInfo>>((act) =>
            {
                return new System.Comparison<UnityEngine.AnimatorClipInfo>((x, y) =>
                {
                    return ((System.Func<UnityEngine.AnimatorClipInfo, UnityEngine.AnimatorClipInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Object>>((act) =>
            {
                return new System.Predicate<System.Object>((obj) =>
                {
                    return ((System.Func<System.Object, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Object>>((act) =>
            {
                return new System.Comparison<System.Object>((x, y) =>
                {
                    return ((System.Func<System.Object, System.Object, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Single>>((act) =>
            {
                return new System.Predicate<System.Single>((obj) =>
                {
                    return ((System.Func<System.Single, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.Single>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.Single>((arg0) =>
                {
                    ((System.Action<System.Single>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Single>>((act) =>
            {
                return new System.Comparison<System.Single>((x, y) =>
                {
                    return ((System.Func<System.Single, System.Single, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Vector4>>((act) =>
            {
                return new System.Predicate<UnityEngine.Vector4>((obj) =>
                {
                    return ((System.Func<UnityEngine.Vector4, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Vector4>>((act) =>
            {
                return new System.Comparison<UnityEngine.Vector4>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Vector4, UnityEngine.Vector4, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Matrix4x4>>((act) =>
            {
                return new System.Predicate<UnityEngine.Matrix4x4>((obj) =>
                {
                    return ((System.Func<UnityEngine.Matrix4x4, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Matrix4x4>>((act) =>
            {
                return new System.Comparison<UnityEngine.Matrix4x4>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Matrix4x4, UnityEngine.Matrix4x4, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Camera.CameraCallback>((act) =>
            {
                return new UnityEngine.Camera.CameraCallback((cam) =>
                {
                    ((System.Action<UnityEngine.Camera>)act)(cam);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.UIFormBase>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.UIFormBase>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.UIFormBase, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.UIFormBase>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.UIFormBase>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.UIFormBase, ZJY.Framework.UIFormBase, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.EventSystems.RaycastResult>>((act) =>
            {
                return new System.Predicate<UnityEngine.EventSystems.RaycastResult>((obj) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.RaycastResult, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.EventSystems.RaycastResult>>((act) =>
            {
                return new System.Comparison<UnityEngine.EventSystems.RaycastResult>((x, y) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.RaycastResult, UnityEngine.EventSystems.RaycastResult, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.GameObject>>((act) =>
            {
                return new System.Predicate<UnityEngine.GameObject>((obj) =>
                {
                    return ((System.Func<UnityEngine.GameObject, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.GameObject>>((act) =>
            {
                return new System.Comparison<UnityEngine.GameObject>((x, y) =>
                {
                    return ((System.Func<UnityEngine.GameObject, UnityEngine.GameObject, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.RectTransform.ReapplyDrivenProperties>((act) =>
            {
                return new UnityEngine.RectTransform.ReapplyDrivenProperties((driven) =>
                {
                    ((System.Action<UnityEngine.RectTransform>)act)(driven);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Vector3>>((act) =>
            {
                return new System.Predicate<UnityEngine.Vector3>((obj) =>
                {
                    return ((System.Func<UnityEngine.Vector3, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Vector3>>((act) =>
            {
                return new System.Comparison<UnityEngine.Vector3>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Vector3, UnityEngine.Vector3, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Color>>((act) =>
            {
                return new System.Predicate<UnityEngine.Color>((obj) =>
                {
                    return ((System.Func<UnityEngine.Color, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Color>>((act) =>
            {
                return new System.Comparison<UnityEngine.Color>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Color, UnityEngine.Color, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Color32>>((act) =>
            {
                return new System.Predicate<UnityEngine.Color32>((obj) =>
                {
                    return ((System.Func<UnityEngine.Color32, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Color32>>((act) =>
            {
                return new System.Comparison<UnityEngine.Color32>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Color32, UnityEngine.Color32, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Vector2>>((act) =>
            {
                return new System.Predicate<UnityEngine.Vector2>((obj) =>
                {
                    return ((System.Func<UnityEngine.Vector2, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<UnityEngine.Vector2>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<UnityEngine.Vector2>((arg0) =>
                {
                    ((System.Action<UnityEngine.Vector2>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Vector2>>((act) =>
            {
                return new System.Comparison<UnityEngine.Vector2>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Vector2, UnityEngine.Vector2, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Int32>>((act) =>
            {
                return new System.Predicate<System.Int32>((obj) =>
                {
                    return ((System.Func<System.Int32, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.DamageResult>((act) =>
            {
                return new ZJY.Framework.DamageResult((result) =>
                {
                    ((System.Action<System.Int32>)act)(result);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.Int32>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.Int32>((arg0) =>
                {
                    ((System.Action<System.Int32>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Int32>>((act) =>
            {
                return new System.Comparison<System.Int32>((x, y) =>
                {
                    return ((System.Func<System.Int32, System.Int32, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.BoneWeight>>((act) =>
            {
                return new System.Predicate<UnityEngine.BoneWeight>((obj) =>
                {
                    return ((System.Func<UnityEngine.BoneWeight, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.BoneWeight>>((act) =>
            {
                return new System.Comparison<UnityEngine.BoneWeight>((x, y) =>
                {
                    return ((System.Func<UnityEngine.BoneWeight, UnityEngine.BoneWeight, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UIVertex>>((act) =>
            {
                return new System.Predicate<UnityEngine.UIVertex>((obj) =>
                {
                    return ((System.Func<UnityEngine.UIVertex, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UIVertex>>((act) =>
            {
                return new System.Comparison<UnityEngine.UIVertex>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UIVertex, UnityEngine.UIVertex, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Rect>>((act) =>
            {
                return new System.Predicate<UnityEngine.Rect>((obj) =>
                {
                    return ((System.Func<UnityEngine.Rect, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Rect>>((act) =>
            {
                return new System.Comparison<UnityEngine.Rect>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Rect, UnityEngine.Rect, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.Boolean>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.Boolean>((arg0) =>
                {
                    ((System.Action<System.Boolean>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.UpdateResourcesCompleteCallback>((act) =>
            {
                return new ZJY.Framework.UpdateResourcesCompleteCallback((result) =>
                {
                    ((System.Action<System.Boolean>)act)(result);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.Selectable>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.Selectable>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.Selectable, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.Selectable>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.Selectable>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.Selectable, UnityEngine.UI.Selectable, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.RoleItem>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.RoleItem>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.RoleItem, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.RoleItem>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.RoleItem>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.RoleItem, ZJY.Framework.RoleItem, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UICharInfo>>((act) =>
            {
                return new System.Predicate<UnityEngine.UICharInfo>((obj) =>
                {
                    return ((System.Func<UnityEngine.UICharInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UICharInfo>>((act) =>
            {
                return new System.Comparison<UnityEngine.UICharInfo>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UICharInfo, UnityEngine.UICharInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UILineInfo>>((act) =>
            {
                return new System.Predicate<UnityEngine.UILineInfo>((obj) =>
                {
                    return ((System.Func<UnityEngine.UILineInfo, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UILineInfo>>((act) =>
            {
                return new System.Comparison<UnityEngine.UILineInfo>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UILineInfo, UnityEngine.UILineInfo, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<DG.Tweening.Tween>>((act) =>
            {
                return new System.Predicate<DG.Tweening.Tween>((obj) =>
                {
                    return ((System.Func<DG.Tweening.Tween, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<DG.Tweening.Tween>>((act) =>
            {
                return new System.Comparison<DG.Tweening.Tween>((x, y) =>
                {
                    return ((System.Func<DG.Tweening.Tween, DG.Tweening.Tween, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<LitJson.WrapperFactory>((act) =>
            {
                return new LitJson.WrapperFactory(() =>
                {
                    return ((System.Func<LitJson.IJsonWrapper>)act)();
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.SocketEvent.OnActionHandler>((act) =>
            {
                return new ZJY.Framework.SocketEvent.OnActionHandler((buffer) =>
                {
                    ((System.Action<System.Byte[]>)act)(buffer);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.CommonEvent.OnActionHandler>((act) =>
            {
                return new ZJY.Framework.CommonEvent.OnActionHandler((gameEventBase) =>
                {
                    ((System.Action<ZJY.Framework.GameEventBase>)act)(gameEventBase);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.TimeAction>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.TimeAction>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.TimeAction, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.TimeAction>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.TimeAction>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.TimeAction, ZJY.Framework.TimeAction, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.FsmBase>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.FsmBase>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.FsmBase, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.FsmBase>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.FsmBase>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.FsmBase, ZJY.Framework.FsmBase, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.IDataTable>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.IDataTable>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.IDataTable, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.IDataTable>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.IDataTable>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.IDataTable, ZJY.Framework.IDataTable, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.SocketConnectedEvent>((act) =>
            {
                return new ZJY.Framework.SocketConnectedEvent((socketTcpRoutine) =>
                {
                    ((System.Action<ZJY.Framework.SocketTcpRoutine>)act)(socketTcpRoutine);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.SocketClosedEvent>((act) =>
            {
                return new ZJY.Framework.SocketClosedEvent((socketTcpRoutine) =>
                {
                    ((System.Action<ZJY.Framework.SocketTcpRoutine>)act)(socketTcpRoutine);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.SocketErrorEvent>((act) =>
            {
                return new ZJY.Framework.SocketErrorEvent((socketTcpRoutine, errorCode, errorMessage) =>
                {
                    ((System.Action<ZJY.Framework.SocketTcpRoutine, ZJY.Framework.NetworkErrorCode, System.String>)act)(socketTcpRoutine, errorCode, errorMessage);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.SocketCustomErrorEvent>((act) =>
            {
                return new ZJY.Framework.SocketCustomErrorEvent((socketTcpRoutine, customErrorData) =>
                {
                    ((System.Action<ZJY.Framework.SocketTcpRoutine, System.Object>)act)(socketTcpRoutine, customErrorData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.SocketTcpRoutine>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.SocketTcpRoutine>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.SocketTcpRoutine, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.SocketTcpRoutine>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.SocketTcpRoutine>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.SocketTcpRoutine, ZJY.Framework.SocketTcpRoutine, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.HttpSendDataCallBack>((act) =>
            {
                return new ZJY.Framework.HttpSendDataCallBack((args) =>
                {
                    ((System.Action<ZJY.Framework.HttpCallBackArgs>)act)(args);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.ObjectPoolBase>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.ObjectPoolBase>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.ObjectPoolBase, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.ObjectPoolBase>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.ObjectPoolBase>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.ObjectPoolBase, ZJY.Framework.ObjectPoolBase, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.String>>((act) =>
            {
                return new System.Predicate<System.String>((obj) =>
                {
                    return ((System.Func<System.String, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.PreLoadShaderFailure>((act) =>
            {
                return new ZJY.Framework.PreLoadShaderFailure((errorMessage) =>
                {
                    ((System.Action<System.String>)act)(errorMessage);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<System.String>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<System.String>((arg0) =>
                {
                    ((System.Action<System.String>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.String>>((act) =>
            {
                return new System.Comparison<System.String>((x, y) =>
                {
                    return ((System.Func<System.String, System.String, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.EntityGroup>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.EntityGroup>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.EntityGroup, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.EntityGroup>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.EntityGroup>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.EntityGroup, ZJY.Framework.EntityGroup, System.Int32>)act)(x, y);
                });
            });


            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadManifestCallBack>((act) =>
            {
                return new ZJY.Framework.LoadManifestCallBack((assetBundleManifest) =>
                {
                    ((System.Action<UnityEngine.AssetBundleManifest>)act)(assetBundleManifest);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.LoadBytesCallback>((act) =>
            {
                return new ZJY.Framework.LoadBytesCallback((fileUri, bytes, errorMessage) =>
                {
                    ((System.Action<System.String, System.Byte[], System.String>)act)(fileUri, bytes, errorMessage);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.UnloadSceneSuccessCallback>((act) =>
            {
                return new ZJY.Framework.UnloadSceneSuccessCallback((sceneAssetName, userData) =>
                {
                    ((System.Action<System.String, System.Object>)act)(sceneAssetName, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.UnloadSceneFailureCallback>((act) =>
            {
                return new ZJY.Framework.UnloadSceneFailureCallback((sceneAssetName, userData) =>
                {
                    ((System.Action<System.String, System.Object>)act)(sceneAssetName, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.UpdateVersionListSuccessCallback>((act) =>
            {
                return new ZJY.Framework.UpdateVersionListSuccessCallback((downloadPath, downloadUri) =>
                {
                    ((System.Action<System.String, System.String>)act)(downloadPath, downloadUri);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.UpdateVersionListFailureCallback>((act) =>
            {
                return new ZJY.Framework.UpdateVersionListFailureCallback((downloadUri, errorMessage) =>
                {
                    ((System.Action<System.String, System.String>)act)(downloadUri, errorMessage);
                });
            });





            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.UIGroup>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.UIGroup>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.UIGroup, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.UIGroup>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.UIGroup>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.UIGroup, ZJY.Framework.UIGroup, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.SoundGroup>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.SoundGroup>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.SoundGroup, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.SoundGroup>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.SoundGroup>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.SoundGroup, ZJY.Framework.SoundGroup, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.OnItemCreateHandler>((act) =>
            {
                return new ZJY.Framework.OnItemCreateHandler((index, obj) =>
                {
                    ((System.Action<System.Int32, UnityEngine.GameObject>)act)(index, obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.DebuggerComponent.LogNode>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.DebuggerComponent.LogNode>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.DebuggerComponent.LogNode, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.DebuggerComponent.LogNode>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.DebuggerComponent.LogNode>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.DebuggerComponent.LogNode, ZJY.Framework.DebuggerComponent.LogNode, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.ChapterEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.ChapterEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.ChapterEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.ChapterEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.ChapterEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.ChapterEntity, ZJY.Framework.ChapterEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.ChapterXLSXEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.ChapterXLSXEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.ChapterXLSXEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.ChapterXLSXEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.ChapterXLSXEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.ChapterXLSXEntity, ZJY.Framework.ChapterXLSXEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.JobAvtarEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.JobAvtarEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.JobAvtarEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.JobAvtarEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.JobAvtarEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.JobAvtarEntity, ZJY.Framework.JobAvtarEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.JobEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.JobEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.JobEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.JobEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.JobEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.JobEntity, ZJY.Framework.JobEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.JobLevelEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.JobLevelEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.JobLevelEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.JobLevelEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.JobLevelEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.JobLevelEntity, ZJY.Framework.JobLevelEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.JobWeaponEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.JobWeaponEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.JobWeaponEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.JobWeaponEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.JobWeaponEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.JobWeaponEntity, ZJY.Framework.JobWeaponEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.JobWingsEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.JobWingsEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.JobWingsEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.JobWingsEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.JobWingsEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.JobWingsEntity, ZJY.Framework.JobWingsEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.LoadingEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.LoadingEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.LoadingEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.LoadingEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.LoadingEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.LoadingEntity, ZJY.Framework.LoadingEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.MusicEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.MusicEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.MusicEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.MusicEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.MusicEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.MusicEntity, ZJY.Framework.MusicEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.RideEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.RideEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.RideEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.RideEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.RideEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.RideEntity, ZJY.Framework.RideEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.SceneEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.SceneEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.SceneEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.SceneEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.SceneEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.SceneEntity, ZJY.Framework.SceneEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.SkillEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.SkillEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.SkillEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.SkillEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.SkillEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.SkillEntity, ZJY.Framework.SkillEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.SoundEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.SoundEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.SoundEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.SoundEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.SoundEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.SoundEntity, ZJY.Framework.SoundEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.TrumpEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.TrumpEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.TrumpEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.TrumpEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.TrumpEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.TrumpEntity, ZJY.Framework.TrumpEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.UIFormEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.UIFormEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.UIFormEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.UIFormEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.UIFormEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.UIFormEntity, ZJY.Framework.UIFormEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.UISoundEntity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.UISoundEntity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.UISoundEntity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.UISoundEntity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.UISoundEntity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.UISoundEntity, ZJY.Framework.UISoundEntity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Object[]>>((act) =>
            {
                return new System.Predicate<System.Object[]>((obj) =>
                {
                    return ((System.Func<System.Object[], System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Object[]>>((act) =>
            {
                return new System.Comparison<System.Object[]>((x, y) =>
                {
                    return ((System.Func<System.Object[], System.Object[], System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.ShowEntitySuccessCallBack>((act) =>
            {
                return new ZJY.Framework.ShowEntitySuccessCallBack((entity, duration, userData) =>
                {
                    ((System.Action<ZJY.Framework.EntityBase, System.Single, System.Object>)act)(entity, duration, userData);
                });
            });




            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.HideEntityCompleteCallBack>((act) =>
            {
                return new ZJY.Framework.HideEntityCompleteCallBack((entityId, entityAssetName, entityGroup, userData) =>
                {
                    ((System.Action<System.Int32, System.String, ZJY.Framework.EntityGroup, System.Object>)act)(entityId, entityAssetName, entityGroup, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.DataTableEntityBase>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.DataTableEntityBase>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.DataTableEntityBase, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.DataTableEntityBase>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.DataTableEntityBase>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.DataTableEntityBase, ZJY.Framework.DataTableEntityBase, System.Int32>)act)(x, y);
                });
            });





            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.OpenUIFormSuccessEvent>((act) =>
            {
                return new ZJY.Framework.OpenUIFormSuccessEvent((uiForm, duration, userData) =>
                {
                    ((System.Action<ZJY.Framework.UIFormBase, System.Single, System.Object>)act)(uiForm, duration, userData);
                });
            });




            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.CloseUIFormCompleteEvent>((act) =>
            {
                return new ZJY.Framework.CloseUIFormCompleteEvent((serialId, uiFormAssetName, uiGroup, userData) =>
                {
                    ((System.Action<System.Int32, System.String, ZJY.Framework.UIGroup, System.Object>)act)(serialId, uiFormAssetName, uiGroup, userData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.TrigSkill>((act) =>
            {
                return new ZJY.Framework.TrigSkill((skill) =>
                {
                    ((System.Action<ZJY.Framework.Skill>)act)(skill);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<ZJY.Framework.SkillComplate>((act) =>
            {
                return new ZJY.Framework.SkillComplate((skill) =>
                {
                    ((System.Action<ZJY.Framework.Skill>)act)(skill);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.IVerify>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.IVerify>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.IVerify, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.IVerify>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.IVerify>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.IVerify, ZJY.Framework.IVerify, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<ZJY.Framework.Entity>>((act) =>
            {
                return new System.Predicate<ZJY.Framework.Entity>((obj) =>
                {
                    return ((System.Func<ZJY.Framework.Entity, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<ZJY.Framework.Entity>>((act) =>
            {
                return new System.Comparison<ZJY.Framework.Entity>((x, y) =>
                {
                    return ((System.Func<ZJY.Framework.Entity, ZJY.Framework.Entity, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<System.Type>>((act) =>
            {
                return new System.Predicate<System.Type>((obj) =>
                {
                    return ((System.Func<System.Type, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<System.Type>>((act) =>
            {
                return new System.Comparison<System.Type>((x, y) =>
                {
                    return ((System.Func<System.Type, System.Type, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.EventSystems.EventTrigger.Entry>>((act) =>
            {
                return new System.Predicate<UnityEngine.EventSystems.EventTrigger.Entry>((obj) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.EventTrigger.Entry, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.EventSystems.EventTrigger.Entry>>((act) =>
            {
                return new System.Comparison<UnityEngine.EventSystems.EventTrigger.Entry>((x, y) =>
                {
                    return ((System.Func<UnityEngine.EventSystems.EventTrigger.Entry, UnityEngine.EventSystems.EventTrigger.Entry, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData>>((act) =>
            {
                return new UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData>((arg0) =>
                {
                    ((System.Action<UnityEngine.EventSystems.BaseEventData>)act)(arg0);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerEnterHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerEnterHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerExitHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerExitHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerDownHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerDownHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerUpHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerUpHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerClickHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IPointerClickHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IInitializePotentialDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IInitializePotentialDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IBeginDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IBeginDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IEndDragHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IEndDragHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IEndDragHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDropHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDropHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IDropHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IScrollHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IScrollHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IScrollHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IUpdateSelectedHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IUpdateSelectedHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IUpdateSelectedHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISelectHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISelectHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDeselectHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IDeselectHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IMoveHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.IMoveHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.IMoveHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISubmitHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISubmitHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ICancelHandler>>((act) =>
            {
                return new UnityEngine.EventSystems.ExecuteEvents.EventFunction<UnityEngine.EventSystems.ICancelHandler>((handler, eventData) =>
                {
                    ((System.Action<UnityEngine.EventSystems.ICancelHandler, UnityEngine.EventSystems.BaseEventData>)act)(handler, eventData);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.Dropdown.OptionData>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.Dropdown.OptionData>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.Dropdown.OptionData, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.Dropdown.OptionData>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.Dropdown.OptionData>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.Dropdown.OptionData, UnityEngine.UI.Dropdown.OptionData, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.Sprite>>((act) =>
            {
                return new System.Predicate<UnityEngine.Sprite>((obj) =>
                {
                    return ((System.Func<UnityEngine.Sprite, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.Sprite>>((act) =>
            {
                return new System.Comparison<UnityEngine.Sprite>((x, y) =>
                {
                    return ((System.Func<UnityEngine.Sprite, UnityEngine.Sprite, System.Int32>)act)(x, y);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.UI.InputField.OnValidateInput>((act) =>
            {
                return new UnityEngine.UI.InputField.OnValidateInput((text, charIndex, addedChar) =>
                {
                    return ((System.Func<System.String, System.Int32, System.Char, System.Char>)act)(text, charIndex, addedChar);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Predicate<UnityEngine.UI.RectMask2D>>((act) =>
            {
                return new System.Predicate<UnityEngine.UI.RectMask2D>((obj) =>
                {
                    return ((System.Func<UnityEngine.UI.RectMask2D, System.Boolean>)act)(obj);
                });
            });

            appdomain.DelegateManager.RegisterDelegateConvertor<System.Comparison<UnityEngine.UI.RectMask2D>>((act) =>
            {
                return new System.Comparison<UnityEngine.UI.RectMask2D>((x, y) =>
                {
                    return ((System.Func<UnityEngine.UI.RectMask2D, UnityEngine.UI.RectMask2D, System.Int32>)act)(x, y);
                });
            });


        }

        static public void RegisterMethodDelegate(AppDomain appdomain)
        {
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Component>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String, UnityEngine.Object, System.Single, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String, System.String, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String, System.Single, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.EntityBase>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object, System.Threading.Tasks.UnobservedTaskExceptionEventArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.IAsyncResult>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task[]>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Threading.Tasks.Task>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Threading.Tasks.Task>, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Int32>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.Int32>, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.AnimatorClipInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Rendering.AsyncGPUReadbackRequest>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Single>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Vector4>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Matrix4x4>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Camera>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.UIFormBase>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.RaycastResult>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.GameObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.RectTransform>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Vector3>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Color>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Color32>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Vector2>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.BoneWeight>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UIVertex>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Rect>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Boolean>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.Selectable>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.RoleItem>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UICharInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UILineInfo>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Font>();
            appdomain.DelegateManager.RegisterMethodDelegate<DG.Tweening.Tween>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.String>>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Threading.Tasks.Task<System.String>, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Byte[]>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.GameEventBase>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.TimeAction>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.FsmBase>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.IDataTable>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.SocketTcpRoutine>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.SocketTcpRoutine, ZJY.Framework.NetworkErrorCode, System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.SocketTcpRoutine, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.HttpCallBackArgs>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.ObjectPoolBase>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.EntityGroup>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.AssetBundleManifest>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String, System.Byte[], System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.String, System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.UIGroup>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.SoundGroup>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32, UnityEngine.GameObject>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.DebuggerComponent.LogNode>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.ChapterEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.ChapterXLSXEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.JobAvtarEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.JobEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.JobLevelEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.JobWeaponEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.JobWingsEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.LoadingEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.MusicEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.RideEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.SceneEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.SkillEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.SoundEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.TrumpEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.UIFormEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.UISoundEntity>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Object[]>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.DownloadAgentBase>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.DownloadAgentBase, System.Int32>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.DownloadAgentBase, System.String>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.EntityBase, System.Single, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32, System.String, ZJY.Framework.EntityGroup, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.DataTableEntityBase>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.AsyncOperation>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32, System.Int32, System.Int64, System.Int64>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.UIFormBase, System.Single, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Int32, System.String, ZJY.Framework.UIGroup, System.Object>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.Skill>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.IVerify>();
            appdomain.DelegateManager.RegisterMethodDelegate<ZJY.Framework.Entity>();
            appdomain.DelegateManager.RegisterMethodDelegate<System.Type>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.EventTrigger.Entry>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IInitializePotentialDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IBeginDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IEndDragHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IDropHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IScrollHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IUpdateSelectedHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.IMoveHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.ISubmitHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.EventSystems.ICancelHandler, UnityEngine.EventSystems.BaseEventData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.Dropdown.OptionData>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.Sprite>();
            appdomain.DelegateManager.RegisterMethodDelegate<UnityEngine.UI.RectMask2D>();

        }


    }
}
