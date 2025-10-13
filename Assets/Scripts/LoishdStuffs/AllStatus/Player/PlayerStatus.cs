using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public int playerCurrentGun;
    public bool climbingState;
    public bool getDoubleJump;

    public static PlayerStatus Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist across scene changes
        }
    }

    void Start()
    {
        getDoubleJump = false;  
        climbingState = false;
    }

    
    void Update()
    {
        
    }
}
