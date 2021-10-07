using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //시퀀스, 순서를 만드는 함순가봄

[RequireComponent(typeof(TextMesh))]
public class PopupText : MonoBehaviour
{
    void Start()
    {
      
        var textMesh = GetComponent<TextMesh>();

       
        var sequence = DOTween.Sequence();

        // 처음에 확대 표시한다
        sequence.Append(transform.DOScale(0.3f, 0.2f));

        // 다음에 위로 이동시킨다
        sequence.Append(transform.DOMoveY(3.0f, 0.3f).SetRelative());

        // 현재의 색을 취득
        var color = textMesh.color;

        //투명
        color.a = 0.0f;

        // 위로 이동함과 동시에 반투명하게 사라지게 한다
        sequence.Join(DOTween.To(() => textMesh.color, c => textMesh.color = c, color, 0.3f).SetEase(Ease.InOutQuart));

        // 삭제
        sequence.OnComplete(() => Destroy(gameObject));
    }
}