using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZombies : MonoBehaviour
{
    public GameObject ZombiePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ZombiePrefab, new Vector2(-5, -5), Quaternion.identity);
    }
}
