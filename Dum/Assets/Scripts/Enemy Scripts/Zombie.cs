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
            // Get bullet's damage
            int damageValue = BulletProperties.damageValue;
            TakeDamage(damageValue);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
/*    public Transform player; 
   private Rigidbody2D rb;
   float speed = 0.8f;
   public bool follow = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(follow){
            
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y,direction.x) *  Mathf.Rad2Deg;
            rb.position = transform.position + (direction * speed * Time.deltaTime);
            rb.rotation = angle;
        
        }

    }

  void onTriggerEnter(Collider vision){
        if(vision.GetComponent<Collider>().tag == player.tag){
            follow = true;
        }
    }


    void onTriggerExit(Collider vision){
        if(vision.GetComponent<Collider>().tag == player.tag){
            follow = false;
        }
    }
} */


/* void onTriggerEnter(Collider vision){
        if(vision.GetComponent<Collider>().tag == player.tag){
            follow = true;
        }
    }


    void onTriggerExit(Collider vision){
        if(vision.GetComponent<Collider>().tag == player.tag){
            follow = false;
        }
    }
*/

/*Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x) *  Mathf.Rad2Deg;
        rb.rotation = angle;
        rb.position += direction * speed * Time.fixedDeltaTime;
*/