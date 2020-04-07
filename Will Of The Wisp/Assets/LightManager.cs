using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] List<int> correctOrder = new List<int>();
    int currentIndex = 0;
    List<int> newOrder = new List<int>();

    void Start()
    {
        
    }

    public void CheckIfCorrect(int order)
    {
        if(newOrder.Count != correctOrder.Count)
        {
            newOrder.Add(order);
        }

        if (newOrder.Count == correctOrder.Count)
        {
            for(int i = 0; i < correctOrder.Count; i++)
            {
                if(newOrder[i] != correctOrder[i])
                {
                    newOrder = new List<int>();
                    Debug.Log("WRONG");
                    return;
                }
            }

            newOrder = new List<int>();
            Debug.Log("CORRECT");
        }

        //if(currentIndex == correctOrder.Count - 1)
        //{
        //    return;
        //}

        //if(correctOrder[currentIndex] != order)
        //{

        //    currentIndex = 0;
        //    Debug.Log("WRONG " + order);
        //}
        //else
        //{
        //    Debug.Log("CORRECT, " + order);
        //    currentIndex += 1;
        ////}

        //if(currentIndex >= correctOrder.Count)
        //{
        //    Debug.Log("CONGRATS");
        //    currentIndex = correctOrder.Count - 1;
        //}
    }
}