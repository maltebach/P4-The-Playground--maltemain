using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public List<Transform> targets;
    public float speed = 5f;
    public float stoppingDistance = 0.1f;
    public float forceMultiplier = 1f;
    public float waitTime = 2f;

    private int currentTargetIndex = 0;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > 0)
        {
            float distance = Vector3.Distance(transform.position, targets[currentTargetIndex].position);
            if (distance < stoppingDistance)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    public void MoveToFirstTarget()
    {
        if (targets.Count > 0)
        {
            currentTargetIndex = 0;
            Vector3 direction = (targets[currentTargetIndex].position - transform.position).normalized;
            float forceMagnitude = speed * forceMultiplier;
            Vector3 force = direction * forceMagnitude;
            rb.AddForce(force, ForceMode.VelocityChange);
        }
    }

    public void MoveToNextTarget()
    {
        Debug.Log("Moving");
        currentTargetIndex = (currentTargetIndex + 1) % targets.Count;
        Vector3 direction = (targets[currentTargetIndex].position - transform.position).normalized;
        float forceMagnitude = speed * forceMultiplier;
        Vector3 force = direction * forceMagnitude;
        rb.AddForce(force, ForceMode.VelocityChange);
    }
}
