using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeightButton : MonoBehaviour
{
    [Range(0, 100)]
    [SerializeField] int amount;

    bool activated = false;

    // Used so we can change the alpha of the button, to more clearly see if it is activated or not.
    Image buttonImage;
    [SerializeField] Color activatedButtonColor;
    [SerializeField] Color deActivatedButtonColor;
    
     public Scale scale;

    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<Image>();

        activated = false;
        buttonImage.color = deActivatedButtonColor;
    }

    public void InteractLever()
    {
        activated = !activated;
        buttonImage.color = activated ? activatedButtonColor : deActivatedButtonColor;

        int amountToSend = activated ? amount : -amount;
        scale.GetAmount(amountToSend);
    }

    public void DisableLever()
    {
        activated = false;
    }
}
