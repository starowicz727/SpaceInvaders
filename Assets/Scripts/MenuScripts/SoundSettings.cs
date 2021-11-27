using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Toggle musicToggle, soundEffectsToggle;

    void Start()
    {
        musicToggle.isOn = !GameState.musicOn;
        soundEffectsToggle.isOn = !GameState.soundEffectsOn;

        if (GameState.musicOn)
        {
            SoundManager.mySoundManager.PlayInLoop(SoundManager.mySoundManager.menuSong);
        }
    }


    public void MusicToggleChange()
    {
        if (musicToggle.isOn)
        {
            GameState.musicOn = false;
            SoundManager.mySoundManager.Stop();
        }
        else
        {
            GameState.musicOn = true;
            SoundManager.mySoundManager.PlayInLoop(SoundManager.mySoundManager.menuSong);
        }
    }
    public void SoundEffectsToggleChange()
    {
        if (soundEffectsToggle.isOn)
        {
            GameState.soundEffectsOn = false;
        }
        else
        {
            GameState.soundEffectsOn = true;
        }
    }
}
