//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

namespace GameFramework.Resource
{
    /// <summary>
    /// 加载资源代理辅助器异步读取资源二进制流完成事件。
    /// </summary>
    public sealed class LoadResourceAgentHelperReadAssetBundleCompleteEventArgs : GameFrameworkEventArgs
    {
        public object AssetBundle { get; private set; }

        /// <summary>
        /// 初始化加载资源代理辅助器异步读取资源二进制流完成事件的新实例。
        /// </summary>
        public LoadResourceAgentHelperReadAssetBundleCompleteEventArgs()
        {
            AssetBundle = null;
        }

        /// <summary>
        /// 创建加载资源代理辅助器异步读取资源二进制流完成事件。
        /// </summary>
        /// <param name="bytes">资源的二进制流。</param>
        /// <returns>创建的加载资源代理辅助器异步读取资源二进制流完成事件。</returns>
        public static LoadResourceAgentHelperReadAssetBundleCompleteEventArgs Create(object asset)
        {
            LoadResourceAgentHelperReadAssetBundleCompleteEventArgs args = ReferencePool.Acquire<LoadResourceAgentHelperReadAssetBundleCompleteEventArgs>();
            args.AssetBundle = asset;
            return args;
        }

        /// <summary>
        /// 清理加载资源代理辅助器异步读取资源二进制流完成事件。
        /// </summary>
        public override void Clear()
        {
            AssetBundle = null;
        }
    }
}
