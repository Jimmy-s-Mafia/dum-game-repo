using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
