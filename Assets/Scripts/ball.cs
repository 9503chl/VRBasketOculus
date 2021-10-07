using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ball : MonoBehaviour
{
    [SerializeField] AudioSource BallAudioSource;
    [SerializeField] float speed = 6f;
    void Start()
    {
        var velocity = speed * transform.forward;
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(velocity, ForceMode.VelocityChange);
    }
    void OnTriggerEnter(Collider other)
    {
        BallAudioSource.Play();
    }
}
