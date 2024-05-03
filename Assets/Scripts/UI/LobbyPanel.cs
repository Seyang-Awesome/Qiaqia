using System;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Lobbies.Models;
using UnityEngine.UI;
using UnityEngine;

public class LobbyPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lobbyNameText;
    [SerializeField] private TextMeshProUGUI hostNameText;
    [SerializeField] private TextMeshProUGUI clientNameText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button hostExitButton;
    [SerializeField] private Button clientExitButton;
    [SerializeField] private GameObject hostPanel;
    [SerializeField] private GameObject clientPanel;

    public void Start()
    {
        startButton.onClick.AddListener(OnClickStartButton);
        hostExitButton.onClick.AddListener(OnClickHostExitButton);
        clientExitButton.onClick.AddListener(OnClientClientExitButton);
    }

    private void OnEnable()
    {
        GlobalNetworkManager.Instance.OnHostDisconnect += OnHostDisconnect;
        
        if(LocalInfo.connectType == ConnectType.Host)
            hostPanel.SetActive(true);
        if(LocalInfo.connectType == ConnectType.Client)
            clientPanel.SetActive(true);
    }

    private void OnDisable()
    {
        GlobalNetworkManager.Instance.OnHostDisconnect -= OnHostDisconnect;
        
        hostPanel.SetActive(false);
        clientPanel.SetActive(false);
    }
    
    public void UpdateLobbyName(string lobbyName)
    {
        lobbyNameText.text = lobbyName;
    }
    
    public void UpdatePlayerName(string hostName, string clientName)
    {
        if(hostName != string.Empty)
            hostNameText.text = hostName;
        else
            hostNameText.text = Consts.WaitingForPlayerMessage;
        
        if (clientName != string.Empty)
            clientNameText.text = clientName;
        else
            clientNameText.text = Consts.WaitingForPlayerMessage;
    }

    private void OnHostDisconnect()
    {
        gameObject.SetActive(false);
        MessagePanel.Instance.ShowErrorMessage(Consts.HostPlayerExitMessage);
    }
    
    private void OnClickStartButton()
    {
        
    }

    private void OnClickHostExitButton()
    {
        LobbyServerManager.Instance.ExitLobbyServerRpc(LocalInfo.GetPlayerNetworkInstance());
        gameObject.SetActive(false);
        GlobalNetworkManager.Instance.CloseHost();
    }

    private void OnClientClientExitButton()
    {
        LobbyServerManager.Instance.ExitLobbyServerRpc(LocalInfo.GetPlayerNetworkInstance());
        gameObject.SetActive(false);
        GlobalNetworkManager.Instance.CloseClient();
    }
    
}



