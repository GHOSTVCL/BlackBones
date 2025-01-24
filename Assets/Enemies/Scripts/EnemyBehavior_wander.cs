using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyBehaviorwander : MonoBehaviour
{
    private player objetive;
    [SerializeField] private float moveSpeed = 3f;
    
    
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
        state = State.Patrolling;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        enemyPathFinding.MoveTo(patrolPosition);
        yield return new WaitForSeconds(2f);
        enemyPathFinding.ispatrolling = false;

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
            yield return new WaitForSeconds(1f);
         
    }
public IEnumerator Atack()
    {
        enemyPathFinding.atack.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        enemyPathFinding.atack.gameObject.SetActive(false);
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
}