using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour{
   public Transform player; 
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
}


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