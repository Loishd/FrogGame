using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Move : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private Rigidbody2D _projectilePrefab;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private bool GroundTouched;
    private float speed = 8f;
    private float JumpPower = 16f;
    private bool isFacingRight = true;
    private Rigidbody2D spawnProjectile;

    private float Bullet_speed = 10;
    private float LastDirection = 10;

    [SerializeField] private Rigidbody2D rb;
    /*[SerializeField] private Transform groundCheck;*/
    [SerializeField] private LayerMask groundLayer;



    void Start()
    {

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        if (Input.GetKeyDown(KeyCode.W) && GroundTouched == true)  // && IsGrounded()
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
            Debug.Log("W Down");
        }
        if (Input.GetKeyUp(KeyCode.W) && GroundTouched == true) //&& rb.velocity.y > 0f
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 2f);
            Debug.Log("W Up");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Rigidbody2D spawnProjectile = Instantiate(_projectilePrefab, transform.position, transform.rotation);

            //spawnProjectile.velocity = new Vector2((spawnProjectile.velocity.x+(LastDirection)), spawnProjectile.velocity.y*10);

            Destroy(spawnProjectile.gameObject, 1f);

            spawnProjectile.velocity = new Vector2((spawnProjectile.velocity.x * 10) + (LastDirection), Random.Range(-1f, 1f));
            spawnProjectile.rotation = spawnProjectile.velocity.y;
        }






    }
    private void facing()
    {
        if (horizontal > 0)
        {
            isFacingRight = true;
        }

        if (horizontal < 0)
        {
            isFacingRight = !isFacingRight;
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    IEnumerator Collision_In()
    {
        yield return new WaitForSeconds(0f);
        GroundTouched = true;
    }
    IEnumerator Collision_Out()
    {
        yield return new WaitForSeconds(2f);
        GroundTouched = false;
    }
    private void OnCollisionEnter2D(Collision2D Ground)
    {
        StartCoroutine(Collision_In());
    }
    private void OnCollisionExit2D(Collision2D Ground)
    {
        StartCoroutine(Collision_Out());
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            LastDirection = horizontal * 10;
        }
    }

}
