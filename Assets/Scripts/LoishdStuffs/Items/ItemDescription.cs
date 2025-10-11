using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PowerUps/ChangeWeapons")]
public class ItemDescription : ScriptableObject
{
    public string gunName;
    public int gunIndex;
    public float duration;
}
