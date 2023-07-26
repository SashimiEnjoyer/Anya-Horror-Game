using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokewithTimer : MonoBehaviour
{
    public UnityEvent Events;
    public bool isStarting = false;
    private float timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarting == true)
        {
            timer -= Time.deltaTime*2;

            if (timer < 0)
            {
                Events.Invoke();
                isStarting = false;
            }
        }
    }

    public void startEvent(float delay)
    {
        timer = delay;
        isStarting = true;
    }
}
