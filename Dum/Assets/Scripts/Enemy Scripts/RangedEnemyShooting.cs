using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10f;
    public bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        if(canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    public IEnumerator Shoot() {
        // Create bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Get bullet rigidbody
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // Fire bullet
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        
        canShoot = false;
        yield return new WaitForSeconds(2f);
        canShoot = true;
    }
}
