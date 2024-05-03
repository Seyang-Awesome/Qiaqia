using System;
using System.Collections.Generic;
using UnityEngine;

public class LocalInfo
{
    // TODO：不用每次都输入名称
    public static ConnectType connectType;
    public static string lobbyName;
    public static string playerName;

    public static PlayerNetworkInstance GetPlayerNetworkInstance()
    {
        return new PlayerNetworkInstance(connectType, playerName);
    }
}

