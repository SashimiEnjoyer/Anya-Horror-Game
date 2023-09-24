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

    public void RotateY(float y)
    {
        transform.DORotate(new Vector3 (transform.rotation.x, y, transform.rotation.z), duration);
    }
}
