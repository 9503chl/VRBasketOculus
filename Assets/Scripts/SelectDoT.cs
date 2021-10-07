using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SelectDoT : MonoBehaviour
{
    public Text text1;
    // Update is called once per frame
    void Start()
    {
        text1.DOText("Select Stage", 2.0f);
    }

}
