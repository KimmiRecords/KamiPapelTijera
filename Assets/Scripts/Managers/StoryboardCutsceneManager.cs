using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryboardCutsceneManager : MonoBehaviour
{
    [SerializeField] AutoDialogue _autoDialogo;
    [SerializeField] string _sceneToLoadOnDialogueEnd;

    private void Start()
    {
        Debug.Log("storyboardmanager start");
        Cursor.lockState = CursorLockMode.Confined;
        EventManager.Subscribe(Evento.OnDialogueEnd, ChangeScene);

        //arranca el dialogo de una
        _autoDialogo.StartDialogue();

        AudioManager.instance.StopAll();
        AudioManager.instance.PlayByName("IntroStoryboardLoop");
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
        LevelManager.Instance.GoToScene(_sceneToLoadOnDialogueEnd);
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnDialogueEnd, ChangeScene);
            //AudioManager.instance.StopByName("IntroStoryboardLoop");
        }
    }

}
