using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScripts : MonoBehaviour
{
    public bool canInteract;
    public PowerUPsDescription PUD;
    void Start()
    {
        canInteract = false;
    }

    void Update()
    {
        if (canInteract == true)
        {
            if (PUD.powerUpIndex == 0)
            {
                PlayerStatus.Instance.getDoubleJump = true;
                Destroy(gameObject);
            }

            else if (PUD.powerUpIndex == 1)
            {
                PlayerStatus.Instance.getTOU = true;
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
