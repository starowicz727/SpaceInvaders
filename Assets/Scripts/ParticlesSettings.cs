using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesSettings : MonoBehaviour
{
    ParticleSystem myParticles;
    void Start()
    {
        myParticles = this.GetComponent<ParticleSystem>();
        myParticles.Play();
    }

    void Update()
    {
        Time.timeScale = 1;
        
    }
}
