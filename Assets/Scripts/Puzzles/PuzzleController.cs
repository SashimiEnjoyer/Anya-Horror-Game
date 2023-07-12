using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleController : MonoBehaviour
{
    public int universalValue;
    public UnityEvent onFinish;
    public UnityEvent onEnd;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setUniversalValue(int setNumber)
    {
        universalValue = setNumber;
    }
}
