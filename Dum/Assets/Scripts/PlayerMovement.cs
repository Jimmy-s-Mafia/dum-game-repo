using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float distancePerSecond = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Amount to move in each dimension
        float dx = 0;
        float dy = 0;

        // Move up
        if (Input.GetKey ("w") || Input.GetKey (KeyCode.UpArrow)) {
            dy = distancePerSecond * Time.deltaTime;
        }
        // Move down
        if (Input.GetKey ("s") || Input.GetKey (KeyCode.DownArrow)) {
            dy = -distancePerSecond * Time.deltaTime;
        }
        // Move left
        if (Input.GetKey ("a") || Input.GetKey (KeyCode.LeftArrow)) {
            dx = -distancePerSecond * Time.deltaTime;
        }
        // Move right
        if (Input.GetKey ("d") || Input.GetKey (KeyCode.RightArrow)) {
            dx = distancePerSecond * Time.deltaTime;
        }
        // Move by that amount
        rb.position += new Vector2(dx, dy);
    }
}
