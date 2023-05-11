using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public List<Transform> targets;
    public float speed = 5f;
    public float stoppingDistance = 0.1f;
    public float waitTime = 2f;

    private int currentTargetIndex = 0;
    private Rigidbody rb;

    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveToFirstTarget()
    {
        if (targets.Count > 0)
        {
            Debug.Log("Moving to First Target");
            currentTargetIndex = 0;
            targetPosition = targets[currentTargetIndex].position;
            isMoving = true;
        }
    }

    public void MoveToNextTarget()
    {
        Debug.Log("Moving to Next Target");
        currentTargetIndex = (currentTargetIndex + 1) % targets.Count;
        targetPosition = targets[currentTargetIndex].position;
        isMoving = true;
    }

    public IEnumerator MoveToFirstTargetCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        MoveToFirstTarget();
    }

    public IEnumerator MoveToNextTargetCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        MoveToNextTarget();
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            float distance = Vector3.Distance(transform.position, targetPosition);

            if (distance > stoppingDistance)
            {
                rb.velocity = direction * speed;
            }
            else
            {
                rb.velocity = Vector3.zero;
                isMoving = false;
            }
        }
    }
}
