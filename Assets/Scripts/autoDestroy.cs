using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestroy : MonoBehaviour
{
    [SerializeField] float lifetime = 4f;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
