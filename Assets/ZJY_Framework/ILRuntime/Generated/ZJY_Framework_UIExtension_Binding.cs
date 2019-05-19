
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
    unsafe class ZJY_Framework_UIExtension_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(ZJY.Framework.UIExtension);
            args = new Type[]{typeof(ZJY.Framework.UIComponent), typeof(ZJY.Framework.UIFormId), typeof(System.Object)};
            method = type.GetMethod("OpenUIForm", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OpenUIForm_0);
            args = new Type[]{typeof(ZJY.Framework.UIComponent), typeof(ZJY.Framework.DialogParams)};
            method = type.GetMethod("OpenDialog", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, OpenDialog_1);


        }


        static StackObject* OpenUIForm_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Object @userData = (System.Object)typeof(System.Object).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ZJY.Framework.UIFormId @uiFormId = (ZJY.Framework.UIFormId)typeof(ZJY.Framework.UIFormId).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ZJY.Framework.UIComponent @uiComponent = (ZJY.Framework.UIComponent)typeof(ZJY.Framework.UIComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            var result_of_this_method = ZJY.Framework.UIExtension.OpenUIForm(@uiComponent, @uiFormId, @userData);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* OpenDialog_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.DialogParams @dialogParams = (ZJY.Framework.DialogParams)typeof(ZJY.Framework.DialogParams).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ZJY.Framework.UIComponent @uiComponent = (ZJY.Framework.UIComponent)typeof(ZJY.Framework.UIComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            ZJY.Framework.UIExtension.OpenDialog(@uiComponent, @dialogParams);

            return __ret;
        }



    }
}
