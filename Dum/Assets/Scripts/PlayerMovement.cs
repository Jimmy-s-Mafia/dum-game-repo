using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Camera cam;
    public float movementSpeed = 5f;
    Vector2 movement;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement horizontally
        movement.x = Input.GetAxisRaw("Horizontal");
        // Movement vertically
        movement.y = Input.GetAxisRaw("Vertical");

        // Find current mouse position
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate() 
    {
        // Movement
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);

        // Direction for player to look
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
}
