using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloristaDialogueTrigger : TriggerDialogue
{
    [SerializeField] int floresRequeridas = 3;

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
            if (LevelManager.Instance.recursosRecolectados[ResourceType.flores] >= floresRequeridas)
            {
                if (!questCompleted)
                {
                    currentDialogue = 2; //paso al dialogo 2, que es el de Gracias por traer!
                    LevelManager.Instance.AddResource(ResourceType.flores, -floresRequeridas);
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
        if ((Dialogue)parameter[1] == _dialogues[0])
        {
            //solo me interesa si el dialogo que terminó fue el 0
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
