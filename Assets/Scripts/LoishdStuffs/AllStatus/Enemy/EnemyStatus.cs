using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    public float enemyHP = 3f;
    private SpriteRenderer sp;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        enemyHP -= damage;
        StartCoroutine(FlashFeedback());
        if (enemyHP <= 0)
        {
            TriggerDeath();
        }
    }

    private IEnumerator FlashFeedback()
    {
        Color color = sp.color;
        sp.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sp.color = color;
    }

    void TriggerDeath()
    {
        Destroy(gameObject);
    }
}
