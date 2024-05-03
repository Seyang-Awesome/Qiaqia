using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidClick : MonoBehaviour
{
    public float limitAlphaA = 0.1f;
    void Start()
    {
        Image image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = limitAlphaA;
    }
}
