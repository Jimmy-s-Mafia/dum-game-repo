using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    
    public HealthBar healthBar;
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    /* void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject e = collision.gameObject;
        if (e.CompareTag("Enemy"))
        {
            // Get enemy's int value to do damage to player
            int damageValue = Zombie.enemyDamage;
            TakeDamage(damageValue);
        }
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
