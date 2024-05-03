using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class TipPanel : MonoSingleton<TipPanel>
{
    [SerializeField] private TextMeshProUGUI tipText;
    protected override bool IsDontDestroyOnLoad => false;

    public static Color correctColor = Color.green;
    public static Color errorColor = Color.red;

    private Vector2 originPos;
    private Vector2 targetPos;

    private void Start()
    {
        originPos = transform.position;
        targetPos = transform.position - new Vector3(0,((RectTransform)transform).rect.height) ;
    }

    public void ShowCorrectTip(string mes)
    {
        tipText.color = correctColor;
        ShowTip(mes);
    }

    public void ShowErrorColor(string mes)
    {
        tipText.color = errorColor;
        ShowTip(mes);
    }

    public void ShowTip(string mes)
    {
        tipText.text = mes;
        DOTween.Sequence()
            .Append(transform.DOMove(targetPos, Consts.TipPanelMoveDuration))
            .AppendInterval(Consts.TipPanelExistDuration)
            .Append(transform.DOMove(originPos, Consts.TipPanelMoveDuration));
    }
}

