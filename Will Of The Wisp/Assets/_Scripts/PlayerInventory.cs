using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInventory : MonoBehaviour
{
    [SerializeField] List<Item> items = new List<Item>();
    [SerializeField] UIInventory uiinventory;

    public void AddToInventory(string itemNameToAdd, string itemDiscriptionToAdd)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].name == itemNameToAdd)
            {
                items[i].AddToInventory();
                uiinventory.AddToInventory(items[i].name, itemDiscriptionToAdd);
                return;
            }
        }
    }

    public bool ExistsInInventory(string findName)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if(items[i].name == findName && items[i].inInventory)
            {
                return true;
            }
        }
        return false;
    }
}

[System.Serializable]
class Item
{
    public string name;
    public bool inInventory;

    public void AddToInventory()
    {
        inInventory = true;
    }
}