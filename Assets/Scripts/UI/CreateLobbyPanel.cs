using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.UI;

public class CreateLobbyPanel : MonoBehaviour
{
    [SerializeField] private Button createLobbyButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private TMP_InputField playerNameInputField;
    [SerializeField] private TMP_InputField lobbyNameInputField;
    [SerializeField] private GameObject lobbyPanel;

    private void Start()
    {
        createLobbyButton.onClick.AddListener(OnClickCreateLobbyButton);
        returnButton.onClick.AddListener(OnClickReturnButton);
    }

    private async void OnClickCreateLobbyButton()
    {
        LocalInfo.connectType = ConnectType.Host;
        LocalInfo.lobbyName = lobbyNameInputField.text == string.Empty
            ? Consts.DefaultLobbyName 
            : lobbyNameInputField.text;
        LocalInfo.playerName = playerNameInputField.text == string.Empty
            ? Consts.DefaultPlayerName
            : playerNameInputField.text;
        
        LoadingPanel.Instance.Show(Consts.CreateLobbyMessage);
        UnityTransport transport = NetworkManager.Singleton.NetworkConfig.NetworkTransport as UnityTransport;
        transport.SetConnectionData(NetworkTools.GetLocalIPAddress(), 7777);
        bool result = await GlobalNetworkManager.Instance.StartHostAsync();
        LoadingPanel.Instance.Hide();

        if (result)
        {
            lobbyPanel.SetActive(true);
            LobbyServerManager.Instance.CreateLobbyServerRpc(LocalInfo.lobbyName);
            LobbyServerManager.Instance.EnterLobbyServerRpc(LocalInfo.GetPlayerNetworkInstance());
            MessagePanel.Instance.ShowCorrectMessage(Consts.CreateLobbySuccessfullyMessage);
        }
        else
        {
            MessagePanel.Instance.ShowErrorMessage(Consts.CreateLobbyFailedMessage);
        }
    }
    
    private void OnClickReturnButton()
    {
        gameObject.SetActive(false);
    }
    
}

