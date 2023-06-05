using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiPuente : Origami
{
    [SerializeField]
    GameObject puente;

    public override void Apply()
    {
        puente.SetActive(true);
        //soniditos y particulas de puente spawneado
    }
}
