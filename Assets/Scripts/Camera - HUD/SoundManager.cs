using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSourceMusic;

    public AudioClip[] clip;

    private void Start()
    {
        
    }
    public void PlaySound(int soundIndex)
    {
        if(soundIndex >= 0 && soundIndex < clip.Length) 
        {
            audioSource.PlayOneShot(clip[soundIndex]);
        }
        else
        {
            Debug.Log("Sound index out of range!");
        }


    }
   public void PlayMusic()
    {
        audioSourceMusic.Play();
    }

}
