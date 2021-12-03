using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public GameObject bulletPrefab;

    public float bulletForce = 5f;
    private bool canShoot = true;
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
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
        GameObject bullet4 = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
        // Get bullet rigidbody
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
        // Fire bullet
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
        rb4.AddForce(firePoint4.up * bulletForce, ForceMode2D.Impulse);

        canShoot = false;
        yield return new WaitForSeconds(2f);
        canShoot = true;
    }
}
