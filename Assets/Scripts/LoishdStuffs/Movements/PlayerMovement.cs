using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 5f;
    public float climbSpeed = 5f;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    public LayerMask platformLayer;
    public float jumpPower = 2f;
    public float dbJumpCount;

    private Rigidbody2D rb;
    private BoxCollider2D playerCollider;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();

        dbJumpCount = 1f;

    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && isGrounded())) //Normal Jump
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpPower * 100));
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded() && dbJumpCount > 0 && PlayerStatus.Instance.getDoubleJump == true && PlayerStatus.Instance.climbingState == false) //DB Jump
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpPower * 50));
            dbJumpCount = 0;
        }

        if (isGrounded() && PlayerStatus.Instance.getDoubleJump == true) //DB Jump reset
        {
            dbJumpCount = 1;
        }

        DropDown();
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        if (PlayerStatus.Instance.climbingState == false)
        {
            float movementHorizontal = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector2(movementHorizontal * playerSpeed, rb.velocity.y);
            rb.velocity = movement;
        }

        else if (PlayerStatus.Instance.climbingState == true)
        {
            float movementVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(0f, movementVertical * climbSpeed);
            rb.velocity = movement;
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

    public bool isOnPlatformed()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, platformLayer))
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

    public void DropDown()
    {
        if (Input.GetKeyDown(KeyCode.S) && isGrounded() && isOnPlatformed() && playerCollider.enabled)
        {
            StartCoroutine(DisablePlayerCollider(0.40f));
        }

    }

    private IEnumerator DisablePlayerCollider(float disableTime)
    {
        playerCollider.enabled = false;
        yield return new WaitForSeconds(disableTime);
        playerCollider.enabled = true;
    }
}
