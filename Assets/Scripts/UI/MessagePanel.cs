using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessagePanel : MonoSingleton<MessagePanel>
{
    [SerializeField] private TextMeshProUGUI messageText;
    protected override bool IsDontDestroyOnLoad => false;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Show(string message)
    {
        Show();
        SetMessage(message);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetMessage(string message)
    {
        messageText.text = message;
    }
}

