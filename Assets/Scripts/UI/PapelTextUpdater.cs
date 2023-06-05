using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapelTextUpdater : TextUpdater
{
    protected override void Start()
    {
        base.Start();
        myText.text = textoInicial + 0.ToString();
    }
    protected override void UpdateText(params object[] parameter)
    {
        base.UpdateText(parameter);
        if (parameter[0] is int) //este pide el papel actual
        {
            myText.text = textoInicial + (int)parameter[0]; //tuki, escribe "papel = x"
        }
    }
}
