using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public int bulletDamage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyStatus enemy = collision.GetComponent<EnemyStatus>();

        if (enemy)
        {
            enemy.TakeDamage(bulletDamage);

            Destroy(gameObject);


        }
    }
}
