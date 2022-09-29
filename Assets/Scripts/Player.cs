using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    TL.Direction facingDirection = TL.Direction.Down;

    public Animator animator;
    
    // Update is called once per frame
    void Update()
    {
        // TODO: use Unity's new InputSystem instead of Input (https://youtu.be/Yjee_e4fICc)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        TL.Direction actualFacingDirection = TL.directionOf(movement);
        if(actualFacingDirection != TL.Direction.None)
            facingDirection = actualFacingDirection;
        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
        animator.SetFloat("facingDirection", (float)facingDirection);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized*moveSpeed*Time.fixedDeltaTime);
    }
}
