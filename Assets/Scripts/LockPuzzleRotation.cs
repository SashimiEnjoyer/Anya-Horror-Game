using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPuzzleRotation : MonoBehaviour
{
    private float deltaRotation = 36;
    private Transform selfTransform;


    void Start()
    {
        selfTransform = GetComponent<Transform>();
    }

    public void rotateLock()
    {
        selfTransform.Rotate(0, 0, deltaRotation, Space.Self);
    }

    public void rotateLockReverse()
    {
        selfTransform.Rotate(0, 0, -deltaRotation, Space.Self);
    }
}
