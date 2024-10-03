using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSizeUpdater : MonoBehaviour
{
    List<ParticleSystem> particles = new List<ParticleSystem>();

    private void Start()
    {
        //get all ps components
        foreach (ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
        {
            particles.Add(ps);
        }
    }


    public void UpdateSize(float size)
    {
        foreach (ParticleSystem ps in particles)
        {
            ParticleSystem.MainModule main = ps.main;
            main.startSize = size;
        }
    }
}
