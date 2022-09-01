using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    
    Rigidbody2D rigidBody2d;

    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    public bool moving;

    public Vector2 lastMotionVector;

    Animator animator;

    void Awake()
    {
        rigidBody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveY = Input.GetAxisRaw("Vertical");
        float moveX = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("horizontal", moveX);
        animator.SetFloat("vertical", moveY);

        moving = moveX != 0 && moveY != 0;
        animator.SetBool("moving", moving);

        if(moveX != 0 || moveY != 0)
        {
            lastMotionVector = new Vector2(moveX, moveY).normalized;

            animator.SetFloat("lastHorizontal", moveX);
            animator.SetFloat("lastVertical", moveY);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidBody2d.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
    }
}
