using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    AutoDialogue _autoDialogo;

    bool _isNewGameButtonDown = false;
    bool _isStarted = false;

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
        if (_isNewGameButtonDown && !_isStarted && Input.anyKeyDown)
        {
            _autoDialogo.StartDialogue();
            _isStarted = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            EventManager.Trigger(Evento.OnPlayerPressedE);
        }
    }



    public void ChangeScene(params object[] parameter)
    {
        EventManager.Unsubscribe(Evento.OnDialogueEnd, ChangeScene);
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
