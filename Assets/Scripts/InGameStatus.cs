using System;
using UnityEngine;

[System.Serializable]
public enum EStatus { pause, play, stop}

public class InGameStatus : MonoBehaviour
{

    public static InGameStatus instance;

    public Action<EStatus> OnStatusChange;
    private EStatus _status;
    
    public EStatus status
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

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        status = EStatus.stop;
    }
}
