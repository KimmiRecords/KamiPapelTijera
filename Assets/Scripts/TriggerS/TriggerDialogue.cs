using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : TriggerScript
{
    [SerializeField]
    bool _burnAfterReading;

    [SerializeField]
    Dialogue[] _dialogues;

    int currentDialogue = 0;

    public override void Interact(params object[] parameter)
    {
        if (triggerBool)
        {
            //print("trigger dialogue interact: muestro el dialogo " + _dialogues[currentDialogue].name);
            DialogueManager.instance.ShowDialogue(_dialogues[currentDialogue]);
        }

        if (_burnAfterReading)
        {
            Destroy(this);
        }
    }
    protected virtual void PasarAlSiguienteDialogo(params object[] parameter)
    {
        if (currentDialogue < _dialogues.Length)
        {
            currentDialogue++;
            //print(currentDialogue);
        }
    }

    //aca deberia agregar el interact.
    //asi deja de triggerear por enter, pero queda con E
}
