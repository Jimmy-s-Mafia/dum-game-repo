using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    private bool canPickup = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = collision.gameObject;
        if (player.CompareTag("Player") && canPickup)
        {
            BulletProperties.damageValue += 5;
            canPickup = false;
            Destroy(gameObject);
        }
    }
}
