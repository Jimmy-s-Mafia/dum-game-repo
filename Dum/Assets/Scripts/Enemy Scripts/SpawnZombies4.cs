using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies4 : MonoBehaviour
{
    public GameObject ZombiePrefab;
    private bool canSpawn = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if object collided with is player
        GameObject p = collision.gameObject;
        if (p.CompareTag("Player")&&canSpawn)
        {
            Instantiate(ZombiePrefab, new Vector2(), Quaternion.identity);
            Instantiate(ZombiePrefab, new Vector2(), Quaternion.identity);
            Instantiate(ZombiePrefab, new Vector2(), Quaternion.identity);
            Instantiate(ZombiePrefab, new Vector2(), Quaternion.identity);
            canSpawn = false;
        }
    }
}
