using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] string itemDiscription;

    public string GetItemName()
    {
        return itemName;
    }
    public string GetItemDiscription()
    {
        return itemDiscription;
    }
    
}