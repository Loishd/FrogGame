using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;

    public float playerHP = 1f;
    public int playerCurrentGun;
    public bool climbingState;
    public bool getDoubleJump;
    public bool getTOU;

    public static PlayerStatus Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        getDoubleJump = false;  
        getTOU = false;
        climbingState = false;
    }

    
    void Update()
    {
        if (climbingState == true)
        {
            if (Input.GetKeyDown(KeyCode.Space)) PlayerStatus.Instance.climbingState = false;
        }
        
    }

    public void TakeDamage(int damage)
    {
        playerHP -= damage;
        if (playerHP <= 0 && getTOU == true)
        {
            StartCoroutine(FlashFeedback());
            playerHP = 1;
            getTOU = false;
        }
        else if (playerHP <= 0)
        {
            TriggerDeath();
        }
        
    }

    void TriggerDeath()
    {
        Destroy(gameObject);
    }

    private IEnumerator FlashFeedback()
    {
        Color color = sr.color;
        sr.color = Color.green;
        yield return new WaitForSeconds(0.2f);
        sr.color = color;
    }
}
