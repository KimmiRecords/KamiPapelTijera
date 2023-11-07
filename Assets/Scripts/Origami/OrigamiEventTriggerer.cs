using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiEventTriggerer : Origami
{
    public Evento eventoParaTrigerear;

    public override void Apply()
    {
        base.Apply();
        EventManager.Trigger(eventoParaTrigerear);
    }
}
