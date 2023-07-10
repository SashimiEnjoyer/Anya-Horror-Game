using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualTrigger : MonoBehaviour
{
    [SerializeField] Transform startRayPosition;
    [SerializeField] LayerMask visualLayer;

    private GameObject temporaryObject;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, visualLayer))
        {
            hit.collider.gameObject.GetComponent<LookTrigger>().getLookAt = true;
            temporaryObject = hit.collider.gameObject;
        }
        else
        {
            if (temporaryObject != null)
            {
                temporaryObject.GetComponent<LookTrigger>().getLookAt = false;
                temporaryObject = null;
            }

        }
    }
}
