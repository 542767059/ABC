
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
    unsafe class ZJY_Framework_GameEntry_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(ZJY.Framework.GameEntry);
            args = new Type[]{};
            method = type.GetMethod("get_Socket", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Socket_0);
            args = new Type[]{};
            method = type.GetMethod("get_Event", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Event_1);
            args = new Type[]{};
            method = type.GetMethod("get_Pool", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Pool_2);
            args = new Type[]{};
            method = type.GetMethod("get_Resource", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Resource_3);
            args = new Type[]{};
            method = type.GetMethod("get_Entity", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Entity_4);
            args = new Type[]{};
            method = type.GetMethod("get_DataTable", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_DataTable_5);
            args = new Type[]{};
            method = type.GetMethod("get_Avtar", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Avtar_6);
            args = new Type[]{};
            method = type.GetMethod("get_Controller", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Controller_7);
            args = new Type[]{};
            method = type.GetMethod("get_Data", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Data_8);
            args = new Type[]{};
            method = type.GetMethod("get_UI", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_UI_9);
            args = new Type[]{};
            method = type.GetMethod("get_Procedure", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Procedure_10);


        }


        static StackObject* get_Socket_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ZJY.Framework.GameEntry.Socket;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_Event_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ZJY.Framework.GameEntry.Event;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_Pool_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ZJY.Framework.GameEntry.Pool;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_Resource_3(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ZJY.Framework.GameEntry.Resource;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_Entity_4(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ZJY.Framework.GameEntry.Entity;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_DataTable_5(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ZJY.Framework.GameEntry.DataTable;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_Avtar_6(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ZJY.Framework.GameEntry.Avtar;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_Controller_7(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ZJY.Framework.GameEntry.Controller;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_Data_8(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ZJY.Framework.GameEntry.Data;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_UI_9(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ZJY.Framework.GameEntry.UI;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* get_Procedure_10(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* __ret = ILIntepreter.Minus(__esp, 0);


            var result_of_this_method = ZJY.Framework.GameEntry.Procedure;

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }



    }
}
