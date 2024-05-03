using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TestAsync : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
            Test();
            
    }

    private async void Test()
    {
        await TestFunc();
        Debug.Log(66);
    }

    private async UniTask TestFunc()
    {
        await UniTask.Delay(2000);
    }
}

