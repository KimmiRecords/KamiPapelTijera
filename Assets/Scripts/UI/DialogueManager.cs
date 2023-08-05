using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //esto hace aparecer el cuadro de dialogo y luego lo pinta de texto

    public static DialogueManager instance;

    [SerializeField] GameObject dialogueGlobe;
    [SerializeField] TMPro.TextMeshProUGUI dialogueTextComponent;
    [SerializeField] Image npcQueTeHablaImage;

    bool input = false;
    bool waitingForInput = false;
    [HideInInspector] public bool isShowing = false;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        //DontDestroyOnLoad(this);
    }
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

    public void ShowDialogue(Dialogue dialogue)
    {
        if (!isShowing)
        {
            //print("DIALOGUE MANAGER: show dialogue " + dialogue.name);
            //dialogue.currentText = 0;


            dialogueGlobe.SetActive(true);
            LevelManager.instance.inDialogue = true;
            isShowing = true;
            EventManager.Trigger(Evento.OnDialogueStart, CameraMode.CloseUp);
            StartCoroutine(WriteText(dialogue));
        }
    }
    public void HideDialogue(Dialogue dialogue)
    {
        //print("hide dialogue " + dialogue.name);
        dialogueTextComponent.text = ""; //esto es lo que deberia estar animado despues
        LevelManager.instance.inDialogue = false;
        dialogueGlobe.SetActive(false);
        isShowing = false;
        EventManager.Trigger(Evento.OnDialogueEnd, CameraMode.Normal, dialogue);
    }
    public IEnumerator WriteText(Dialogue dialogue)
    {
        for (int i = 0; i < dialogue.textos.Length; i++)
        {
            //print("ARRANCA EL WRITE TEXT - cambio el texto a " + dialogue.textos[i] + " (" + i + ")");
            dialogueTextComponent.text = dialogue.textos[i]; //esto es lo que deberia estar animado despues
            npcQueTeHablaImage.sprite = dialogue.sprite;    //sprite[i]
            SetNativeSize(npcQueTeHablaImage.sprite); //??? esto es necesario si todos los sprites son del mismo tama�o?

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
