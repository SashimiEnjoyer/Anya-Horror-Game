using System;
using UnityEngine;

[System.Serializable]
public enum EStatus { pause, play, stop}

[Serializable]
public class ProgressTracker
{
    public bool walletTaken;
    public bool trashTaken;
}

public class InGameStatus : MonoBehaviour
{
    public static Action<EStatus> OnStatusChange;
    private static EStatus _status;
    public static ProgressTracker myProgressTracker = new ProgressTracker();

    public static EStatus status
    {
        set
        {
            _status = value;
            OnStatusChange?.Invoke(value);
        }

        get
        {
            return _status;
        }
    }

    //public static bool IsConditionSatisfied(ProgressTracker interactableProgress)
    //{
    //    return 
    //}
}
