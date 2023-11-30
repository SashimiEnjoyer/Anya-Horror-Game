using DG.Tweening;
using UnityEngine;

public class Door : InteractableItems
{
    [Header("Door Settings")]
    [Space]
    [SerializeField] GameObject objectToMove;
    public bool isSlide = false;
    public bool isSlideAxisZ = false;
    public bool isReversed = false;
    public bool isPositive = false;
    public float deltaRotation = 90;
    public float deltaMove = 10;
    public float timeRotation = 1;
    private bool isExecuting = false;
    private float time = 0;

    private void Awake()
    {
        if (objectToMove == null)
            objectToMove = gameObject;
    }

    void Update()
    {
        if (isExecuting)
        {
            time += Time.deltaTime;

            if (time > timeRotation + 0.5)
            {
                isExecuting = false;
                time = 0;
            }
        }
    }

    public override void Execute()
    {
        if (!isExecuting)
        {
            base.Execute();
            isExecuting = true;

            if (isSlide)
            {
                if (isReversed)
                {
                    if (!isSlideAxisZ)
                    {
                        if (isPositive)
                        {
                            //transform.Rotate(0, 90, 0);
                            DOTweenModulePhysics.DOMoveX(objectToMove.GetComponent<Rigidbody>(), transform.position.x + deltaMove, 1f);
                            isPositive = false;

                        }
                        else
                        {
                            DOTweenModulePhysics.DOMoveX(objectToMove.GetComponent<Rigidbody>(), transform.position.x - deltaMove, 1f);
                            isPositive = true;
                        }
                    }
                    else
                    {
                        if (isPositive)
                        {
                            DOTweenModulePhysics.DOMoveZ(objectToMove.GetComponent<Rigidbody>(), transform.position.z + deltaMove, 1f);
                            isPositive = false;

                        }
                        else
                        {
                            DOTweenModulePhysics.DOMoveZ(objectToMove.GetComponent<Rigidbody>(), transform.position.z - deltaMove, 1f);
                            isPositive = true;
                        }
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
}
