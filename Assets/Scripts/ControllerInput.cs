using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    public GameObject ShootingBall;
    public Transform firePos;
    
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            ShootBall();
        }
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            ShootBall();
        }
#endif
    }
    void ShootBall()
    {
        Instantiate(ShootingBall, firePos.position, firePos.rotation);
    }
}
