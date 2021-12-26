using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ball : MonoBehaviour
{
    [SerializeField] AudioSource BallAudioSource;
    [SerializeField] float speed = 6f;
    Transform tr;
    bool isSpin = false;
    void Start()
    {
        var velocity = speed * transform.forward;
        var rigidbody = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        rigidbody.AddForce(velocity, ForceMode.VelocityChange);
    }
    private void Update()
    {
        if (!isSpin) tr.Rotate(2.5f, 0, 0);
    }
    void OnTriggerEnter(Collider other)
    {
        BallAudioSource.Play();
        isSpin = true;
    }
}
