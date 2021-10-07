using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class CloseUp : MonoBehaviour
{
    void Start()
    {
        var rectTranform = GetComponent<RectTransform>();

        var sequence = DOTween.Sequence();
        transform.localScale = Vector3.zero;

        sequence.Append(transform.DOScale(1, 1).SetEase(Ease.OutBounce));

        sequence.Join(GetComponent<CanvasGroup>().DOFade(1, 1));
    }
}
