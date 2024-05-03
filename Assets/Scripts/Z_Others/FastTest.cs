using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class FastTest : NetworkBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DebugServerRpc();
            NetworkManager.Shutdown();
        }
    }

    [ServerRpc(RequireOwnership = false)]
    public void DebugServerRpc()
    {
        Debug.Log("Test");
    }
}

