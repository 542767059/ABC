
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
    unsafe class ZJY_Framework_CommonEvent_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(ZJY.Framework.CommonEvent);
            args = new Type[]{typeof(System.Object), typeof(ZJY.Framework.GameEventBase)};
            method = type.GetMethod("Dispatch", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Dispatch_0);
            args = new Type[]{typeof(System.Int32), typeof(ZJY.Framework.CommonEvent.OnActionHandler)};
            method = type.GetMethod("AddEventListener", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, AddEventListener_1);
            args = new Type[]{typeof(System.Int32), typeof(ZJY.Framework.CommonEvent.OnActionHandler)};
            method = type.GetMethod("RemoveEventListener", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, RemoveEventListener_2);


        }


        static StackObject* Dispatch_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.GameEventBase @gameEventBase = (ZJY.Framework.GameEventBase)typeof(ZJY.Framework.GameEventBase).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Object @sender = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ZJY.Framework.CommonEvent instance_of_this_method = (ZJY.Framework.CommonEvent)typeof(ZJY.Framework.CommonEvent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Dispatch(@sender, @gameEventBase);

            return __ret;
        }

        static StackObject* AddEventListener_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.CommonEvent.OnActionHandler @handler = (ZJY.Framework.CommonEvent.OnActionHandler)typeof(ZJY.Framework.CommonEvent.OnActionHandler).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Int32 @key = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ZJY.Framework.CommonEvent instance_of_this_method = (ZJY.Framework.CommonEvent)typeof(ZJY.Framework.CommonEvent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.AddEventListener(@key, @handler);

            return __ret;
        }

        static StackObject* RemoveEventListener_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.CommonEvent.OnActionHandler @handler = (ZJY.Framework.CommonEvent.OnActionHandler)typeof(ZJY.Framework.CommonEvent.OnActionHandler).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Int32 @key = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ZJY.Framework.CommonEvent instance_of_this_method = (ZJY.Framework.CommonEvent)typeof(ZJY.Framework.CommonEvent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.RemoveEventListener(@key, @handler);

            return __ret;
        }



    }
}
