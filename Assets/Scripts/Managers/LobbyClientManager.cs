using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class LobbyClientManager : NetworkBehaviourSingleton<LobbyClientManager>
{
    protected override bool IsDontDestroyOnLoad => false;
    
    [SerializeField] private LobbyPanel lobbyPanel;
    
    [ClientRpc]
    public void UpdateLobbyNameClientRpc(FixedString64Bytes lobbyName)
    {
        lobbyPanel.UpdateLobbyName(lobbyName.ToString());
    }
    
    [ClientRpc]
    public void UpdatePlayerNameClientRpc(FixedString64Bytes hostName, FixedString64Bytes clientName)
    {
        lobbyPanel.UpdatePlayerName(hostName.ToString(),clientName.ToString());
    }
}

