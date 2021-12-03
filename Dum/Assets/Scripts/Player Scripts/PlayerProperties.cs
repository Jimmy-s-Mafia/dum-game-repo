using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public int maxHealth = 100;
    public static int currentHealth;
    private bool collisionCheck;
    
    public HealthBar healthBar;
    public Animator animator;

    public Transform player;
    public GameObject hurtPrefab;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        healthBar.SetHealth(currentHealth);
    }
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
	// Hurt Sound
	GameObject hurt = Instantiate(hurtPrefab, player.position, player.rotation);

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
