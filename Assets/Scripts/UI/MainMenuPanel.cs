using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] private Button hostButton;
    [SerializeField] private Button clientButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private GameObject createLobbyPanel;
    [SerializeField] private GameObject joinLobbyPanel;
    [SerializeField] private GameObject lobbyPanel;

    private void Start()
    {
        hostButton.onClick.AddListener(OnClickHostButton);
        clientButton.onClick.AddListener(OnClickClientButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    private void OnClickHostButton()
    {
        createLobbyPanel.SetActive(true);
    }
    
    private void OnClickClientButton()
    {
        joinLobbyPanel.SetActive(true);
    }

    private void OnClickExitButton()
    {
        Application.Quit();
    }
}

