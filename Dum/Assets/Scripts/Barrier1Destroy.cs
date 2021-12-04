using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier1Destroy : MonoBehaviour
{
    public int EnemyCount = 2;          // this is the number of enemies that need destroyed before the barrier disappears.
    public GameObject explosion;        // holds explosion prefab.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KillCounter.killCount >= EnemyCount) {

            // Instantiate explosion at the barrier location
            GameObject e = Instantiate(explosion, transform.position, Quaternion.identity);

            // Destroy explosion after short time
            Destroy(e, 0.50f);

            Destroy(this.gameObject);       
        }
    }
}
