using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZJY.Framework
{
    /// <summary>
    /// Splash动画流程
    /// </summary>
    public class ProcedureSplash : ProcedureBase
    {
        private float m_SplashTime;
        private bool m_Lunchfirst = true;
        public override void OnEnter()
        {
            base.OnEnter();
            m_SplashTime = 0f;
            InitForm.Instance.HideCG = HideCG;
        }

        /// <summary>
        /// CG按钮点击
        /// </summary>
        /// <returns></returns>
        private void HideCG()
        {
            InitForm.Instance.ShowProgress("正在进行初始化", 0);
            RequestWebInit();
        }

        public override void OnUpdate(float deltaTime, float unscaledDeltaTime)
        {
            base.OnUpdate(deltaTime, unscaledDeltaTime);

            if (!m_Lunchfirst)
            {
                return;
            }
            m_SplashTime += deltaTime;

            InitForm.Instance.ShowSplash(m_SplashTime);

            if (m_SplashTime > 5f)
            {
                m_Lunchfirst = false;
                // 编辑器模式下，直接进入预加载流程；否则，检查一下版本
                InitForm.Instance.HideSplash();
            }

        }


        private void RequestWebInit()
        {
            //访问帐号服务器
            string url = GameEntry.Http.RealWebAccountUrl + "/api/init";

            Dictionary<string, object> dic = GameEntry.Pool.SpawnClassObject<Dictionary<string, object>>();
            dic.Clear();
            dic["ChannelId"] = 0;
            dic["InnerVersion"] = 1001;

            GameEntry.Http.SendData(url, OnWebAccountInit, true, dic);
        }
        /// <summary>
        /// 帐号服务器访问回调
        /// </summary>
        /// <param name="args"></param>
        private void OnWebAccountInit(HttpCallBackArgs args)
        {
            if (!args.HasError)
            {
                LitJson.JsonData data = LitJson.JsonMapper.ToObject(args.Value);

                bool hasError = (bool)data["HasError"];
                if (!hasError)
                {
                    LitJson.JsonData config = LitJson.JsonMapper.ToObject(data["Value"].ToString());

                    GameEntry.Data.SystemData.CurrAccountServerTime = long.Parse(config["ServerTime"].ToString());
                    //GameEntry.Data.SystemData.SourceUrl = config["SourceUrl"].ToString();
                    Debug.Log("暂时直接使用目标地址CDN，正式使用使用上面的回调");
                    {
                        GameEntry.Data.SystemData.SourceUrl = GameEntry.Http.RealWebAccountUrl.Replace(":8080", ":8081/");
                    }
                    GameEntry.Data.SystemData.RechargeUrl = config["RechargeUrl"].ToString();
                    GameEntry.Data.SystemData.TDAppId = config["TDAppId"].ToString();
                    GameEntry.Data.SystemData.IsOpenTD = int.Parse(config["IsOpenTD"].ToString()) == 1;

                    GameEntry.Data.SystemData.VersionLength = int.Parse(config["VersionLength"].ToString());
                    GameEntry.Data.SystemData.VersionHashCode = int.Parse(config["VersionHashCode"].ToString());
                    GameEntry.Data.SystemData.VersionZipLength = int.Parse(config["VersionZipLength"].ToString());
                    GameEntry.Data.SystemData.VersionZipHashCode = int.Parse(config["VersionZipHashCode"].ToString());

                    Log.Info("ServerTime==" + GameEntry.Data.SystemData.CurrAccountServerTime);
                    Log.Info("SourceUrl==" + GameEntry.Data.SystemData.SourceUrl);

                    ChangeState(GameEntry.Resource.EditorResourceMode ? typeof(ProcedurePreload) : typeof(ProcedureCheckVersion));
                }
                else
                {
                    string msg = data["ErrorMsg"].ToString();
                    Log.Error(msg);
                    Debug.LogError("无法连接到网络请重试!");
                    //todo
                }
            }
        }
    }
}
