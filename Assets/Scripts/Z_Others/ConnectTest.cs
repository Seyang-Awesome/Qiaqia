using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ConnectTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            NetworkManager.Singleton.StartHost();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            NetworkManager.Singleton.StartClient();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            NetworkManager.Singleton.Shutdown();
        }
    }
}

