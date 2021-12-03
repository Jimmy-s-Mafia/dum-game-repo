using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    // prevent "over healing", no more than 50 recovered
    private bool canHeal = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = collision.gameObject;
        if (player.CompareTag("Player"))
        {
            // restore player health by 50 if current health less than 50
            if (PlayerProperties.currentHealth <= 50 && canHeal)
            {
                PlayerProperties.currentHealth += 50;
                canHeal = false;
                Debug.Log(PlayerProperties.currentHealth);
                Destroy(gameObject);
            }
            // restore the difference if greater than 50
            // because max health is 100, setting to 100 is easier
            if (PlayerProperties.currentHealth > 50 && canHeal)
            {
                PlayerProperties.currentHealth = 100;
                canHeal = false;
                Debug.Log(PlayerProperties.currentHealth);
                Destroy(gameObject);
            }
        }
    }
}
