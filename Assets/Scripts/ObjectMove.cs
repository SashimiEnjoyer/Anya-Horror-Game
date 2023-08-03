using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectMove : MonoBehaviour
{
    public Transform goToPosition;
    public float duration; 

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Move()
    {
        transform.DOMove(goToPosition.position, duration);
    }
}
