using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Score : MonoBehaviour
{
    Text uiText;
    public int Points { get; private set; }

    void Start()
    {
        uiText = GetComponent<Text>();
    }

    public void AddScore(int addPoint, float aTime)
    {
        if (aTime <= 15.0f)
        {
            Points += addPoint + 1;
            uiText.text = string.Format("점수 : {0:D3}점", Points);
        }
        else
        {
            Points += addPoint;
            uiText.text = string.Format("점수 : {0:D3}점", Points);
        }
    }
}
