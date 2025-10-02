using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;
    public float fireRate = 0.5f;
    private float nextFireTime;
    private Vector2 shootDirection;
    public Transform firePoint;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (Time.time >= nextFireTime))
        {
            Shoot();
            nextFireTime = Time.time + fireRate;    
        }
    }

    void Shoot()
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

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = shootDirection * bulletSpeed; 

        Destroy(bullet, 0.5f);  
    }

}
