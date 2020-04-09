using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] GameObject prefabUI;

    public void AddToInventory(string itemName, string itemDiscription)
    {
        List<Text> texts = new List<Text>();
        GameObject uiGameObject = prefabUI;
        Component[] textComponents = uiGameObject.GetComponentsInChildren(typeof(Text));

        foreach (Text text in textComponents)
        {
            texts.Add(text);
        }
        texts[0].text = itemName;
        texts[1].text = itemDiscription;
        

        Instantiate(uiGameObject, transform);

    }


}