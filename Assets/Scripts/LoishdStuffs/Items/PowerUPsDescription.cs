using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/Main")]
public class PowerUPsDescription : ScriptableObject
{
    public string powerUpName;
    public int powerUpIndex;
    public float duration;
}
