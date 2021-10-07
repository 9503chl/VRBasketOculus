using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotate : MonoBehaviour
{
    float time = 2.0f;
    float x1;
    Vector3 movement;
    Vector3 position;
    public Transform targetTransform; //다른 오브젝트 가져오는 쉬운방법
    Rigidbody rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();  
    }

    void Update()
    {
        transform.Translate(Vector3.forward * 0.00085f); //가는방향
        time -= Time.deltaTime;
        transform.LookAt(targetTransform);
        float eDistance = (targetTransform.position - transform.position).sqrMagnitude;
        if(eDistance  > 60.0f)
        {
            transform.position = new Vector3(Random.Range(-3.0f, -1.0f), 1.0f, -3.0f);
        }
        if (time <= 0.0f)
        {
            rigid.AddForce(Vector3.up * 400.0f , ForceMode.Impulse);
            time = Random.Range(0.0f, 3.0f);
        }
    }
}
