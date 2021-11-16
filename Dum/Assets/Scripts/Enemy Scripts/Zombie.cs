using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    Rigidbody2D rb;                  // This object's Rigidbody
    float distancePerSecond = 1f;
    bool chasePlayer = false;
    public static int enemyDamage = 10;
    public int maxHealth = 50;
    public int currentHealth;
    public HealthBar healthBar;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (chasePlayer)
        {
            GameObject p = GameObject.FindWithTag("Player");    // p = player
            if (p == null) return;

            Rigidbody2D prb = p.GetComponent<Rigidbody2D>();      // prb = player Rigidbody

            // Move toward player
            Vector2 delta = prb.position - rb.position;
            delta.Normalize();
            rb.position += delta * distancePerSecond * Time.deltaTime;
        }
    }

    // Trigger movement
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if object collided with is player
        GameObject p = collision.gameObject;
        if (p.CompareTag("Player"))
        {
            // Start moving toward player
            chasePlayer = true;
        }
    }

    // Stop movement
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject p = collision.gameObject;
        if (p.CompareTag("Player"))
        {
            // Stop moving toward player
            chasePlayer = false;
        }
    }

    // Damage player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;
        /*if (gameObject.CompareTag("Player"))
        {
            chasePlayer = false;
        }*/
        
        if (gameObject.CompareTag("Player Bullet"))
        {
            rb.velocity = Vector2.zero;
            //rb.angularVelocity = Vector2.zero;


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
}
