
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
    unsafe class ZJY_Framework_EntityExtension_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(ZJY.Framework.EntityExtension);
            args = new Type[]{typeof(ZJY.Framework.EntityComponent), typeof(ZJY.Framework.Entity), typeof(System.Int32), typeof(System.Int32)};
            method = type.GetMethod("ShowWing", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ShowWing_0);
            args = new Type[]{typeof(ZJY.Framework.EntityComponent), typeof(ZJY.Framework.Entity), typeof(System.Int32), typeof(System.Int32)};
            method = type.GetMethod("ShowWeapon", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ShowWeapon_1);
            args = new Type[]{typeof(ZJY.Framework.EntityComponent), typeof(ZJY.Framework.Entity), typeof(System.Int32), typeof(System.Int32)};
            method = type.GetMethod("ShowMagic", flag, null, args, null);
            app.RegisterCLRMethodRedirection(method, ShowMagic_2);


        }


        static StackObject* ShowWing_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @wingTypeId = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Int32 @jobId = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ZJY.Framework.Entity @owner = (ZJY.Framework.Entity)typeof(ZJY.Framework.Entity).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            ZJY.Framework.EntityComponent @entityComponent = (ZJY.Framework.EntityComponent)typeof(ZJY.Framework.EntityComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            ZJY.Framework.EntityExtension.ShowWing(@entityComponent, @owner, @jobId, @wingTypeId);

            return __ret;
        }

        static StackObject* ShowWeapon_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @wingTypeId = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Int32 @jobId = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ZJY.Framework.Entity @owner = (ZJY.Framework.Entity)typeof(ZJY.Framework.Entity).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            ZJY.Framework.EntityComponent @entityComponent = (ZJY.Framework.EntityComponent)typeof(ZJY.Framework.EntityComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            ZJY.Framework.EntityExtension.ShowWeapon(@entityComponent, @owner, @jobId, @wingTypeId);

            return __ret;
        }

        static StackObject* ShowMagic_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 4);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Int32 @wingTypeId = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Int32 @jobId = ptr_of_this_method->Value;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            ZJY.Framework.Entity @owner = (ZJY.Framework.Entity)typeof(ZJY.Framework.Entity).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            ZJY.Framework.EntityComponent @entityComponent = (ZJY.Framework.EntityComponent)typeof(ZJY.Framework.EntityComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);


            ZJY.Framework.EntityExtension.ShowMagic(@entityComponent, @owner, @jobId, @wingTypeId);

            return __ret;
        }



    }
}
