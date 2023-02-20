using UnityEngine.UI;
using UnityEngine;

public class Boss : EnemyBase, IDamageable
{
    public Level level;
    public enum Level
    {
        Level_1, 
        Level_2, 
        Level_3
    }

    [SerializeField] private Slider healthSlider;
    [SerializeField] private GameEvent onBossDie;
    float newSpeed;

    private void Start()
    {
        currentHealth = maxHealth;
        rb.velocity = new Vector2(-1 * speed, 0);

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
        newSpeed = speed * 2;

        
    }

    private void Update()
    {
        healthSlider.value = currentHealth;
        BeDestroy();

        if (spawning)
        {
            MoveIntoScene();
        }
        if (!spawning)
        {
            if (currentHealth >= maxHealth/2)
            {     
               
                switch (level)
                {
                    case Level.Level_1:
                        Shoot();
                        MoveAttack();
                        break;
                    case Level.Level_2:
                        Combo1(1.4f);
                        MoveAttack();
                        break;
                    case Level.Level_3:
                        Combo1(1.8f);
                        MoveAttack();
                        break;
                }
            }
            if (currentHealth < maxHealth/2)
            {     
                switch (level)
                {
                    case Level.Level_1:
                        Shoot();
                        MoveAttack();
                        break;
                    case Level.Level_2:
                        Combo1(1.4f);
                        Combo2();
                        break;
                    case Level.Level_3:
                        Combo1(2.2f);
                        Combo2();
                        break;
                }
            }
        }           

    }
    protected override void Shoot()
    {
        timer += Time.deltaTime;
        if (timer >= resetShoot)
        {
            Instantiate(projectitlePrefab, spawnBullet.transform.position, spawnBullet.transform.rotation);
            timer = 0;
        }
    }
    private void Combo1(float x)
    {
        timer += Time.deltaTime;
        if (timer >= resetShoot/x)
        {
            for(int i = 0; i <= 5; i++)
            {
                Instantiate(projectitlePrefab, spawnBullet.transform.position, spawnBullet.transform.rotation);
            }
            
            timer = 0;
        }
    }
    private void Combo2()
    {     
        if (transform.position.x <= -8)
        {
            rb.velocity = new Vector2(1 * newSpeed, 0);
        }
        if (transform.position.x >7 && transform.position.x <= 10)
        {
            rb.velocity = new Vector2(-1 * newSpeed, 0);
        }
    }
    private void MoveAttack()
    {
        if (transform.position.y >= range)
        {
            rb.velocity = new Vector2(0, -1 * speed);
        }
        if (transform.position.y <= -range)
        {
            rb.velocity = new Vector2(0, 1 * speed);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    protected override void BeDestroy()
    {
        if (currentHealth <= 0)
        {
            onBossDie?.Invoke();
            _scoreSO.AddScore(scoreCanGet);
            DropItem();
            Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentHealth -= 3;
        }
    }
}
