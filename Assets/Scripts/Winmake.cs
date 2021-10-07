using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winmake : MonoBehaviour
{
    float timer1 = 1.0f;
    public GameObject gameobj;

    void Update()
    {
        timer1 -= Time.deltaTime;
        if (timer1 <= 0.0f) gameobj.SetActive(true);
    }
}
