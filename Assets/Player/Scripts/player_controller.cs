using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform lightatack;
    [SerializeField] private Transform heavyatack;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI XpText;

    [SerializeField] public Sprite FirePrefab;
    [SerializeField] public Sprite WaterPrefab;
    [SerializeField] public Sprite ToxicPrefab;
    [SerializeField] public Sprite IcePrefab;
    [SerializeField] public Sprite NightPrefab;
    [SerializeField] public Sprite IdlePrefab;
    private SpriteRenderer playerSprites;
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
        playerSprites = gameObject.GetComponent<SpriteRenderer>();
        AsignSprite(Evolution());
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
    private void AsignSprite(int evolucion)
    {
        switch(evolucion)
        {
            case 1:
                playerSprites.sprite = FirePrefab;
                break;
            case 2:
                playerSprites.sprite = WaterPrefab;
                break;
            case 3:
                playerSprites.sprite = ToxicPrefab;
                break;
            case 4:
                playerSprites.sprite = IcePrefab;
                break;
            case 5:
                playerSprites.sprite = NightPrefab;
                break;


        }
    }
    private int Evolution()
    {
        int[] valores = {EvolutionManager.instance.FireEvolution,
            EvolutionManager.instance.WaterEvolution,
            EvolutionManager.instance.ToxicEvolution,
            EvolutionManager.instance.IceEvolution,
            EvolutionManager.instance.nightEvolution};
        int maximo = 0;
        int prefab = 0;
        for(int i = 0; i < valores.Length; i++)
        {
            if (valores[i] > maximo)
            {
                maximo = valores[i];
                prefab = i;
            }
        }
        return prefab + 1;

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
