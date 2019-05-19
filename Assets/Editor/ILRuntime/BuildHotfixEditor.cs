using System.IO;
using UnityEditor;
using UnityEngine;

namespace ZJY.Editor
{
    //[InitializeOnLoad]
    public class Startup
    {
        private const string ScriptAssembliesDir = "Library/ScriptAssemblies";
        private const string CodeDir = "Assets/DownLoad/Hotfix/";
        private const string HotfixDll = "ZJY.Hotfix.dll";
        private const string HotfixPdb = "ZJY.Hotfix.pdb";

        static Startup()
        {
            File.Copy(Path.Combine(ScriptAssembliesDir, HotfixDll), Path.Combine(CodeDir, "Hotfix.dll.bytes"), true);
            File.Copy(Path.Combine(ScriptAssembliesDir, HotfixPdb), Path.Combine(CodeDir, "Hotfix.pdb.bytes"), true);
            Debug.Log($"复制Hotfix.dll, Hotfix.pdb到DownLoad/Hotfix/完成");
            AssetDatabase.Refresh();
        }
    }
}