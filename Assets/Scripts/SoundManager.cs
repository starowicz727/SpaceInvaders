using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager mySoundManager;

    public AudioClip alienBullet, spaceshipBullet, alienExplosion, spaceshipHit, spaceshipExplosion, gameSong, menuSong;
    
    private AudioSource myAudioSource;
    void Start()
    {
        mySoundManager = this;

        myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShot(AudioClip myClip)
    {
        if (GameState.soundEffectsOn == true)
        {
            myAudioSource.PlayOneShot(myClip);
        }
    }

    public void PlayInLoop(AudioClip myClip)
    {
        if(GameState.musicOn == true)
        {
            myAudioSource.clip = myClip;
            myAudioSource.loop = true;
            myAudioSource.Play();
        }
    }

    public void Stop()
    {
        myAudioSource.Stop();
    }
}
