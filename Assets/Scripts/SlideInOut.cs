using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(RectTransform))]
public class SlideInOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rectTranform = GetComponent<RectTransform>();

        var sequence = DOTween.Sequence();

        sequence.Append(rectTranform.DOMoveX(0.0f, 1.0f));

        sequence.Append(rectTranform.DOMoveX(-1400.0f, 0.8f)); //왼쪽끝으로 사라짐
    }
}
