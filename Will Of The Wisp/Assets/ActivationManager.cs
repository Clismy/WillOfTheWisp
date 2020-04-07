using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationManager : MonoBehaviour
{
    [SerializeField] Interaction myInteraction = Interaction.Lever;

    Lever l;
    Candle c;

    private enum Interaction
    {
        Lever,
        Candle,
        Weight
    }

    void Start()
    {
        if(myInteraction == Interaction.Lever)
        {
            l = GetComponent<Lever>();
        }
        else if(myInteraction == Interaction.Candle)
        {
            c = GetComponent<Candle>();
        }
    }

    public void Activate()
    {
        if(l != null)
        {
            l.InteractLever();
        }
        else if(c != null)
        {
            c.ActivateCandle();
        }
    }
}