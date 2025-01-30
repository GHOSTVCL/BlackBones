using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    [SerializeField] public float speed = 3f;
    [SerializeField] private GameObject atackObject;
    [SerializeField] public Transform lightatack;
    [SerializeField] private TextMeshProUGUI lifeText;

    [SerializeField] public Sprite FirePrefab;
    [SerializeField] public Sprite WaterPrefab;
    [SerializeField] public Sprite ToxicPrefab;
    [SerializeField] public Sprite IcePrefab;
    [SerializeField] public Sprite NightPrefab;
    [SerializeField] public Sprite IdlePrefab;
    [SerializeField] public Light playerLight;
    [SerializeField] private Animator Animations;
    [SerializeField] private AudioClip slash;
    private AudioSource audioSource;
    private Animation WalkAnim;
    private SpriteRenderer playerSprites;
    private Rigidbody rb;
    private Vector3 moveInput;
    private float moveZ;
    private float moveX;
    private bool mirandoDerecha = true;
    public float maxlife = 1000;
    public float actuallife = 1000;
    public bool isdeath = false;
    public bool resetlife = false;
    private Vector3 StartPosition;

    private float damageInterval = 1f;
    private float damageTimer = 0f;

    [HideInInspector]
    public bool slowed;
    public bool atacksound = false;
    [HideInInspector]
    public float baseSpeed;

    private int resistedIntensity;

    private GameObject roomManager;
    private SaveRooms roomSaved;

    private string scene;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        actuallife = maxlife;
        StartPosition = transform.position;
        playerSprites = gameObject.GetComponent<SpriteRenderer>();
        roomManager = GameObject.Find("RoomManager");
        roomSaved = roomManager.GetComponent<SaveRooms>();
        audioSource = GetComponent<AudioSource>();

        gameObject.transform.position = new Vector3(0, 1, 0);
        AsignSprite(Evolution());
        baseSpeed = speed;
        slowed = false;
    }
    private void Update()
    {
        AsignSprite(Evolution());
        moveZ = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");
        moveInput = new Vector3(moveX, 0f, moveZ);
        lifeText.text = "X" + GameManager.instance.lifes.ToString();
        if(actuallife < 0)
        {
            Die();
        }
    }
    private void FixedUpdate()
    {
        Mover();
        movementAnimations();
        AmbientEffect(LevelAmbient(roomSaved.levelCount));
    }
    private void movementAnimations()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            Animations.SetBool("Walk", true);  
        }
        else
        {
            Animations.SetBool("Walk", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Animations.SetBool("WalkFront", true);

        }
        else
        {
            Animations.SetBool("WalkFront", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Animations.SetBool("WalkBack", true);

        }
        else
        {
            Animations.SetBool("WalkBack", false);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Animations.SetTrigger("atack");
        }
    }
    private void Mover()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);

        if(Input.GetKey(KeyCode.A)&& mirandoDerecha)
        {
            Flip();
            lightatack.localScale = new Vector3(-lightatack.localScale.x, lightatack.localScale.y, lightatack.localScale.z);
        }
        if (Input.GetKey(KeyCode.D) &&!mirandoDerecha)
        {
            Flip();
            lightatack.localScale = new Vector3(lightatack.localScale.x, lightatack.localScale.y, lightatack.localScale.z);
        }   
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(Atack(lightatack));
        }
    }
    private IEnumerator Atack(Transform atack)
    {
        if(!atacksound)
        {
            audioSource.PlayOneShot(slash);
            atacksound = true;
        }
        Animations.SetBool("Atack", true);
        atack.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        atack.gameObject.SetActive(false);
        Animations.SetBool("Atack", false);
        atacksound = false;

    }
    public void Die()
    {
        if(GameManager.instance.lifes > 0)
        {
            gameObject.SetActive(false);
            SaveRooms.instance.levelCount = -1;
            new WaitForSeconds(1f);
            transform.position = StartPosition;
            gameObject.SetActive(true);
            actuallife = maxlife;
            GameManager.instance.lifes -= 1;
            GameManager.instance.EnemyCount = 0;
            GameManager.instance.Adn = 3;
            scene = "BornScreen";
            SceneManager.LoadScene(scene);
        }
        else
        {
            GameManager.instance.EnemyCount = 0;
            GameManager.instance.Adn = 3;
            scene = "GameOverScene";
            SceneManager.LoadScene(scene);
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
        switch (evolucion)
        {
            case 1:
                playerSprites.sprite = FirePrefab;
                Animations.SetBool("Fire", true);
                Animations.SetBool("Ice", false);
                Animations.SetBool("Night", false);
                Animations.SetBool("Water", false);
                Animations.SetBool("toxic", false);
                break;
            case 2:
                playerSprites.sprite = WaterPrefab;
                Animations.SetBool("Water", true);
                Animations.SetBool("Fire", false);
                Animations.SetBool("Ice", false);
                Animations.SetBool("Night", false);
                Animations.SetBool("toxic", false);
                break;
            case 3:
                playerSprites.sprite = ToxicPrefab;
                Animations.SetBool("toxic", true);
                Animations.SetBool("Fire", false);
                Animations.SetBool("Ice", false);
                Animations.SetBool("Night", false);
                Animations.SetBool("Water", false);  
                break;
            case 4:
                playerSprites.sprite = IcePrefab;
                Animations.SetBool("Ice", true);
                Animations.SetBool("Fire", false);
                Animations.SetBool("Night", false);
                Animations.SetBool("Water", false);
                Animations.SetBool("toxic", false);
                break;
            case 5:
                playerSprites.sprite = NightPrefab;
                Animations.SetBool("Night", true);
                Animations.SetBool("Ice", false);
                Animations.SetBool("Fire", false);
                Animations.SetBool("Water", false);
                Animations.SetBool("toxic", false);
                break;
            case 6:
                playerSprites.sprite = IdlePrefab;
                Animations.SetBool("Fire", false);
                Animations.SetBool("Ice", false);
                Animations.SetBool("Night", false);
                Animations.SetBool("Water", false);
                Animations.SetBool("toxic", false);
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
        bool empate = false;
        for(int i = 0; i < valores.Length; i++)
        {
            if (valores[i] > maximo)
            {
                maximo = valores[i];
                prefab = i;
                empate = false;
            }
            else if (valores[i]== maximo )
            {
                empate = true;
            }
        }
        return empate ? 6 :prefab + 1;

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            actuallife -= 5;
            EnemyBehaviorwander.Instance.GetKnockBack(EnemyBehaviorwander.Instance.transform, 2);
            
            if (actuallife <= 0)
            {
                isdeath = !isdeath;
                Die();
                
            }
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("damage"))
        {
            TriggerDamage();
            damageTimer = 0f;
        }
    }

    private void OnTriggerStay(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("damage"))
        {
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                TriggerDamage();
                damageTimer = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("damage"))
        {
            damageTimer = 0f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("InstantKill"))
        {
            actuallife = 0;
        }
    }

    private void TriggerDamage()
    {
        actuallife -= 1;

        if (actuallife <= 0 && !isdeath)
        {
            isdeath = true;
            Die();
        }
    }

    public int LevelIntensity()
    {
        int actualIntensity = 0;
        switch (roomSaved.levelCount)
        {
            case 1:
                actualIntensity = IntensityDebuff(roomSaved.roomCount,1);
                    break;
            case 2:
                actualIntensity = IntensityDebuff(roomSaved.roomCount, 2);
                break;
            case 3:
                actualIntensity = IntensityDebuff(roomSaved.roomCount, 3);
                break;
            case 4:
                actualIntensity = IntensityDebuff(roomSaved.roomCount, 4);
                break;
            case 5:
                actualIntensity = IntensityDebuff(roomSaved.roomCount, 5);
                break;

        }
        return actualIntensity;
    }

    private int IntensityDebuff(int room, int level)
    {
        int actualIntensity = 0;
        
        switch(level)
        {
            case 1:
               actualIntensity = roomSaved.intesitysLvl1[room -1];
                break;
            case 2:
                actualIntensity = roomSaved.intesitysLvl2[room -1];
                break;
            case 3:
                actualIntensity = roomSaved.intesitysLvl3[room -1];
                break;
            case 4:
                actualIntensity = roomSaved.intesitysLvl4[room - 1];
                break;
            case 5:
                actualIntensity = roomSaved.intesitysLvl5[room - 1];
                break;
        }

        return actualIntensity;
    }

    public void EvolveResistance(Color ambient, int intensity)
    {
        if (ambient == new Color(1f, 0f, 0f, 0.1f))
        {
            if(EvolutionManager.instance.FireEvolution >= 1 && EvolutionManager.instance.FireEvolution < 5)
            {
                resistedIntensity = intensity - 1;
            }
            else if (EvolutionManager.instance.FireEvolution >= 5 && EvolutionManager.instance.FireEvolution < 9)
            {
                resistedIntensity = intensity - 2;
            }
            else if (EvolutionManager.instance.FireEvolution >= 9)
            {
                resistedIntensity = intensity - 3;
            }
            else
            {
                resistedIntensity = intensity;
            }
            if (Evolution() == 1)
            {
                resistedIntensity -= 1;
            }
        }
        if (ambient == new Color(0f, 0f, 1f, 0.1f))
        {
            if (EvolutionManager.instance.WaterEvolution >= 1 && EvolutionManager.instance.WaterEvolution < 5)
            {
                resistedIntensity = intensity - 1;
            }
            else if (EvolutionManager.instance.WaterEvolution >= 5 && EvolutionManager.instance.WaterEvolution < 9)
            {
                resistedIntensity = intensity - 2;
            }
            else if (EvolutionManager.instance.WaterEvolution >= 9)
            {
                resistedIntensity = intensity - 3;
            }
            else
            {
                resistedIntensity = intensity;
            }
            if (Evolution() == 2)
            {
                resistedIntensity -= 1;
            }
        }
        if (ambient == new Color(0f, 1f, 0f, 0.1f))
        {
            if (EvolutionManager.instance.ToxicEvolution >= 1 && EvolutionManager.instance.ToxicEvolution < 5)
            {
                resistedIntensity = intensity - 1;
            }
            else if (EvolutionManager.instance.ToxicEvolution >= 5 && EvolutionManager.instance.ToxicEvolution < 9)
            {
                resistedIntensity = intensity - 2;
            }
            else if (EvolutionManager.instance.ToxicEvolution >= 9)
            {
                resistedIntensity = intensity - 3;
            }
            else
            {
                resistedIntensity = intensity;
            }
            if (Evolution() == 3)
            {
                resistedIntensity -= 1;
            }
        }
        if (ambient == new Color(0f, 0f, 0f, 0.1f))
        {
            if (EvolutionManager.instance.nightEvolution >= 1 && EvolutionManager.instance.nightEvolution < 5)
            {
                resistedIntensity = intensity - 1;
            }
            else if (EvolutionManager.instance.nightEvolution >= 5 && EvolutionManager.instance.nightEvolution < 9)
            {
                resistedIntensity = intensity - 2;
            }
            else if (EvolutionManager.instance.nightEvolution >= 9)
            {
                resistedIntensity = intensity - 3;
            }
            else
            {
                resistedIntensity = intensity;
            }
            if (Evolution() == 4)
            {
                resistedIntensity -= 1;
            }
        }
        if (ambient == new Color(0f, 1f, 1f, 0.1f))
        {
            if (EvolutionManager.instance.IceEvolution >= 1 && EvolutionManager.instance.IceEvolution < 5)
            {
                resistedIntensity = intensity - 1;
            }
            else if (EvolutionManager.instance.IceEvolution >= 5 && EvolutionManager.instance.IceEvolution < 9)
            {
                resistedIntensity = intensity - 2;
            }
            else if (EvolutionManager.instance.IceEvolution >= 9)
            {
                resistedIntensity = intensity - 3;
            }
            else
            {
                resistedIntensity = intensity;
            }
            if (Evolution() == 5)
            {
                resistedIntensity -= 1;
            }
        }
        if (resistedIntensity < 0)
        {
            resistedIntensity = 0;
        }
        playerLight.range -= resistedIntensity;
    }

    public void AmbientEffect(Color ambient)
    {
        if (ambient == new Color(1f, 0f, 0f, 0.1f))
        {
            StartCoroutine(DrainLife());
        }
        if (ambient == new Color(0f, 0f, 1f, 0.1f))
        {
            if(slowed == false && resistedIntensity != 0)
            {
                speed = speed -(resistedIntensity-0.5f) ;
                slowed = true;
            }
        }
        if (ambient == new Color(0f, 1f, 0f, 0.1f))
        {
            StartCoroutine(DrainLife());
        }
        if (ambient == new Color(0f, 0f, 0f, 0.1f))
        {
            playerLight.gameObject.SetActive(true);
        }
        if (ambient == new Color(0f, 1f, 1f, 0.1f))
        {
            if (slowed == false && resistedIntensity != 0)
            {
                speed = speed - (resistedIntensity-0.5f);
                slowed = true;
            }
        }
    }
    private IEnumerator DrainLife()
    {
        actuallife -= (resistedIntensity) * Time.deltaTime;
        yield return new WaitForSeconds(1f);
    }
    public Color LevelAmbient(int level)
    {
        Color ambient = Color.white;

        switch (level)
        {
            case 1:
                ambient = roomSaved.ambientLvl1;
                break;
            case 2:
                ambient = roomSaved.ambientLvl2;
                break;
            case 3:
                ambient = roomSaved.ambientLvl3;
                break;
            case 4:
                ambient = roomSaved.ambientLvl4;
                break;
            case 5:
                ambient = roomSaved.ambientLvl5;
                break;
        }

        return ambient;
    }
    public void GetKnockBack(Transform damageSource, float knockBackThurst)
    {
        Vector3 diference = (transform.position - damageSource.position).normalized * knockBackThurst * rb.mass;
        rb.AddForce(diference, ForceMode.Impulse);
    }
}
