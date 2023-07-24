using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTeleport : MonoBehaviour
{
    public Transform objectToTeleport;
    public Transform PointA;
    public Transform PointB;

    public bool findPlayerObject = false;


    void Start()
    {
        if (findPlayerObject && GameObject.FindGameObjectsWithTag("Player") != null)
            objectToTeleport = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toPointA()
    {
        objectToTeleport.position = PointA.position;
        objectToTeleport.rotation = PointA.rotation;
    }

    public void toPointB()
    {
        objectToTeleport.position = PointB.position;
        objectToTeleport.rotation = PointA.rotation;
    }
}
