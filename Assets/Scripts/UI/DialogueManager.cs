using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : Singleton<DialogueManager>
{
    //esto hace aparecer el cuadro de dialogo y luego lo pinta de texto

    [SerializeField] GameObject dialogueGlobe;
    [SerializeField] TMPro.TextMeshProUGUI dialogueGlobeText;
    [SerializeField] TMPro.TextMeshProUGUI dialogueGlobeSpeaker;
    [SerializeField] Image npcQueTeHablaImage;

    bool input = false;
    bool waitingForInput = false;
    [HideInInspector] public bool isShowing = false;

    protected override void Awake()
    {
        base.Awake();
        EventManager.Subscribe(Evento.OnPlayerPressedE, CheckPlayerInput);
    }

    public void CheckPlayerInput(params object[] parameter)
    {
        if (waitingForInput)
        {
            //print("recibi input true");
            input = true;
            PlayEToInteractSound();
        }
    }

    public void BUTTON_NextText() //para que el button lo dispare. unity "2021"
    {
        CheckPlayerInput();
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
            PlayEToInteractSound();
            LevelManager.Instance.inDialogue = true;
            isShowing = true;
            //EventManager.Trigger(Evento.OnDialogueStart, CameraMode.CloseUp);
            StartCoroutine(WriteText(dialogue));
        }
    }

    public void HideDialogue(DialogueSO dialogue)
    {
        //print("hide dialogue " + dialogue.name);
        dialogueGlobeText.text = ""; //esto es lo que deberia estar animado despues
        dialogueGlobeSpeaker.text = "";
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

            dialogueGlobeText.text = dialogue.events[i].text;
            dialogueGlobeSpeaker.text = dialogue.events[i].speakerName;
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

    public void PlayEToInteractSound()
    {
        AudioManager.instance.PlayByName("PickupSFX", 0.5f);

    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, CheckPlayerInput);
        }
    }
}
