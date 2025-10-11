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
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        

        dbJumpCount = 1f;
        
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && isGrounded())) //Normal Jump
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpPower * 100));
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded() && dbJumpCount > 0 && PlayerStatus.Instance.getDoubleJump == true) //DB Jump
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpPower * 50));
            dbJumpCount = 0;
        }

        if (isGrounded() && PlayerStatus.Instance.getDoubleJump == true) //DB Jump reset
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
