using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemInteractAppear : MonoBehaviour
{
    public Transform point1;
    public Transform point2;

    [Header("Temporary Invoke Function to script FirstPersonController on FreezeMovement()")]
    public UnityEvent onInteractEvent;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            moveDown();
            destroyChild();
        }
    }

    public void moveUp() // change to using tween
    {
        transform.position = point1.position;
    }

    public void moveDown() //change to using tween
    {
        transform.position = point2.position;
    }

    public void spawnPuzzle(GameObject spawnObject)
    {
        Instantiate(spawnObject, transform);
        onInteractEvent?.Invoke();
        moveUp();
    }

    public void destroyChild()
    {
        int childs = transform.childCount;

        for (int i = childs - 1; i >= 0; i--)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }
}
