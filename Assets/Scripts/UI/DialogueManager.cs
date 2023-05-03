using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //esto hace aparecer el cuadro de dialogo y luego lo pinta de texto

    public static DialogueManager instance;

    [SerializeField]
    GameObject dialogueGlobe;
    [SerializeField]
    TMPro.TextMeshProUGUI dialogueTextComponent;

    bool input = false;
    bool waitingForInput = false;
    bool isShowing = false;

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
        DontDestroyOnLoad(this);
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
        }
    }
    public void ShowDialogue(string[] textos)
    {
        if (!isShowing)
        {
            //print("show dialogue");
            dialogueGlobe.SetActive(true);
            LevelManager.instance.inDialogue = true;
            StartCoroutine(WriteText(textos));
            isShowing = true;
        }
    }
    public void HideDialogue()
    {
        //print("hide dialogue");
        dialogueTextComponent.text = ""; //esto es lo que deberia estar animado despues
        LevelManager.instance.inDialogue = false;
        dialogueGlobe.SetActive(false);
        isShowing = false;
    }
    public IEnumerator WriteText(string[] textos)
    {
        for (int i = 0; i < textos.Length; i++)
        {
            //print("ARRANCA EL WRITE TEXT - cambio el texto a " + textos[i]);
            dialogueTextComponent.text = textos[i]; //esto es lo que deberia estar animado despues
            waitingForInput = true;

            while (!input)
                yield return null;

            //print("termine de esperar, waitforinput false");
            input = false;
            waitingForInput = false;
        }
        HideDialogue();
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, CheckPlayerInput);
        }
    }
}
