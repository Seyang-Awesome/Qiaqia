using System;
using System.Collections.Generic;
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

    private void Start()
    {
        joinButton.onClick.AddListener(OnClickJoinButton);
        returnButton.onClick.AddListener(OnClickReturnButton);
    }

    private void OnClickJoinButton()
    {
        MessagePanel.Instance.Show(Consts.JoinLobbyListMessage);
        
        LocalInfo.connectType = ConnectType.ByClient;
        LocalInfo.playerName = playerNameInputField.text == string.Empty
            ? Consts.DefaultPlayerName
            : playerNameInputField.text;
        
        UnityTransport transport = NetworkManager.Singleton.NetworkConfig.NetworkTransport as UnityTransport;
        transport.SetConnectionData(ipInputField.text, 7777);

        // 这里的结果被捕获了
        bool result = NetworkManager.Singleton.StartClient();
        
        if (result)
            SceneLoader.Instance.LoadScene(Consts.LobbySceneName);
        else
            TipPanel.Instance.ShowErrorColor(Consts.JoinLobbyFailedTip);
        
        MessagePanel.Instance.Hide();
    }
    
    private void OnClickReturnButton()
    {
        gameObject.SetActive(false);
    }
}

