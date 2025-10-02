using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public float jumpPower = 2f;
    public float dbJumpCount;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        sr = GetComponent<SpriteRenderer>();

        dbJumpCount = 1f;
        sr.flipX = false;
    }

    void Update()
    {
        FlipImage();

        if ((Input.GetKeyDown(KeyCode.Space) && isGrounded()))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpPower * 100));
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded() && dbJumpCount > 0)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpPower * 100));
            dbJumpCount = 0;
        }

        if (isGrounded())
        {
            dbJumpCount = 1;
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        //Main Movement
        float movementHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(movementHorizontal * playerSpeed, rb.velocity.y);

        rb.velocity = movement;

        
    }

    public void FlipImage()
    {
        //Flip Image
        if (Input.GetKeyDown(KeyCode.A))
        {
            sr.flipX = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            sr.flipX = false;
        }
    }

    public bool isGrounded()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

}
