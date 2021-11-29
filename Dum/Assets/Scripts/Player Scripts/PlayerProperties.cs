using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool collisionCheck;
    
    public HealthBar healthBar;
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    /* void Update()
    {
        
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject e = collision.gameObject;
        if (e.CompareTag("Enemy"))
        {
            collisionCheck = true;
            while (collisionCheck)
            {
                // Get enemy's int value to do damage to player
                int damageValue = Zombie.enemyDamage;
                TakeDamage(damageValue);
                // Wait 2 seconds before damaging player again if still in range
                StartCoroutine(Timer());
                collisionCheck = false;
            }
        }
        else if (e.CompareTag("Bullet"))
        {
            // Get bullet's damage
            int damageValue = BulletProperties.damageValue;
            TakeDamage(damageValue);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
    }
}
