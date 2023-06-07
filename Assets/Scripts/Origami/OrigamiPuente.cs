using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiPuente : Origami
{
    //este script va en la RUTA, no en el objeto puente
    [SerializeField]
    GameObject puente;

    public override void Apply()
    {
        puente.SetActive(true);
        AudioManager.instance.PlayByName("BridgeCompleted");
        //soniditos y particulas de puente spawneado
    }
}
