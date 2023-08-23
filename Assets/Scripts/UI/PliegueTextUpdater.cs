using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PliegueTextUpdater : TextUpdater
{
    protected override void UpdateText(params object[] parameter)
    {
        //deberia llegarme el fold actual en el param0 y los fold totales en param1
        print("updateoooo");
        if (parameter[0] is int foldActual && parameter[1] is int foldsTotales)
        {
            myText.text = textoInicial + foldActual.ToString() + "/" + foldsTotales.ToString();
        }
    }
}
