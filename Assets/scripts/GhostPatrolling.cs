using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPatrolling : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;

    private int targetPoint = 0;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsTarget();

        // Check if reached patrol point
        if (Vector3.Distance(transform.position, patrolPoints[targetPoint].position) < 0.1f)
        {
            IncreaseTargetPoint();
        }
    }

    void MoveTowardsTarget()
    {
        // Move towards the current target point
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
        RotateTowards(patrolPoints[targetPoint].position);
    }

    void RotateTowards(Vector3 targetPosition)
    {
        // Rotate towards the target position
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
    }

    void IncreaseTargetPoint()
    {
        // Move to the next patrol point in the array
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;  // Loop back to the first patrol point if at the end
        }
    }

    // Method to reset the ghost's position to its initial point
    public void ResetPosition()
    {
        transform.position = initialPosition;
        targetPoint = 0;  // Reset the target point to the initial one
    }
}

