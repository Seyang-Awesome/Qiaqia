using System.Collections;
using System.Collections.Generic;using Unity.Netcode;
using UnityEngine;

public struct PlayerNetworkInstance : INetworkSerializable
{
    public ConnectType connectType;
    public string playerName;

    // public PlayerNetworkInstance()
    // {
    //     connectType = ConnectType.None;
    //     playerName = string.Empty;
    // }

    public PlayerNetworkInstance(ConnectType connectType, string playerName)
    {
        this.connectType = connectType;
        this.playerName = playerName;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref connectType);
        serializer.SerializeValue(ref playerName);
    }
}
