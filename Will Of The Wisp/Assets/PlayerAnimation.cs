using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    float isMoving = 0;

    Vector2 input;
    [SerializeField] float overStep;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float target = 0;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(Mathf.Abs(horizontal) == 1 && Mathf.Abs(input.x) == 1 || Mathf.Abs(vertical) == 1 && Mathf.Abs(input.y) == 1)
        {
            target = 1;
        }

        isMoving = Mathf.MoveTowards(isMoving, target, Time.deltaTime * overStep);

        anim.SetFloat("IsMoving", isMoving);
    }

    public void SetInput(Vector2 newInput)
    {
        input = newInput;
    }
}