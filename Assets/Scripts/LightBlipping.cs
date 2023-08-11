using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlipping : MonoBehaviour
{
    public float blippingInterval = 3;

    public float timer;


    void Start()
    {
        timer = 0;
    }

    
    void Update()
    {
        timer += Time.deltaTime / 1;

        if (timer > blippingInterval + 0.5 && timer < blippingInterval + 0.8)
        {
            GetComponent<Light>().enabled = false;
        }

        if (timer > blippingInterval + 1 && timer < blippingInterval + 1.2)
        {
            GetComponent<Light>().enabled = true;
        }

        if (timer > blippingInterval + 2 && timer < blippingInterval + 2.3)
        {
            GetComponent<Light>().enabled = false;
        }

        if (timer > blippingInterval + 2.8)
        {
            GetComponent<Light>().enabled = true;
            timer = 0;
        }
    }
}
