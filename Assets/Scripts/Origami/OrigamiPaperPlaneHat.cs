using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiPaperPlaneHat : Origami
{
    //este origami solo dispara el evento "te doy avioncito de papel"

    public override void Apply()
    {
        LevelManager.Instance.AddResource(ResourceType.papel, -paperCost);
        EventManager.Trigger(Evento.OnOrigamiGivePaperPlaneHat, CameraMode.General);
        //particulas
        //estaria genial un GlitterManager, que le decis donde y tuki, pone un glitter ahi
    }
}
