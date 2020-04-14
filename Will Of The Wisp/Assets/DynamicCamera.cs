using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    [SerializeField] Transform minCamPos, maxCamPos;
    [SerializeField] Transform player;
    [SerializeField] int cameraSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 d = player.position - transform.position;

        transform.position = Vector3.Lerp(minCamPos.position, maxCamPos.position, (Mathf.Clamp(d.z, -cameraSpeed, cameraSpeed)/cameraSpeed));

        Vector3 lookPos = player.position - transform.position;
        lookPos.x = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, (Mathf.Clamp(d.z, -cameraSpeed, cameraSpeed) / cameraSpeed));
    }
}