using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectPointerMovement : MonoBehaviour
{
    private float currentY;
    private float initialY;
    public float deltaMove;
    private float delay = 5;

    void Start()
    {
        initialY = transform.position.y;
        transform.DOMoveY(initialY + deltaMove + 0.1f, delay, false);
    }

    // Update is called once per frame
    void Update()
    {
        currentY = transform.position.y;

        if (currentY >= initialY + deltaMove + 0.01f)
            transform.DOMoveY(initialY - (deltaMove * 1) - 0.1f, delay, false);

        if (currentY <= initialY - deltaMove - 0.01f)
            transform.DOMoveY(initialY + (deltaMove * 1) + 0.1f, delay, false);

    }
}
