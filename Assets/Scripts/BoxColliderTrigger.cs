using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxColliderTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;
    public bool isActive = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isActive == true)
            onTriggerEnter.Invoke();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && isActive == true)
            onTriggerExit.Invoke();
    }

    public void deactivate()
    {
        isActive = false;
    }
}
