using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaTextUpdater : TextUpdater
{
    //tambien actualiza la barra de vida

    [SerializeField]
    Image vidaFillable;
    
    protected override void UpdateText(params object[] parameter)
    {
        base.UpdateText(parameter);
        if (parameter[0] is float) //este pide la vida actual
        {
            myText.text = textoInicial + (float)parameter[0]; //tuki, escribe "numero de pagina = x"
        }

        vidaFillable.fillAmount = (float)parameter[0] / (float)parameter[1];
    }
}
