using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointerReceiver : MonoBehaviour
{

    public bool interactableItem = true; //keep true

    [SerializeField] UnityEvent onTrigger;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void invokeFunction()
    {
        onTrigger.Invoke();
    }

    public void testFunction()
    {
        Debug.Log("Anya is my wife.");
    }
}
