using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public Camera cam;
    public float movementSpeed = 5f;
    public bool movementCheck = false;
    Vector2 movement;
    Vector2 mousePosition;

    private bool canDash = true;

    public float totalStamina = 3;
    public float stamina;
    public Slider staminaBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stamina = totalStamina;
        staminaBar.maxValue = stamina;
        staminaBar.value = stamina;
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
        staminaBar.value = 0f;
        movementSpeed = 14f;
        yield return new WaitForSeconds(0.25f);
        movementSpeed = 5f;

        for (int i=0; i<3; i++) {
            yield return new WaitForSeconds(1f);
            staminaBar.value += 1;
        }

        staminaBar.value += 1;
        canDash = true;
    }
}
