using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : InteractableItems
{
    public Items itemData;
    public override void Execute()
    {
        base.Execute();
        InventoryManager.instance.SaveItemToInventory(itemData);
        gameObject.SetActive(false);
    }
}
