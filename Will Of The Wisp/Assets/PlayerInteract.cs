using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    PlayerInventory pI;

    GameObject closestObject;
    GameObject previousObject;

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
            if (Vector3.Distance(transform.position, closestObject.transform.position) < radius && Input.GetKeyDown(pickUpKey))
            {
                int currentLayer = closestObject.layer;

                if (currentLayer == LayerMask.NameToLayer(interactableLayerName))
                {

                }
                else if (currentLayer == LayerMask.NameToLayer(pickUpLayerName))
                {

                    string name = closestObject.GetComponent<PickUp>().GetItemName();
                    pI.AddToInventory(name);
                    closestObject.SetActive(false);
                }
                else if (currentLayer == LayerMask.NameToLayer(lookLayerName))
                {

                }

                closestObject.layer = 0;
                closestObject = null;
            }
        }
    }

    void FindClosestObject()
    {
        RaycastHit[] circleHit = Physics.SphereCastAll(transform.position, radius, transform.forward, 0f, layersToCollide);

        Vector3 newTransform = transform.position;
        float destination = Mathf.Infinity;

        foreach (RaycastHit r in circleHit)
        {
            Vector3 diff = r.transform.position - newTransform;
            float newDistance = diff.sqrMagnitude;
            if (destination > newDistance && newDistance >= 0)
            {
                destination = newDistance;
                previousObject = closestObject;
                closestObject = r.transform.gameObject;
            }
        }
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