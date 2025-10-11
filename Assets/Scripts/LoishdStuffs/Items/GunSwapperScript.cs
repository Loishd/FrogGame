using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwapperScript : MonoBehaviour
{
    public bool canInteract;
    public ItemDescription ID;
    void Start()
    {
        canInteract = false;
    }

    void Update()
    {
        if (canInteract == true)
        {
            if (ID.gunIndex == 0)
            {
                PlayerStatus.Instance.playerCurrentGun = 0;
                Destroy(gameObject);
            }

            else if (ID.gunIndex == 1)
            {
                PlayerStatus.Instance.playerCurrentGun = 1;
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
