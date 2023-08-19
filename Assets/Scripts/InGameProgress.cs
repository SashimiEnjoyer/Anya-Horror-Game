using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameProgress : MonoBehaviour
{
    public static InGameProgress instance;

    public GameObject[] progressGameObjects;
    private int lastProgress;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void SetGameProgress(int progress)
    {
        progressGameObjects[lastProgress].SetActive(false);
        progressGameObjects[progress].SetActive(true);
        lastProgress = progress;
    }

    //InGameProgress.instance.SetGameProgress(0);
}
