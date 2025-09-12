using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // source https://www.youtube.com/watch?v=K1xZ-rycYY8

    void Start()
    {
        
    }
    

  
    void Update()
    {
        Player_Move_Control();
        GroundCheck();
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    void Player_Move_Control()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // Input Axis A&D
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); // Move rigid body velocity left & right

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonUp("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int a = +1;
            Debug.Log(("a = {0}",a));
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            int b = +1;
            Debug.Log(("b = {0}", b));
        }

        Flip();
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }
    void GroundCheck()
    {
        if (IsGrounded())
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision hit");

    }

    private void FixedUpdate()

    {
       
    }


}
