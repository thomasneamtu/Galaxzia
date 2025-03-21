using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundEffects;
    public AudioClip selectionFX;
   
    public void PlayClickFX()
    {
        soundEffects.PlayOneShot(selectionFX);
    }
    
}
