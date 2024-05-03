using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingPanel : MonoSingleton<LoadingPanel>
{
    [SerializeField] private TextMeshProUGUI loadingMessageText;
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
        loadingMessageText.text = message;
        Show();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

