
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
    unsafe class ZJY_Framework_DataTableDBModelBase_2_SceneDBModel_SceneEntity_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(ZJY.Framework.DataTableDBModelBase<ZJY.Framework.SceneDBModel, ZJY.Framework.SceneEntity>);
            args = new Type[]{typeof(System.Int32)};
            method = type.GetMethod("Get", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, Get_0);


        }


        static StackObject* Get_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 2);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @id = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            ZJY.Framework.DataTableDBModelBase<ZJY.Framework.SceneDBModel, ZJY.Framework.SceneEntity> instance_of_this_method = (ZJY.Framework.DataTableDBModelBase<ZJY.Framework.SceneDBModel, ZJY.Framework.SceneEntity>)typeof(ZJY.Framework.DataTableDBModelBase<ZJY.Framework.SceneDBModel, ZJY.Framework.SceneEntity>).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.Get(@id);

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }



    }
}
