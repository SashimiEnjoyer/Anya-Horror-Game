using UnityEngine;

public class ItemInteractor : MonoBehaviour
{
    [SerializeField] Transform startRayPosition;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] GameObject UIIndicator;
    [SerializeField] float rayLength = 2f;

    public bool isInteracting = false;
    public GameObject pointer;

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
            currentTouchedItem ??= hit.transform.GetComponent<IInteractable>();
            
            currentTouchedItem.TouchItem();

            if (!itemTouched)
                itemTouched = true;

            Debug.DrawRay(startRayPosition.position, startRayPosition.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
        else
        {
            if (currentTouchedItem != null)
            {
                currentTouchedItem.UnTouchItem();
                currentTouchedItem = null;
            }

            if (itemTouched)
                itemTouched = false;

             Debug.DrawRay(startRayPosition.position, startRayPosition.TransformDirection(Vector3.forward) * rayLength, Color.white);
        }

        if (isInteracting == false)
            pointer.SetActive(true);
        else 
            pointer.SetActive(false);

    }

    void InteractPressed()
    {
        if (itemTouched)
            currentTouchedItem?.Execute();

    }


}
