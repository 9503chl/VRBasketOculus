using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllClear : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Invoke("allclear", 0.5f);
    }
    void allclear()
    {
        SceneManager.LoadScene("SelectStage");
    }
}
