using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameProgressCrossScene : MonoBehaviour
{
    public InGameProgress inGameProgress;

    void Start()
    {
        inGameProgress = GameObject.Find("GameStaging").GetComponent<InGameProgress>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameProgressCross(int progress)
    {
        inGameProgress.SetGameProgress(progress);
    }
}
