using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private TL TL;

    public Vector3 playerPos;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Vector2 movement;
    public TL.Direction facingDirection = TL.Direction.Down;

    public Animator animator;

    public PaintBomb BombPrefab;

    private Camera cam;
    public Vector3 mouseWorldPos = new();
    void Start()
    {
        TL = GameObject.Find("/System/TL").GetComponent<TL>();
        cam = Camera.main;
    }
    void Update()
    {
        // TODO: use Unity's new InputSystem instead of Input (https://youtu.be/Yjee_e4fICc)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        playerPos = transform.position;
        
        TL.Direction actualFacingDirection = TL.directionOf(movement);
        if(actualFacingDirection != TL.Direction.None)
            facingDirection = actualFacingDirection;
        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
        animator.SetFloat("facingDirection", (float)facingDirection);

        // Transforms the Screen position to World position using the current mouse position
        // Reference: https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html
        mouseWorldPos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(BombPrefab, mouseWorldPos, transform.rotation);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized*moveSpeed*Time.fixedDeltaTime);
    }
}
