using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWait : MonoBehaviour
{
    float time = 2.7f;
    public GameObject button1;
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0.0f)
        {
            button1.gameObject.SetActive(true);
        }
    }
}
