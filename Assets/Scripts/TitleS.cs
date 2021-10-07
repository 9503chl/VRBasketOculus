using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleS : MonoBehaviour
{
    public AudioSource TitleSound;
    public GameObject button1, button2;

    void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == "TouchPoint1")
        {
            TitleSound.Play();
            Invoke("StartG", 0.9f);
        }
        if (this.gameObject.name == "TouchPoint2")
        {
            TitleSound.Play();
            Invoke("QuitG", 0.9f);
        }
    }
    void StartG()
    {
        SceneManager.LoadScene("SelectStage");
        button1.transform.GetComponent<MeshRenderer>().material.DOFade(0,0.7f);
    }
    void QuitG()
    {
        Application.Quit();
        button2.transform.GetComponent<MeshRenderer>().material.DOFade(0, 0.7f);
    }
}
