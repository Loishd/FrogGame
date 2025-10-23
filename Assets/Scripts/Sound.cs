using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
   
    void Start()
    {

    }
    public void Sound1()
    {
        SoundManager.Instance.PlaySound2D("AAA");
    }
    public void Sound2()
    {
        SoundManager.Instance.PlaySound2D("");
    }


    void Update()
    {
        
    }
}
