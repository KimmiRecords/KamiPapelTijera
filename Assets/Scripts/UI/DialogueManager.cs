using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    //esto hace aparecer el cuadro de dialogo y luego lo pinta de texto

    //public static DialogueManager instance;

    [SerializeField] GameObject dialogueGlobe;
    [SerializeField] TMPro.TextMeshProUGUI dialogueTextComponent;
    [SerializeField] Image npcQueTeHablaImage;

    bool input = false;
    bool waitingForInput = false;
    [HideInInspector] public bool isShowing = false;

    private void Start()
    {
        EventManager.Subscribe(Evento.OnPlayerPressedE, CheckPlayerInput);
    }

    public void CheckPlayerInput(params object[] parameter)
    {
        if (waitingForInput)
        {
            //print("recibi input true");
            input = true;
            AudioManager.instance.PlayByName("PickupSFX", 2.5f);
        }
    }

    public void ShowDialogue(DialogueSO dialogue)
    {
        if (OverlayManager.Instance != null && OverlayManager.Instance.isLocked)
        {
            return;
        }

        if (!isShowing && !LevelManager.Instance.inDialogue)
        {
            //print("DIALOGUE MANAGER: show dialogue " + dialogue.name);
            dialogue.currentText = 0;

            dialogueGlobe.SetActive(true);
            LevelManager.Instance.inDialogue = true;
            isShowing = true;
            EventManager.Trigger(Evento.OnDialogueStart, CameraMode.CloseUp);
            StartCoroutine(WriteText(dialogue));
        }
    }

    public void HideDialogue(DialogueSO dialogue)
    {
        //print("hide dialogue " + dialogue.name);
        dialogueTextComponent.text = ""; //esto es lo que deberia estar animado despues
        LevelManager.Instance.inDialogue = false;
        dialogueGlobe.SetActive(false);
        isShowing = false;
        EventManager.Trigger(Evento.OnDialogueEnd, CameraMode.Normal, dialogue);
    }
    public IEnumerator WriteText(DialogueSO dialogue)
    {
        for (int i = 0; i < dialogue.events.Length; i++)
        {
            //print("ARRANCA EL WRITE TEXT ");
            dialogue.currentText++;

            dialogueTextComponent.text = dialogue.events[i].text;
            npcQueTeHablaImage.sprite = dialogue.events[i].sprite; 

            SetNativeSize(npcQueTeHablaImage.sprite); //??? esto es necesario si todos los sprites son del mismo tamaño?

            yield return new WaitForEndOfFrame();
            waitingForInput = true;

            while (!input)
                yield return null; //va a salir del while cuando toques E

            //print("termine de esperar, waitforinput false");
            input = false;
            waitingForInput = false;
        }
        HideDialogue(dialogue);
    }

    public void SetNativeSize(Sprite sprite)
    {
          float spriteRatio = sprite.rect.width / sprite.rect.height;
          npcQueTeHablaImage.rectTransform.sizeDelta = new Vector2(npcQueTeHablaImage.rectTransform.sizeDelta.y * spriteRatio, npcQueTeHablaImage.rectTransform.sizeDelta.y);
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, CheckPlayerInput);
        }
    }
}
