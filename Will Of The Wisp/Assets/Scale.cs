using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public int counterWeight;
    public int maxAngle;
    private int amountToSend;
    private int weightAmount;
  
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = counterWeight > maxAngle ?  Quaternion.Euler(0, 0, maxAngle) : Quaternion.Euler(0, 0, counterWeight);
        
    }

    public void GetAmount(int amountToSend)
    {
        weightAmount -= amountToSend;

        int finalWeight = counterWeight + weightAmount;

        Debug.Log(finalWeight);
        transform.rotation = finalWeight > maxAngle ? Quaternion.Euler(0, 0, maxAngle) : Quaternion.Euler(0, 0, finalWeight);
        if (finalWeight == 0)
        {
            Debug.Log("Congratulations");
        }

    }
}
