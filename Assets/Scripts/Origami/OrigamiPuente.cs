using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiPuente : Origami
{
    //este script va en la RUTA, no en el objeto puente
    [SerializeField]
    GameObject objetoParaSpawnear;

    public override void Apply()
    {
        base.Apply();
        objetoParaSpawnear.SetActive(true);
        AudioManager.instance.PlayByName("BridgeCompleted");
        //soniditos y particulas de puente spawneado
    }
}
