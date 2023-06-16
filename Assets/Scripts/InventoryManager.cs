using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Items
{
    public int id;   
    public string name;
    public Image image;
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public Dictionary<int, Items> savedItems = new Dictionary<int, Items>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SaveItemToInventory(Items itemToSave)
    {
        if (!savedItems.ContainsValue(itemToSave))
        {
            savedItems.Add(itemToSave.id, itemToSave);
        }
    }

    public void ReleaseItemFromInventory(Items itemToRelease)
    {

        if (savedItems.ContainsValue(itemToRelease))
        {
            savedItems.Remove(itemToRelease.id);
        }
    }
}
