using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.ParticleSystemJobs;

public class MenuScript : MonoBehaviour   // script inserted into CanvasMenu
{
    
    public void PlayNewGame()
    {
        //myParticles.Pause();
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
