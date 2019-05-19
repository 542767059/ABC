
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
    unsafe class ZJY_Framework_JobAvtarEntity_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ZJY.Framework.JobAvtarEntity);

            field = type.GetField("AssetName", flag);
            app.RegisterCLRFieldGetter(field, get_AssetName_0);
            app.RegisterCLRFieldSetter(field, set_AssetName_0);


        }



        static object get_AssetName_0(ref object o)
        {
            return ((ZJY.Framework.JobAvtarEntity)o).AssetName;
        }
        static void set_AssetName_0(ref object o, object v)
        {
            ((ZJY.Framework.JobAvtarEntity)o).AssetName = (System.String)v;
        }


    }
}
