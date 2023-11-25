using UnityEngine;

public class InGameProgressCrossScene : MonoBehaviour
{
    public void SetGameProgressCross(int progress)
    {
        GameObject.FindGameObjectWithTag("Progress").GetComponent<InGameProgress>().SetGameProgress(progress);
    }
}
