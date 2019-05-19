using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ZJY.Framework
{
    public static class UIExtension
    {
        public static IEnumerator FadeToAlpha(this CanvasGroup canvasGroup, float alpha, float duration)
        {
            float time = 0f;
            float originalAlpha = canvasGroup.alpha;
            while (time < duration)
            {
                time += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(originalAlpha, alpha, time / duration);
                yield return new WaitForEndOfFrame();
            }

            canvasGroup.alpha = alpha;
        }

        public static IEnumerator SmoothValue(this Slider slider, float value, float duration)
        {
            float time = 0f;
            float originalValue = slider.value;
            while (time < duration)
            {
                time += Time.deltaTime;
                slider.value = Mathf.Lerp(originalValue, value, time / duration);
                yield return new WaitForEndOfFrame();
            }

            slider.value = value;
        }

        public static bool HasUIForm(this UIComponent uiComponent, UIFormId uiFormId, string uiGroupName = null)
        {
            return uiComponent.HasUIForm((int)uiFormId, uiGroupName);
        }

        public static bool HasUIForm(this UIComponent uiComponent, int uiFormId, string uiGroupName = null)
        {
            UIFormDBModel uiFormDBModel = GameEntry.DataTable.GetDataTable<UIFormDBModel>();
            UIFormEntity uiFormEntity = uiFormDBModel.Get(uiFormId);
            if (uiFormEntity == null)
            {
                return false;
            }

            string assetName = AssetUtility.GetUIFormAsset(uiFormEntity.AssetName);
            if (string.IsNullOrEmpty(uiGroupName))
            {
                return uiComponent.HasUIForm(assetName);
            }

            UIGroup uiGroup = uiComponent.GetUIGroup(uiGroupName);
            if (uiGroup == null)
            {
                return false;
            }

            return uiGroup.HasUIForm(assetName);
        }

        public static UIForm GetUIForm(this UIComponent uiComponent, UIFormId uiFormId, string uiGroupName = null)
        {
            return uiComponent.GetUIForm((int)uiFormId, uiGroupName);
        }

        public static UIForm GetUIForm(this UIComponent uiComponent, int uiFormId, string uiGroupName = null)
        {
            UIFormDBModel uiFormDBModel = GameEntry.DataTable.GetDataTable<UIFormDBModel>();
            UIFormEntity uiFormEntity = uiFormDBModel.Get(uiFormId);
            if (uiFormEntity == null)
            {
                return null;
            }

            string assetName = AssetUtility.GetUIFormAsset(uiFormEntity.AssetName);
            UIForm uiForm = null;
            if (string.IsNullOrEmpty(uiGroupName))
            {
                uiForm = (UIForm)uiComponent.GetUIForm(assetName);
                if (uiForm == null)
                {
                    return null;
                }

                return uiForm;
            }

            UIGroup uiGroup = uiComponent.GetUIGroup(uiGroupName);
            if (uiGroup == null)
            {
                return null;
            }

            uiForm = (UIForm)uiGroup.GetUIForm(assetName);
            if (uiForm == null)
            {
                return null;
            }

            return uiForm;
        }

        public static int? OpenUIForm(this UIComponent uiComponent, UIFormId uiFormId, object userData = null)
        {
            return uiComponent.OpenUIForm((int)uiFormId, userData);
        }

        public static int? OpenUIForm(this UIComponent uiComponent, int uiFormId, object userData = null)
        {
            UIFormDBModel uiFormDBModel = GameEntry.DataTable.GetDataTable<UIFormDBModel>();
            UIFormEntity uiFormEntity = uiFormDBModel.Get(uiFormId);
            if (uiFormEntity == null)
            {
                Log.Warning("Can not load UI form '{0}' from data table.", uiFormId.ToString());
                return null;
            }

            string assetName = AssetUtility.GetUIFormAsset(uiFormEntity.AssetName);

            //读表 
            if (!uiFormEntity.AllowMultiInstance)
            {
                if (uiComponent.IsLoadingUIForm(assetName))
                {
                    return null;
                }

                if (uiComponent.HasUIForm(assetName))
                {
                    return null;
                }
            }

            return uiComponent.OpenUIForm(assetName, uiFormEntity.UIGroupName, Constant.AssetPriority.UIFormAsset, uiFormEntity.PauseCoveredUIForm, userData);
        }

        public static void CloseDefaultUIForm(this UIComponent uiComponent)
        {
            uiComponent.CloseAllLoadingUIForms();
            UIGroup defalutGroup = uiComponent.GetUIGroup("Default");
            if (defalutGroup == null)
            {
                return;
            }
            UIFormBase[] allUIForm = defalutGroup.GetAllUIForms();
            foreach (var uiForm in allUIForm)
            {
                uiComponent.CloseUIForm(uiForm);
            }
        }

        /// <summary>
        /// 打开提示窗口
        /// </summary>
        /// <param name="uiComponent"></param>
        /// <param name="dialogParams">提示参数</param>
        public static void OpenDialog(this UIComponent uiComponent, DialogParams dialogParams)
        {
            uiComponent.OpenUIForm(UIFormId.DialogForm, dialogParams);
        }
    }
}
