
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;
using ILRuntime.Reflection;
using ILRuntime.CLR.Utils;

namespace ILRuntime.Runtime.Generated
{
    unsafe class ZJY_Framework_EntityComponent_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(ZJY.Framework.EntityComponent);
            args = new Type[]{typeof(ZJY.Framework.EntityBase)};
            method = type.GetMethod("IsValidEntity", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, IsValidEntity_0);
            args = new Type[]{typeof(System.Int32), typeof(System.Type), typeof(System.String), typeof(System.String), typeof(System.Int32), typeof(System.Object)};
            method = type.GetMethod("ShowEntity", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ShowEntity_1);
            args = new Type[]{typeof(System.Int32)};
            method = type.GetMethod("HideEntity", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, HideEntity_2);
            args = new Type[]{typeof(System.Int32), typeof(System.Object)};
            method = type.GetMethod("HideEntity", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, HideEntity_3);
            args = new Type[]{typeof(ZJY.Framework.EntityBase)};
            method = type.GetMethod("HideEntity", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, HideEntity_4);
            args = new Type[]{typeof(ZJY.Framework.EntityBase), typeof(System.Object)};
            method = type.GetMethod("HideEntity", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, HideEntity_5);
            args = new Type[]{};
            method = type.GetMethod("HideAllLoadedEntities", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, HideAllLoadedEntities_6);
            args = new Type[]{};
            method = type.GetMethod("HideAllLoadingEntities", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, HideAllLoadingEntities_7);


        }


        static StackObject* IsValidEntity_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.EntityBase @entity = (ZJY.Framework.EntityBase)typeof(ZJY.Framework.EntityBase).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ZJY.Framework.EntityComponent instance_of_this_method = (ZJY.Framework.EntityComponent)typeof(ZJY.Framework.EntityComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.IsValidEntity(@entity);

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method ? 1 : 0;
            return __ret + 1;
        }

        static StackObject* ShowEntity_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 7);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Object @userData = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Int32 @priority = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            System.String @entityGroupName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            System.String @entityAssetName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 5);
            System.Type @entityBase = (System.Type)typeof(System.Type).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 6);
            System.Int32 @entityId = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 7);
            ZJY.Framework.EntityComponent instance_of_this_method = (ZJY.Framework.EntityComponent)typeof(ZJY.Framework.EntityComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.ShowEntity(@entityId, @entityBase, @entityAssetName, @entityGroupName, @priority, @userData);

            return __ret;
        }

        static StackObject* HideEntity_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @entityId = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ZJY.Framework.EntityComponent instance_of_this_method = (ZJY.Framework.EntityComponent)typeof(ZJY.Framework.EntityComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.HideEntity(@entityId);

            return __ret;
        }

        static StackObject* HideEntity_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Object @userData = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Int32 @entityId = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ZJY.Framework.EntityComponent instance_of_this_method = (ZJY.Framework.EntityComponent)typeof(ZJY.Framework.EntityComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.HideEntity(@entityId, @userData);

            return __ret;
        }

        static StackObject* HideEntity_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.EntityBase @entity = (ZJY.Framework.EntityBase)typeof(ZJY.Framework.EntityBase).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ZJY.Framework.EntityComponent instance_of_this_method = (ZJY.Framework.EntityComponent)typeof(ZJY.Framework.EntityComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.HideEntity(@entity);

            return __ret;
        }

        static StackObject* HideEntity_5(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Object @userData = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ZJY.Framework.EntityBase @entity = (ZJY.Framework.EntityBase)typeof(ZJY.Framework.EntityBase).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ZJY.Framework.EntityComponent instance_of_this_method = (ZJY.Framework.EntityComponent)typeof(ZJY.Framework.EntityComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.HideEntity(@entity, @userData);

            return __ret;
        }

        static StackObject* HideAllLoadedEntities_6(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.EntityComponent instance_of_this_method = (ZJY.Framework.EntityComponent)typeof(ZJY.Framework.EntityComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.HideAllLoadedEntities();

            return __ret;
        }

        static StackObject* HideAllLoadingEntities_7(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.EntityComponent instance_of_this_method = (ZJY.Framework.EntityComponent)typeof(ZJY.Framework.EntityComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.HideAllLoadingEntities();

            return __ret;
        }



    }
}
