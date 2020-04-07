using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] string itemName;

    public string GetItemName()
    {
        return itemName;
    }
}