using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

[Serializable]
public struct PlayerNetworkInstance : INetworkSerializable
{
    public bool isValid;
    public ConnectType connectType;
    public FixedString64Bytes playerName;

    // public PlayerNetworkInstance()
    // {
    //     connectType = ConnectType.None;
    //     playerName = string.Empty;
    // }

    public PlayerNetworkInstance(ConnectType connectType, string playerName)
    {
        this.isValid = true;
        this.connectType = connectType;
        this.playerName = playerName;
    }

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
    {
        serializer.SerializeValue(ref isValid);
        serializer.SerializeValue(ref connectType);
        serializer.SerializeValue(ref playerName);
    }
}
