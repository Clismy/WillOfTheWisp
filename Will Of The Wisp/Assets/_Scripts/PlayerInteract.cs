﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    PlayerInventory pI;

    GameObject closestObject;

    [SerializeField] float radius;
    [SerializeField] bool showRadius = false;
    [SerializeField] KeyCode pickUpKey;
    [SerializeField] LayerMask layersToCollide;
    [SerializeField] string interactableLayerName, pickUpLayerName, lookLayerName;

    void Start()
    {
        pI = GetComponent<PlayerInventory>();
    }

    void Update()
    {
        FindClosestObject();

        if (closestObject != null)
        {
            if (InRange() && Input.GetKeyDown(pickUpKey))
            {
                int currentLayer = closestObject.layer;

                if (currentLayer == LayerMask.NameToLayer(interactableLayerName))
                {
                    closestObject.GetComponent<ActivationManager>().Activate(transform);
                }
                else if (currentLayer == LayerMask.NameToLayer(pickUpLayerName))
                {
                    PickUp pickUp = closestObject.GetComponent<PickUp>();
                    string name = pickUp.GetItemName();
                    string discription = pickUp.GetItemDiscription();
                    pI.AddToInventory(name, discription);

                    closestObject.SetActive(false);

                    closestObject.layer = 0;
                }
                else if (currentLayer == LayerMask.NameToLayer(lookLayerName)) 
                {

                }

                closestObject = null;
            }
        }
    }

    void FindClosestObject()
    {
        RaycastHit[] circleHit = Physics.SphereCastAll(transform.position, radius, transform.forward, 0f, layersToCollide);

        Vector3 newTransform = transform.position;
        float destination = Mathf.Infinity;

        closestObject = null;
        foreach (RaycastHit r in circleHit)
        {
            Vector3 diff = r.transform.position - newTransform;
            float newDistance = diff.sqrMagnitude;
            if (destination > newDistance && newDistance >= 0)
            {
                destination = newDistance;
                closestObject = r.transform.gameObject;
            }
        }
    }

    bool InRange()
    {
        return (Vector3.Distance(new Vector3(transform.position.x, 0f, transform.position.z), new Vector3(closestObject.transform.position.x, 0f, closestObject.transform.position.z)) < radius);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (showRadius)
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}