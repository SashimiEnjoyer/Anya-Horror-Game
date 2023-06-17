using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : InteractableItems
{
    public Items itemData;
    public override void Execute()
    {
        base.Execute();
        //Save to Invertory
        InventoryManager.instance.SaveItemToInventory(itemData);
        //Deactive Gameobject
        gameObject.SetActive(false);
    }
}
