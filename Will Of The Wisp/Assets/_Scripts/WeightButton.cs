using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightButton : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] int amount;

    bool activated = false;

    public Scale scale;
    [SerializeField] Sprite myImage;

    void Start()
    {
        activated = false;
    }

    public void InteractLever()
    {
        activated = !activated;
        

        int amountToSend = activated ? amount : -amount;
        scale.GetAmount(amountToSend, myImage);
    }

    public void DisableLever()
    {
        activated = false;
    }
}