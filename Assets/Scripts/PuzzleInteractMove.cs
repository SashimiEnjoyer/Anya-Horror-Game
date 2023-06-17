using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteractMove : MonoBehaviour
{
    public Transform targetObject;
    public Transform targetTransform;

    //initial position to return to
    public Transform initialTransform;

    void Start()
    {
        initialTransform.position = targetObject.position;
        initialTransform.rotation = targetObject.rotation;
        initialTransform.localScale = targetObject.localScale;
    }

    public void invokeMoveToTarget()
    {
        //create empty and set transform
        targetObject.position = targetTransform.position;
        targetObject.rotation = targetTransform.rotation;
        targetObject.localScale = targetTransform.localScale;
    }

    public void invokeMoveToReturn()
    {
        targetObject.position = initialTransform.position;
        targetObject.rotation = initialTransform.rotation;
        targetObject.localScale = initialTransform.localScale;
    }
}
