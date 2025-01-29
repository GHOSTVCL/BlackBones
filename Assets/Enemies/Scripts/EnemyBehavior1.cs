using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyBehavior1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float DetectionRadius = 4f;
    [SerializeField] private Transform atack;

    [SerializeField] private AudioClip Sound1;
    [SerializeField] private AudioClip Sound2;
    [SerializeField] private AudioClip Sound3;
    private int randomsound;
    private AudioSource audiosource;
    public float life = 3f;
    private Transform player;
    private Rigidbody rb;
    private bool right = true;
    private bool playedsound = false;
    private Animator animations;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animations = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
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
            if(!playedsound)
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
        
            Vector3 moveEnemy = (player.position - transform.position).normalized;
            moveEnemy.y = 0;
            DoAnimations(moveEnemy);
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
        else
        {
            playedsound = false;
            animations.SetBool("walk", false);
        }
        if(distanceToPlayer <= 1)
        {
            StartCoroutine(Atack());
        }

        
    }
    private IEnumerator Atack()
    {
        animations.SetBool("walk", false);
        animations.SetBool("atack", true);
        atack.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        atack.gameObject.SetActive(false);
        animations.SetBool("atack", false);
        yield return new WaitForSeconds(1f);
        StopCoroutine(Atack());
    }
    public void DoAnimations(Vector3 movement)
    {
        if (movement.x > 0 || movement.x < 0)
        {
            animations.SetBool("walk", true);
        }
        else
        {
            animations.SetBool("walk", false);
        }
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
        if (collider.gameObject.CompareTag("lightatack"))
        {
            life -= 1;
            GetKnockBack(player.transform, 2);
            Debug.Log(life);
            
        }
        if(collider.gameObject.CompareTag("heavyatack"))
        {
            life -= 2;
            Debug.Log(life);
            
        }
        if (life <= 0)
        {
            GameManager.instance.EnemyCount += 1;
            GameManager.instance.score += 500;
            
            Destroy(gameObject);
        }
    }
    public void GetKnockBack(Transform damageSource, float knockBackThurst)
    {
        Vector3 diference = (transform.position - damageSource.position).normalized * knockBackThurst * rb.mass;
        rb.AddForce(diference, ForceMode.Impulse);
    }

}
