using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] AutoDialogue _autoDialogo;

    bool _isNewGameButtonDown = false;
    bool _dialogueStarted = false;

    [SerializeField] string sceneToLoadOnDialogueEnd;

    public GameObject LoadingAnimationCanvas;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        //events
        EventManager.Subscribe(Evento.OnDialogueEnd, OnDialogueEnd);


        AudioManager.instance.StopAll();
        AudioManager.instance.PlayByName("4S_IntroBigChords");
        AudioManager.instance.PlayByName("ForestAtNight");
    }

    public void OnNewGameButtonDown()
    {
        _isNewGameButtonDown = true;
        if (_isNewGameButtonDown && !_dialogueStarted)
        {
            _autoDialogo.StartDialogue();
            StartAsyncLoadingOfNextScene();
            AudioManager.instance.StopByName("4S_IntroBigChords");
            AudioManager.instance.StopByName("ForestAtNight");
            AudioManager.instance.PlayByName("IntroStoryboardLoop");

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

    public void StartAsyncLoadingOfNextScene()
    {
        LevelManager.Instance.StartAsyncLoadingOfNextScene(sceneToLoadOnDialogueEnd);
    }

    public void OnDialogueEnd(params object[] parameter)
    {
        LoadingAnimationCanvas.SetActive(true);
        LevelManager.Instance.LoadThePreLoadedScene();
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnDialogueEnd, OnDialogueEnd);
            //AudioManager.instance.StopByName("IntroStoryboardLoop");
        }
    }

}
