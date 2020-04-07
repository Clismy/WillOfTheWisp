using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField] int order;
    LightManager lightM;
    
    void Start()
    {
        lightM = GetComponentInParent<LightManager>();   
    }

    public void ActivateCandle()
    {
        lightM.CheckIfCorrect(order);
    }
}