
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
    unsafe class ZJY_Framework_ButtonHelper_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ZJY.Framework.ButtonHelper);
            args = new Type[]{typeof(System.Int32)};
            method = type.GetMethod("set_Id", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, set_Id_0);
            args = new Type[]{};
            method = type.GetMethod("get_Id", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, get_Id_1);

            field = type.GetField("OnClick", flag);
            app.RegisterCLRFieldGetter(field, get_OnClick_0);
            app.RegisterCLRFieldSetter(field, set_OnClick_0);


        }


        static StackObject* set_Id_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @value = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ZJY.Framework.ButtonHelper instance_of_this_method = (ZJY.Framework.ButtonHelper)typeof(ZJY.Framework.ButtonHelper).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            instance_of_this_method.Id = value;

            return __ret;
        }

        static StackObject* get_Id_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.ButtonHelper instance_of_this_method = (ZJY.Framework.ButtonHelper)typeof(ZJY.Framework.ButtonHelper).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.Id;

            __ret->ObjectType = ObjectTypes.Integer;
            __ret->Value = result_of_this_method;
            return __ret + 1;
        }


        static object get_OnClick_0(ref object o)
        {
            return ((ZJY.Framework.ButtonHelper)o).OnClick;
        }
        static void set_OnClick_0(ref object o, object v)
        {
            ((ZJY.Framework.ButtonHelper)o).OnClick = (System.Action<System.Int32>)v;
        }


    }
}
