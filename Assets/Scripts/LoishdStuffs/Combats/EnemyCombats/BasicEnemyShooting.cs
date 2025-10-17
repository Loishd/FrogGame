using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyShooting : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform enemyBulletPosition;
    public GameObject player;
    private float timer;
    public float shootCD = 2; //Cooldown
    public float triggerDistance = 15f; //In this range, enemy will shoot

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        //Check if player is in range.
        if (player != null) 
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance <= triggerDistance)
            {
                //Shoot with Cooldown
                timer += Time.deltaTime;

                if (timer > shootCD)
                {
                    timer = 0;
                    Shoot();
                }
            }

            //Manually Checking Distance
            if (Input.GetKeyDown(KeyCode.R))
            {
                Debug.Log($"Distance : {distance}");
            }
        }

        
        
    }

    public void Shoot() 
    {
        Instantiate(enemyBulletPrefab, enemyBulletPosition.position, Quaternion.identity);
    }
}
