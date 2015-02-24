using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private const float Speed = 20f;
    private CharacterController controller;
    private Vector3 targetPosition;

    public AnimationClip run;
    public AnimationClip idle;

    public RaycastHit hit;

    // Use this for initialization
    private void Start()
    {
        targetPosition = transform.position;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 hitPosition = targetPosition;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag != "Player")
                {
                    //Debug.Log("Silence! I kill you!");
                    hitPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                }
            }
            MoveToPosition(hitPosition, hit.collider.tag);
        }
        else
        {
            animation.CrossFade(idle.name);
        }
    }

    private void MoveToPosition(Vector3 position, string colliderTag)
    {
        Quaternion rotation = Quaternion.LookRotation(position - transform.position);
        rotation.x = 0f;
        rotation.z = 0f;
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);
        if (Vector3.Distance(transform.position, position) >= Melee.weaponRange)
        {
            controller.SimpleMove(transform.forward * Speed);
            animation.CrossFade(run.name);
        }
        else if (Vector3.Distance(transform.position, position) < Melee.weaponRange && colliderTag != "Player")
        {
            //Debug.Log("hi there");
            animation.Play("attack");
            Melee.AttackEnemy(position, hit);
        }
    }

    private Vector3 GetTargetPosition(Vector3 positionAtScreen)
    {
        Ray ray = Camera.main.ScreenPointToRay(positionAtScreen);
        RaycastHit hit;

        Vector3 hitPosition = targetPosition;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag != "Player")
            {
                Debug.Log("I am coming!");
                hitPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
        }
        return hitPosition;
    }
}
