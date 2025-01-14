using System.Collections.Generic;

namespace GameFramework.Network
{
    /// <summary>
    /// 网络频道辅助器走字节流方式的接口。
    /// </summary>
    public interface INetworkChannelByteHelper : INetworkChannelHelper
    {
        /// <summary>
        /// 序列化消息包。
        /// </summary>
        /// <typeparam name="T">消息包类型。</typeparam>
        /// <param name="packet">要序列化的消息包。</param>
        /// <param name="destination">要序列化的字节流。</param>
        /// <returns>是否序列化成功。</returns>
        bool Serialize<T>(T packet, out byte[] destination) where T : Packet;

        /// <summary>
        /// 反序列化消息包头。
        /// </summary>
        /// <param name="source">要反序列化的来源字节流。</param>
        /// <param name="customErrorData">用户自定义错误数据。</param>
        /// <returns>反序列化后的消息包头。</returns>
        IPacketHeader DeserializePacketHeader(byte[] source, out object customErrorData);

        /// <summary>
        /// 反序列化消息包。
        /// </summary>
        /// <param name="packetResults">装载结果集</param>
        /// <param name="packetHeader">消息包头。</param>
        /// <param name="source">要反序列化的来源字节流。</param>
        /// <param name="customErrorData">用户自定义错误数据。</param>
        /// <returns>反序列化后的消息包。</returns>
        void DeserializePacketNonAlloc(List<Packet> packetResults, IPacketHeader packetHeader, byte[] source, out object customErrorData);
    }
}