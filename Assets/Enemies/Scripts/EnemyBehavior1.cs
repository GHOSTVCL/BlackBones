using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyBehavior1 : MonoBehaviour
{
    private player objetive;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float DetectionRadius = 4f;
    [SerializeField] private Transform atack;
    public float life = 3f;
    private Transform player;
    private Rigidbody rb;
    private bool right = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if(distanceToPlayer <= DetectionRadius)
        {
            Vector3 moveEnemy = (player.position - transform.position).normalized;
            moveEnemy.y = 0;

            rb.MovePosition(rb.position + moveEnemy * moveSpeed * Time.deltaTime);
            
            if(moveEnemy.x > 0 && !right)
            {
                Flip();
            }
            if(moveEnemy.x < 0 && right)
            {
                Flip();
            }
        }
        if(distanceToPlayer <= 0.5)
        {
            Atack();
        }

        
    }
    private void Atack()
    {

    }
    private void Flip()
    {
        right = !right;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("playeratack"))
        {
            life -= 1;

            Debug.Log(life);
            if (life <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
