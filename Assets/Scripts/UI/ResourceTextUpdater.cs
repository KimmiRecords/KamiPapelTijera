using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTextUpdater : TextUpdater
{
    [SerializeField]
    ResourceType tipoDeResource;
    protected override void Start()
    {
        base.Start();
        myText.text = textoInicial + 0.ToString();
    }
    protected override void UpdateText(params object[] parameter)
    {
        base.UpdateText(parameter);
        if ((ResourceType)parameter[0] == tipoDeResource) //este pide algun resource
        {
            myText.text = textoInicial + (int)parameter[1]; //tuki, escribe "resource = x"
        }
    }
}
