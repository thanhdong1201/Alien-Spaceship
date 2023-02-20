using UnityEngine.InputSystem;
using UnityEngine;
using StarterAssets;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private GameObject shield;
    private GameObject projectitlePrefab;
    private float hp;
    private float speed;
    private float shieldTime = 5f;  
    private GameObject explosionFX;   
    private AudioClip shootSound;
    private AudioClip destroySound;

    [Header("Event")]
    [SerializeField] private GameEvent onPlayerDie;

    private AudioSource audioSource;
    private StarterAssetsInputs _input;
    private Rigidbody2D rb;
    private bool isSpawning;
    private bool hasShield;
    private float timer;
    bool destroyed = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        hp = playerSO.maxHealth;
        shieldTime = playerSO.shieldTime;
        speed = playerSO.speed;
        projectitlePrefab = playerSO.currentProjectitlePrefab;
        explosionFX = playerSO.explosionFX;
        shootSound = playerSO.shootSound;
        destroySound = playerSO.destroySound;
    }

    public void AddPower(GameObject gameObject)
    {
        projectitlePrefab = gameObject;
        playerSO.SetProjectitle(gameObject);
    }

    private void Start()
    {
        // GetComponents
        _input = GetComponent<StarterAssetsInputs>();

        //Set value
        shield.SetActive(true);
        isSpawning = true;
        hasShield = true;
    }

    void Move()
    {
        Vector2 inputDirection = new Vector2(_input.move.x, _input.move.y).normalized;

        if (_input.move == Vector2.zero)
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (_input.move != Vector2.zero)
        {
            rb.velocity = inputDirection.normalized * speed;
        }
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        ShieldTime();
        MoveIntoScene();
        Move();

        //Shoot
        if (_input.jump)
        {    
            if (timer <= 0)
            {
                _input.jump = false;
                audioSource.PlayOneShot(shootSound);
                Instantiate(projectitlePrefab, spawnBullet.transform.position, spawnBullet.transform.rotation);
                timer = 0.3f;
            }
            
        }

        
        //HP
        if (hp <= 0)
        {
            destroyed = true;        
            audioSource.PlayOneShot(destroySound);
            Instantiate(explosionFX, transform.position, transform.rotation);
            onPlayerDie?.Invoke();
            Destroy(gameObject);
        }
        if (destroyed)
        {
            playerSO.SetDefaultProjectitle();
        }
    }

    void MoveIntoScene()
    {
        if (isSpawning)
        {
            FindObjectOfType<LogicManager>().DisableBox();
            if (transform.position.x < -6.8)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed / 2);
            }
            if (transform.position.x >= -6.8)
            {
                transform.Translate(Vector3.zero);
                isSpawning = false;
            }
        }
        if (!isSpawning)
        {
            FindObjectOfType<LogicManager>().EnableBox();
        }
    }

    void ShieldTime()
    {
        shieldTime -= Time.deltaTime;
        if (shieldTime > 0)
        {
            hasShield = true;
            shield.SetActive(true);
        }
        if (shieldTime <= 0)
        {
            hasShield = false;
            shield.SetActive(false);
            shieldTime = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(2);
        }
    }
    public void TakeDamage(int damage)
    {
        if (hasShield)
        {

        }
        if (!hasShield)
        {
            hp -= damage;           
        }     
    }
}
