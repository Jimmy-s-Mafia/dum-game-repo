using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies3 : MonoBehaviour
{
    public GameObject ZombiePrefab;
    private bool canSpawn = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if object collided with is player
        GameObject p = collision.gameObject;
        if (p.CompareTag("Player")&&canSpawn)
        {
            Instantiate(ZombiePrefab, new Vector2(-5, -14), Quaternion.identity);
            Instantiate(ZombiePrefab, new Vector2(6, -14), Quaternion.identity);
            Instantiate(ZombiePrefab, new Vector2(-5, -25), Quaternion.identity);
            Instantiate(ZombiePrefab, new Vector2(5, -30), Quaternion.identity);
            canSpawn = false;
        }
    }
}
