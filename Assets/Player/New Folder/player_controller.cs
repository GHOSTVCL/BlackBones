using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform lightatack;
    [SerializeField] private Transform heavyatack;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI XpText;
    private Rigidbody rb;
    private Vector3 moveInput;
    private float moveZ;
    private float moveX;
    private bool mirandoDerecha = true;
    public float maxlife = 3;
    public float actuallife;
    public bool isdeath = false;
    public bool resetlife = false;
    private Vector3 StartPosition;
    public float Xp;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        actuallife = maxlife;
        StartPosition = transform.position;
        
    }
    private void Update()
    {
        moveZ = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");
        moveInput = new Vector3(moveX, 0f, moveZ);
        lifeText.text = "X" + GameManager.instance.lifes.ToString();
        XpText.text = "X" + Xp.ToString();
    }
    private void FixedUpdate()
    {
        Mover();
    }
    private void Mover()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);

        if(Input.GetKey(KeyCode.A) && mirandoDerecha)
        {
            Flip();
        }
        if(Input.GetKey(KeyCode.D) && !mirandoDerecha)
        {
            Flip();
        }

        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Atack(lightatack));
        }
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(Atack(heavyatack));
        }
    }
    private IEnumerator Atack(Transform atack)
    {
        atack.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        atack.gameObject.SetActive(false);


    }
    private void DoneAtack(Transform atack)
    {
        atack.gameObject.SetActive(false);
    }
    public void Die()
    {
        if(GameManager.instance.lifes > 0)
        {
            gameObject.SetActive(false);
            new WaitForSeconds(1f);
            transform.position = StartPosition;
            gameObject.SetActive(true);
            actuallife = 3;
            GameManager.instance.lifes -= 1;
        }
        else
        {
            //gameOverScreen
        }
        
    }
    private void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            actuallife -= 1;

            
            if (actuallife <= 0)
            {
                isdeath = !isdeath;
                Die();
                
            }
        }
    }
}
