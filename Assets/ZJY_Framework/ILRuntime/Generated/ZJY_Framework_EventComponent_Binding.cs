
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
    unsafe class ZJY_Framework_EventComponent_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ZJY.Framework.EventComponent);

            field = type.GetField("CommonEvent", flag);
            app.RegisterCLRFieldGetter(field, get_CommonEvent_0);
            app.RegisterCLRFieldSetter(field, set_CommonEvent_0);
            field = type.GetField("SocketEvent", flag);
            app.RegisterCLRFieldGetter(field, get_SocketEvent_1);
            app.RegisterCLRFieldSetter(field, set_SocketEvent_1);


        }



        static object get_CommonEvent_0(ref object o)
        {
            return ((ZJY.Framework.EventComponent)o).CommonEvent;
        }
        static void set_CommonEvent_0(ref object o, object v)
        {
            ((ZJY.Framework.EventComponent)o).CommonEvent = (ZJY.Framework.CommonEvent)v;
        }
        static object get_SocketEvent_1(ref object o)
        {
            return ((ZJY.Framework.EventComponent)o).SocketEvent;
        }
        static void set_SocketEvent_1(ref object o, object v)
        {
            ((ZJY.Framework.EventComponent)o).SocketEvent = (ZJY.Framework.SocketEvent)v;
        }


    }
}
