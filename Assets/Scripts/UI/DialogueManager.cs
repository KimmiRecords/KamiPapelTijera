using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;
using UnityEngine.Localization.Settings;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] GameObject dialogueGlobe;
    [SerializeField] TMPro.TextMeshProUGUI dialogueGlobeText;
    [SerializeField] TMPro.TextMeshProUGUI dialogueGlobeSpeaker;
    [SerializeField] Image npcQueTeHablaImage;

    bool input = false;
    bool waitingForInput = false;
    [HideInInspector] public bool isShowing = false;
    public bool lockedByAnimation = false;

    protected override void Awake()
    {
        base.Awake();
        EventManager.Subscribe(Evento.OnPlayerPressedE, CheckPlayerInput);
    }

    public void CheckPlayerInput(params object[] parameter)
    {
        if (waitingForInput && !lockedByAnimation)
        {
            input = true;
            PlayEToInteractSound();
        }
    }

    public void BUTTON_NextText()
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
            dialogue.currentText = 0;
            dialogueGlobe.SetActive(true);
            PlayEToInteractSound();
            LevelManager.Instance.inDialogue = true;
            isShowing = true;
            StartCoroutine(WriteText(dialogue));
        }
    }

    public void HideDialogue(DialogueSO dialogue)
    {
        dialogueGlobeText.text = "";
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
            dialogue.currentText++;
            EventManager.Trigger(Evento.OnDialogueWriteText, dialogue);

            // Setear el texto del diálogo y el nombre del speaker usando localización si existe
            yield return StartCoroutine(SetLocalizedText(dialogue.events[i].text, dialogueGlobeText));
            yield return StartCoroutine(SetLocalizedText(dialogue.events[i].speakerName, dialogueGlobeSpeaker));

            npcQueTeHablaImage.sprite = dialogue.events[i].sprite;

            SetNativeSize(npcQueTeHablaImage.sprite);

            yield return new WaitForEndOfFrame();
            waitingForInput = true;

            while (!input)
                yield return null;

            input = false;
            waitingForInput = false;
        }
        HideDialogue(dialogue);
    }

    private IEnumerator SetLocalizedText(string fallbackText, TMPro.TextMeshProUGUI textElement)
    {
        // Primero asignamos el texto por defecto
        //textElement.text = fallbackText;

        if (!string.IsNullOrEmpty(fallbackText))
        {
            // Obtenemos la tabla de localización
            var tableOperation = LocalizationSettings.StringDatabase.GetTableAsync("DialogueTable");
            yield return tableOperation;

            StringTable stringTable = tableOperation.Result;
            if (stringTable != null)
            {
                // Verificamos si la clave existe en la tabla
                var entry = stringTable.GetEntry(fallbackText);
                if (entry != null && !string.IsNullOrEmpty(entry.GetLocalizedString()))
                {
                    textElement.text = entry.GetLocalizedString();
                }
                else
                {
                    textElement.text = fallbackText;
                }
            }
        }
        else
        {
            textElement.text = fallbackText;
        }
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
