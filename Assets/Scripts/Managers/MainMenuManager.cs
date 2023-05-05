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
            EventManager.Trigger(Evento.OnPlayerPressedE);
            if (_dialogueStarted && !LevelManager.instance.inDialogue)
            {
                 ChangeScene();
            }
        }
    }

    public void ChangeScene(params object[] parameter)
    {
        //print("change scene");
        LevelManager.instance.GoToScene(sceneToLoadOnDialogueEnd);
    }

}
