using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameProgress : MonoBehaviour
{

    public GameObject[] progressGameObjects;
    private int lastProgress;

    public void SetGameProgress(int progress)
    {
        Debug.LogWarning("Execute! " + progress);
        progressGameObjects[lastProgress].SetActive(false);
        progressGameObjects[progress].SetActive(true);
        lastProgress = progress;
    }

    //InGameProgress.instance.SetGameProgress(0);
}
