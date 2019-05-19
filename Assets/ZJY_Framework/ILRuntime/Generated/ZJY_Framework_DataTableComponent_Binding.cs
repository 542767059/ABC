
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
    unsafe class ZJY_Framework_DataTableComponent_Binding
    {
        public static void Register(ILRuntime.Runtime.Enviorment.AppDomain app)
        {
            MethodBase method;
            Type[] args;
            Type type = typeof(ZJY.Framework.DataTableComponent);
            Dictionary<string, List<MethodInfo>> genericMethods = new Dictionary<string, List<MethodInfo>>();
            List<MethodInfo> lst = null;                    
            foreach(var m in type.GetMethods())
            {
                if(m.IsGenericMethodDefinition)
                {
                    if (!genericMethods.TryGetValue(m.Name, out lst))
                    {
                        lst = new List<MethodInfo>();
                        genericMethods[m.Name] = lst;
                    }
                    lst.Add(m);
                }
            }
            args = new Type[]{typeof(ZJY.Framework.JobDBModel)};
            if (genericMethods.TryGetValue("GetDataTable", out lst))
            {
                foreach(var m in lst)
                {
                    if(m.MatchGenericParameters(args, typeof(ZJY.Framework.JobDBModel)))
                    {
                        method = m.MakeGenericMethod(args);
                        app.RegisterCLRMethodRedirection(method, GetDataTable_0);

                        break;
                    }
                }
            }
            args = new Type[]{typeof(ZJY.Framework.SceneDBModel)};
            if (genericMethods.TryGetValue("GetDataTable", out lst))
            {
                foreach(var m in lst)
                {
                    if(m.MatchGenericParameters(args, typeof(ZJY.Framework.SceneDBModel)))
                    {
                        method = m.MakeGenericMethod(args);
                        app.RegisterCLRMethodRedirection(method, GetDataTable_1);

                        break;
                    }
                }
            }
            args = new Type[]{typeof(ZJY.Framework.JobAvtarDBModel)};
            if (genericMethods.TryGetValue("GetDataTable", out lst))
            {
                foreach(var m in lst)
                {
                    if(m.MatchGenericParameters(args, typeof(ZJY.Framework.JobAvtarDBModel)))
                    {
                        method = m.MakeGenericMethod(args);
                        app.RegisterCLRMethodRedirection(method, GetDataTable_2);

                        break;
                    }
                }
            }


        }


        static StackObject* GetDataTable_0(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.DataTableComponent instance_of_this_method = (ZJY.Framework.DataTableComponent)typeof(ZJY.Framework.DataTableComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetDataTable<ZJY.Framework.JobDBModel>();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* GetDataTable_1(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.DataTableComponent instance_of_this_method = (ZJY.Framework.DataTableComponent)typeof(ZJY.Framework.DataTableComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetDataTable<ZJY.Framework.SceneDBModel>();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }

        static StackObject* GetDataTable_2(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 1);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            ZJY.Framework.DataTableComponent instance_of_this_method = (ZJY.Framework.DataTableComponent)typeof(ZJY.Framework.DataTableComponent).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            var result_of_this_method = instance_of_this_method.GetDataTable<ZJY.Framework.JobAvtarDBModel>();

            return ILIntepreter.PushObject(__ret, __mStack, result_of_this_method);
        }



    }
}
