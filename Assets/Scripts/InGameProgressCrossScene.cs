using UnityEngine;

public class InGameProgressCrossScene : MonoBehaviour
{
    public void SetGameProgressCross(int progress)
    {
        GameObject.Find("InGame Essentials").GetComponent<InGameProgress>().SetGameProgress(progress);
    }
}
