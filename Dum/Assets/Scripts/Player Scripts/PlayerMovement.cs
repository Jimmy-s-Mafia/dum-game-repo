using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public Camera cam;
    public float movementSpeed = 10f;
    public bool movementCheck = false;
    Vector2 movement;
    Vector2 mousePosition;
    private bool canDash = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

        // Dash
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Countdown());
        }
    }

    void FixedUpdate() 
    {
        // Movement
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        movementCheck = true;
        if(movementCheck)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
        // Direction for player to look
        Vector2 lookDirection = mousePosition - rb.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 270;
        rb.rotation = angle;
    }

    IEnumerator Countdown()
    {
        canDash = false;
        movementSpeed = 12f;
        yield return new WaitForSeconds(0.5f);
        movementSpeed = 10f;
        canDash = true;
    }
}
