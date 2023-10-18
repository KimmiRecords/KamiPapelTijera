using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryboardCutsceneManager : MonoBehaviour
{
    //para todas las escenas de storyboard
    //la idea es que haya una dps de cada nivel
    //la del mainmenu no cuenta jeje


    [SerializeField] AutoDialogue _autoDialogo;
    [SerializeField] string _sceneToLoadOnDialogueEnd;
    [SerializeField] GameObject _endingSplash; //aparece cuando termina el dialogo

    bool _waitingForInput;

    private void Start()
    {
        Debug.Log("storyboardmanager start");
        Cursor.lockState = CursorLockMode.Confined;
        EventManager.Subscribe(Evento.OnDialogueEnd, ShowEndingSplash);

        //arranca el dialogo de una
        _autoDialogo.StartDialogue();

        AudioManager.instance.StopAll();
        AudioManager.instance.PlayByName("IntroStoryboardLoop");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_waitingForInput)
            {
                _waitingForInput = false;
                ChangeScene();
            }

            EventManager.Trigger(Evento.OnPlayerPressedE); //como no tengo PlayerController, lo hago aca.
        }
    }

    public void FakePlayerInput()
    {
        if (_waitingForInput)
        {
            _waitingForInput = false;
            ChangeScene();
        }

        EventManager.Trigger(Evento.OnPlayerPressedE);
    }

    public void ShowEndingSplash(params object[] parameter)
    {
        //funciona sin parametros
        //porque solo hay un dialogo posible en este tipo de escena de storyboard

        _endingSplash.SetActive(true);
        _waitingForInput = true; //se queda todo quieto hasta q apretes E de nuevo
        
    }

    public void ChangeScene(params object[] parameter)
    {
        //print("change scene");
        LevelManager.Instance.GoToScene(_sceneToLoadOnDialogueEnd);
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnDialogueEnd, ShowEndingSplash);
        }
    }

}
