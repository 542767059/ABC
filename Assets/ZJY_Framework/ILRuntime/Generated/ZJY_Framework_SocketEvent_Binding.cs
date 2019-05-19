
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
    unsafe class ZJY_Framework_SocketEvent_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(ZJY.Framework.SocketEvent);
            args = new Type[]{typeof(System.UInt16), typeof(ZJY.Framework.SocketEvent.OnActionHandler)};
            method = type.GetMethod("AddEventListener", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, AddEventListener_0);
            args = new Type[]{typeof(System.UInt16), typeof(ZJY.Framework.SocketEvent.OnActionHandler)};
            method = type.GetMethod("RemoveEventListener", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, RemoveEventListener_1);


        }


        static StackObject* AddEventListener_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.SocketEvent.OnActionHandler @handler = (ZJY.Framework.SocketEvent.OnActionHandler)typeof(ZJY.Framework.SocketEvent.OnActionHandler).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt16 @key = (ushort)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ZJY.Framework.SocketEvent instance_of_this_method = (ZJY.Framework.SocketEvent)typeof(ZJY.Framework.SocketEvent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.AddEventListener(@key, @handler);

            return __ret;
        }

        static StackObject* RemoveEventListener_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.SocketEvent.OnActionHandler @handler = (ZJY.Framework.SocketEvent.OnActionHandler)typeof(ZJY.Framework.SocketEvent.OnActionHandler).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.UInt16 @key = (ushort)ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ZJY.Framework.SocketEvent instance_of_this_method = (ZJY.Framework.SocketEvent)typeof(ZJY.Framework.SocketEvent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.RemoveEventListener(@key, @handler);

            return __ret;
        }



    }
}
