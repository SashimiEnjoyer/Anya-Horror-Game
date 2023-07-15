using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhotoFrame : MonoBehaviour
{
    public int universalValue;

    public UnityEvent function1;
    public UnityEvent function2;

    public int value1;
    public int value2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<ItemInteractAppear>() != null)
            universalValue = GetComponent<ItemInteractAppear>().universalValue;

        if (GetComponent<PuzzleController>() != null)
            universalValue = GetComponent<PuzzleController>().universalValue;

        if (universalValue == value1)
            function1.Invoke();

        if (universalValue == value2)
            function2.Invoke();
    }
}
