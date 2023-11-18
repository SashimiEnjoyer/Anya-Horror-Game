using DG.Tweening;
using UnityEngine;

public class Door : InteractableItems
{
    [Header("Door Settings")]
    [Space]
    [SerializeField] GameObject objectToMove;
    public bool isSlide = false;
    public bool isReversed = false;
    public bool isPositive = false;
    public float deltaRotation = 90;
    public float timeRotation = 1;

    private void Awake()
    {
        if (objectToMove == null)
            objectToMove = gameObject;
    }

    public override void Execute()
    {
        base.Execute();

        if (isSlide)
        {
            if (isReversed)
            {
                if (isPositive)
                {
                    //transform.Rotate(0, 90, 0);
                    DOTweenModulePhysics.DOMoveX(objectToMove.GetComponent<Rigidbody>(), transform.position.x + 10, 1f);
                    isPositive = false;

                }
                else
                {
                    DOTweenModulePhysics.DOMoveX(objectToMove.GetComponent<Rigidbody>(), transform.position.x - 10, 1f);
                    isPositive = true;
                }
            }
        }
        else
        {
            if (isReversed)
            {
                if (isPositive)
                {
                    //transform.Rotate(0, 90, 0);
                    DOTweenModulePhysics.DORotate(objectToMove.GetComponent<Rigidbody>(), transform.rotation.eulerAngles + new Vector3(0, deltaRotation, 0), timeRotation);
                    isPositive = false;
                }
                else
                {
                    DOTweenModulePhysics.DORotate(objectToMove.GetComponent<Rigidbody>(), transform.rotation.eulerAngles + new Vector3(0, -deltaRotation, 0), timeRotation);
                    isPositive = true;
                }
            }
        }
        
    }
}
