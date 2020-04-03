using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float acceleration, deAcceleration;

    [SerializeField] float rotationSpeed;

    bool stopMoving = false;

    [SerializeField] LayerMask wallMask;

    [SerializeField] float distanceToWall;
    [SerializeField] float startY, endY;

    Quaternion previousRotation;

    Vector3 input;

    Rigidbody rb;

    [SerializeField] PlayerAnimation pA;

    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 beforeInput = new Vector3(horizontal, vertical);

        beforeInput = new Vector3(Check(beforeInput.x, Vector3.right), Check(beforeInput.y, Vector3.forward));
        Debug.Log(beforeInput.x);
        pA.SetInput(beforeInput);

        input = new Vector3(GetAcceleratedInput(beforeInput.x, input.x), 0f, GetAcceleratedInput(beforeInput.y, input.z));

        float speed = movementSpeed;
        Vector3 moveDirection = input.normalized * speed;

        rb.velocity = moveDirection;

        Quaternion targetRot = Quaternion.LookRotation(rb.velocity);

        if (input.x == 0 && input.z == 0)
        {
            targetRot = previousRotation;
        }
        else
        {
            previousRotation = targetRot;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, Time.deltaTime * rotationSpeed);

        
    }

    float GetAcceleratedInput(float newInput, float oldInput)
    {
        if (Mathf.Abs(newInput) > 0)
        {
            oldInput = Mathf.MoveTowards(oldInput, newInput, acceleration * Time.deltaTime);
        }
        else
        {
            oldInput = Mathf.MoveTowards(oldInput, 0f, deAcceleration * Time.deltaTime);
        }

        return oldInput;
    }

    int SetDirection(float value, float input)
    {
        int direction = 0; //Make A Variable That Will Store The Direction Of The Player, Depending On Where They Press
        if (value > 0) //If The Player Pressed "Right"
        {
            direction = 1;
        }
        else if (value < 0) //If The Player Pressed "Left"
        {
            direction = -1;
        }

        if (stopMoving == true)
        {
            direction = 0;
            input = 0;
        }

        return direction;
    }

    float Check(float inp, Vector3 camDir)
    {
        RaycastHit hit;
        Vector3 d = inp > 0 ? camDir : -camDir;

        if (inp == 0)
            return 0;

        for (float i = startY; i < endY; i += 0.1f)
        {
            Debug.DrawRay(transform.position + Vector3.up * i, d * distanceToWall, Color.yellow);

            if (Physics.Raycast(transform.position + Vector3.up * i, d, out hit, distanceToWall, wallMask))
            {
                //if (hit.normal != Vector3.right || hit.normal != Vector3.forward)
                //{
                //    return inp;
                //}
                return 0;
            }
        }
        return inp;
    }
}