using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Cysharp.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

public class NetworkTools
{
    public const int Port = 9050;
    public static string GetLocalIPAddress()
    {
        string localIP = string.Empty;
        foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }

    [ServerRpc]
    public static void HostShutdown()
    {
        NetworkManager.Singleton.Shutdown();
    }

    [ClientRpc]
    public static void ClientShutdown()
    {
        NetworkManager.Singleton.Shutdown();
    }
    
    [ServerRpc(RequireOwnership = false)]
    public static void HostCorrectMessage(string mes)
    {
        MessagePanel.Instance.ShowCorrectMessage(mes);
    }

    [ServerRpc(RequireOwnership = false)]
    public static void HostErrorMessage(string mes)
    {
        MessagePanel.Instance.ShowErrorMessage(mes);
    }

    [ClientRpc]
    public static void ClientCorrectMessage(string mes)
    {
        MessagePanel.Instance.ShowCorrectMessage(mes);
    }

    [ClientRpc]
    public static void ClientErrorMessage(string mes)
    {
        MessagePanel.Instance.ShowErrorMessage(mes);
    }
    
}

