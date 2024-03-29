using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HongueroTiburcioDialogueTrigger : TriggerDialogue
{
    //tiburcio es el de la quest de los hongos. si le llevas 3 hongos te da 20 de papel.

    [SerializeField] int hongosRequeridos = 3;

    [SerializeField] int paperReward = 20;

    bool questCompleted;

    protected override void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerPressedE, Interact); //los triggers siempre estan atentos a que el player aprete E
        EventManager.Subscribe(Evento.OnDialogueEnd, PasarAlSiguienteDialogo);
    }

    public override void Interact(params object[] parameter)
    {
        if (triggerBool)
        {
            //print("trigger dialogue interact: muestro el dialogo " + _dialogues[currentDialogue].name);
            if (LevelManager.Instance.recursosRecolectados[ResourceType.hongos] >= hongosRequeridos)
            {
                if (!questCompleted)
                {
                    currentDialogue = 2; //paso al dialogo 2, que es el de Gracias por traer!
                    LevelManager.Instance.AddResource(ResourceType.hongos, -hongosRequeridos);
                    LevelManager.Instance.AddResource(ResourceType.papel, paperReward);
                    AudioManager.instance.PlayByName("QuestCompleted02");
                    questCompleted = true;
                }
                else
                {
                    currentDialogue = 3; //paso al dialogo 3, que es el de Gracias por haberme traido!
                }
            }
            DialogueManager.Instance.ShowDialogue(_dialogues[currentDialogue]);

        }

        if (_burnAfterReading)
        {
            Destroy(this);
        }
    }

    protected override void PasarAlSiguienteDialogo(params object[] parameter)
    {
        if ((DialogueSO)parameter[1] == _dialogues[0])
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
