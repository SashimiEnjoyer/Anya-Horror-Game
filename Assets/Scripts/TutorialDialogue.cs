using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;


public class TutorialDialogue : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public bool isInputing;
    public float timingInScreen;
    private float initialTime;

    // Start is called before the first frame update
    void Start()
    {
        initialTime = timingInScreen;
    }

    // Update is called once per frame
    void Update()
    {


        if (isInputing == true)
        {
            timingInScreen -= Time.deltaTime*2;

            if (timingInScreen < 0)
            {
                timeOut();
            }
        }
    }

    public void inputText(string text)
    {
        if (isInputing == false)
        {
            textMesh.text = text;
            isInputing = true;
            textMesh.DOFade(1, 2);
            Debug.Log("it just works");
        }
        else
        {
            textMesh.text = text;
            timingInScreen = initialTime;
        }
    }

    public void setTiming(float timing)
    {
        timingInScreen = timing;
        initialTime = timing;
    }

    public void timeOut()
    {
        isInputing = false;
        textMesh.DOFade(0, 2);
        timingInScreen = initialTime;
    }

    public void midChange(string text)
    {
        textMesh.text = text;
    }
}


