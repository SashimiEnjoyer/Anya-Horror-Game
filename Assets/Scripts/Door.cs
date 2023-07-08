using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool isSlide = false;
    public bool isReversed = false;
    public bool isPositive = false;

    public void Execute()
    {
        Debug.Log("Execute " + transform.rotation);

        if (isSlide)
        {

        }
        else
        {
            if (isReversed)
            {
                if (isPositive)
                {
                    //transform.Rotate(0, 90, 0);
                    DOTweenModulePhysics.DORotate(gameObject.GetComponent<Rigidbody>(),transform.rotation.eulerAngles + new Vector3(0, 90, 0), 1);
                    isPositive = false;
                    
                }else
                {
                    DOTweenModulePhysics.DORotate(gameObject.GetComponent<Rigidbody>(), transform.rotation.eulerAngles + new Vector3(0, -90, 0), 1);
                    isPositive = true;
                }
            }
        }
    }

    public void TouchItem()
    {
        //throw new System.NotImplementedException();
    }
}
