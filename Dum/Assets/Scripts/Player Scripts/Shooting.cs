using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject gunshotPrefab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Get bullet rigidbody
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // Fire bullet
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
	
	//Create sound
	GameObject gunshot = Instantiate(gunshotPrefab, firePoint.position, firePoint.rotation);
    }
}
