using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossBehavior : MonoBehaviour
{
    public GameObject explosion;

    Rigidbody2D rb;
    GameObject player;
    Vector2 playerPosition;
    
    public int maxHealth = 2000;
    public int currentHealth;

    public Slider bossHealthBar;
    public GameObject displayBossBar;
    public GameObject bossLabel;

    private bool playerInRange;
    public bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        bossHealthBar.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null) return;

        // Find current player position
        playerPosition = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject p = collision.gameObject;
        if (p.CompareTag("Player"))
        {
            playerInRange = true;
            bossLabel.SetActive(true);
            displayBossBar.SetActive(true);
            BossShooting.canShoot = true;
        }
    }

    void FixedUpdate() 
    {   
        if (playerInRange)
        {
            // Direction for boss to look
            Vector2 lookDirection = playerPosition - rb.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 180;
            rb.rotation = angle;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Bullet"))
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
        // healthBar.SetHealth(currentHealth);

        bossHealthBar.value = currentHealth;
        
        if(currentHealth <= 0)
        {
            // Instantiate explosion at the boss location
            GameObject e = Instantiate(explosion, transform.position, Quaternion.identity);
            // Destroy explosion after short time
            Destroy(e, 0.50f);

            Destroy(gameObject);
            bossLabel.SetActive(false);
            displayBossBar.SetActive(false);
            isDead = true;
        }
    }
}
