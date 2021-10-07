using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RimRotator : MonoBehaviour
{
    Vector3 position;
    float time1 = 0.0f;
    float time2 = 5.2f;
    float px, pz = 0.0f;
    bool fstart = true;
    void Update()
    {
        if (fstart)
        {
            px = GameObject.Find("GoalDae").GetComponent<Rotator>().x1; //Rotator 즉 골대 이동위치 가져오기
            pz = GameObject.Find("GoalDae").GetComponent<Rotator>().z1; //마찬가지
            transform.Translate(Vector3.right * (px * -1));
            transform.Translate(Vector3.forward * (pz * -1));
            time2 = 5.2f;
            fstart = false;
        }
        if (time2 <= 0.0f)
        {
            px = GameObject.Find("GoalDae").GetComponent<Rotator>().x1; //Rotator 즉 골대 이동위치 가져오기
            pz = GameObject.Find("GoalDae").GetComponent<Rotator>().z1; //마찬가지
            transform.Translate(Vector3.right * (px*-1));
            transform.Translate(Vector3.forward * (pz*-1));
            time2 = 5.2f; //시간초기화
        }
        else
        {
            time2 -= Time.deltaTime;
            time1 += Time.deltaTime;
            if (time1 <= 1.5f)
            {
                transform.Translate(Vector3.right* 0.3f * Time.deltaTime); 
            }
            else if (time1 >= 1.5f)
            {
                transform.Translate(Vector3.left * 0.3f * Time.deltaTime);
            }
            if (time1 >= 3.0) time1 = 0.0f; //초기화
        }
    }
}
