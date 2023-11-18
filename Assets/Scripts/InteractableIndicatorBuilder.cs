using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InteractableIndicatorBuilder : MonoBehaviour
{
    public static InteractableIndicatorBuilder instance;
    private bool isActive;
    [SerializeField] GameObject indicatorObject;
    [SerializeField] Image indicatorImage;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    public void SetIndicator(Sprite sprite)
    {
        if (sprite == null)
            return;

        if (!isActive)
        {
            indicatorObject.SetActive(true);
            isActive = true;    
        }

        indicatorImage.sprite = sprite;

    }

    public void HideIndicator()
    {
        if (isActive)
        {
            indicatorObject.SetActive(false);
            isActive = false;
        }
    }
}
