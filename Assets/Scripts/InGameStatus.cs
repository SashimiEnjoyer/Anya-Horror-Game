using System;
using UnityEngine;

[System.Serializable]
public enum EStatus { pause, play, stop, dialogue}

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

    public static EStatus Status
    {
        set
        {
            _status = value;

            switch (_status)
            {
                case EStatus.pause:
                    Cursor.lockState = CursorLockMode.None;
                    break;
                case EStatus.play:
                    Cursor.lockState = CursorLockMode.Locked;
                    break;
                case EStatus.stop:
                    Cursor.lockState = CursorLockMode.None;
                    break;
                case EStatus.dialogue:
                    Cursor.lockState = CursorLockMode.Locked;
                    break;
                default:
                    break;
            }

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
