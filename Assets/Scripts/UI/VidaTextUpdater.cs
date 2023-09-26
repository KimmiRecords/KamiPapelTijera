using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VidaTextUpdater : TextUpdater
{
    //tambien actualiza la barra de vida

    [SerializeField] Image vidaFillable;

    Color verdeGrinch = new Color(0.298f, 0.98f, 0.1274f);
    
    protected override void UpdateText(params object[] parameters)
    {
        base.UpdateText(parameters);
        if (parameters[0] is float) //este pide la vida actual
        {
            //myText.text = textoInicial + (float)parameter[0]; //tuki, escribe
        }

        if (parameters[1] is float) //y este la vida max
        {
            vidaFillable.fillAmount = (float)parameters[0] / (float)parameters[1];
            vidaFillable.color = Color.Lerp(Color.red, verdeGrinch, vidaFillable.fillAmount);
        }
    }
}
