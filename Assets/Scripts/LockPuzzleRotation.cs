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
        selfTransform.Rotate(deltaRotation, 0, 0, Space.World);
    }

    public void rotateLockReverse()
    {
        selfTransform.Rotate(-deltaRotation, 0, 0, Space.World);
    }
}
