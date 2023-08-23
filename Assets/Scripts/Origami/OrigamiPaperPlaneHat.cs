using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiPaperPlaneHat : Origami
{
    //este origami solo dispara el evento "te doy avioncito de papel"

    public override void Apply()
    {
        base.Apply();
        EventManager.Trigger(Evento.OnOrigamiGivePaperPlaneHat, CameraMode.General);
        //particulas
    }
}
