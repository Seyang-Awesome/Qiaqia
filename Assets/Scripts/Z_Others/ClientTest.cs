using System;
using System.Collections.Generic;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class ClientTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            FindLobbies();
        }
    }

    private async void FindLobbies()
    {
        QueryLobbiesOptions options = new() { 
            Count = 10, 
            Filters = new List<QueryFilter>()
        {
            new(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT)
        }};
        await LobbyService.Instance.QueryLobbiesAsync(options);
        QueryResponse response = await LobbyService.Instance.QueryLobbiesAsync(options);
        List<Lobby> foundLobbies = response.Results;

        Debug.Log(foundLobbies.Count);
        foreach (var lobby in foundLobbies)
        {
            Debug.Log(lobby.Name);
        }
    }
}

