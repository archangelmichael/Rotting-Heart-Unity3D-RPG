using UnityEngine;
using System.Collections;

public class EnemyAI : AI, IMovable
{
	public float distance;
    public Transform target;
    public CharacterController controller;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    public float lookAtDistance = 50.0f;
    public float chaseDistance = 30.0f;
    public float attackRange = 10.0f;
    public float moveSpeed = 15.0f;
    public float damping = 4.0f;

    public float monsterDamage = 40;
    public float attackRepeatTime = 1.0f;
    private float attackTime;

    // Use this for initialization
    void Start()
    {
        attackTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
        if (distance < lookAtDistance)
        {
            LookAt();
        }
        if (distance < chaseDistance && distance > attackRange)
        {
            Move();
        }
        if (distance < attackRange && Player.PlayerIsDead)
        {
            animation.Play("idle");
        }
        else if (distance < attackRange && !Player.PlayerIsDead)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (Time.time > attackTime)
        {
            target.SendMessage("Damage",monsterDamage,SendMessageOptions.DontRequireReceiver);
            attackTime = Time.time + attackRepeatTime;
            animation.Play("attack");
        }
    }

    public override void Move()
    {
        moveDirection = transform.forward;
        moveDirection *= moveSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        animation.Play("walk");
    }

    public void LookAt()
    {
        Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }
}

