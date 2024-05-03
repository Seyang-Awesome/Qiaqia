using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class LobbyServerManager : NetworkBehaviourSingleton<LobbyServerManager>
{
    protected override bool IsDontDestroyOnLoad => false;

    // [SerializeField] private LobbyPanel lobbyPanel;
    private string lobbyName;
    private PlayerNetworkInstance host;
    private PlayerNetworkInstance client;
    private bool IsReady => host.isValid && client.isValid;

    [ServerRpc(RequireOwnership = false)]
    public void CreateLobbyServerRpc(string lobbyName)
    {
        this.lobbyName = lobbyName;
        UpdateClientLobbyPanel();
    }

    [ServerRpc(RequireOwnership = false)]
    public void EnterLobbyServerRpc(PlayerNetworkInstance player)
    {
        if (player.connectType == ConnectType.Host)
            host = player;
        if (player.connectType == ConnectType.Client)
            client = player;
        UpdateClientLobbyPanel();
    }

    [ServerRpc(RequireOwnership = false)]
    public void ExitLobbyServerRpc(PlayerNetworkInstance player)
    {
        if (player.connectType == ConnectType.Host)
        {
            lobbyName = string.Empty;
            host = default;
            client = default;
        }

        if (player.connectType == ConnectType.Client)
        {
            client = default;
            UpdateClientLobbyPanel();
        }
    }

    private void UpdateClientLobbyPanel()
    {
        LobbyClientManager.Instance.UpdateLobbyNameClientRpc(lobbyName);
        LobbyClientManager.Instance.UpdatePlayerNameClientRpc(
            host.playerName,
            client.playerName);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UpdateClientLobbyPanel();
    }
}

