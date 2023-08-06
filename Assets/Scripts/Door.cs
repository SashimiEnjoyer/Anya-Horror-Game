using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public bool isSlide = false;
    public bool isReversed = false;
    public bool isPositive = false;
    public bool takingOrder = false;
    public float deltaRotation = 90;
    public float timeRotation = 1;

    public bool playerInDoors = false;
    private float timer = 0;

    public void Execute()
    {
        if (takingOrder == false)
        {
            takingOrder = true;

            if (isSlide)
            {
                if (isReversed)
                {
                    if (isPositive)
                    {
                        //transform.Rotate(0, 90, 0);
                        DOTweenModulePhysics.DOMoveX(gameObject.GetComponent<Rigidbody>(), transform.position.x + 10, 1f);
                        isPositive = false;

                    }
                    else
                    {
                        DOTweenModulePhysics.DOMoveX(gameObject.GetComponent<Rigidbody>(), transform.position.x - 10, 1f);
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
                        isSlide = true;
                        //transform.Rotate(0, 90, 0);
                        DOTweenModulePhysics.DORotate(gameObject.GetComponent<Rigidbody>(), transform.rotation.eulerAngles + new Vector3(0, deltaRotation, 0), timeRotation);
                        isPositive = false;

                    }
                    else
                    {
                        isSlide = true;
                        DOTweenModulePhysics.DORotate(gameObject.GetComponent<Rigidbody>(), transform.rotation.eulerAngles + new Vector3(0, -deltaRotation, 0), timeRotation);
                        isPositive = true;
                    }
                }
            }
        }
    }

    public void TouchItem()
    {
        //throw new System.NotImplementedException();
    }


    void Update()
    {
        

        if(takingOrder == true)
        {
            timer += Time.deltaTime;

            GetComponent<Collider>().isTrigger = true;

            if(timer >= timeRotation)
            {
                timer = 0;
                isSlide = false;
                GetComponent<Collider>().isTrigger = false;
                takingOrder = false;
            }
        }

        if(playerInDoors == true)
            GetComponent<Collider>().isTrigger = true;
        
        if(playerInDoors == false && isSlide == false) 
            GetComponent<Collider>().isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
            playerInDoors = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") 
            playerInDoors = false;
    }

    public void UnTouchItem()
    {
        //throw new System.NotImplementedException();
    }
}
