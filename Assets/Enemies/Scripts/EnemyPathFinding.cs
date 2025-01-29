using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float DetectionRadius = 4f;
    [SerializeField] public Transform atack;

    [SerializeField] private AudioClip Sound1;
    [SerializeField] private AudioClip Sound2;
    [SerializeField] private AudioClip Sound3;
    private int randomsound;
    private AudioSource audiosource;
    private bool playedsound = false;
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
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float DistanceToPlayer = Vector3.Distance(transform.position, player.position);
        if(DistanceToPlayer <= DetectionRadius)
        {
            if (!playedsound)
            {
                randomsound = Random.Range(1, 3);
                switch (randomsound)
                {
                    case 1:
                        audiosource.PlayOneShot(Sound1);
                        break;
                    case 2:
                        audiosource.PlayOneShot(Sound2);
                        break;
                    case 3:
                        audiosource.PlayOneShot(Sound3);
                        break;
                }
                playedsound = true;
            }
            behavior.state = EnemyBehaviorwander.State.Chase;
            StartCoroutine(behavior.ChaseBehavior());
        }
        else 
        {
            playedsound = false;
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
