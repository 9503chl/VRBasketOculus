using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject ballPrefabs;
    [SerializeField] GameObject SballPrefabs;
    [SerializeField] Transform hands;

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetButtonDown("Fire2")) ShootS();
#endif
        if ((OVRInput.GetDown(OVRInput.RawButton.B))) Shoot();
        if ((OVRInput.GetDown(OVRInput.RawButton.A))) ShootS();
    }
    void Shoot()
    {
        Instantiate(ballPrefabs,hands.position, hands.rotation);
    }
    void ShootS()
    {
        Instantiate(SballPrefabs, hands.position, hands.rotation);
    }
}
