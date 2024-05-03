using System;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LobbyButton : MonoBehaviour
{
    [SerializeField] private Button lobbyButton;
    [SerializeField] private TextMeshProUGUI lobbyName;

    public void Init(Lobby lobby)
    {
        lobbyName.text = lobby.Name;
        // lobbyButton.onClick
    }
}

