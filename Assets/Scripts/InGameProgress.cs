using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameProgress : MonoBehaviour
{
    public GameObject[] progressGameObjects;
    private int lastProgress;

    public void SetGameProgress(int progress)
    {
        progressGameObjects[lastProgress].SetActive(false);
        progressGameObjects[progress].SetActive(true);
    }
}
