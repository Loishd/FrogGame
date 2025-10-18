using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct SoundEffect
{
    public string groupID;
    public AudioClip[] clips;
}
  


public class SoundLibrary : MonoBehaviour
{
    public SoundEffect[] soundEffects;
    public AudioClip GetClipFromName(string name)
    
    {
        foreach (var soundEffect in soundEffects)
        {
            if (soundEffect.groupID == name)
            {
                int index = Random.Range(0, soundEffect.clips.Length);
                return soundEffect.clips[index];
            }
        }
        return null;
    }

    
}

