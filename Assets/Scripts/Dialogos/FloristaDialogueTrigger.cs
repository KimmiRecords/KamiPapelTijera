using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloristaDialogueTrigger : TriggerDialogue
{
    [SerializeField]
    int floresRequeridas = 3;

    [SerializeField]
    int paperReward = 20;

    bool questCompleted;

    protected override void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
        EventManager.Subscribe(Evento.OnDialogueEnd, PasarAlSiguienteDialogo);
    }

    public override void Interact(params object[] parameter)
    {

        if (LevelManager.instance.recursosRecolectados[ResourceType.flores] >= floresRequeridas)
        {
            if (!questCompleted)
            {
                currentDialogue = 2; //paso al dialogo 2, que es el de Gracias por traer!
                LevelManager.instance.AddPickup(ResourceType.flores, -floresRequeridas);
                EventManager.Trigger(Evento.OnCortableDropsPaper, paperReward);
                questCompleted = true;
            }
        }

        //el 0 se lee una sola vez
        //una vez leido, pasa al 1
        //una vez juntadas lasflores, pasa al 2
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

    protected override void PasarAlSiguienteDialogo(params object[] parameter)
    {
        if ((Dialogue)parameter[1] == _dialogues[0])
        {
            //si el dialogo q termino fue mi dialogo0, paso al 1
            base.PasarAlSiguienteDialogo(parameter);
        }
    }

    protected override void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Interact);
            EventManager.Unsubscribe(Evento.OnDialogueEnd, PasarAlSiguienteDialogo);
        }
    }
}
