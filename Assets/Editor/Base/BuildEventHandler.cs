using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Editor.AssetBundleTools;
using ZJY.Framework;

namespace ZJY.Editor
{
    /// <summary>
    /// 构建Assetbundle事件
    /// </summary>
    public class BuildEventHandler : IBuildEventHandler
    {
        public bool ContinueOnFailure
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 所有平台生成结束后的后处理事件
        /// </summary>
        /// <param name="productName">产品名称</param>
        /// <param name="companyName">公司名称</param>
        /// <param name="gameIdentifier">游戏识别号</param>
        /// <param name="applicableGameVersion">适用游戏版本</param>
        /// <param name="internalResourceVersion">内部资源版本</param>
        /// <param name="unityVersion">Unity 版本</param>
        /// <param name="buildOptions">生成选项</param>
        /// <param name="zip">是否压缩</param>
        /// <param name="outputDirectory">生成目录</param>
        /// <param name="workingPath">生成时的工作路径</param>
        /// <param name="outputPackageSelected">是否生成单机模式所需的文件</param>
        /// <param name="outputPackagePath">为单机模式生成的文件存放于此路径若游戏是单机游戏，生成结束后将此目录中对应平台的文件拷贝至 StreamingAssets 后打包 App 即可</param>
        /// <param name="outputFullSelected">是否生成可更新模式所需的远程文件</param>
        /// <param name="outputFullPath">为可更新模式生成的远程文件存放于此路径若游戏是网络游戏，生成结束后应将此目录上传至 Web 服务器，供玩家下载用</param>
        /// <param name="outputPackedSelected">是否生成可更新模式所需的本地文件</param>
        /// <param name="outputPackedPath">为可更新模式生成的本地文件存放于此路径若游戏是网络游戏，生成结束后将此目录中对应平台的文件拷贝至 StreamingAssets 后打包 App 即可</param>
        /// <param name="buildReportPath">生成报告路径</param>
        public void PostprocessAllPlatforms(string productName, string companyName, string gameIdentifier,
            string applicableGameVersion, int internalResourceVersion, string unityVersion, BuildAssetBundleOptions buildOptions, bool zip,
            string outputDirectory, string workingPath, bool outputPackageSelected, string outputPackagePath, bool outputFullSelected, string outputFullPath, bool outputPackedSelected, string outputPackedPath, string buildReportPath)
        {
            
        }

        /// <summary>
        /// 某个平台生成结束后的后处理事件
        /// </summary>
        /// <param name="platform">生成平台</param>
        /// <param name="workingPath">生成时的工作路径</param>
        /// <param name="outputPackageSelected">是否生成单机模式所需的文件</param>
        /// <param name="outputPackagePath">为单机模式生成的文件存放于此路径若游戏是单机游戏，生成结束后将此目录中对应平台的文件拷贝至 StreamingAssets 后打包 App 即可</param>
        /// <param name="outputFullSelected">是否生成可更新模式所需的远程文件</param>
        /// <param name="outputFullPath">为可更新模式生成的远程文件存放于此路径若游戏是网络游戏，生成结束后应将此目录上传至 Web 服务器，供玩家下载用</param>
        /// <param name="outputPackedSelected">是否生成可更新模式所需的本地文件</param>
        /// <param name="outputPackedPath">为可更新模式生成的本地文件存放于此路径若游戏是网络游戏，生成结束后将此目录中对应平台的文件拷贝至 StreamingAssets 后打包 App 即可</param>
        /// <param name="isSuccess">是否生成成功</param>
        public void PostprocessPlatform(Platform platform, string workingPath, bool outputPackageSelected, string outputPackagePath, bool outputFullSelected, string outputFullPath, bool outputPackedSelected, string outputPackedPath, bool isSuccess)
        {
            if (!outputPackageSelected && !outputPackedSelected)
            {
                return;
            }
            string streamingAssetsPath = PathUtil.GetCombinePath(Application.dataPath, "StreamingAssets");
            if (!Directory.Exists(streamingAssetsPath))
            {
                Directory.CreateDirectory(streamingAssetsPath);
            }

            if (outputPackedSelected)
            {
                string[] fileNames = Directory.GetFiles(outputPackedPath, "*", SearchOption.AllDirectories);
                foreach (string fileName in fileNames)
                {
                    string destFileName = PathUtil.GetCombinePath(streamingAssetsPath, fileName.Substring(outputPackedPath.Length));
                    FileInfo destFileInfo = new FileInfo(destFileName);
                    if (!destFileInfo.Directory.Exists)
                    {
                        destFileInfo.Directory.Create();
                    }

                    File.Copy(fileName, destFileName);
                }
            }
            else
            {
                string[] fileNames = Directory.GetFiles(outputPackagePath, "*", SearchOption.AllDirectories);
                foreach (string fileName in fileNames)
                {
                    string destFileName = PathUtil.GetCombinePath(streamingAssetsPath, fileName.Substring(outputPackagePath.Length));
                    FileInfo destFileInfo = new FileInfo(destFileName);
                    if (!destFileInfo.Directory.Exists)
                    {
                        destFileInfo.Directory.Create();
                    }

                    File.Copy(fileName, destFileName);
                }
            }
        }

