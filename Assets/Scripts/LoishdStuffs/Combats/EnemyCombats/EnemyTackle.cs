using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyTackle : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private float triggerDistance = 15f;
    [SerializeField] private float enemySpeed = 5f;
    public int enemyDamage = 1;
    public int trackingPos;

    private Rigidbody2D rb;
    private PlayerStatus playerStatus;
    private BoxCollider2D enemyCollider;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatus = player.GetComponent<PlayerStatus>();
        rb = player.GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<BoxCollider2D>();

        trackingPos = 0;
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
                if (((transform.position.x > player.transform.position.x) && trackingPos != 1) || trackingPos == -1)
                {
                    //Move Left
                    transform.position += Vector3.left * enemySpeed * Time.deltaTime;
                    trackingPos = -1;
                }

                if (((transform.position.x < player.transform.position.x) && trackingPos != -1) || trackingPos == 1)
                {
                    //Move Right
                    transform.position += Vector3.right * enemySpeed * Time.deltaTime;
                    trackingPos = 1;
                }

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerStatus.TakeDamage(enemyDamage);
            StartCoroutine(DisableEnemyCollider(1f));
        }

        if (collision.gameObject.CompareTag("KillBlueDart"))
        {
            TriggerDeath();
        }
    }

    private IEnumerator DisableEnemyCollider(float disableTime)
    {
        Physics2D.IgnoreLayerCollision(3, 8, true);
        yield return new WaitForSeconds(disableTime);
        Physics2D.IgnoreLayerCollision(3, 8, false);
    }

    void TriggerDeath()
    {
        Destroy(gameObject);    
    }
}
