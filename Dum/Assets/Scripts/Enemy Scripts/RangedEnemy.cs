using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject player;
    Vector2 playerPosition;
    public int maxHealth = 50;
    public int currentHealth;

    public GameObject hurtPrefab;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null) return;

        // Find current player position
        playerPosition = player.transform.position;
    }

    void FixedUpdate() 
    {   
        // Direction for boss to look
        Vector2 lookDirection = playerPosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 270;
        rb.rotation = angle;
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
        // Hurt sound
	    GameObject zombieHurt = Instantiate(hurtPrefab);

        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            // Instantiate explosion at the zombie location
            GameObject e = Instantiate(explosion, transform.position, Quaternion.identity);
            // Destroy explosion after short time
            Destroy(e, 0.50f);

            Destroy(gameObject);
            KillCounter.killCount++;
        }
    }
}
