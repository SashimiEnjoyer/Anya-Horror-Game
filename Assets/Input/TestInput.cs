
using UnityEngine;

public class TestInput : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        InGameInput.onInteractPressed += TestInteract;
    }

    private void OnDestroy()
    {
        InGameInput.onInteractPressed -= TestInteract;
    }

    private void TestInteract()
    {
        Debug.Log("Interact Pressed!");

        player.transform.position = new Vector3(1, 0.7f, 0);    
    }
}
