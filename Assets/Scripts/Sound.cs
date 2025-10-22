using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
   
    void Start()
    {
        
    }
    public void duck()
    {
        SoundManager.Instance.PlaySound2D("group1");
    }

   
    void Update()
    {
        
    }
}
