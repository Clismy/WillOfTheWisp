using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scale : MonoBehaviour
{
    public int counterWeight;
    public int maxAngle;
    private int amountToSend;
    private int weightAmount;

    List<Sprite> list = new List<Sprite>();

    List<Image> images = new List<Image>();
    [SerializeField] GameObject imageParent;

    bool updateList = false;

    [SerializeField] Color enabled, disabled;

    void Start()
    {
        transform.rotation = counterWeight > maxAngle ?  Quaternion.Euler(0, 0, maxAngle) : Quaternion.Euler(0, 0, counterWeight);

        for (int i = 0; i < imageParent.transform.childCount; i++)
        {
            list.Add(null);
            images.Add(imageParent.transform.GetChild(i).GetComponent<Image>());
            images[i].color = disabled;
        }
    }

    void Update()
    {
        if (updateList)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (i + 1 >= list.Count)
                {
                    break;
                }

                if (list[i] == null && list[i + 1] != null)
                {
                    Sprite temp = list[i];
                    list[i] = list[i + 1];
                    list[i + 1] = temp;
                }

                images[i].sprite = list[i];
                images[i].color = list[i] != null ? enabled : disabled;
            }
            updateList = false;
        }
    }

    public void GetAmount(int amountToSend, Sprite newImage)
    {
        if (amountToSend < 0)
        {
            Remove(newImage);
        }
        else
        {
            Add(newImage);
        }

        weightAmount -= amountToSend;

        int finalWeight = counterWeight + weightAmount;

        Debug.Log(finalWeight);
        transform.rotation = finalWeight > maxAngle ? Quaternion.Euler(0, 0, maxAngle) : Quaternion.Euler(0, 0, finalWeight);
        if (finalWeight == 0)
        {
            Debug.Log("Congratulations");
        }

        updateList = true;
    }

    void Add(Sprite myImage)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == null)
            {
                list[i] = myImage;
                return;
            }
        }
    }

    void Remove(Sprite myImage)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == myImage)
            {
                list[i] = null;
                return;
            }
        }
    }
}
