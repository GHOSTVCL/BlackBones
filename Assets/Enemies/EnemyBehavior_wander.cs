using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyBehavior_wander : MonoBehaviour
{
    private player objetive;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float DetectionRadius = 4f;
    [SerializeField] private float PatrolRadius = 3f;
    private Transform player;
    private Rigidbody rb;
    private bool right = true;
    private Vector3 startPosition;
    private bool isPatrolling;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= DetectionRadius)
        {
            isPatrolling = false;
            FollowPlayer();
            
        }
        else
        {
            isPatrolling = true;
            Patrol();       
        }
    }

    private void FollowPlayer()
    {
        
        
            Vector3 moveEnemy = (player.position - transform.position).normalized;
            moveEnemy.y = 0;

            rb.MovePosition(rb.position + moveEnemy * moveSpeed * Time.deltaTime);

            if (moveEnemy.x > 0 && !right)
            {
                Flip();
            }
            if (moveEnemy.x < 0 && right)
            {
                Flip();
            }
    }


    private void Patrol()
    {
        Vector3 moveDirection = PatrolMovement();
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);

        if (moveDirection.x > 0 && !right)
        {
            Flip();
        }
        if (moveDirection.x < 0 && right)
        {
            Flip();
        }
    }
    private Vector3 PatrolMovement()
    {
        Vector3 currentPos = rb.position;
        float distanceFromStart = Vector3.Distance(currentPos, startPosition);
        if(distanceFromStart >= PatrolRadius)
        {
            return -((currentPos - startPosition).normalized);
        }
        return (currentPos - startPosition).normalized;
    }
    private void Flip()
    {
        right = !right;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
