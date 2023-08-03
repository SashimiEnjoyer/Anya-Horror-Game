using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LookTrigger : MonoBehaviour
{
    public bool getLookAt;
    public bool isActive;
    public UnityEvent lookAtEvent;
    public UnityEvent notLookEvent;

    void Start()
    {

    }

    void Update()
    {
        if (isActive == true)
        {
            if (getLookAt == true)
            {
                lookAtEvent.Invoke();
            }

            if (getLookAt == false)
            {
                notLookEvent.Invoke();
            }
                

        }
    }

    public void setActive()
    {
        isActive = true;
    }
}
