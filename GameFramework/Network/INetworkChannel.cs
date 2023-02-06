﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using System.Net;
using System.Net.Sockets;

namespace GameFramework.Network
{
    /// <summary>
    /// 网络频道接口。
    /// </summary>
    public interface INetworkChannel
    {
        /// <summary>
        /// 获取网络频道名称。
        /// </summary>
        string Name
        {
            get;
        }

        /// <summary>
        /// 本地连接地址
        /// </summary>
        string LocalAddress
        {
            get;
        }

        /// <summary>
        /// 远端连接地址
        /// </summary>
        /// <value></value>
        string RemoteAddress
        {
            get;
        }

        /// <summary>
        /// 获取是否已连接。
        /// </summary>
        bool Connected
        {
            get;
        }

        /// <summary>
        /// 获取网络服务类型。
        /// </summary>
        ServiceType ServiceType
        {
            get;
        }

        /// <summary>
        /// 获取网络地址类型。
        /// </summary>
        AddressFamily AddressFamily
        {
            get;
        }

        /// <summary>
        /// 获取要发送的消息包数量。
        /// </summary>
        int SendPacketCount
        {
            get;
        }

        /// <summary>
        /// 获取累计发送的消息包数量。
        /// </summary>
        int SentPacketCount
        {
            get;
        }

        /// <summary>
        /// 获取已接收未处理的消息包数量。
        /// </summary>
        int ReceivePacketCount
        {
            get;
        }

        /// <summary>
        /// 获取累计已接收的消息包数量。
        /// </summary>
        int ReceivedPacketCount
        {
            get;
        }

        /// <summary>
        /// 获取或设置当收到消息包时是否重置心跳流逝时间。
        /// </summary>
        bool ResetHeartBeatElapseSecondsWhenReceivePacket
        {
            get;
            set;
        }

        /// <summary>
        /// 获取丢失心跳的次数。
        /// </summary>
        int MissHeartBeatCount
        {
            get;
        }

        /// <summary>
        /// 获取或设置心跳间隔时长，以秒为单位。
        /// </summary>
        float HeartBeatInterval
        {
            get;
            set;
        }

        /// <summary>
        /// 获取心跳等待时长，以秒为单位。
        /// </summary>
        float HeartBeatElapseSeconds
        {
            get;
        }

        /// <summary>
        /// 通道连接完成回调
        /// </summary>
        GameFrameworkAction<INetworkChannel, object> NetworkChannelConnected
        {
            get;
            set;
        }
        /// <summary>
        /// 通道关闭回调
        /// </summary>
        GameFrameworkAction<INetworkChannel> NetworkChannelClosed
        {
            get;
            set;
        }
        /// <summary>
        /// 通道丢失心跳回调
        /// </summary>
        GameFrameworkAction<INetworkChannel, int> NetworkChannelMissHeartBeat
        {
            get;
            set;
        }
        /// <summary>
        /// 通道错误回调
        /// </summary>
        GameFrameworkAction<INetworkChannel, NetworkErrorCode, SocketError, string> NetworkChannelError
        {
            get;
            set;
        }
        /// <summary>
        /// 通道自定义错误回调
        /// </summary>
        GameFrameworkAction<INetworkChannel, object> NetworkChannelCustomError
        {
            get;
            set;
        }

        /// <summary>
        /// 注册网络消息包处理函数。
        /// </summary>
        /// <param name="handler">要注册的网络消息包处理函数。</param>
        void RegisterHandler(IPacketHandler handler);

        /// <summary>
        /// 反注册网络消息包处理函数。
        /// </summary>
        /// <param name="handler"></param>
        void UnRegisterHandler(IPacketHandler handler);

        /// <summary>
        /// 设置默认事件处理函数。
        /// </summary>
        /// <param name="handler">要设置的默认事件处理函数。</param>
        void SetDefaultHandler(EventHandler<Packet> handler);

        /// <summary>
        /// 连接到远程主机。
        /// </summary>
        /// <param name="ipAddress">远程主机的 IP 地址。</param>
        /// <param name="port">远程主机的端口号。</param>
        void Connect(IPAddress ipAddress, int port);

        /// <summary>
        /// 连接到远程主机。
        /// </summary>
        /// <param name="ipAddress">远程主机的 IP 地址。</param>
        /// <param name="port">远程主机的端口号。</param>
        /// <param name="userData">用户自定义数据。</param>
        void Connect(IPAddress ipAddress, int port, object userData);

        /// <summary>
        /// 通过域名或ip连接到远程主机。
        /// </summary>
        /// <param name="targetAddress">远程主机的 IP（域名） 地址。</param>
        /// <param name="port">远程主机的端口号。</param>
        void Connect(string ipAddress);

        /// <summary>
        /// 通过域名或ip连接到远程主机。
        /// </summary>
        /// <param name="targetAddress">远程主机的 IP（域名） 地址。</param>
        /// <param name="port">远程主机的端口号。</param>
        /// <param name="userData">用户自定义数据。</param>
        void Connect(string targetAddress, object userData);

        /// <summary>
        /// 关闭网络频道。
        /// </summary>
        void Close();

        /// <summary>
        /// 向远程主机发送消息包。
        /// </summary>
        /// <typeparam name="T">消息包类型。</typeparam>
        /// <param name="packet">要发送的消息包。</param>
        void Send<T>(T packet) where T : Packet;
        /// <summary>
        /// 网络管理器轮询
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        void Update(float elapseSeconds, float realElapseSeconds);
        /// <summary>
        /// 关闭并清理
        /// </summary>
        void Shutdown();
        /// <summary>
        /// 抛出接收包
        /// </summary>
        void FireReceivePacket(Packet packet);
    }
}
