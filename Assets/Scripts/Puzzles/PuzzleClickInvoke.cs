using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleClickInvoke : MonoBehaviour
{
    [SerializeField] UnityEvent onTrigger;

    private void OnMouseDown()
    {
        onTrigger.Invoke();
    }
}
