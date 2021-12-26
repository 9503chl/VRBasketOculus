using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeed : MonoBehaviour
{
    private Rigidbody rb;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        rb.AddRelativeForce(Vector3.forward * 2000.0f);
    }
    private void Update()
    {
        tr.Rotate(2.5f, 0, 0);
    }
}
