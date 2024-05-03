using System;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class NetworkBehaviourSingleton<T> : NetworkBehaviour where T : MonoBehaviour
{
    protected virtual bool IsDontDestroyOnLoad => true;

    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null || instance.IsUnityNull())
                instance = FindObjectOfType<T>();
            if (instance == null || instance.IsUnityNull())
                instance = new GameObject(typeof(T).Name).AddComponent<T>();
            return instance;
        }
        private set => instance = value;
    }

    public virtual void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this as T;
        }

        if (IsDontDestroyOnLoad)
            DontDestroyOnLoad(gameObject);
    }

    // public override void OnNetworkSpawn()
    // {
    //     if (NetworkManager.IsClient && !NetworkManager.IsHost)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
}
