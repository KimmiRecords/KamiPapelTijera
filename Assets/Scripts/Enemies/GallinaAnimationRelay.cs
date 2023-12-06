using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GallinaAnimationRelay : MonoBehaviour
{
    [SerializeField] GallinaSounds gallinaSounds;

    public void PlayPasos()
    {
        gallinaSounds.PlayPasosSound();
    }
}
