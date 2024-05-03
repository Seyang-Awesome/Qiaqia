using System;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class CreateLobbyPanel : MonoBehaviour
{
    [SerializeField] private Button createLobbyButton;
    [SerializeField] private Button returnButton;
    [SerializeField] private TMP_InputField playerNameInputField;
    [SerializeField] private TMP_InputField lobbyNameInputField;

    private void Start()
    {
        createLobbyButton.onClick.AddListener(OnClickCreateLobbyButton);
        returnButton.onClick.AddListener(OnClickReturnButton);
    }

    private void OnClickCreateLobbyButton()
    {
        LocalInfo.connectType = ConnectType.ByHost;
        LocalInfo.lobbyName = lobbyNameInputField.text == string.Empty 
            ? Consts.DefaultLobbyName 
            : lobbyNameInputField.text;
        LocalInfo.playerName = playerNameInputField.text == string.Empty
            ? Consts.DefaultPlayerName
            : playerNameInputField.text;
        
        MessagePanel.Instance.Show(Consts.CreateLobbyMessage);
        try
        {
            NetworkManager.Singleton.StartHost();
            LocalInfo.lobbyName = lobbyNameInputField.text;
            
            SceneLoader.Instance.NetworkLoadScene(Consts.LobbySceneName);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
        finally
        {
            MessagePanel.Instance.Hide();
        }
    }
    
    private void OnClickReturnButton()
    {
        gameObject.SetActive(false);
    }
    
}

