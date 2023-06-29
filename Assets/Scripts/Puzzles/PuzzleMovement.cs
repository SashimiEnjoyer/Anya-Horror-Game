using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMovement : MonoBehaviour
{
    public GameObject mainBody;
    public float rotateSensitivity = 2;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKey("w"))
        {
            mainBody.transform.Rotate(rotateSensitivity, 0, 0, Space.World);
        }

        if (Input.GetKey("s"))
        {
            mainBody.transform.Rotate( -1* rotateSensitivity, 0, 0, Space.World);
        }

        if (Input.GetKey("a"))
        {
            mainBody.transform.Rotate(0, rotateSensitivity, 0, Space.World);
        }

        if (Input.GetKey("d"))
        {
            mainBody.transform.Rotate(0, -1 * rotateSensitivity, 0, Space.World);
        }

        if (Input.GetKey("q"))
        {
            mainBody.transform.Rotate(0, 0, rotateSensitivity, Space.World);
        }

        if (Input.GetKey("e"))
        {
            mainBody.transform.Rotate(0, 0, -1 * rotateSensitivity, Space.World);
        }
    }
}
