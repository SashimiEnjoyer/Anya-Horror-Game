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
        InteractableIndicatorBuilder.instance.SetIndicator(indicatorUISprite);
    }

    public void UnTouchItem()
    {
        InteractableIndicatorBuilder.instance.HideIndicator();
    }
}
