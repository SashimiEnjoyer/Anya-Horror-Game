using UnityEngine;

public class InGameProgressCrossScene : MonoBehaviour
{
    public void SetGameProgressCross(int progress)
    {
        InGameProgress.instance.SetGameProgress(progress);
    }
}
