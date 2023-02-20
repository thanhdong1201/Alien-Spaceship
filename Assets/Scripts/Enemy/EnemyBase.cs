using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemySO _enemySO;
    [SerializeField] protected ScoreSO _scoreSO;
    [SerializeField] protected Transform spawnBullet;
    protected DropItem dropItem;
    protected Rigidbody2D rb;

    protected float maxHealth;
    protected float currentHealth;
    protected float damageReceive;
    protected float speed;
    protected float range;
    protected float resetShoot;
    protected int scoreCanGet;
    public bool spawning = true;
    protected GameObject projectitlePrefab;
    protected GameObject explosionFX;

    protected float timer = 0;

    private void Awake()
    {
        maxHealth = _enemySO.maxHealth;
        speed = _enemySO.speed;
        range = _enemySO.speed;
        resetShoot = _enemySO.resetShoot;
        scoreCanGet = _enemySO.scoreCanGet;
        projectitlePrefab = _enemySO.projectitlePrefab;
        explosionFX = _enemySO.explosionFX;

        rb = GetComponent<Rigidbody2D>();
        dropItem = GetComponent<DropItem>();
    }

    protected virtual void Shoot()
    {
        if (projectitlePrefab != null)
        {
            if (spawnBullet != null)
            {
                timer += Time.deltaTime;
                if (timer >= resetShoot)
                {
                    Instantiate(projectitlePrefab, spawnBullet.transform.position, spawnBullet.transform.rotation);
                    timer = 0;
                }
            }       
        }
    }

    protected void DropItem()
    {
        if (dropItem != null)
        {
            int random = Random.Range(1, 4);
            if (random == 2)
            {
                dropItem.Drop();
            }
        }
    }

    protected void MoveIntoScene()
    {
        if (transform.position.x > 9)
        {
            rb.velocity = new Vector2(-1 * speed, 0);
        }
        if (transform.position.x <= 9)
        {
            spawning = false;
            rb.velocity = new Vector2(0, 1 * speed);
        }
    }

    protected virtual void BeDestroy()
    {
        if (currentHealth <= 0)
        {
            _scoreSO.AddScore(scoreCanGet);
            DropItem();
            Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
