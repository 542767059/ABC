using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System.Text;
using ZJY.Framework;

namespace ZJY.Editor
{
    public class Menu
    {
        [MenuItem("Game Framework/Setting", false, 30)]
        public static void Settings()
        {
            SettingsWindow win = (SettingsWindow)EditorWindow.GetWindow(typeof(SettingsWindow));
            win.titleContent = new GUIContent("Setting");
            win.Show();
        }


        [MenuItem("自定义工具/资源管理/资源打包管理")]
        public static void AssetBundleCreate()
        {
            AssetBundleWindow win = EditorWindow.GetWindow<AssetBundleWindow>();
            win.titleContent = new GUIContent("资源打包");
            win.Show();
        }

        [MenuItem("自定义工具/资源管理/初始资源拷贝到StreamingAsstes")]
        public static void AssetBundleCopyToStreamingAsstes()
        {
            string toPath = Application.streamingAssetsPath + "/AssetBundles/";

            if (Directory.Exists(toPath))
            {
                Directory.Delete(toPath, true);
            }
            Directory.CreateDirectory(toPath);

            IOUtil.CopyDirectory(Application.persistentDataPath, toPath);
            AssetDatabase.Refresh();
            Debug.Log("拷贝完毕");
        }

        [MenuItem("GameObject/CreateTempUIForm", false, -100)]
        static void CreateTempUIForm()
        {
            if (Selection.transforms.Length == 0)
            {
                return;
            }

            Transform trans = Selection.transforms[0];

            HotfixForm hotfixForm = trans.GetComponent<HotfixForm>();
            if (hotfixForm == null)
            {
                Debug.LogError("该UI上没有HotfixForm脚本");
                return;
            }

            string viewName = trans.gameObject.name;

            HotFormInfo[] hotFormInfos = hotfixForm.HotFormInfos;

            int len = hotFormInfos.Length;

            StringBuilder sbr = new StringBuilder();
            sbr.Append("using UnityEngine;\r\n");
            sbr.Append("using UnityEngine.UI;\r\n");
            sbr.Append("using ZJY.Framework;\r\n");
            sbr.Append("\r\n");
            sbr.Append("namespace Hotfix\r\n");
            sbr.Append("{\r\n");
            sbr.AppendFormat("    public class {0}View : HotUIForm\r\n", viewName);
            sbr.Append("    {\r\n");

            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 窗口控制器\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.AppendFormat("        private {0}Ctrl m_{0}Ctrl;\r\n", viewName);
            sbr.Append("\r\n");

            sbr.Append("        #region 组件\r\n");
            for (int i = 0; i < len; i++)
            {
                HotFormInfo hotFormInfo = hotFormInfos[i];
                sbr.Append("        /// <summary>\r\n");
                sbr.AppendFormat("        /// {0}\r\n", hotFormInfo.Name);
                sbr.Append("        /// </summary>\r\n");
                if (hotFormInfo.HotAttributeType == HotAttributeType.Unknow)
                {
                    sbr.AppendFormat("        public {0} {1}\r\n", "Transform", hotFormInfo.Trans.name);
                }
                else
                {
                    sbr.AppendFormat("        public {0} {1}\r\n", hotFormInfo.HotAttributeType.ToString(), hotFormInfo.Trans.name);
                }
                
                sbr.Append("        {\r\n");
                sbr.Append("            get;\r\n");
                sbr.Append("            private set;\r\n");
                sbr.Append("        }\r\n");
                sbr.Append("\r\n");
            }
            sbr.Append("        #endregion\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面初始化\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"uiForm\">真正的UI窗口</param>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.Append("        public override void OnInit(HotfixForm uiForm, object userData)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("            base.OnInit(uiForm, userData);\r\n");

            for (int i = 0; i < len; i++)
            {
                HotFormInfo hotFormInfo = hotFormInfos[i];
                if (hotFormInfo.HotAttributeType == HotAttributeType.Unknow)
                {
                    sbr.AppendFormat("            {0} = uiForm.GetTransType({1}) as {2};\r\n", hotFormInfo.TransformName.ToString(), i.ToString(), "Transform");
                }
                else
                {
                    sbr.AppendFormat("            {0} = uiForm.GetTransType({1}) as {2};\r\n", hotFormInfo.TransformName.ToString(), i.ToString(), hotFormInfo.HotAttributeType.ToString());
                }    
            }

            sbr.AppendFormat("            m_{0}Ctrl = new {0}Ctrl();\r\n", viewName);
            sbr.AppendFormat("            m_{0}Ctrl.OnInit(this, userData);\r\n", viewName);
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面打开\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.Append("        public override void OnOpen(object userData)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("            base.OnOpen(userData);\r\n");
            sbr.AppendFormat("            m_{0}Ctrl.OnOpen(userData);\r\n", viewName);
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面关闭\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.Append("        public override void OnClose(object userData)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("            base.OnClose(userData);\r\n");
            sbr.AppendFormat("            m_{0}Ctrl.OnClose(userData);\r\n", viewName);
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面暂停\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        public override void OnPause()\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("            base.OnPause();\r\n");
            sbr.AppendFormat("            m_{0}Ctrl.OnPause();\r\n", viewName);
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面暂停恢复\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.Append("        public override void OnResume(object userData)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("            base.OnResume(userData);\r\n");
            sbr.AppendFormat("            m_{0}Ctrl.OnResume(userData);\r\n", viewName);
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面遮挡\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.Append("        public override void OnCover(object userData)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("            base.OnCover(userData);\r\n");
            sbr.AppendFormat("            m_{0}Ctrl.OnCover(userData);\r\n", viewName);
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面遮挡恢复\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        public override void OnReveal()\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("            base.OnReveal();\r\n");
            sbr.AppendFormat("            m_{0}Ctrl.OnReveal();\r\n", viewName);
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面激活\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.Append("        public override void OnRefocus(object userData)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("            base.OnRefocus(userData);\r\n");
            sbr.AppendFormat("            m_{0}Ctrl.OnRefocus(userData);\r\n", viewName);
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面轮询\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"deltaTime\">逻辑流逝时间，以秒为单位</param>\r\n");
            sbr.Append("        /// <param name=\"unscaledDeltaTime\">真实流逝时间，以秒为单位</param>\r\n");
            sbr.Append("        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("            base.OnUpdate(deltaTime, unscaledDeltaTime);\r\n");
            sbr.AppendFormat("            m_{0}Ctrl.OnUpdate(deltaTime, unscaledDeltaTime);\r\n", viewName);
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面深度改变\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"uiGroupDepth\">界面组深度</param>\r\n");
            sbr.Append("        /// <param name=\"depthInUIGroup\">界面在界面组中的深度</param>\r\n");
            sbr.Append("        public override void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("            base.OnDepthChanged(uiGroupDepth, depthInUIGroup);\r\n");
            sbr.AppendFormat("            m_{0}Ctrl.OnDepthChanged(uiGroupDepth, depthInUIGroup);\r\n", viewName);
            sbr.Append("        }\r\n");
            sbr.Append("    }\r\n");
            sbr.Append("}\r\n");

            string viewpath = Application.dataPath + "/../Hotfix/Module/UI/Temp/" + viewName + "View.cs";

            using (FileStream fs = new FileStream(viewpath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(sbr.ToString());
                }
            }

            sbr.Length = 0;
            sbr.Append("using UnityEngine;\r\n");
            sbr.Append("using UnityEngine.UI;\r\n");
            sbr.Append("using ZJY.Framework;\r\n");
            sbr.Append("\r\n");
            sbr.Append("namespace Hotfix\r\n");
            sbr.Append("{\r\n");
            sbr.AppendFormat("    public class {0}Ctrl\r\n", viewName);
            sbr.Append("    {\r\n");

            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 控制的窗口\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.AppendFormat("        private {0}View m_{0}View;\r\n", viewName);

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面初始化\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"view\">控制的窗口</param>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.AppendFormat("        public void OnInit({0}View view, object userData)\r\n", viewName);
            sbr.Append("        {\r\n");
            sbr.AppendFormat("            m_{0}View = view;\r\n", viewName);
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面打开\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.Append("        public void OnOpen(object userData)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面关闭\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.Append("        public void OnClose(object userData)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面暂停\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        public void OnPause()\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面暂停恢复\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.Append("        public void OnResume(object userData)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面遮挡\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.Append("        public void OnCover(object userData)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面遮挡恢复\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        public void OnReveal()\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面激活\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"userData\">用户数据</param>\r\n");
            sbr.Append("        public void OnRefocus(object userData)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面轮询\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"deltaTime\">逻辑流逝时间，以秒为单位</param>\r\n");
            sbr.Append("        /// <param name=\"unscaledDeltaTime\">真实流逝时间，以秒为单位</param>\r\n");
            sbr.Append("        public void OnUpdate(float deltaTime, float unscaledDeltaTime)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("        }\r\n");

            sbr.Append("\r\n");
            sbr.Append("        /// <summary>\r\n");
            sbr.Append("        /// 界面深度改变\r\n");
            sbr.Append("        /// </summary>\r\n");
            sbr.Append("        /// <param name=\"uiGroupDepth\">界面组深度</param>\r\n");
            sbr.Append("        /// <param name=\"depthInUIGroup\">界面在界面组中的深度</param>\r\n");
            sbr.Append("        public void OnDepthChanged(int uiGroupDepth, int depthInUIGroup)\r\n");
            sbr.Append("        {\r\n");
            sbr.Append("        }\r\n");
            sbr.Append("    }\r\n");
            sbr.Append("}\r\n");

            string ctrlpath = Application.dataPath + "/../Hotfix/Module/UI/Temp/" + viewName + "Ctrl.cs";

            using (FileStream fs = new FileStream(ctrlpath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(sbr.ToString());
                }
            }

            UnityEditor.EditorUtility.DisplayDialog("Create view & ctrl", "Create Temp View And Ctrl OK！", "OK");
        }

        [InitializeOnLoadMethod]
        static void StartInitializeOnLoadMethod()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
        }

        static void OnHierarchyGUI(int instanceID, Rect selectionRect)
        {
            if (Event.current != null && selectionRect.Contains(Event.current.mousePosition)
                && Event.current.button == 1 && Event.current.type <= EventType.MouseUp)
            {
                GameObject selectedGameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
                //这里可以判断selectedGameObject的条件
                if (selectedGameObject.GetComponent<HotfixForm>() != null)
                {
                    Vector2 mousePosition = Event.current.mousePosition;

                    EditorUtility.DisplayPopupMenu(new Rect(mousePosition.x, mousePosition.y, 0, 0), "GameObject", null);
                    Event.current.Use();
                }
            }
        }
    }
}