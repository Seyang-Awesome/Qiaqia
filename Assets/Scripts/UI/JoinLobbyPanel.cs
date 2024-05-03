using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class JoinLobbyPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField ipInputField;
    [SerializeField] private TMP_InputField playerNameInputField;
    [SerializeField] private Button joinButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private GameObject lobbyPanel;
    
    private void Start()
    {
        joinButton.onClick.AddListener(OnClickJoinButton);
        returnButton.onClick.AddListener(OnClickReturnButton);
    }

    private async void OnClickJoinButton()
    {
        LocalInfo.connectType = ConnectType.Client;
        LocalInfo.playerName = playerNameInputField.text == string.Empty
            ? Consts.DefaultPlayerName
            : playerNameInputField.text;
        
        LoadingPanel.Instance.Show(Consts.JoinLobbyMessage);
        UnityTransport transport = NetworkManager.Singleton.NetworkConfig.NetworkTransport as UnityTransport;
        transport.SetConnectionData(ipInputField.text, 7777);
        bool result = await GlobalNetworkManager.Instance.StartClientAsync();
        LoadingPanel.Instance.Hide();

        if (result && GlobalNetworkManager.Instance.ConnectState == ConnectState.Connect)
        {
            lobbyPanel.SetActive(true);
            LobbyServerManager.Instance.EnterLobbyServerRpc(LocalInfo.GetPlayerNetworkInstance());
            MessagePanel.Instance.ShowCorrectMessage(Consts.JoinLobbySuccessfullyMessage);
        }
        else if (GlobalNetworkManager.Instance.ConnectState == ConnectState.DisConnect)
        {
            GlobalNetworkManager.Instance.CloseClient();
            MessagePanel.Instance.ShowErrorMessage(Consts.JoinLobbyFailedMessage);
        }
        else
            MessagePanel.Instance.ShowErrorMessage(Consts.JoinLobbyFailedMessage);

        // if(!result)
        //     TipPanel.Instance.ShowErrorColor(Consts.JoinLobbyFailedTip);
    }
    
    private void OnClickReturnButton()
    {
        gameObject.SetActive(false);
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.J))
    //     {
    //         LobbyServerManager.Instance.EnterLobbyServerRpc(LocalInfo.GetPlayerNetworkInstance());
    //     }
    //     
    //     if (Input.GetKeyDown(KeyCode.C))
    //     {
    //         UnityTransport transport = NetworkManager.Singleton.NetworkConfig.NetworkTransport as UnityTransport;
    //         transport.SetConnectionData("192.168.31.165", 7777);
    //
    //         // 这里的异常被捕获了
    //         bool result = GlobalNetworkManager.Instance.StartClient();
    //     }
    // }
}

