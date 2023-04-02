using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolapaTirar : Solapa
{
    //esta solapa se mueve en x para entrar y salir

    public override void CambiarEstado()
    {
        base.CambiarEstado(); //esto cambio el isOn entre tru o false
        anim.SetBool("isOpen", isOn);
    }

}
