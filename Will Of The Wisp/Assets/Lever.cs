using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] float amount;

    bool activated = false;

    Meter meter;

    // Start is called before the first frame update
    void Start()
    {
        meter = transform.GetComponentInParent<Meter>();
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractLever()
    {
        activated = !activated;

        float amountToSend = activated ? amount : -amount;


        meter.GetAmount(amountToSend);
        //meter.ChangeLever(amountToSend);

    }

    public void DisableLever()
    {
        activated = false;
    }
}