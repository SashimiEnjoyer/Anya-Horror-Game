using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void Execute();
    public void TouchItem();
    public void UnTouchItem();
}
