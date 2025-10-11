using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletPrefab2;
    public float bulletSpeed = 50f;
    public float fireRate = 0.5f;
    private float nextFireTime;
    private Vector2 shootDirection;
    public Transform firePoint;
    [SerializeField]private SpriteRenderer sr;

    void Start()
    {
        PlayerStatus.Instance.playerCurrentGun = 0;
        sr.flipX = false;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && (Time.time >= nextFireTime))
        {
            Shoot();
            nextFireTime = Time.time + fireRate;    
        }

        FlipImage();
        ChangeDirection();
    }

    void Shoot()
    {
        if (PlayerStatus.Instance.playerCurrentGun == 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            Destroy(bullet, 0.25f);
        }
        else if (PlayerStatus.Instance.playerCurrentGun == 1)
        {
            GameObject bullet = Instantiate(bulletPrefab2, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed;
            Destroy(bullet, 0.25f);
        }

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

    public void ChangeDirection()
    {
        if (Input.GetKey(KeyCode.A))
        {
            shootDirection = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            shootDirection = Vector2.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            shootDirection = Vector2.up;
        }
    }
}
