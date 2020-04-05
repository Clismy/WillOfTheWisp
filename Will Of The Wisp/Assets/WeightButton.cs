using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButton : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] int amount;

    bool activated = false;

     public Scale scale;

    // Start is called before the first frame update
    void Start()
    {
        activated = false;
    }

    public void InteractLever()
    {
        activated = !activated;

        int amountToSend = activated ? amount : -amount;
        scale.GetAmount(amountToSend);
    }

    public void DisableLever()
    {
        activated = false;
    }
}
