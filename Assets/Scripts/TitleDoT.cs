using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleDoT : MonoBehaviour
{
    public GameObject VR;
    public GameObject BASKET;
    public GameObject BALL;
    public GameObject WITCH;
    public AudioSource swing;
    public AudioSource laugh;

    void Start()
    {
        VR.transform.DOLocalMoveZ(100, 1).SetEase(Ease.InQuad);
        swing.Play();
        Invoke("basket", 0.5f);
        Invoke("ball", 1.0f);
        Invoke("witch", 2.0f);
    }

    void basket()
    {
        BASKET.SetActive(true);
        BASKET.transform.DOLocalMoveZ(100, 1).SetEase(Ease.InQuad);
        swing.Play();
    }
    void ball()
    {
        BALL.SetActive(true);
        BALL.transform.DOLocalMoveZ(100, 1).SetEase(Ease.InQuad);
        swing.Play();
    }
    void witch()
    {
        WITCH.SetActive(true);
        WITCH.transform.DOLocalMoveX(1.5f, 9).SetEase(Ease.OutQuad);
        laugh.Play();
    }
}