        /// <summary>
        /// 所有平台生成开始前的预处理事件
        /// </summary>
        /// <param name="productName">产品名称</param>
        /// <param name="companyName">公司名称</param>
        /// <param name="gameIdentifier">游戏识别号</param>
        /// <param name="applicableGameVersion">适用游戏版本</param>
        /// <param name="internalResourceVersion">内部资源版本</param>
        /// <param name="unityVersion">Unity 版本</param>
        /// <param name="buildOptions">生成选项</param>
        /// <param name="zip">是否压缩</param>
        /// <param name="outputDirectory">生成目录</param>
        /// <param name="workingPath">生成时的工作路径</param>
        /// <param name="outputPackageSelected">是否生成单机模式所需的文件</param>
        /// <param name="outputPackagePath">为单机模式生成的文件存放于此路径若游戏是单机游戏，生成结束后将此目录中对应平台的文件拷贝至 StreamingAssets 后打包 App 即可</param>
        /// <param name="outputFullSelected">是否生成可更新模式所需的远程文件</param>
        /// <param name="outputFullPath">为可更新模式生成的远程文件存放于此路径若游戏是网络游戏，生成结束后应将此目录上传至 Web 服务器，供玩家下载用</param>
        /// <param name="outputPackedSelected">是否生成可更新模式所需的本地文件</param>
        /// <param name="outputPackedPath">为可更新模式生成的本地文件存放于此路径若游戏是网络游戏，生成结束后将此目录中对应平台的文件拷贝至 StreamingAssets 后打包 App 即可</param>
        /// <param name="buildReportPath">生成报告路径</param>
        public void PreprocessAllPlatforms(string productName, string companyName, string gameIdentifier,
            string applicableGameVersion, int internalResourceVersion, string unityVersion, BuildAssetBundleOptions buildOptions, bool zip,
            string outputDirectory, string workingPath, bool outputPackageSelected, string outputPackagePath, bool outputFullSelected, string outputFullPath, bool outputPackedSelected, string outputPackedPath, string buildReportPath)
        {
            string streamingAssetsPath = PathUtil.GetCombinePath(Application.dataPath, "StreamingAssets");
            if (!Directory.Exists(streamingAssetsPath))
            {
                return;
            }
            string[] fileNames = Directory.GetFiles(streamingAssetsPath, "*", SearchOption.AllDirectories);
            foreach (string fileName in fileNames)
            {
                File.Delete(fileName);
            }

            PathUtil.RemoveEmptyDirectory(streamingAssetsPath);
        }

        /// <summary>
        /// 某个平台生成开始前的预处理事件
        /// </summary>
        /// <param name="platform">生成平台</param>
        /// <param name="workingPath">生成时的工作路径</param>
        /// <param name="outputPackageSelected">是否生成单机模式所需的文件</param>
        /// <param name="outputPackagePath">为单机模式生成的文件存放于此路径若游戏是单机游戏，生成结束后将此目录中对应平台的文件拷贝至 StreamingAssets 后打包 App 即可</param>
        /// <param name="outputFullSelected">是否生成可更新模式所需的远程文件</param>
        /// <param name="outputFullPath">为可更新模式生成的远程文件存放于此路径若游戏是网络游戏，生成结束后应将此目录上传至 Web 服务器，供玩家下载用</param>
        /// <param name="outputPackedSelected">是否生成可更新模式所需的本地文件</param>
        /// <param name="outputPackedPath">为可更新模式生成的本地文件存放于此路径若游戏是网络游戏，生成结束后将此目录中对应平台的文件拷贝至 StreamingAssets 后打包 App 即可</param>

        public void PreprocessPlatform(Platform platform, string workingPath, bool outputPackageSelected, string outputPackagePath, bool outputFullSelected, string outputFullPath, bool outputPackedSelected, string outputPackedPath)
        {

        }
    }
}
