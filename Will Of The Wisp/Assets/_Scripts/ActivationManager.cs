using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ActivationManager : MonoBehaviour
{
    [SerializeField] Interaction myInteraction = Interaction.Lever;

    Lever l;
    Candle c;
    TransitionDoor t;
    Flowchart f;

    private enum Interaction
    {
        Lever,
        Candle,
        Door,
        Dialogue,
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
        else if(myInteraction == Interaction.Door)
        {
            t = GetComponent<TransitionDoor>();
        }
        else if(myInteraction == Interaction.Dialogue)
        {
            f = GetComponent<Flowchart>();
        }
    }

    public void Activate(Transform player)
    {
        if(l != null)
        {
            l.InteractLever();
        }
        else if(c != null)
        {
            c.ActivateCandle();
        }
        else if(t != null)
        {
            t.Interact(player);
        }
        else if(f != null)
        {
            f.SendFungusMessage("hello");
        }
    }
}