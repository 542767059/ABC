
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ILRuntime.Runtime.Generated
{
    class CLRBindings
    {


        /// <summary>
        /// Initialize the CLR binding, please invoke this AFTER CLR Redirection registration
        /// </summary>
        public static void Initialize(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            ZJY_Framework_GameEntry_Binding.Register(app);
            ZJY_Framework_SocketComponent_Binding.Register(app);
            System_IO_Stream_Binding.Register(app);
            ZJY_Framework_MMO_MemoryStream_Binding.Register(app);
            System_IO_MemoryStream_Binding.Register(app);
            UnityEngine_Debug_Binding.Register(app);
            System_Collections_Generic_LinkedList_1_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_LinkedListNode_1_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_LinkedList_1_ILTypeInstance_Binding_Enumerator_Binding.Register(app);
            System_Object_Binding.Register(app);
            System_Type_Binding.Register(app);
            System_IDisposable_Binding.Register(app);
            System_Activator_Binding.Register(app);
            ZJY_Framework_TextUtil_Binding.Register(app);
            System_Exception_Binding.Register(app);
            ZJY_Framework_Log_Binding.Register(app);
            ZJY_Framework_EventComponent_Binding.Register(app);
            ZJY_Framework_PoolComponent_Binding.Register(app);
            ZJY_Framework_ILRuntimePreloadGameEvent_Binding.Register(app);
            ZJY_Framework_CommonEvent_Binding.Register(app);
            System_String_Binding.Register(app);
            System_Threading_Monitor_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_String_ILTypeInstance_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_String_ILTypeInstance_Binding.Register(app);
            ZJY_Framework_ResourceComponent_Binding.Register(app);
            System_Collections_Generic_List_1_ILTypeInstance_Binding.Register(app);
            UnityEngine_Object_Binding.Register(app);
            UnityEngine_TextAsset_Binding.Register(app);
            ZJY_Framework_LoadAssetCallbacks_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_ILTypeInstance_Binding.Register(app);
            ZJY_Framework_SocketEvent_Binding.Register(app);
            ZJY_Framework_EntityBase_Binding.Register(app);
            System_Int32_Binding.Register(app);
            UnityEngine_Transform_Binding.Register(app);
            UnityEngine_Vector3_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_ILTypeInstance_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_Int32_ILTypeInstance_Binding.Register(app);
            ZJY_Framework_EntityComponent_Binding.Register(app);
            ZJY_Framework_HotfixEntityData_Binding.Register(app);
            ZJY_Framework_EntityData_Binding.Register(app);
            UnityEngine_Quaternion_Binding.Register(app);
            ZJY_Framework_DataTableComponent_Binding.Register(app);
            ZJY_Framework_DataTableDBModelBase_2_JobDBModel_JobEntity_Binding.Register(app);
            ZJY_Framework_DataTableDBModelBase_2_SceneDBModel_SceneEntity_Binding.Register(app);
            ZJY_Framework_SceneEntity_Binding.Register(app);
            ZJY_Framework_GameUtil_Binding.Register(app);
            ZJY_Framework_JobEntity_Binding.Register(app);
            ZJY_Framework_AssetUtility_Binding.Register(app);
            UnityEngine_Component_Binding.Register(app);
            GameObjectUtil_Binding.Register(app);
            ZJY_Framework_JobAvtarDBModel_Binding.Register(app);
            ZJY_Framework_JobAvtarEntity_Binding.Register(app);
            ZJY_Framework_AvtarComponent_Binding.Register(app);
            ZJY_Framework_ControllerComponent_Binding.Register(app);
            ZJY_Framework_EntityExtension_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_List_1_ILTypeInstance_Binding.Register(app);
            System_Collections_Generic_Queue_1_ILTypeInstance_Binding.Register(app);
            ILHotfix_HotScripts_Binding.Register(app);
            ILHotfix_RefOutParam_1_Int32_Binding.Register(app);
            ILHotfix_RefOutParam_1_String_Binding.Register(app);
            System_Collections_Generic_List_1_Object_Binding.Register(app);
            System_Reflection_MemberInfo_Binding.Register(app);
            ZJY_Framework_UIForm_Binding.Register(app);
            UnityEngine_UI_Button_Binding.Register(app);
            UnityEngine_Events_UnityEvent_Binding.Register(app);
            ZJY_Framework_ButtonHelper_Binding.Register(app);
            ZJY_Framework_DataComponent_Binding.Register(app);
            ZJY_Framework_UserData_Binding.Register(app);
            System_Collections_Generic_List_1_RoleItem_Binding.Register(app);
            ZJY_Framework_RoleItem_Binding.Register(app);
            ZJY_Framework_DeleateRoleSuccessGameEvent_Binding.Register(app);
            ZJY_Framework_UIExtension_Binding.Register(app);
            System_Byte_Binding.Register(app);
            UnityEngine_UI_Text_Binding.Register(app);
            UnityEngine_GameObject_Binding.Register(app);
            UnityEngine_Random_Binding.Register(app);
            RoleOperation_EnterGameProto_Binding.Register(app);
            ZJY_Framework_DialogParams_Binding.Register(app);
            RoleOperation_DeleteRoleProto_Binding.Register(app);
            ZJY_Framework_VarInt_Binding.Register(app);
            ZJY_Framework_ProcedureComponent_Binding.Register(app);
            ZJY_Framework_HotfixForm_Binding.Register(app);
            UnityEngine_Time_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Queue_1_Object_Binding.Register(app);
            System_Collections_Generic_Queue_1_Object_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Type_Int32_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Queue_1_Object_Binding_Enumerator_Binding.Register(app);
            System_Collections_Generic_KeyValuePair_2_Int32_Queue_1_Object_Binding.Register(app);
            System_Collections_Generic_Dictionary_2_Int32_Byte_Binding.Register(app);

            ILRuntime.CLR.TypeSystem.CLRType __clrType = null;
        }

        /// <summary>
        /// Release the CLR binding, please invoke this BEFORE ILRuntime Appdomain destroy
        /// </summary>
        public static void Shutdown(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
        }
    }
}
