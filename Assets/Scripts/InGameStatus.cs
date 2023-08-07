using System;
using UnityEngine;

[System.Serializable]
public enum EStatus { pause, play, stop}

public class InGameStatus : MonoBehaviour
{

    public static Action<EStatus> OnStatusChange;
    private static EStatus _status;
    
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

}
