using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffHand : MonoBehaviour
{
    [SerializeField] GameObject Onhand;
    [SerializeField] GameObject Offhand;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(this.transform.rotation.eulerAngles.x);
        if (this.transform.rotation.eulerAngles.x <= 340 && this.transform.rotation.eulerAngles.x >= 85)
        {
            Onhand.SetActive(true);
            Offhand.SetActive(false);
        }
        else
        {
            Offhand.SetActive(true); 
            Onhand.SetActive(false);
        }
    }
}
