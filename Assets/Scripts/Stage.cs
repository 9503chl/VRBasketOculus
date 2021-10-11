using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    public AudioSource StageSound;
    void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.name == "RetryB")
        {
            StageSound.Play();
            Invoke("Retry", 0.7f);
        }
        if (this.gameObject.name == "EndB")
        {
            StageSound.Play();
            Invoke("End1", 0.7f);
        }
        if (this.gameObject.name == "NextB")
        {
            StageSound.Play();
            Invoke("NextStage", 0.7f);
        }
        
    }
    void Retry()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }
    void End1()
    {
        SceneManager.LoadScene("SelectStage");
    }
    void NextStage()
    {
        if(SceneManager.GetActiveScene().name == "Stage1") SceneManager.LoadScene("Stage2");
        else if (SceneManager.GetActiveScene().name == "Stage2") SceneManager.LoadScene("Stage3");
        else SceneManager.LoadScene("AllClear");
    }
}
