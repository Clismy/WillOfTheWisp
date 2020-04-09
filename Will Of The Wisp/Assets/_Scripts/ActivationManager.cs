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
    WeightButton w;

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
        switch (myInteraction)
        {
            case Interaction.Lever:
                l = GetComponent<Lever>();
                break;
            case Interaction.Candle:
                c = GetComponent<Candle>();
                break;
            case Interaction.Door:
                t = GetComponent<TransitionDoor>();
                break;
            case Interaction.Dialogue:
                f = GetComponent<Flowchart>();
                break;
            case Interaction.Weight:
                w = GetComponent<WeightButton>();
                break;
        }
    }

    public void Activate(Transform player)
    {
        l?.InteractLever();
        c?.ActivateCandle();
        t?.Interact(player);
        f?.SendFungusMessage("hello");
        w?.InteractLever();
    }
}