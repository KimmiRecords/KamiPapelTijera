using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayManager : Singleton<OverlayManager>
{
    [SerializeField] Overlay _defeatOverlay, _victoryOverlay, _mainQuestOverlay;

    public bool isLocked;

    [SerializeField] DialogueSO victoryTriggeringDialogue, mainQuestTriggeringDialogue;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        EventManager.Subscribe(Evento.OnPlayerDie, ShowDefeatOverlay);
        EventManager.Subscribe(Evento.OnDialogueEnd, ShowOverlay);
        EventManager.Subscribe(Evento.OnPlayerPressedE, Unlock);
    }

    public void ShowDefeatOverlay(params object[] parameter)
    {
        _defeatOverlay.gameObject.SetActive(true);
        Lock();
    }

    public void ShowOverlay(params object[] parameter)
    {
        //por ahora muestra el victory o el mainquest

        if ((DialogueSO)parameter[1] == victoryTriggeringDialogue)
        {
            //Debug.Log("overlay manager: show victory overlay");
            _victoryOverlay.gameObject.SetActive(true);
            Lock();
        }

        if ((DialogueSO)parameter[1] == mainQuestTriggeringDialogue)
        {
            _mainQuestOverlay.gameObject.SetActive(true);
            Lock();
        }
    }

    public void Lock(params object[] parameter)
    {
        //Debug.Log("overlay manager: lock");
        LevelManager.Instance.inDialogue = true;
        isLocked = true;
    }

    public void Unlock(params object[] parameter)
    {
        if (isLocked)
        {
            //Debug.Log("overlay unlock: set indialogue y islocked false");
            LevelManager.Instance.inDialogue = false;
            isLocked = false;
            AudioManager.instance.PlayByName("PickupSFX", 2.5f);
        }

        //Debug.Log("overlay unlock: apago todos los overlays");
        _defeatOverlay.gameObject.SetActive(false);
        _mainQuestOverlay.gameObject.SetActive(false);
        //_victoryOverlay.gameObject.SetActive(false);
    }

    public void BTN_ContinueGame()
    {
        //Debug.Log("continua el juego");
        _victoryOverlay.gameObject.SetActive(false);
        EventManager.Trigger(Evento.OnPlayerChooseContinueGame);
        Unlock();
    }

    public void BTN_GoToCutscene()
    {
        //Debug.Log("go to cutscene");
        _victoryOverlay.gameObject.SetActive(false);
        InitializeCutscene();
    }

    public void InitializeCutscene()
    {
        //Debug.Log("arranca la cutscene");
        LevelManager.Instance.GoToScene("Nivel1_EndCutscene");
    }

    void OnDestroy()
    {
        if (!gameObject.scene.isLoaded)
        {
            EventManager.Unsubscribe(Evento.OnPlayerDie, ShowDefeatOverlay);
            EventManager.Unsubscribe(Evento.OnDialogueEnd, ShowOverlay);
            EventManager.Unsubscribe(Evento.OnPlayerPressedE, Unlock);
        }
    }
}
