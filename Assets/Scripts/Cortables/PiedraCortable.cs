using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraCortable : PickupCortable
{
    //las piedras cortables chequean q esten siendo cortadas por
    //la tijera mejorada

    //ademas, la piedra desaparece despues de un rato
    //eventualmente da otro tipo de papel: papel duro
    //en ese caso heredo de pickupcortable y ya

    public override void GetCut(float dmg)
    {
        if (isCortable && dmg >= 100) //re trucho. solo funca xq la tijera mejorada pega 100 jajajaj
        {
            ApplyCut();
        }
    }
}
