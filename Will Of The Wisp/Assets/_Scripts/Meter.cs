using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
    public List<Lever> levers;

    public float meterAmount = 0f;
    
    [Range (0,100)]
    [SerializeField] float maxAmount;

    [SerializeField] Slider UIMeter;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            levers.Add(transform.GetChild(i).GetComponent<Lever>()); 
        }
    }

    public void GetAmount(float amountToSend)
    {
        meterAmount += amountToSend;

        if (meterAmount > maxAmount)
        {
            DeactivateLevers();
        }

        UIMeter.value = meterAmount / 100;

    }
    public void DeactivateLevers()
    {
        for (int i = 0; i < levers.Count; i++)
        {
            levers[i].DisableLever(); 
        }
        meterAmount = 0f;
    }
}
