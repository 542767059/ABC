
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
    unsafe class ZJY_Framework_JobEntity_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            FieldInfo field;
            Type[] args;
            Type type = typeof(ZJY.Framework.JobEntity);

            field = type.GetField("AssetName", flag);
            app.RegisterCLRFieldGetter(field, get_AssetName_0);
            app.RegisterCLRFieldSetter(field, set_AssetName_0);
            field = type.GetField("RoleController", flag);
            app.RegisterCLRFieldGetter(field, get_RoleController_1);
            app.RegisterCLRFieldSetter(field, set_RoleController_1);
            field = type.GetField("HeadNotSelectAssetName", flag);
            app.RegisterCLRFieldGetter(field, get_HeadNotSelectAssetName_2);
            app.RegisterCLRFieldSetter(field, set_HeadNotSelectAssetName_2);
            field = type.GetField("HeadSelectAssetName", flag);
            app.RegisterCLRFieldGetter(field, get_HeadSelectAssetName_3);
            app.RegisterCLRFieldSetter(field, set_HeadSelectAssetName_3);
            field = type.GetField("DescAllAssetName", flag);
            app.RegisterCLRFieldGetter(field, get_DescAllAssetName_4);
            app.RegisterCLRFieldSetter(field, set_DescAllAssetName_4);
            field = type.GetField("DescSpecificAssetName", flag);
            app.RegisterCLRFieldGetter(field, get_DescSpecificAssetName_5);
            app.RegisterCLRFieldSetter(field, set_DescSpecificAssetName_5);


        }



        static object get_AssetName_0(ref object o)
        {
            return ((ZJY.Framework.JobEntity)o).AssetName;
        }
        static void set_AssetName_0(ref object o, object v)
        {
            ((ZJY.Framework.JobEntity)o).AssetName = (System.String)v;
        }
        static object get_RoleController_1(ref object o)
        {
            return ((ZJY.Framework.JobEntity)o).RoleController;
        }
        static void set_RoleController_1(ref object o, object v)
        {
            ((ZJY.Framework.JobEntity)o).RoleController = (System.String)v;
        }
        static object get_HeadNotSelectAssetName_2(ref object o)
        {
            return ((ZJY.Framework.JobEntity)o).HeadNotSelectAssetName;
        }
        static void set_HeadNotSelectAssetName_2(ref object o, object v)
        {
            ((ZJY.Framework.JobEntity)o).HeadNotSelectAssetName = (System.String)v;
        }
        static object get_HeadSelectAssetName_3(ref object o)
        {
            return ((ZJY.Framework.JobEntity)o).HeadSelectAssetName;
        }
        static void set_HeadSelectAssetName_3(ref object o, object v)
        {
            ((ZJY.Framework.JobEntity)o).HeadSelectAssetName = (System.String)v;
        }
        static object get_DescAllAssetName_4(ref object o)
        {
            return ((ZJY.Framework.JobEntity)o).DescAllAssetName;
        }
        static void set_DescAllAssetName_4(ref object o, object v)
        {
            ((ZJY.Framework.JobEntity)o).DescAllAssetName = (System.String)v;
        }
        static object get_DescSpecificAssetName_5(ref object o)
        {
            return ((ZJY.Framework.JobEntity)o).DescSpecificAssetName;
        }
        static void set_DescSpecificAssetName_5(ref object o, object v)
        {
            ((ZJY.Framework.JobEntity)o).DescSpecificAssetName = (System.String)v;
        }


    }
}
