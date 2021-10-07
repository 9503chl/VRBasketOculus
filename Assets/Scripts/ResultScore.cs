using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    void Start()
    {
        var gameObj = GameObject.FindWithTag("Score");
        var score = gameObj.GetComponent<Score>();

        var uiText = GetComponent<Text>();
        uiText.text = string.Format("{0:D3}Á¡", score.Points);
    }
}
