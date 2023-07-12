using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemInteractAppear : MonoBehaviour
{
    private bool puzzleOngoing = false;
    public GameObject ItemAppear;

    [Header("Temporary Invoke Function to script FirstPersonController on FreezeMovement()")]
    public UnityEvent onInteractEvent;

    [Header("Universal Value use on all function")]
    public int universalValue = 000;

    [Header("Puzzle Finish Event")]
    public UnityEvent onFinishEvent;

    [Header("Puzzle Exit Event")]
    public UnityEvent onEndEvent;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && puzzleOngoing == true)
        {  
            onEndEvent.Invoke();
            puzzleEnd();
        }

        if (puzzleOngoing == true)
        {
            getReturnValueFromChild();
        }
    }

    public void spawnPuzzle(GameObject spawnObject)
    {
        if (puzzleOngoing == false)
        {
            Instantiate(spawnObject, ItemAppear.transform);
            onInteractEvent?.Invoke();
            puzzleOngoing = true;
        }

        setUniversalValueonChild();

        if (onFinishEvent != null)
            ItemAppear.transform.GetChild(0).GetComponent<PuzzleController>().onFinish = onFinishEvent;

        if (onEndEvent != null)
            ItemAppear.transform.GetChild(0).GetComponent<PuzzleController>().onEnd = onEndEvent;

    }

    public void destroyChild()
    {
        int childs = ItemAppear.transform.childCount;

        for (int i = childs - 1; i >= 0; i--)
        {
            GameObject.Destroy(ItemAppear.transform.GetChild(i).gameObject);
        }
    }

    public void setUniversalValue(int setNumber)
    {
        universalValue = setNumber;
    }

    public void setUniversalValueonChild()
    {
        ItemAppear.transform.GetChild(0).GetComponent<PuzzleController>().universalValue = universalValue;
    }

    public void puzzleEnd()
    {
        if (puzzleOngoing == true)
        {
            destroyChild();
            puzzleOngoing = false;
        }
    }

    public void getReturnValueFromChild()
    {
        if(ItemAppear.transform.GetChild(0).GetComponent<PuzzleController>() != null)
            universalValue = ItemAppear.transform.GetChild(0).GetComponent<PuzzleController>().universalValue;
    }
}
