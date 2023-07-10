using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractor : MonoBehaviour
{
    [SerializeField] Transform startRayPosition;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] GameObject UIIndicator;
    [SerializeField] float rayLength = 2f;

    

    bool itemTouched = false;
    IInteractable currentTouchedItem = null;

    private void Start()
    {
        InGameInput.onInteractPressed += InteractPressed; 
    }

    private void OnDestroy()
    {
        InGameInput.onInteractPressed -= InteractPressed;
    }

    private void FixedUpdate()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(startRayPosition.position, startRayPosition.TransformDirection(Vector3.forward), out hit, rayLength, interactableLayer))
        {
            if(!UIIndicator.activeInHierarchy)
                UIIndicator.SetActive(true);
            
            currentTouchedItem ??= hit.transform.GetComponent<IInteractable>();
            
            currentTouchedItem.TouchItem();

            if (!itemTouched)
                itemTouched = true;
            Debug.DrawRay(startRayPosition.position, startRayPosition.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        else
        {
            if (currentTouchedItem != null)
                currentTouchedItem = null;

            if (UIIndicator.activeInHierarchy)
                UIIndicator.SetActive(false);

            if (itemTouched)
                itemTouched = false;
             Debug.DrawRay(startRayPosition.position, startRayPosition.TransformDirection(Vector3.forward) * rayLength, Color.white);
        }

        

    }

    void InteractPressed()
    {
        if (itemTouched)
            currentTouchedItem?.Execute();

    }


}
