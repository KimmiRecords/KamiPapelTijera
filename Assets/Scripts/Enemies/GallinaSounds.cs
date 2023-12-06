using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GallinaSounds : MonoBehaviour
{
    [SerializeField] AudioSource _gallinaEvade, _gallinaCortada;
    [SerializeField] AudioSource[] _gallinaPasosArray;

    public void PlayEvadeSound()
    {
        _gallinaEvade.Play();
    }

    public void PlayCortadaSound()
    {
        _gallinaCortada.Play();
    }

    public void PlayPasosSound()
    {
        int random = Random.Range(0, _gallinaPasosArray.Length);
        _gallinaPasosArray[random].Play();
    }
}
