using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class UIFadeInOut : MonoBehaviour
{
    public UnityEvent eventInLoading;
    public Image fadeScreen;
    private float imageAlpha;
    public bool fadingIn = false;
    public bool fadingInOnly = false;
    public float duration = 1;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        imageAlpha = fadeScreen.color.a;

        if (fadingIn == true )
        {
            if(imageAlpha == 1)
            {
                
                eventInLoading.Invoke();
                FadeOut();
            }
        }

        if (fadingInOnly == true)
        {
            if (imageAlpha == 1)
            {
                eventInLoading.Invoke();
            }
        }
    }

    public void FadeIn()
    {
        fadeScreen.DOFade( 1, duration);
        fadingIn = true;
    }

    public void FadeOut()
    {
        fadeScreen.DOFade( 0, duration);
        fadingIn = false;
        fadingInOnly = false;
    }

    public void FadeInOnly()
    {
        fadeScreen.DOFade(1, duration);
        fadingInOnly = true;
    }
}
