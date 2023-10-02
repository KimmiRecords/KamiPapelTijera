using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaginaActualTextUpdater : TextUpdater
{
    protected override void Awake()
    {
        base.Awake();
        myText.text = textoInicial + 1.ToString(); //tuki, escribe "numero de pagina = x"
    }
    protected override void UpdateText(params object[] parameter)
    {
        base.UpdateText(parameter);
        if (parameter[0] is int) //este pide el nro de pagina
        {
            myText.text = textoInicial + (int)parameter[0]; //tuki, escribe "numero de pagina = x"
        }
    }
}
