using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepresaCortable : ObjetoCortable
{
    //solo aviso q fui cortado, el represamanager se encarga del resto

    protected override void ApplyCut()
    {
        base.ApplyCut();
        EventManager.Trigger(Evento.OnRepresaWasCut);
    }
}
