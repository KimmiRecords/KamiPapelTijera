using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    AutoDialogue _autoDialogo;

    bool _isNewGameButtonDown = false;
    bool _dialogueStarted = false;

    [SerializeField]
    string sceneToLoadOnDialogueEnd;

    private void Start()
    {
        EventManager.Subscribe(Evento.OnDialogueEnd, ChangeScene);
    }

    public void OnNewGameButtonDown()
    {
        _isNewGameButtonDown = true;
    }

    void Update()
    {
        if (_isNewGameButtonDown && !_dialogueStarted && Input.anyKeyDown)
        {
            _autoDialogo.StartDialogue();
            _dialogueStarted = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            EventManager.Trigger(Evento.OnPlayerPressedE); //para que avance el texto

            //if (_dialogueStarted && !LevelManager.instance.inDialogue)
            //{
            //     ChangeScene();
            //}
        }
    }

    public void ChangeScene(params object[] parameter)
    {
        //print("change scene");
        LevelManager.instance.GoToScene(sceneToLoadOnDialogueEnd);
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnDialogueEnd, ChangeScene);
        }
    }

}
