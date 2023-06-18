using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapelTextUpdater : TextUpdater
{
    protected override void Awake()
    {
        base.Awake();
        myText.text = textoInicial + 0.ToString();
    }
    protected override void UpdateText(params object[] parameter)
    {
        base.UpdateText(parameter);
        if ((ResourceType)parameter[0] == ResourceType.papel) //este pide el papel actual
        {
            myText.text = textoInicial + (int)parameter[1]; //tuki, escribe "papel = x"
        }
    }
}
