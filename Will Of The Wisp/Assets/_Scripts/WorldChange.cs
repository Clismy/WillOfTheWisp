using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldChange : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject overworld;
    public GameObject underworld;

    private int worldCount;
    void Start()
    {
        overworld.SetActive(true);
        underworld.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ChangeWorld();
        } 
    }
    void ChangeWorld()
    {
        if (worldCount == 0)
        {
            overworld.SetActive(false);
            underworld.SetActive(true);
            worldCount = 1;
        }
        else
        {
            overworld.SetActive(true);
            underworld.SetActive(false);
            worldCount = 0;
        }
    }
}
