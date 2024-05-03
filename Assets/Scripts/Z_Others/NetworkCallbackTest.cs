using System;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class NetworkCallbackTest : MonoBehaviour
{
    private void Start()
    {
        NetworkManager.Singleton.OnServerStarted += () => Debug.Log("OnServerStarted");
        NetworkManager.Singleton.OnServerStopped += _ => Debug.Log("OnServerStopped");
        NetworkManager.Singleton.OnClientStarted += () => Debug.Log("OnClientStarted");
        NetworkManager.Singleton.OnClientStopped += _ => Debug.Log("OnClientStopped");
        NetworkManager.Singleton.OnClientConnectedCallback += _ => Debug.Log("OnClientConnectedCallback");
        NetworkManager.Singleton.OnClientDisconnectCallback += _ => Debug.Log("OnClientDisconnectCallback");
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            // UnityTransport transport = NetworkManager.Singleton.NetworkConfig.NetworkTransport as UnityTransport;
            // transport.SetConnectionData("192.168.31.165", 7777);
            
            NetworkManager.Singleton.StartHost();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            // UnityTransport transport = NetworkManager.Singleton.NetworkConfig.NetworkTransport as UnityTransport;
            // transport.SetConnectionData("192.168.31.165", 7777);
            
            NetworkManager.Singleton.StartClient();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            NetworkManager.Singleton.Shutdown();
        }
    }
    
    
}

