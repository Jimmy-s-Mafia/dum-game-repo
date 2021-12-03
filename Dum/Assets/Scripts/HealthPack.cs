using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    //HealthPack prefab

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject gameObject = collision.gameObject;
        if (gameObject.CompareTag("Player"))
        {
            // restore player health by 50 if current health less than 50
            if (PlayerProperties.currentHealth <= 50)
            {
                PlayerProperties.currentHealth += 50;
            }
            // restore the difference if greater than 50
            // because max health is 100, setting to 100 is easier
            if (PlayerProperties.currentHealth > 50)
            {
                PlayerProperties.currentHealth = 100;
            }
        }
    }
}
