
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
    unsafe class RoleOperation_EnterGameProto_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(global::RoleOperation_EnterGameProto);

            field = type.GetField("RoleId", flag);
            app.RegisterCLRFieldGetter(field, get_RoleId_0);
            app.RegisterCLRFieldSetter(field, set_RoleId_0);

            app.RegisterCLRMemberwiseClone(type, PerformMemberwiseClone);

            app.RegisterCLRCreateDefaultInstance(type, () => new global::RoleOperation_EnterGameProto());


        }

        static void WriteBackInstance(ILRuntime.Runtime.Enviorment.AppDomain __domain, StackObject* ptr_of_this_method, IList<object> __mStack, ref global::RoleOperation_EnterGameProto instance_of_this_method)
        {
            ptr_of_this_method = ILIntepreter.GetObjectAndResolveReference(ptr_of_this_method);
            switch(ptr_of_this_method->ObjectType)
            {
                case ObjectTypes.Object:
                    {
                        __mStack[ptr_of_this_method->Value] = instance_of_this_method;
                    }
                    break;
                case ObjectTypes.FieldReference:
                    {
                        var ___obj = __mStack[ptr_of_this_method->Value];
                        if(___obj is ILTypeInstance)
                        {
                            ((ILTypeInstance)___obj)[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            var t = __domain.GetType(___obj.GetType()) as CLRType;
                            t.SetFieldValue(ptr_of_this_method->ValueLow, ref ___obj, instance_of_this_method);
                        }
                    }
                    break;
                case ObjectTypes.StaticFieldReference:
                    {
                        var t = __domain.GetType(ptr_of_this_method->Value);
                        if(t is ILType)
                        {
                            ((ILType)t).StaticInstance[ptr_of_this_method->ValueLow] = instance_of_this_method;
                        }
                        else
                        {
                            ((CLRType)t).SetStaticFieldValue(ptr_of_this_method->ValueLow, instance_of_this_method);
                        }
                    }
                    break;
                 case ObjectTypes.ArrayReference:
                    {
                        var instance_of_arrayReference = __mStack[ptr_of_this_method->Value] as global::RoleOperation_EnterGameProto[];
                        instance_of_arrayReference[ptr_of_this_method->ValueLow] = instance_of_this_method;
                    }
                    break;
            }
        }


        static object get_RoleId_0(ref object o)
        {
            return ((global::RoleOperation_EnterGameProto)o).RoleId;
        }
        static void set_RoleId_0(ref object o, object v)
        {
            var h = GCHandle.Alloc(o, GCHandleType.Pinned);
            global::RoleOperation_EnterGameProto* p = (global::RoleOperation_EnterGameProto *)(void *)h.AddrOfPinnedObject();
            p->RoleId = (System.Int32)v;
            h.Free();
        }

        static object PerformMemberwiseClone(ref object o)
        {
            var ins = new global::RoleOperation_EnterGameProto();
            ins = (global::RoleOperation_EnterGameProto)o;
            return ins;
        }


    }
}
