using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractableItems : MonoBehaviour, IInteractable
{
    public UnityEvent onInteractEvent;
    [SerializeField] Sprite indicatorUISprite;
    [SerializeField] GameObject UIIndicator;

    public virtual void Execute()
    {
        Debug.Log("Item Interactable Executed!");
        onInteractEvent?.Invoke();
    }

    public void TouchItem()
    {
        if (!UIIndicator.activeInHierarchy)
        {
            UIIndicator.GetComponentInChildren<Image>().sprite = indicatorUISprite;
            UIIndicator.SetActive(true);
        }
    }

    public void UnTouchItem()
    {
        if (UIIndicator.activeInHierarchy)
        {
            UIIndicator.SetActive(false);
        }
    }
}
