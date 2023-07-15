using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerInteract : MonoBehaviour
{
    private bool inObject;

    void Start()
    {
        
    }

    
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.GetComponent<PointerReceiver>().interactableItem == true)
        {
            if (Input.GetKeyDown("e"))
            {
                collision.gameObject.GetComponent<PointerReceiver>().invokeFunction();
            }
            

        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PointerReceiver>().interactableItem == true)
        {

            meshOn();

        }     
    }


    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.GetComponent<PointerReceiver>().interactableItem == true)
        {

            meshOff();

        }
    }

    public void meshOn()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }

    public void meshOff()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
