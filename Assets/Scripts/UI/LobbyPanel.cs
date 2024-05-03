using System;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LobbyPanel : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI hostNameText;
    [SerializeField] private TextMeshProUGUI clientNameText;
    [SerializeField] private GameObject hostPanel;
    [SerializeField] private GameObject clientPanel;

    private NetworkVariable<PlayerNetworkInstance> host = new();
    private NetworkVariable<PlayerNetworkInstance> client = new();

    private ConnectType localConnectType;

    private void Start()
    {
        localConnectType = LocalInfo.connectType;
        if (localConnectType == ConnectType.ByHost)
        {
            host.Value = new PlayerNetworkInstance(localConnectType, LocalInfo.playerName);
            hostPanel.SetActive(true);
        }
        
        if(localConnectType == ConnectType.ByClient)
        {
            client.Value = new PlayerNetworkInstance(localConnectType, LocalInfo.playerName);
            clientPanel.SetActive(true);
        }

        UpdatePlayerName();
        UpdatePanel();
        host.OnValueChanged+= (_,__) => UpdatePlayerName();
        client.OnValueChanged+= (_,__) => UpdatePlayerName();
    }
    
    private void UpdatePlayerName()
    {
        if(host.Value.connectType != ConnectType.None)
            hostNameText.text = host.Value.playerName;
        else
            hostNameText.text = Consts.WaitingForPlayerMessage;
        
        if (client.Value.connectType != ConnectType.None)
            clientNameText.text = client.Value.playerName;
        else
            clientNameText.text = Consts.WaitingForPlayerMessage;
    }

    private void UpdatePanel()
    {
        if(localConnectType == ConnectType.ByHost)
            hostPanel.SetActive(true);
        if(localConnectType == ConnectType.ByClient)
            clientPanel.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            client.Value = new PlayerNetworkInstance(ConnectType.ByHost, "Test");
        }
    }
}



