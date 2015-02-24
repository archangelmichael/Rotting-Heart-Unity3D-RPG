using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float distance = 20.0f;
    public float height = 7.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 1.0f;

    private void LateUpdate()
    {
        if (!target)
        {
            return;
        }

        Vector3 nextPosition = GetNextPosition(target.position);
        Quaternion nextRotation = GetNextRotaion(target);

        MoveTowardsTarget(nextPosition, nextRotation);

        // Look at the target
        transform.LookAt(target);
    }

    public Vector3 GetNextPosition(Vector3 targetPosition)
    {
        float wantedHeight = target.position.y + height;
        float nextHeight =
            Mathf.Lerp(transform.position.y, wantedHeight, heightDamping * Time.deltaTime);
        Vector3 nextPositon = new Vector3(target.position.x, nextHeight, target.position.z);

        return nextPositon;
    }

    public Quaternion GetNextRotaion(Transform target)
    {
        float wantedRotationAngle = target.eulerAngles.y;
        float nextRotationAngle =
            Mathf.LerpAngle(transform.eulerAngles.y, wantedRotationAngle, rotationDamping * Time.deltaTime);
        Quaternion nextRotation = Quaternion.Euler(0, nextRotationAngle, 0);

        return nextRotation;
    }

    public void MoveTowardsTarget(Vector3 targetPosition, Quaternion rotationToTarget)
    {
        transform.position = targetPosition;
        transform.position -= rotationToTarget * Vector3.forward * distance;
    }
}