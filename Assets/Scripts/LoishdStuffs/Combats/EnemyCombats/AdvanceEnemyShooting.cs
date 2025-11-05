using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvanceEnemyShooting : MonoBehaviour
{
    public GameObject enemyBulletPrefab;
    public Transform enemyBulletPosition;
    public GameObject player;
    private float timer;
    public float reloadingTime = 2f; //Cooldown
    public float shootingCD = 1f;
    public int ammoMin;
    public int ammoMax = 3;
    public float triggerDistance = 15f; //In this range, enemy will shoot
    public bool isTrigger;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ammoMin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            //Check if player is in range.
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance <= triggerDistance)
            {
                isTrigger = true;

                for (ammoMin = 0; ammoMin < ammoMax; ammoMin++)
                {
                    //Shoot with Cooldown
                    timer += Time.deltaTime;

                    if (timer > shootingCD)
                    {
                        timer = 0;
                        Shoot();
                    }

                    if (ammoMin == ammoMax)
                    {
                        
                    }
                }
            }
            else
            {
                isTrigger = false;
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

    public IEnumerator AdvanceShoot()
    {
        if (ammoMin > 0)
        {
            Instantiate(enemyBulletPrefab, enemyBulletPosition.position, Quaternion.identity);
            ammoMin--;
        }
        else if (ammoMin <= 0)
        {
            Debug.Log("Reloading..");
            yield return new WaitForSeconds(reloadingTime);
            Debug.Log("Reloading Completed");
            ammoMin = ammoMax;
        }

    }
}
