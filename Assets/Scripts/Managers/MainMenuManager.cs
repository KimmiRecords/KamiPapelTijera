using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] AutoDialogue _autoDialogo;

    bool _isNewGameButtonDown = false;
    bool _dialogueStarted = false;

    [SerializeField] string sceneToLoadOnDialogueEnd;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        EventManager.Subscribe(Evento.OnDialogueEnd, ChangeScene);
    }

    public void OnNewGameButtonDown()
    {
        _isNewGameButtonDown = true;
        if (_isNewGameButtonDown && !_dialogueStarted)
        {
            _autoDialogo.StartDialogue();
            _dialogueStarted = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EventManager.Trigger(Evento.OnPlayerPressedE); //como no tengo PlayerController, lo hago aca.
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
