using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloresAzulesTextUpdater : TextUpdater
{
    protected override void Start()
    {
        base.Start();
        myText.text = textoInicial + 0.ToString();
    }
    protected override void UpdateText(params object[] parameter)
    {
        base.UpdateText(parameter);
        if ((ResourceType)parameter[0] == ResourceType.flores) //este pide las flores azules actuales
        {
            myText.text = textoInicial + (int)parameter[1]; //tuki, escribe "flores = x"
        }
    }
}
