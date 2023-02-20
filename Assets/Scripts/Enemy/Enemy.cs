using UnityEngine;

public class Enemy : EnemyBase, IDamageable
{
    public TypeMove typeMove;
    public float x = 1f;
    public enum TypeMove
    {
        StraightForward,
        RightForward,
        LeftForward,
        RightBack,
        LeftBack,
        RightToStraight,
        LeftToStraight,
    }

    private void Start()
    {
        currentHealth = maxHealth;
        rb.velocity = new Vector2(-1 * speed, 0);
    }
    private void Update()
    {
        BeDestroy();

        if (spawning)
        {

        }
        if (!spawning)
        {
            MoveAttack();
            Shoot();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            currentHealth -= 3;
        }
    }

    private void MoveAttack()
    {
        float newspeed = speed;
        

        switch (typeMove)
        {
            case TypeMove.StraightForward:
                rb.velocity = new Vector2(-1 * newspeed, 0);
                break;
            case TypeMove.RightForward:
                rb.velocity = new Vector2(-1f * newspeed, 1f * newspeed);
                break;
            case TypeMove.LeftForward:
                rb.velocity = new Vector2(-1 * newspeed, -1 * newspeed);
                break;
            case TypeMove.RightBack:
                rb.velocity = new Vector2(1 * newspeed, 1 * newspeed);
                break;
            case TypeMove.LeftBack:
                rb.velocity = new Vector2(1 * newspeed, -1 * newspeed);
                break;
            case TypeMove.RightToStraight:     
                if(transform.position.y < -x)
                {
                    rb.velocity = new Vector2(-1f * newspeed, 1f * newspeed);
                }   
                if(transform.position.y >= -x)
                {
                    rb.velocity = new Vector2(-1 * newspeed, 0);
                }
                break;
            case TypeMove.LeftToStraight:
                if (transform.position.y > x)
                {
                    rb.velocity = new Vector2(-1f * newspeed, -1f * newspeed);
                }      
                if (transform.position.y <= x)
                {
                    rb.velocity = new Vector2(-1 * newspeed, 0);
                }
                break;
        }
    }
}
