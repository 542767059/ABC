using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;
using ZJY.Framework;
using System.Reflection;
using ILHotfix;

namespace ZJY.Editor
{
    [System.Reflection.Obfuscation(Exclude = true)]
    public partial class ILRuntimeCLRBinding
    {
        [MenuItem("Game Framework/ILRuntime/Generate CLR Binding Code")]
        static void GenerateCLRBinding()
        {
            List<Type> types = new List<Type>();
            types.Add(typeof(int));
            types.Add(typeof(float));
            types.Add(typeof(long));
            types.Add(typeof(object));
            types.Add(typeof(string));
            types.Add(typeof(Array));
            types.Add(typeof(Vector2));
            types.Add(typeof(Vector3));
            types.Add(typeof(Quaternion));
            types.Add(typeof(GameObject));
            types.Add(typeof(UnityEngine.Object));
            types.Add(typeof(Transform));
            types.Add(typeof(RectTransform));
            types.Add(typeof(Time));
            types.Add(typeof(Texture));
            types.Add(typeof(Texture2D));
            types.Add(typeof(Resources));
            types.Add(typeof(AssetBundle));
            types.Add(typeof(Camera));
            types.Add(typeof(SystemInfo));
            types.Add(typeof(Time));
            types.Add(typeof(System.Type));
            types.Add(typeof(System.Reflection.MethodInfo));
            types.Add(typeof(System.Reflection.FieldInfo));
            types.Add(typeof(System.Reflection.PropertyInfo));
            types.Add(typeof(Debug));

            //所有DLL内的类型的真实C#类型都是ILTypeInstance
            types.Add(typeof(List<ILRuntime.Runtime.Intepreter.ILTypeInstance>));
            types.Add(typeof(ILRuntime.Runtime.Intepreter.ILTypeInstance));
            types.Add(typeof(System.Array));

            types.Add(typeof(System.Math));
            types.Add(typeof(System.Convert));
            types.Add(typeof(System.DateTime));
            types.Add(typeof(System.TimeSpan));
            types.Add(typeof(System.Text.StringBuilder));
            types.Add(typeof(Dictionary<ILRuntime.Runtime.Intepreter.ILTypeInstance, ILRuntime.Runtime.Intepreter.ILTypeInstance>));
            types.Add(typeof(Dictionary<int, ILRuntime.Runtime.Intepreter.ILTypeInstance>));
            types.Add(typeof(Dictionary<uint, ILRuntime.Runtime.Intepreter.ILTypeInstance>));
            types.Add(typeof(Dictionary<long, ILRuntime.Runtime.Intepreter.ILTypeInstance>));
            types.Add(typeof(Dictionary<ulong, ILRuntime.Runtime.Intepreter.ILTypeInstance>));
            types.Add(typeof(Dictionary<string, ILRuntime.Runtime.Intepreter.ILTypeInstance>));
            types.Add(typeof(System.Text.RegularExpressions.Regex));
            types.Add(typeof(System.Text.RegularExpressions.Group));
            types.Add(typeof(System.Text.RegularExpressions.Match));
            types.Add(typeof(System.Text.RegularExpressions.CaptureCollection));
            types.Add(typeof(System.Text.RegularExpressions.GroupCollection));
            types.Add(typeof(UnityEngine.UI.LayoutElement));
            types.Add(typeof(UnityEngine.UI.Text));
            types.Add(typeof(UnityEngine.UI.Image));
            types.Add(typeof(UnityEngine.UI.Graphic));
            types.Add(typeof(UnityEngine.EventSystems.UIBehaviour));
            types.Add(typeof(UnityEngine.MonoBehaviour));
            types.Add(typeof(UnityEngine.Color));
            types.Add(typeof(HashSet<long>));
            types.Add(typeof(HashSet<int>));
            types.Add(typeof(HashSet<string>));
            types.Add(typeof(System.Linq.Enumerable));
            types.Add(typeof(Canvas));
            types.Add(typeof(Matrix4x4));
            types.Add(typeof(UnityEngine.Video.VideoPlayer));
            types.Add(typeof(System.Enum));
            types.Add(typeof(Screen));

            types.Add(typeof(HotScripts));

            Assembly assembly = null;
            try
            {
                assembly = Assembly.Load("Assembly-CSharp");
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
            foreach (Type type in assembly.GetTypes())
            {
                if (type.ContainsGenericParameters)
                {
                    continue;
                }
                if (type.FullName.Contains("+"))
                {
                    continue;
                }

                if (type.FullName.StartsWith("ZJY.Framework."))
                {
                    types.Add(type);
                }
            }

            try
            {
                ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(types, "Assets/ZJY_Framework/ILRuntime/Generated");
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }


            GenHotfixDelegate.GenOne();
            AssetDatabase.Refresh();
        }

        [MenuItem("Game Framework/ILRuntime/Generate CLR Binding Code by Analysis")]
        static void GenerateCLRBindingByAnalysis()
        {
            //用新的分析热更dll调用引用来生成绑定代码
            byte[] bytes = null;
            ILRuntime.Runtime.Enviorment.AppDomain domain = new ILRuntime.Runtime.Enviorment.AppDomain();
            using (System.IO.FileStream fs = new System.IO.FileStream("Assets/DownLoad/Hotfix/Hotfix.dll.bytes", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
            }
            var dllStream = new System.IO.MemoryStream(bytes);
            domain.LoadAssembly(dllStream);
            //Crossbind Adapter is needed to generate the correct binding code
            ILHelper.InitILRuntime(domain);
            ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(domain, "Assets/ZJY_Framework/ILRuntime/Generated");

            GenHotfixDelegate.GenOne();
            AssetDatabase.Refresh();
        }
        [MenuItem("Game Framework/ILRuntime/Clear")]
        static void ClearCLRBinding()
        {
            string outputPath = "Assets/ZJY_Framework/ILRuntime/Generated";
            if (!System.IO.Directory.Exists(outputPath))
                System.IO.Directory.CreateDirectory(outputPath);
            string[] oldFiles = System.IO.Directory.GetFiles(outputPath, "*.cs");
            foreach (var i in oldFiles)
            {
                System.IO.File.Delete(i);
            }
            GenHotfixDelegate.GenClear();
            ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingInitializeScript(new List<string>(), new List<Type>(), outputPath);
            AssetDatabase.Refresh();
        }
    }

}
