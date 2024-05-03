using System;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HostTest : MonoBehaviour
{
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            CreateLobby();
        }
    }

    private async void Init()
    {
        if (UnityServices.State == ServicesInitializationState.Initialized) return;

        InitializationOptions options = new();
        options.SetProfile(Random.Range(0, 1000).ToString());

        await UnityServices.InitializeAsync(options);
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    private void CreateLobby()
    {
        LobbyService.Instance.CreateLobbyAsync("Test",2);
        
    }
}

