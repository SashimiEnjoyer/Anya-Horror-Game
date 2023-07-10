using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTrigger : MonoBehaviour
{
    public bool getLookAt;
    public bool isActive = false;

    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().isTrigger = true;
    }

    void Update()
    {
        if (isActive == true)
        {
            if (getLookAt == true)
                setDisappear();
            else if (getLookAt == false)
            {
                setAppear();
                isActive = false;
            }
        }
    }

    public void setActive()
    {
        isActive = true;
    }

    public void setAppear()
    {
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Collider>().isTrigger = false;
    }

    public void setDisappear()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().isTrigger = true;
    }

}
