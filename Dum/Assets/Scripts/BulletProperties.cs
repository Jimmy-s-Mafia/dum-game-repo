using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProperties : MonoBehaviour
{
    public static int damageValue = 10;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
