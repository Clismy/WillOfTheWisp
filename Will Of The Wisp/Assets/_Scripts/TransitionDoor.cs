using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDoor : MonoBehaviour
{
    [SerializeField] TransitionDoor targetDoor;

    [SerializeField] Transform playerTransform, cameraTransform;


    public void Interact(Transform player)
    {
        player.position = targetDoor.GetPlayerPosition();
        Camera.main.transform.position = targetDoor.GetCameraPosition();
    }

    public Vector3 GetPlayerPosition()
    {
        return playerTransform.position;
    }
    public Vector3 GetCameraPosition()
    {
        return cameraTransform.position;
    }
}