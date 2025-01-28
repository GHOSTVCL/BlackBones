using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyBehaviorwander : MonoBehaviour
{
    public static EnemyBehaviorwander Instance { get; private set; }
    private player objetive;
    [SerializeField] private float moveSpeed = 3f;
    private Animator Animations;
    
    private Transform player;
    private Rigidbody rb;
    private bool right = true;
    private EnemyPathFinding enemyPathFinding;

    public enum State
    {
        Patrolling,
        Chase
    }
    public State state;

    private void Awake()
    {
        Instance = this;
        state = State.Patrolling;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Animations = GetComponent<Animator>();
        enemyPathFinding = GetComponent<EnemyPathFinding>();
    }
    private void Start()
    {
        StartCoroutine(PatrollingBehavior());
    }
   
    public IEnumerator PatrollingBehavior()
    {
        enemyPathFinding.ispatrolling = true;
        state = State.Patrolling;
        Vector3 patrolPosition = GetNewPosition();
        Vector3 movement = (patrolPosition - transform.position).normalized;
        DoAnimations(movement);
        enemyPathFinding.MoveTo(patrolPosition);
        yield return new WaitForSeconds(2f);
        enemyPathFinding.ispatrolling = false;

    }
    public void DoAnimations(Vector3 movement)
    {
        if (movement.x > 0 || movement.x < 0)
        {
            Animations.SetBool("walk", true);
        }
        else
        {
            Animations.SetBool("walk", false);
        }
    }
  public IEnumerator ChaseBehavior()
    {
       
            Vector3 moveEnemy = (player.position - transform.position).normalized;
            moveEnemy.y = 0;

            rb.MovePosition(rb.position + moveEnemy * moveSpeed * Time.fixedDeltaTime);

            if (moveEnemy.x > 0 && !right)
            {
                Flip();
            }
            if (moveEnemy.x < 0 && right)
            {
                Flip();
            }
        DoAnimations(moveEnemy);
        yield return new WaitForSeconds(1f);
         
    }
public IEnumerator Atack()
    {
        Animations.SetBool("walk", false);
        Animations.SetBool("atack", true);
        enemyPathFinding.atack.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        enemyPathFinding.atack.gameObject.SetActive(false);
        Animations.SetBool("atack", false);
        yield return new WaitForSeconds(2f);
    }
    private Vector3 GetNewPosition()
    {
        return new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f)).normalized;
    }
    private void Flip()
    {
        right = !right;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    public void GetKnockBack(Transform damageSource, float knockBackThurst)
    {
        Vector3 diference = (transform.position - damageSource.position).normalized * knockBackThurst*rb.mass;
        rb.AddForce(diference, ForceMode.Impulse);
    }


}