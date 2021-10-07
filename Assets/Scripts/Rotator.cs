using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] static float rTime = 5.2f;
    float RunTime = rTime;
    public float x1 = 0.0f;
    public float z1 = 0.0f;
    public Transform targetPoint;
    static bool fStart = true;
    void Update()
    {
        if(fStart)
        {
            fStart = false;
            x1 = Random.Range(-0.5f, 0.5f);
            z1 = Random.Range(-0.5f, 0.5f);
            transform.Translate(Vector3.right * x1);
            transform.Translate(Vector3.forward * z1);
        }
        RunTime -= Time.deltaTime;
        if(RunTime <= 0.0f) //0.5 �Ÿ���ŭ �̵��ϱ�
        {
            x1 = Random.Range(-0.5f, 0.5f);
            z1 = Random.Range(-0.5f, 0.5f);
            transform.Translate(Vector3.right * x1); //transform�̶� �ٸ� 
            transform.Translate(Vector3.forward * z1);
            RunTime = rTime;
        }
        float eDistance = (targetPoint.position - transform.position).sqrMagnitude;
        if(eDistance >= 200.0f || eDistance <= 20.0f) //�־����� �ٽ� ���ڸ�
        {
            transform.position = new Vector3(-12.8f, 2.01f, 6.0f); 
        }
    }
}
