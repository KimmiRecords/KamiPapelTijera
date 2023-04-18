using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoja : MonoBehaviour
{
    public void HojaIdleStart()
    {
        print("esta hoja termino de doblarse y arranco su animacion de idle");
        EventManager.Trigger(Evento.OnPageFinishTurning);
        Destroy(gameObject);
    }
}
