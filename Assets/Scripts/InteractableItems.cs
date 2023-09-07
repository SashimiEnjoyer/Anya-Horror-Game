using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractableItems : MonoBehaviour, IInteractable
{
    public bool findIndicatorUISprite;
    public ProgressTracker progress = new ProgressTracker();
    public UnityEvent onInteractEvent;
    public UnityEvent onFalseConditionEvent;
    [SerializeField] Sprite indicatorUISprite;
    [SerializeField] GameObject UIIndicator;

    void Awake()
    {
        if (findIndicatorUISprite == true)
            UIIndicator = GameObject.Find("Panel Item Indicator");
    }

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
