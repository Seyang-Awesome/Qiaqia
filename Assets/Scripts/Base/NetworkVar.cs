using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkVar<T>
{
    private NetworkVariable<T> value = new();

    public T Value
    {
        get => value.Value;
        set => SetValueServerRpc(value);
    }

    public NetworkVariable<T>.OnValueChangedDelegate OnValueChanged => value.OnValueChanged;

    [ServerRpc(RequireOwnership =  false)]
    private void SetValueServerRpc(T _value)
    {
        value.Value = _value;
    }
}

