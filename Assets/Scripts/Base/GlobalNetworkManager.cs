using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;

public class GlobalNetworkManager : NetworkBehaviourSingleton<GlobalNetworkManager>
{
    public ConnectState ConnectState { get; set; } = ConnectState.DisConnect;
    public ConnectType ConnectType { get; set; } = ConnectType.None;
    public event Action OnHostDisconnect;

    [ClientRpc]
    private void OnCloseHostClientRpc()
    {
        OnHostDisconnect?.Invoke();
    }

    public async UniTask<bool> StartHostAsync(Action onCompleteIfSuccess = null, Action onCompleteIfFailed = null)
    {
        bool result = NetworkManager.StartHost();
        await UniTask.Delay(500);
        if(result)
            onCompleteIfSuccess?.Invoke();
        else
            onCompleteIfFailed?.Invoke();
        return result;
    }

    public async UniTask<bool> StartClientAsync(Action onCompleteIfSuccess = null, Action onCompleteIfFailed = null)
    {
        bool result = NetworkManager.StartClient();
        await UniTask.Delay(500);
        if(result)
            onCompleteIfSuccess?.Invoke();
        else
            onCompleteIfFailed?.Invoke();
        return result;
    }

    public void CloseHost()
    {
        OnCloseHostClientRpc();
        NetworkManager.Shutdown();
    }

    public void CloseClient()
    {
        NetworkManager.Shutdown();
    }
    
    // private void Update()
    // {
    //     Debug.Log($"NetworkState:{NetworkStateChecker.NetworkState},ConnectType:{NetworkStateChecker.ConnectType}");
    // }
}

