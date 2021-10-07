using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFade : MonoBehaviour
{
    void Start()
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.DOFade(2.0f, 4.0f).SetEase(Ease.InOutQuart).SetLoops(2, LoopType.Yoyo);
    }
}