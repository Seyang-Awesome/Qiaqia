using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
public class NetworkStateChecker : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        GlobalNetworkManager.Instance.ConnectState = ConnectState.Connect;
        if (NetworkManager.IsHost)
        {
            GlobalNetworkManager.Instance.ConnectType = ConnectType.Host;
        }
        else if (NetworkManager.IsClient && !NetworkManager.IsHost)
        {
            GlobalNetworkManager.Instance.ConnectType = ConnectType.Client;
        }
    }

    public override void OnNetworkDespawn()
    {
        GlobalNetworkManager.Instance.ConnectState = ConnectState.DisConnect;
        GlobalNetworkManager.Instance.ConnectType = ConnectType.None;
    }
}

