using UnityEngine;
using System.Collections;

public class NeutralAI : AI, IMovable
{
    private float distance;
    public Transform target;
    public CharacterController controller;
    private float gravity = 20.0f;
    public Vector3 moveDirection = Vector3.zero;

    private float lookAtDistance = 50.0f;
    private float chaseDistance = 30.0f;
    private float attackRange = 10.0f;
    private float moveSpeed = 15.0f;
    private float damping = 4.0f;

    
    void Update()
    {
        Move();
    }

    public override void Move()
    {
        Random generator = new Random();
        moveDirection = transform.forward;
        moveDirection *= moveSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        animation.Play("walk");
    }
}
