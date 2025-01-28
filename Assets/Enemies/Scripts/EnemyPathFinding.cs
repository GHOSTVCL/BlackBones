using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float DetectionRadius = 4f;
    [SerializeField] public Transform atack;
    private Transform player;
    private Rigidbody rb;
    private Vector3 movement;
    private EnemyBehaviorwander behavior;
    public bool ispatrolling = false;
    public float life = 3f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        behavior = GetComponent<EnemyBehaviorwander>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float DistanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(DistanceToPlayer <= DetectionRadius)
        {
            behavior.state = EnemyBehaviorwander.State.Chase;
            StartCoroutine(behavior.ChaseBehavior());
        }
        else 
        {
            behavior.state = EnemyBehaviorwander.State.Patrolling;
            if (!ispatrolling)
            {
                StartCoroutine(behavior.PatrollingBehavior());
            } 
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            StopCoroutine(behavior.PatrollingBehavior());
        }
        if(DistanceToPlayer <= 0.5)
        {
            StartCoroutine(behavior.Atack());
        }
        
       
        
    }

    public void MoveTo(Vector3 targetPosition)
    {
        movement = targetPosition;
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("lightatack"))
        {
            life -= 1;
            behavior.GetKnockBack(player.transform, 2);
            Debug.Log(life);
            
        }
        if (collider.gameObject.CompareTag("heavyatack"))
        {
            life -= 2;
            Debug.Log(life);

        }
        if (life <= 0)
        {
            GameManager.instance.score += 500;
            GameManager.instance.EnemyCount += 1;
            gameObject.SetActive(false);
        }
    }
}
