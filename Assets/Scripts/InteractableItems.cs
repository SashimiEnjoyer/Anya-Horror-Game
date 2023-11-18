using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InteractableItems : MonoBehaviour, IInteractable
{
    [Header("Base Interactable")]
    [Space]
    public ProgressTracker progress = new ProgressTracker();
    public UnityEvent onInteractEvent;
    public UnityEvent onFalseConditionEvent;
    [SerializeField] Sprite indicatorUISprite;
    [SerializeField] GameObject UIIndicator;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip successInteractionClip;
    [SerializeField] protected AudioClip falseInteractionClip;

    private void Awake()
    {
        if(audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public virtual void Execute()
    {
        Debug.Log("Item Interactable Executed!");
        audioSource?.PlayOneShot(successInteractionClip);
        onInteractEvent?.Invoke();
    }

    public void TouchItem()
    {
        if (UIIndicator == null)
            return;

        if (!UIIndicator.activeInHierarchy)
        {
            UIIndicator.SetActive(true);
            UIIndicator.GetComponentInChildren<Image>().sprite = indicatorUISprite;
        }
    }

    public void UnTouchItem()
    {
        if (UIIndicator == null)
            return;

        if (UIIndicator.activeInHierarchy)
        {
            UIIndicator.SetActive(false);
        }
    }
}
