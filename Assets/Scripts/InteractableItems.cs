using UnityEngine;
using UnityEngine.Events;

public class InteractableItems : MonoBehaviour, IInteractable
{
    public UnityEvent onInteractEvent;
    public GameObject UIIndicator;

    public virtual void Execute()
    {
        Debug.Log("Item Interactable Executed!");
        onInteractEvent?.Invoke();
    }

    public void TouchItem()
    {
        Debug.Log($"Touched {gameObject.name}");
    }
}
