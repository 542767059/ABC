
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
    unsafe class ZJY_Framework_SocketComponent_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(ZJY.Framework.SocketComponent);
            args = new Type[]{};
            method = type.GetMethod("get_SocketSendMS", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_SocketSendMS_0);
            args = new Type[]{};
            method = type.GetMethod("get_SocketReceiveMS", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_SocketReceiveMS_1);
            args = new Type[]{typeof(ZJY.Framework.IProto)};
            method = type.GetMethod("SendProtoMessage", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, SendProtoMessage_2);


        }


        static StackObject* get_SocketSendMS_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.SocketComponent instance_of_this_method = (ZJY.Framework.SocketComponent)typeof(ZJY.Framework.SocketComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.SocketSendMS;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_SocketReceiveMS_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.SocketComponent instance_of_this_method = (ZJY.Framework.SocketComponent)typeof(ZJY.Framework.SocketComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.SocketReceiveMS;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* SendProtoMessage_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.IProto @proto = (ZJY.Framework.IProto)typeof(ZJY.Framework.IProto).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ZJY.Framework.SocketComponent instance_of_this_method = (ZJY.Framework.SocketComponent)typeof(ZJY.Framework.SocketComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.SendProtoMessage(@proto);

            return __ret;
        }



    }
}
