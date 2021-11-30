using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject BossPrefab;
    private bool canSpawn = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if object collided with is player
        GameObject p = collision.gameObject;
        if (p.CompareTag("Player")&&canSpawn)
        {
            Instantiate(BossPrefab, new Vector2(32, -59), Quaternion.identity);
            canSpawn = false;
        }
    }
}
